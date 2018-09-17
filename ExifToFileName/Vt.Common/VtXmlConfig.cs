/*
- zcela jednoduchy ukladac/nacitac nastaveni z xml souboru
- priblizne tento format:
 

<Config>
	<retezec Value="qwerty"/>
	<bool Value="0"/>
	<bool Value="True"/>
	<integer Value="0"/>
</Config>


 * 
 Pouziti napr takhle:

        private void SaveXmlConfig()
        {
            XmlConfig XCfg = new XmlConfig();
            XCfg.Load();

            // CheckBox
            XCfg.SetCheckBox(ref CBExif);
            XCfg.SetCheckBox(ref CBTripTracker);
            XCfg.SetCheckBox(ref CBResizeSmaller);
            XCfg.SetCheckBox(ref CBFilenamesToAscii);
            XCfg.SetCheckBox(ref ChToLowerCase);
            // NumericUpDown
            XCfg.SetNumericUpDown(ref NumThumbCompression);
            XCfg.SetNumericUpDown(ref NumImagesCompression);
            XCfg.SetNumericUpDown(ref NumThumbnailsSize);
            XCfg.SetNumericUpDown(ref NumImagesSize);
            XCfg.SetNumericUpDown(ref NumImagesPerRow);

            XCfg.SetString(SPathSource.Name, SPathSource.SelectedFolder);
            XCfg.SetString(SPathWebRoot.Name, SPathWebRoot.SelectedFolder);
            XCfg.SetString(UCColorBackground.Name, UCColorBackground.HtmlColor);
            XCfg.SetString(TBCss.Name, TBCss.Text);

            XCfg.Save();
        }


        private void LoadXmlConfig()
        {
            XmlConfig XCfg = new XmlConfig();
            XCfg.Load();

            // CheckBox
            XCfg.GetCheckBox(ref CBExif);
            XCfg.GetCheckBox(ref CBTripTracker);
            XCfg.GetCheckBox(ref CBResizeSmaller);
            XCfg.GetCheckBox(ref CBFilenamesToAscii);
            XCfg.GetCheckBox(ref ChToLowerCase);
            // NumericUpDown
            XCfg.GetNumericUpDown(ref NumThumbCompression);
            XCfg.GetNumericUpDown(ref NumImagesCompression);
            XCfg.GetNumericUpDown(ref NumThumbnailsSize);
            XCfg.GetNumericUpDown(ref NumImagesSize);
            XCfg.GetNumericUpDown(ref NumImagesPerRow);

            SPathSource.SelectedFolder  = XCfg.GetString(SPathSource.Name, SPathSource.SelectedFolder);
            SPathWebRoot.SelectedFolder = XCfg.GetString(SPathWebRoot.Name, SPathWebRoot.SelectedFolder);
            UCColorBackground.HtmlColor = XCfg.GetString(UCColorBackground.Name, UCColorBackground.HtmlColor);
            TBCss.Text = XCfg.GetString(TBCss.Name, TBCss.Text);
        }

 
*/



using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Collections;
using System.Windows.Forms;


namespace Vt.XmlConfig
{
    class XmlConfig
    {
        private static string CONFIG_NAME = "config";

        XmlDocument XmlDoc = null;
        XmlNode     ConfigNode = null;

        
        public XmlConfig()
        {
            XmlDoc = null;
        }

        // neni-li zadano jmeno, tak filemane aplikace + koncovka
        private string GetDefaultCfgFileName()
        {
            return AppDomain.CurrentDomain.FriendlyName + ".cfg.xml";
        }

        public bool Load()
        {
            return Load(GetDefaultCfgFileName());
        }

        public bool Load(string FileName)
        {
            XmlDoc = new XmlDocument();
            try
            {
                XmlDoc.Load(FileName);
                // nacteni xml souboru ok - zkusim najit root node
                if (XmlDoc.DocumentElement.Name.Equals(CONFIG_NAME))
                    ConfigNode = XmlDoc.DocumentElement;
                else
                {
                    foreach (XmlNode Node in XmlDoc.DocumentElement)
                    {
                        if (Node.Name.Equals(CONFIG_NAME))
                        {
                            ConfigNode = Node;
                            break;
                        }
                    }
                }
                return true;
            }
            catch
            {
                // vytvorim root node
                XmlNode NewNode = XmlDoc.CreateElement(CONFIG_NAME);
                NewNode.InnerText = "AutoCreated by Vt.XmlConfig.Load()";
                XmlDoc.AppendChild(NewNode);
                ConfigNode = XmlDoc.DocumentElement;
                return false;
            }
        }


        public bool Save()
        {
            return Save(GetDefaultCfgFileName());
        }
        public bool Save(string FileName)
        {
            XmlDoc.Save(FileName);
            return true;
        }



        public string FindNodeValue(string Key)
        {
            XmlNode XNode = FindNode(Key);
            if (XNode != null)
                return XNode.InnerText;
            else
                return null;
        }

        public XmlNode FindNode(string Key)
        {
            if (ConfigNode != null)
            {
                foreach (XmlNode XNode in ConfigNode)
                    if (XNode.Name.Equals(Key))
                        return XNode;
            }
            return null;
        }

        public bool ExistNode(string Key)
        {
            return (FindNode(Key) != null);
        }


