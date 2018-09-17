/*
 dle: http://www.eggheadcafe.com/articles/20030706.asp
 
Lossless JPEG Rewrites in C#
By Peter A. Bromberg, Ph.D.
Printer - Friendly Version 	Peter Bromberg

While playing around with some of the GDI+ classes to manipulate pictures from 
my digital camera, I found that if you want to add or modify an image description 
of an EXIF image file (EXIF = JPEG plus additional information) you can read and 
write the image description with the PropertyItem data structure. These PropertyItems 
are very useful to avoid the bit manipulating in the file structure of an exif file.

But the problem is: when writing the image with the changed or new description the 
picture part becomes recompressed. You can notice this from the file size; you 
add information to the file and the file size decreases. When you repeat changing 
the description, the image become more and more poor, because jpg is a lossy compression. 
So how do you load and save an jpg or exif file without recompressing the bitmap?

The trick is to rotate the picture by 90 degrees. In this case the framework supplies 
a lossless rewriting of a jpeg file:
 
 */

using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Vt.Jpeg;
using Vt.JpegExifConstants;
using Vt.Strings;


namespace Vt.JpegExifWrite
{

    public class JpegExifWrite
    {
        /// <summary>
        /// zapise do jpegu ascii textovou exif informaci
        /// </summary>
        /// <param name="Filename">jmeno jpeg souboru</param>
        /// <param name="TextValue">text</param>
        /// <param name="Id">id cislo exif vlastnosti</param>
        public static void WriteASCIIValue(string Filename, string TextValue, PropertyTagId Id)
        {
            // load the image to change
            Image PicImage = Image.FromFile(Filename);

            System.Drawing.Imaging.Encoder Enc = System.Drawing.Imaging.Encoder.Transformation;
            EncoderParameters EncParms = new EncoderParameters(1);
            ImageCodecInfo CodecInfo = Vt.Jpeg.Jpeg.GetEncoderInfo("image/jpeg");

            // put the new description into the right property item
            PropertyItem[] PropertyItems = PicImage.PropertyItems;
            PropertyItems[0].Id    = (int)Id; // 0x010e;
            PropertyItems[0].Type  = (short)PropertyTagType.ASCII;
            PropertyItems[0].Len   = TextValue.Length;
            PropertyItems[0].Value = VtStrings.StringToByteArray(TextValue);
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
            PicImage.Save(Filename, CodecInfo, EncParms);
            PicImage.Dispose();
            PicImage = null;
        }







        public static void WriteASCIIValue(Vt.Jpeg.Jpeg VtJpeg, string TextValue, PropertyTagId Id)
        {
            // load the image to change
            Image PicImage = new Bitmap(VtJpeg.SourceBitmap);
            

            System.Drawing.Imaging.Encoder Enc = System.Drawing.Imaging.Encoder.Transformation;
            EncoderParameters EncParms = new EncoderParameters(1);
            ImageCodecInfo CodecInfo = Vt.Jpeg.Jpeg.GetEncoderInfo("image/jpeg");

            // put the new description into the right property item
            PropertyItem[] PropertyItems = PicImage.PropertyItems;
            PropertyItems[0].Id = (int)Id; // 0x010e;
            PropertyItems[0].Type = (short)PropertyTagType.ASCII;
            PropertyItems[0].Len = TextValue.Length;
            PropertyItems[0].Value = VtStrings.StringToByteArray(TextValue);
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
//            PicImage.Save(Filename, CodecInfo, EncParms);
  VtJpeg.LoadFromBitmap(PicImage as Bitmap);


            PicImage.Dispose();
            PicImage = null;
        }
    
    
    
    }

}
