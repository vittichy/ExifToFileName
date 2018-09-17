/*
    2007-04 GetThumbnail()
 
 
*/


using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

using Vt.JpegExifConstants;
using System.IO;
using Vt.Strings;

namespace Vt.Jpeg
{
	public class VtJpegException : System.ApplicationException
	{
		public VtJpegException(string str) : base(str)
		{
		}
	};


	/// <summary>
	/// Summary description for CVtJpeg.
	/// </summary>
    public class Jpeg :IDisposable
	{
		// Bitmapa kde je uchovan zdrojovy obrazek
		private Bitmap SrcBitmap = null;



		/// <summary>
		/// destruktor - je to vlastne metoda Finalize(), jen se v c# jinou syntaxi !
		/// Volaji primo spravce pameti, pote co je objek oznacen jako smeni, nelze
		/// volat z programu !!
		/// </summary>
		~Jpeg()
		{
			if(SrcBitmap != null) 
			{
				SrcBitmap.Dispose();
				SrcBitmap = null;
			}
		}
		
		/// <summary>
		/// uklid prostredku po bitmape - jinak zustava v pameti a pri mniha instancich 
		/// muze celou pamet sezrat !! Je lepsi tuto metodu pouzivat po skonceni prace
		/// s instanci Jpegu !! nez cekat na volani destruktoru (finalize) spravcem pameti !!
		/// </summary>
		public void Dispose()
		{
			CheckSrcBitmap();

			SrcBitmap.Dispose();
			SrcBitmap = null;
		}

		
		public Bitmap SourceBitmap
		{
			get 
			{
				return SrcBitmap;
			}
		}
		
		
		public static ImageCodecInfo GetEncoderInfo(string MimeType)
		{
			ImageCodecInfo[] Codecs = ImageCodecInfo.GetImageEncoders();
			foreach (ImageCodecInfo Codec in Codecs) 
			{
				if (Codec.MimeType == MimeType)
					return Codec;
			}
			return null;
		}

		private EncoderParameters GetEncoderParameters(long Compression)
		{
			System.Drawing.Imaging.Encoder Enc = System.Drawing.Imaging.Encoder.Quality;
			EncoderParameters EncParams= new EncoderParameters(1);
			EncoderParameter EncParam = new EncoderParameter(Enc, Compression);
			EncParams.Param[0] = EncParam;
			return EncParams;
		}


		private void CheckSrcBitmap()
		{
			if(SrcBitmap == null)
				throw new VtJpegException("Jpeg not loaded.");
		}

        /// <summary>
        /// nahraje jpeg ze souboru
        /// </summary>
        /// <param name="FileName"></param>
        public void LoadFromFile(string FileName)
        {
            SrcBitmap = Image.FromFile(FileName) as Bitmap;
        }

        /// <summary>
        /// nahraje jpeg ze souboru + test na chybu, jpeg muze byt poruseny a pak nacteni selze !
        /// </summary>
        /// <param name="FileName"></param>
        public bool LoadFromFile(string FileName, out Exception Ex)
        {
            try
            {
                SrcBitmap = Image.FromFile(FileName) as Bitmap;
                Ex = null;
                return true;
            }
            catch(Exception JpegEx)
            {
                Ex = JpegEx;
                return false;
            }
        }


		/// <summary>
		/// nahraje jpeg z jine bitmapy
		/// </summary>
		/// <param name="FileName"></param>
		public void LoadFromBitmap(Bitmap Source)
		{
			SrcBitmap = Source.Clone() as Bitmap;
		}

        public void LoadFromStream(MemoryStream MemStream)
        {
            SrcBitmap = Image.FromStream(MemStream) as Bitmap;
        }