        public string GetString(string Key)
        {
            return GetString(Key, null);
        }
        public string GetString(string Key, string DefaultValue)
        {
            string Value = FindNodeValue(Key);
            if (Value != null)
                return Value;
            else
                return DefaultValue;
        }

        public string GetString(string Key, string Att, string DefaultValue)
        {
            XmlNode XNode = FindNode(Key);
            if (XNode != null)
            {
                foreach (XmlAttribute XAtt in XNode.Attributes)
                {
                    if (XAtt.Name == Att)
                    {
                        return XAtt.Value;
                    }
                }
            }
            return null;
        }

        public bool SetString(string Key, string Value)
        {
            if (ConfigNode != null)
            {
                foreach (XmlNode XNode in ConfigNode)
                    if (XNode.Name.Equals(Key))
                    {
                        XNode.InnerText = Value;
                        return true;
                    }
                // nenasel, tak zakladam novy !
                XmlNode NewNode = XmlDoc.CreateElement(Key);
                NewNode.InnerText = Value;
                ConfigNode.AppendChild(NewNode);
            }
            return false;
        }



        public bool SetBool(string Key, bool Value)
        {
            return SetString(Key, Value.ToString());
        }
        public bool GetBool(string Key, bool DefaultValue)
        {
            string Value = FindNodeValue(Key);
            if (Value != null)
                return StrToBool(Value);
            else
                return DefaultValue;
        }


        public bool SetDecimal(string Key, decimal Value)
        {
            return SetString(Key, Value.ToString());
        }

        public decimal GetDecimal(string Key, decimal DefaultValue)
        {
            string StrValue = FindNodeValue(Key);
            if (StrValue != null)
                return StrToDecimal(StrValue, DefaultValue);
            else
                return DefaultValue;
        }



        private void ArrayListToNode(XmlNode Node, ArrayList AList)
        {
            Node.Attributes.RemoveAll();
            int i = 0;
            foreach(string s in AList)
            {
                XmlAttribute XAtt = XmlDoc.CreateAttribute("item" + i.ToString());
                XAtt.Value = s;
                Node.Attributes.Append(XAtt);
                i++;
            }
        }





        public void SetStrings(string Key, ArrayList AList)
        {
            if (ConfigNode != null)
            {
                foreach (XmlNode XNode in ConfigNode)
                    if (XNode.Name.Equals(Key))
                    {
                        ArrayListToNode(XNode, AList);
                        return;
                    }
                // nenasel, tak zakladam novy !
                XmlNode NewNode = XmlDoc.CreateElement(Key);
                ArrayListToNode(NewNode, AList);
                ConfigNode.AppendChild(NewNode);
            }
        }

        public void GetStrings(string Key, ref ArrayList AList)
        {
            AList.Clear();
            XmlNode XNode = FindNode(Key);
            if (XNode != null)
            {
                for (int i = 0; i < XNode.Attributes.Count; i++)
                {
                    XmlAttribute XAtt = XNode.Attributes[i];
                    if (XAtt != null)
                    {
                        string s = XAtt.Value;
                        AList.Add(s);
                    }
                }
            }
        }


        //
        // ListBox
        //
        public bool SetListBox(string Key, ref ListBox LBox)
        {
            if (ConfigNode != null)
            {
                ArrayList AList = new ArrayList();
                foreach (string Item in LBox.Items)
                    AList.Add(Item);
                SetStrings(Key, AList);
            }
            return false;
        }

        public void GetListBox(string Key, ref ListBox LBox)
        {
            LBox.Items.Clear();
            XmlNode XNode = FindNode(Key);
            if (XNode != null)
            {
                for (int i = 0; i < XNode.Attributes.Count; i++)
                {
                    XmlAttribute XAtt = XNode.Attributes[i];
                    if (XAtt != null)
                    {
                        string s = XAtt.Value;
                        LBox.Items.Add(s);
                    }
                }
            }
        }


        //
        // CheckBox
        //
        public void SetCheckBox(ref CheckBox CBox)
        {
            SetBool(CBox.Name, CBox.Checked);
        }

        public void GetCheckBox(ref CheckBox CBox)
        {
            CBox.Checked = GetBool(CBox.Name, CBox.Checked);
        }
        public void GetCheckBox(ref CheckBox CBox, bool DefaultValue)
        {
            CBox.Checked = GetBool(CBox.Name, DefaultValue);
        }

        //
        // NumericUpDown
        //
        public void SetNumericUpDown(ref NumericUpDown NUpDown)
        {
            SetDecimal(NUpDown.Name, NUpDown.Value);
        }
        public void GetNumericUpDown(ref NumericUpDown NUpDown)
        {
            NUpDown.Value = GetDecimal(NUpDown.Name, NUpDown.Value);
        }
        public void GetNumericUpDown(ref NumericUpDown NUpDown, decimal DefaultValue)
        {
            NUpDown.Value = GetDecimal(NUpDown.Name, DefaultValue);
        }
        
        

        //
        // prevody
        //
        //
        private bool StrToBool(string Value)
        {
            if (Value != null)
                return ((Value.Equals("1")) | (Value.ToLower().Equals("true")));
            else
                return false;
        }

        // Convert.ToDecimal(strValue) or Decimal.Parse(strValue) 
        private decimal StrToDecimal(string StrValue, decimal DefaultValue)
        {
            decimal Result;
            try
            {
                Result = Decimal.Parse(StrValue);
            }
            catch
            {
                Result = DefaultValue;
            }
            return Result;
        }


    }
}