		/// <summary>
		/// ulozeni do souboru
		/// </summary>
		/// <param name="FileName"></param>
		/// <param name="Compression"></param>
		public void SaveToFile(string FileName, long Compression)
		{
			CheckSrcBitmap();

			ImageCodecInfo CodecInfo;
			EncoderParameters EncParams;
			string MimeType = "image/jpeg";

			// informace od kodeku		
			CodecInfo = GetEncoderInfo(MimeType);
			EncParams = GetEncoderParameters(Compression);

			// ulozeni bitmapy na disk
			SrcBitmap.Save(FileName, CodecInfo, EncParams);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="Width"></param>
		/// <param name="Height"></param>
		public void Resize(int Width, int Height)
		{
			CheckSrcBitmap();

			Bitmap ABitmap;
			Graphics AGraphics;

			// pomocna Bitmapa urcene velikosti
			ABitmap = new Bitmap(Width, Height, SrcBitmap.PixelFormat);
			AGraphics = Graphics.FromImage(ABitmap);
			AGraphics.SmoothingMode     = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			AGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			AGraphics.DrawImage(SrcBitmap, 0, 0, ABitmap.Width, ABitmap.Height);
			
			// prehodim novou Bitmapu do stare
			SrcBitmap.Dispose();
			SrcBitmap = ABitmap;

			AGraphics.Dispose();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="NewFileName"></param>
		/// <param name="MaxSize"></param>
		/// <param name="Compression"></param>
		public void Resize(int MaxSize)
		{
			CheckSrcBitmap();

			int Width, 
				Height;
			double Ratio;

			if(SrcBitmap.Width > SrcBitmap.Height)
			{
				Ratio = (double) SrcBitmap.Width / MaxSize;  // musi byt na double !! jinak se zaokrouli na int !!!
				Height = (int) Math.Round(SrcBitmap.Height / Ratio);
				Width = MaxSize;
			}
			else
			{
				Ratio = (double) SrcBitmap.Height / MaxSize;
				Width = (int) Math.Round(SrcBitmap.Width / Ratio);
				Height = MaxSize;
			}
			Resize(Width, Height);
		}


		/// <summary>
		/// 
		/// </summary>
		public void ConvertToGrayScale() 
		{	
			CheckSrcBitmap();

			Color Col;
			int BlackWhite;

			for(int w = 0; w < SrcBitmap.Width; w++)
			{
				for (int h = 0; h < SrcBitmap.Height; h++)
				{
					// barva pixlu na urcitem bode
					Col = SrcBitmap.GetPixel(w, h);
					// prevod na prumernou cerno-bilou
					BlackWhite = (Col.R + Col.G + Col.B) / 3;
					// nastaveni pixlu
					SrcBitmap.SetPixel(w, h, Color.FromArgb(BlackWhite, BlackWhite, BlackWhite));
				}
			}

		}


		/// <summary>
		/// vraci sirku jpegu
		/// </summary>
		public int Width 
		{
			get
			{
				CheckSrcBitmap();
				return SrcBitmap.Width;
			}
		}

		/// <summary>
		/// vraci vysku jpegu
		/// </summary>
		public int Height
		{
			get
			{
				CheckSrcBitmap();
				return SrcBitmap.Height;
			}
		}

		/// <summary>
		/// vraci seznam PropertyItem[] od Bitmapy
		/// </summary>
		public PropertyItem[] PropertyItems
		{
			get 
			{
				CheckSrcBitmap();
				return SrcBitmap.PropertyItems;
			}
		}

		/// <summary>
		/// vraci konkretni PropertyItem dle ID
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public PropertyItem GetPropertyItem(int Id)
		{
			CheckSrcBitmap();

			try 
			{
				PropertyItem PItem = SrcBitmap.GetPropertyItem(Id);
				return PItem;
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// vraci konkretni PropertyItem dle ID
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
        public PropertyItem GetPropertyItem(PropertyTagId TagId)
        {
            return GetPropertyItem((int)TagId);
        }

        public bool ExistPropertyItem(PropertyTagId TagId)
        {
            return (GetPropertyItem((int)TagId) != null);
        }


		/// <summary>
		/// vraci PropertyItem dle ID prevedeny na string
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public string GetPropertyItemAsString(int Id)
		{
			CheckSrcBitmap();

			PropertyItem PItem = GetPropertyItem((int) Id);
			if(PItem == null)
				return null;
			else
				return PropertyItemToString(PItem);
		}

		/// <summary>
		/// vraci PropertyItem dle ID prevedeny na string
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public string GetPropertyItemAsString(PropertyTagId TagId)
		{
			return GetPropertyItemAsString((int) TagId);
		}

		/// <summary>
		/// prevede PropertyItem.Value na retezec v zavyslosti na PropertyItem.Type
		/// </summary>
		/// <param name="PItem"></param>
		/// <returns></returns>
		static public string PropertyItemToString(PropertyItem PItem)
		{
			if(PItem == null)
				return null;
			else
				return PropertyValueToString(PItem);
		}

		/// <summary>
		/// samotny prevod PropertyItem.Value na string dle PropertyItem.Type
		/// </summary>
		/// <param name="PItem"></param>
		/// <returns></returns>
		static private string PropertyValueToString(PropertyItem PItem)
		{
			const int BYTEJUMP_SHORT		= 2;
			const int BYTEJUMP_LONG			= 4;
			const int BYTEJUMP_SLONG		= 4;
			const int BYTEJUMP_RATIONAL		= 8;
			const int BYTEJUMP_SRATIONAL	= 8;

			string Result = null;

			switch((PropertyTagType) PItem.Type)
			{
				case(PropertyTagType.Byte): // 1
				{
					Result = BitConverter.ToString(PItem.Value, 0, PItem.Len);
					break;
				}
				case(PropertyTagType.ASCII): // 2
				{
                    /* - puvodni, ale pak nejde cestina !!!
                    System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();  
					Result = Encoding.GetString(PItem.Value, 0, PItem.Len - 1);
                    */
                    // spravny prevod do defaultniho kodovani, tj v ceskych win bude fungovat cestina
                    Result = VtStrings.BytesToStrCS(PItem.Value);
					break;
				}
				case(PropertyTagType.Short): // 3
				{
					for(int i = 0; i < PItem.Len; i = i + BYTEJUMP_SHORT) 
					{
						System.UInt16 Value = BitConverter.ToUInt16(PItem.Value, i);
						Result += Value.ToString();
					}
					break;
				}
				case(PropertyTagType.Long): // 4
				{
					for(int i = 0; i < PItem.Len; i = i + BYTEJUMP_LONG) 
					{
						System.UInt32 Value = BitConverter.ToUInt32(PItem.Value, i);
						Result += Value.ToString();
					}
					break;
				}
				case(PropertyTagType.Rational): // 5
				{
					for (int i = 0; i < PItem.Len; i = i + BYTEJUMP_RATIONAL) 
					{
						System.UInt32 Numer = BitConverter.ToUInt32(PItem.Value, i);
						System.UInt32 Denom = BitConverter.ToUInt32(PItem.Value, i + BYTEJUMP_LONG);
						if(Result != null)
							Result += ' ';
						Result += Numer.ToString() + '/' + Denom.ToString();
					}
					break;
				}
				case(PropertyTagType.Undefined): // 7
				{
					Result = BitConverter.ToString(PItem.Value, 0, PItem.Len);
					break;
				}
				case(PropertyTagType.SLONG): // 9
				{
					for(int i = 0; i < PItem.Len; i = i + BYTEJUMP_SLONG) 
					{
						System.Int32 Value = BitConverter.ToInt32(PItem.Value, i);
						Result += Value.ToString();
					}
					break;
				}
				case(PropertyTagType.SRational): // 10
				{
					for (int i = 0; i < PItem.Len; i = i + BYTEJUMP_SRATIONAL) 
					{
						System.Int32 Numer = BitConverter.ToInt32(PItem.Value, i);
						System.Int32 Denom = BitConverter.ToInt32(PItem.Value, i + BYTEJUMP_SLONG);
						if(Result != null)
							Result += ' ';
						Result += Numer.ToString() + '/' + Denom.ToString();
					}
					break;
				}

				default:
					break;
			}
			return Result;
		}






        // ziskani DateTime z Exifu
        // data z exifu nelze nejak pretypovat na DateTime, takze pouze parsuju retezec s datumem, pokud se 
        // nezadari, tak vracim DateTime.MinValue
        public DateTime GetPropertyItemAsDateTime(PropertyTagId TagId)
        {
            string DateStr = GetPropertyItemAsString(TagId);
            if (DateStr == null)
                return DateTime.MinValue;
            else
            {
                try
                {
                    DateTime Result = DateTime.ParseExact(DateStr, "yyyy:MM:dd HH:mm:ss", null);
                    return Result;
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }






		/// <summary>
		/// zapise PropertyItem do obrazku
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public void SetPropertyItem(PropertyTagId TagId, string Text)
		{
			CheckSrcBitmap();

			// ziskani nove instance PropertyItem
			Encoding EncAscii = Encoding.ASCII;
			PropertyItem NewPItem = CreatePropertyItem(PropertyTagType.ASCII, TagId, Text.Length, EncAscii.GetBytes(Text));
			// zapis do Bitmapy
			if(NewPItem != null)
				SourceBitmap.SetPropertyItem(NewPItem);
		}


		/// <summary>
		/// - PropertyItem nema verejny konstruktor, proto se musi ziskat kopii z jiz nejakeho existujiciho. Zatim 
		///   predpoklada, ze tu jiz vzdy bude nejaky PropertyItem a ten zkopiruju ... pokud bych chtel pridavat
		///   do obrazku kde neni jeste zadny, musim si ho vytvorit z jineho obrazku (ten bu mohl byt napr v resourcich)
		/// </summary>
		/// <param name="Type"></param>
		/// <param name="TagId"></param>
		/// <param name="Len"></param>
		/// <param name="Value"></param>
		/// <returns></returns>
		private PropertyItem CreatePropertyItem(PropertyTagType Type, PropertyTagId TagId, int Len, byte[] Value)
		{ 
			CheckSrcBitmap();
			PropertyItem PItem = null;

			// zjistit prvni item - z neho si zkopiruju instanci PropertyItemu !
			int[] IdList = SourceBitmap.PropertyIdList;
			if(IdList.Length > 0) 
			{
				PItem = SrcBitmap.GetPropertyItem(IdList[0]);
				// zkopirovani mych aktualnich dat
				PItem.Type  = (short) Type;
				PItem.Id    = (int) TagId;
				PItem.Len   = Len;
				PItem.Value = new byte[Value.Length];
				Value.CopyTo(PItem.Value, 0);
			}
			return PItem;
		}




















		/// <summary>
		/// Creates a new Image containing the same image only rotated
		/// </summary>
		/// <param name="image">The <see cref="System.Drawing.Image"/> to rotate</param>
		/// <param name="angle">The amount to rotate the image, clockwise, in degrees</param>
		/// <returns>A new <see cref="System.Drawing.Bitmap"/> that is just large enough
		/// to contain the rotated image without cutting any corners off.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <see cref="image"/> is null.</exception>
		public void Rotate(float angle, bool Crop)
		{
			CheckSrcBitmap();

			const double pi2 = Math.PI / 2.0;

			// Why can't C# allow these to be const, or at least readonly
			// *sigh*  I'm starting to talk like Christian Graus :omg:
			double oldWidth = (double) SrcBitmap.Width;
			double oldHeight = (double) SrcBitmap.Height;
			
			// Convert degrees to radians
			double theta = ((double) angle) * Math.PI / 180.0;
			double locked_theta = theta;

			// Ensure theta is now [0, 2pi)
			while( locked_theta < 0.0 )
				locked_theta += 2 * Math.PI;

			double newWidth, newHeight; 
			int nWidth, nHeight; // The newWidth/newHeight expressed as ints

			#region Explaination of the calculations
			/*
			 * The trig involved in calculating the new width and height
			 * is fairly simple; the hard part was remembering that when 
			 * PI/2 <= theta <= PI and 3PI/2 <= theta < 2PI the width and 
			 * height are switched.
			 * 
			 * When you rotate a rectangle, r, the bounding box surrounding r
			 * contains for right-triangles of empty space.  Each of the 
			 * triangles hypotenuse's are a known length, either the width or
			 * the height of r.  Because we know the length of the hypotenuse
			 * and we have a known angle of rotation, we can use the trig
			 * function identities to find the length of the other two sides.
			 * 
			 * sine = opposite/hypotenuse
			 * cosine = adjacent/hypotenuse
			 * 
			 * solving for the unknown we get
			 * 
			 * opposite = sine * hypotenuse
			 * adjacent = cosine * hypotenuse
			 * 
			 * Another interesting point about these triangles is that there
			 * are only two different triangles. The proof for which is easy
			 * to see, but its been too long since I've written a proof that
			 * I can't explain it well enough to want to publish it.  
			 * 
			 * Just trust me when I say the triangles formed by the lengths 
			 * width are always the same (for a given theta) and the same 
			 * goes for the height of r.
			 * 
			 * Rather than associate the opposite/adjacent sides with the
			 * width and height of the original bitmap, I'll associate them
			 * based on their position.
			 * 
			 * adjacent/oppositeTop will refer to the triangles making up the 
			 * upper right and lower left corners
			 * 
			 * adjacent/oppositeBottom will refer to the triangles making up 
			 * the upper left and lower right corners
			 * 
			 * The names are based on the right side corners, because thats 
			 * where I did my work on paper (the right side).
			 * 
			 * Now if you draw this out, you will see that the width of the 
			 * bounding box is calculated by adding together adjacentTop and 
			 * oppositeBottom while the height is calculate by adding 
			 * together adjacentBottom and oppositeTop.
			 */
			#endregion

			double adjacentTop, oppositeTop;
			double adjacentBottom, oppositeBottom;

			// We need to calculate the sides of the triangles based
			// on how much rotation is being done to the bitmap.
			//   Refer to the first paragraph in the explaination above for 
			//   reasons why.
			if( (locked_theta >= 0.0 && locked_theta < pi2) ||
				(locked_theta >= Math.PI && locked_theta < (Math.PI + pi2) ) )
			{
				adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
				oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth;

				adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
				oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
			}
			else
			{
				adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
				oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight;

				adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
				oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
			}
			
			newWidth = adjacentTop + oppositeBottom;
			newHeight = adjacentBottom + oppositeTop;

			nWidth = (int) Math.Ceiling(newWidth);
			nHeight = (int) Math.Ceiling(newHeight);


			Bitmap rotatedBmp = new Bitmap(nWidth, nHeight);

     		using(Graphics g = Graphics.FromImage(rotatedBmp))
			{

					// Create solid brush.
					SolidBrush blueBrush = new SolidBrush(Color.Red);
					// Create location and size of rectangle.
					float x = 0.0F;
					float y = 0.0F;
					float width = nWidth;
					float height = nHeight;
					// Fill rectangle to screen.
					g.FillRectangle(blueBrush, x, y, width, height);


				// This array will be used to pass in the three points that 
				// make up the rotated image
				Point [] points;

				/*
				 * The values of opposite/adjacentTop/Bottom are referring to 
				 * fixed locations instead of in relation to the
				 * rotating image so I need to change which values are used
				 * based on the how much the image is rotating.
				 * 
				 * For each point, one of the coordinates will always be 0, 
				 * nWidth, or nHeight.  This because the Bitmap we are drawing on
				 * is the bounding box for the rotated bitmap.  If both of the 
				 * corrdinates for any of the given points wasn't in the set above
				 * then the bitmap we are drawing on WOULDN'T be the bounding box
				 * as required.
				 */
				if( locked_theta >= 0.0 && locked_theta < pi2 )
				{
					points = new Point[] { 
											 new Point( (int) oppositeBottom, 0 ), 
											 new Point( nWidth, (int) oppositeTop ),
											 new Point( 0, (int) adjacentBottom )
										 };

				}
				else if( locked_theta >= pi2 && locked_theta < Math.PI )
				{
					points = new Point[] { 
											 new Point( nWidth, (int) oppositeTop ),
											 new Point( (int) adjacentTop, nHeight ),
											 new Point( (int) oppositeBottom, 0 )						 
										 };
				}
				else if( locked_theta >= Math.PI && locked_theta < (Math.PI + pi2) )
				{
					points = new Point[] { 
											 new Point( (int) adjacentTop, nHeight ), 
											 new Point( 0, (int) adjacentBottom ),
											 new Point( nWidth, (int) oppositeTop )
										 };
				}
				else
				{
					points = new Point[] { 
											 new Point( 0, (int) adjacentBottom ), 
											 new Point( (int) oppositeBottom, 0 ),
											 new Point( (int) adjacentTop, nHeight )		
										 };
				}

				g.DrawImage(SrcBitmap, points);
			}

			SrcBitmap.Dispose();
			SrcBitmap = rotatedBmp;
		}







        // vraci Bitmapu nahledu z exif dat (PropertyTagId.ThumbnailData) nebo null pokud v exifu nic neni
        public Bitmap GetThumbnail()
        {
            foreach (PropertyItem PItem in PropertyItems)
            {
                PropertyTagId PId = (PropertyTagId)(PItem.Id);
                if (PId == PropertyTagId.ThumbnailData)
                {
                    MemoryStream MemStream = new MemoryStream(PItem.Value);
                    Bitmap ThumbBitmap = new Bitmap(MemStream);
                    return ThumbBitmap;
                }
            }
            return null;
        }











        // fce pri pridani exif infa do Source bitmapy
        // nakonec se zda, ze to takto funguje, ale je to takova divna prasecina, tak budu radeji pouzivat
        // statickou fci na pridani image description primo do souboru viz: SaveAndAddImageDescription()
        /*
        public void WriteASCIIValue(string TextValue, PropertyTagId Id)
        {
            System.Drawing.Imaging.Encoder Enc = System.Drawing.Imaging.Encoder.Transformation;
            EncoderParameters EncParms = new EncoderParameters(1);
            ImageCodecInfo CodecInfo = Vt.Jpeg.Jpeg.GetEncoderInfo("image/jpeg");

            // load the image to change
// Image PicImage = Image.FromFile(Filename);

            // put the new description into the right property item
            PropertyItem[] PropertyItems = SrcBitmap.PropertyItems; 
            PropertyItems[0].Id = (int)Id; // 0x010e;
            PropertyItems[0].Type = (short)PropertyTagType.ASCII;
            PropertyItems[0].Len = TextValue.Length;
            PropertyItems[0].Value = VtStrings.StringToByteArray(TextValue);
            SrcBitmap.SetPropertyItem(PropertyItems[0]);

            // for lossless rewriting must rotate the image by 90 degrees!
            EncoderParameter EncParm = new EncoderParameter(Enc, (long)EncoderValue.TransformRotate90);
            EncParms.Param[0] = EncParm;

            // ulozim transformovany jpeg do streamu
            MemoryStream TmpStream = new MemoryStream();
            SrcBitmap.Save(TmpStream, CodecInfo, EncParms);
            // vymaz z pameti
            SrcBitmap.Dispose();
//            SrcBitmap = null;

            // ted ho otocim zpet a dam do puvodniho souboru
            SrcBitmap = new Bitmap(TmpStream); // Image.FromStream(TmpStream) as Bitmap;
            EncParm = new EncoderParameter(Enc, (long)EncoderValue.TransformRotate270);
            EncParms.Param[0] = EncParm;

            MemoryStream TmpStream2 = new MemoryStream();
            TmpStream.Position=0;

            SrcBitmap.Save(TmpStream2, CodecInfo, EncParms);
            // vymaz z pameti
            SrcBitmap.Dispose();

            SrcBitmap = new Bitmap(TmpStream2); //Image.FromStream(TmpStream) as Bitmap;

//           SrcBitmap.Save("123.jpg", CodecInfo, EncParms);
//            LoadFromFile("123.jpg");

            MemoryStream TmpStream3 = new MemoryStream();
            SourceBitmap.Save(TmpStream3, ImageFormat.Jpeg);
            LoadFromStream(TmpStream3);
//            PicImage.Dispose();
//            PicImage = null;
        }
         */




        /// <summary>
        /// zapise do jpegu ascii textovou exif informaci
        /// </summary>
        /// <param name="Filename">jmeno jpeg souboru</param>
        /// <param name="TextValue">text</param>
        /// <param name="Id">id cislo exif vlastnosti</param>
        public static void SaveAndAddImageDescription(string SourceFile, string DestinationFile, string Description)
        {
            // load the image to change
            Image PicImage = Image.FromFile(SourceFile);

            System.Drawing.Imaging.Encoder Enc = System.Drawing.Imaging.Encoder.Transformation;
            EncoderParameters EncParms = new EncoderParameters(1);
            ImageCodecInfo CodecInfo = Vt.Jpeg.Jpeg.GetEncoderInfo("image/jpeg");

            // put the new description into the right property item
            PropertyItem[] PropertyItems = PicImage.PropertyItems;
            PropertyItems[0].Id = (int)PropertyTagId.ImageDescription; // ExifUserComment; // ImageDescription; //0x010e; ; // (int)PropertyTagId.ImageDescription; // (int)Id; // 0x010e;
            PropertyItems[0].Type = (short)PropertyTagType.ASCII;
            PropertyItems[0].Len = Description.Length;
            PropertyItems[0].Value = VtStrings.StrToByteArrayCS(Description);
            PicImage.SetPropertyItem(PropertyItems[0]);

            // for lossless rewriting must rotate the image by 90 degrees!
            EncoderParameter EncParm = new EncoderParameter(Enc, (long)EncoderValue.TransformRotate90);
            EncParms.Param[0] = EncParm;

            // ulozim transformovany jpeg do streamu
            MemoryStream TmpStream = new MemoryStream();
            PicImage.Save(TmpStream, CodecInfo, EncParms);
            // vymaz z pameti
            PicImage.Dispose();
            PicImage = null;

            // ted ho otocim zpet a dam do puvodniho souboru
            PicImage = Image.FromStream(TmpStream);
            EncParm = new EncoderParameter(Enc, (long)EncoderValue.TransformRotate270);
            EncParms.Param[0] = EncParm;
            PicImage.Save(DestinationFile, CodecInfo, EncParms);
            PicImage.Dispose();
            PicImage = null;
        }












        /// <summary>
        /// zapise do jpegu ascii textovou exif informaci
        /// </summary>
        /// <param name="Filename">jmeno jpeg souboru</param>
        /// <param name="TextValue">text</param>
        /// <param name="Id">id cislo exif vlastnosti</param>
        public static void LosslessRotate(string SourceFile, string DestinationFile, long Rotation)
        {
            // load the image to change
            Image PicImage = Image.FromFile(SourceFile);

            System.Drawing.Imaging.Encoder Enc = System.Drawing.Imaging.Encoder.Transformation;
            EncoderParameters EncParms = new EncoderParameters(1);
            ImageCodecInfo CodecInfo = Vt.Jpeg.Jpeg.GetEncoderInfo("image/jpeg");
/*
            // put the new description into the right property item
            PropertyItem[] PropertyItems = PicImage.PropertyItems;
            PropertyItems[0].Id = (int)PropertyTagId.ImageDescription; // ExifUserComment; // ImageDescription; //0x010e; ; // (int)PropertyTagId.ImageDescription; // (int)Id; // 0x010e;
            PropertyItems[0].Type = (short)PropertyTagType.ASCII;
            PropertyItems[0].Len = Description.Length;
            PropertyItems[0].Value = VtStrings.StrToByteArrayCS(Description);
            PicImage.SetPropertyItem(PropertyItems[0]);
*/
            // for lossless rewriting must rotate the image by 90 degrees!
            EncoderParameter EncParm = new EncoderParameter(Enc, Rotation); // (long)EncoderValue.TransformRotate90);
            EncParms.Param[0] = EncParm;
            PicImage.Save(DestinationFile, CodecInfo, EncParms);



            /*
            Image i = Image.FromFile(this.imageFilename);
            ImageCodecInfo usedIC = this.GetEncoderInfo(“image/jpeg“);

            System.Drawing.Imaging.Encoder encoder =
            System.Drawing.Imaging.Encoder.Transformation;

            EncoderParameters encparams = new EncoderParameters(1);
            EncoderParameter encparam = 
            new EncoderParameter(encoder, (long)EncoderValue.TransformRotate270);
            encparams.Param[0] = encparam;

            i.Save(“filename.jpg“, usedIC, encparams );

            i.Dispose();
            i = null;
            GC.Collect();
 
             */




            /*
                        // ulozim transformovany jpeg do streamu
                        MemoryStream TmpStream = new MemoryStream();
                        PicImage.Save(TmpStream, CodecInfo, EncParms);
                        // vymaz z pameti
                        PicImage.Dispose();
                        PicImage = null;

                        // ted ho otocim zpet a dam do puvodniho souboru
                        PicImage = Image.FromStream(TmpStream);
                        EncParm = new EncoderParameter(Enc, (long)EncoderValue.TransformRotate270);
                        EncParms.Param[0] = EncParm;
                        PicImage.Save(DestinationFile, CodecInfo, EncParms);
             */ 
            PicImage.Dispose();
            PicImage = null;
        }















        /// <summary>
        /// zapise do jpegu ascii textovou exif informaci
        /// </summary>
        /// <param name="Filename">jmeno jpeg souboru</param>
        /// <param name="TextValue">text</param>
        /// <param name="Id">id cislo exif vlastnosti</param>
        public static void SaveAndAddImageDateTime(string SourceFile, string DestinationFile, DateTime ImageDateTime)
        {
            // prevod datetime na str
            string StrDateTime = ImageDateTime.ToString("yyyy:MM:dd HH:mm:ss");

            // load the image to change
            Image PicImage = Image.FromFile(SourceFile);

            System.Drawing.Imaging.Encoder Enc = System.Drawing.Imaging.Encoder.Transformation;
            EncoderParameters EncParms = new EncoderParameters(1);
            ImageCodecInfo CodecInfo = Vt.Jpeg.Jpeg.GetEncoderInfo("image/jpeg");

            // put the new description into the right property item
            PropertyItem[] PropertyItems = PicImage.PropertyItems;
            PropertyItems[0].Id    = (int)PropertyTagId.DateTime;
            PropertyItems[0].Type  = (short)PropertyTagType.ASCII;
            PropertyItems[0].Len   = StrDateTime.Length;
            PropertyItems[0].Value = VtStrings.StrToByteArrayCS(StrDateTime);
            PicImage.SetPropertyItem(PropertyItems[0]);

            // for lossless rewriting must rotate the image by 90 degrees!
            EncoderParameter EncParm = new EncoderParameter(Enc, (long)EncoderValue.TransformRotate90);
            EncParms.Param[0] = EncParm;

            // ulozim transformovany jpeg do streamu
            MemoryStream TmpStream = new MemoryStream();
            PicImage.Save(TmpStream, CodecInfo, EncParms);
            // vymaz z pameti
            PicImage.Dispose();
            PicImage = null;

            // ted ho otocim zpet a dam do puvodniho souboru
            PicImage = Image.FromStream(TmpStream);
            EncParm = new EncoderParameter(Enc, (long)EncoderValue.TransformRotate270);
            EncParms.Param[0] = EncParm;
            PicImage.Save(DestinationFile, CodecInfo, EncParms);
            PicImage.Dispose();
            PicImage = null;
        }


 
	}
}
