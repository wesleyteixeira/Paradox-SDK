﻿using System;
using System.IO;
using System.Xml;

namespace Harmony.SDK.Paradox.Model
{
    #region XML Example

    /*   
       <?xml version="1.0"?>
        <objects>
          <object objectname="TPanelInfoExXML" name="PanelInfoEx">
            <published>
              <method name="Description" readonly="False" type="UnicodeString"></method>
              <method name="ProductID" readonly="False" type="Integer">0</method>
              <method name="SerialNo" readonly="False" type="UnicodeString"></method>
              <method name="Version" readonly="False" type="Integer">0</method>
              <method name="Revision" readonly="False" type="Integer">0</method>
              <method name="Build" readonly="False" type="Integer">0</method>
              <method name="AreaCount" readonly="False" type="Integer">0</method>
              <method name="ZoneCount" readonly="False" type="Integer">0</method>
              <method name="PGMCount" readonly="False" type="Integer">0</method>
              <method name="UserCount" readonly="False" type="Integer">0</method>
              <method name="DoorCount" readonly="False" type="Integer">0</method>
              <method name="ReceiverCount" readonly="False" type="Integer">0</method>
              <method name="ScheduleCount" readonly="False" type="Integer">0</method>
              <method name="AccessLevelCount" readonly="False" type="Integer">0</method>
            </published>
          </object>
        </objects>
    */

    #endregion

    public class PanelInfoEx : BasePanelModel<PanelInfoEx>
    {
        public string Description;
        public int ProductID;
        public string SerialNo;
        public int Version;
        public int Revision;
        public int Build;
        public int AreaCount;
        public int ZoneCount;
        public int PGMCount;
        public int UserCount;
        public int DoorCount;
        public int ReceiverCount;
        public int ScheduleCount;
        public int AccessLevelCount;

        public PanelInfoEx()
        {
            ObjectName = "TPanelInfoExXML";
            Name = "PanelInfoEx";
        }
        
        protected internal bool parseXML(string xmlString)
        {
            string sname, svalue;
            if (xmlString != null)
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {
                    try
                    {
                        reader.ReadToFollowing("object");
                        base.ParseXml(reader);

                        while (reader.ReadToFollowing("method"))
                        {
                            reader.MoveToFirstAttribute();
                            sname = reader.Value;

                            if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "method")
                            {
                                svalue = reader.ReadString();

                                if (sname == "Description") Description = svalue.Trim();
                                else if (sname == "ProductID") ProductID = Convert.ToInt32(svalue.Trim());
                                else if (sname == "SerialNo") SerialNo = svalue.Trim();
                                else if (sname == "Version") Version = Convert.ToInt32(svalue.Trim());
                                else if (sname == "Revision") Revision = Convert.ToInt32(svalue.Trim());
                                else if (sname == "Build") Build = Convert.ToInt32(svalue.Trim());
                                else if (sname == "AreaCount") AreaCount = Convert.ToInt32(svalue.Trim());
                                else if (sname == "ZoneCount") ZoneCount = Convert.ToInt32(svalue.Trim());
                                else if (sname == "PGMCount") PGMCount = Convert.ToInt32(svalue.Trim());
                                else if (sname == "UserCount") UserCount = Convert.ToInt32(svalue.Trim());
                                else if (sname == "DoorCount") DoorCount = Convert.ToInt32(svalue.Trim());
                                else if (sname == "ReceiverCount") ReceiverCount = Convert.ToInt32(svalue.Trim());
                                else if (sname == "ScheduleCount") ScheduleCount = Convert.ToInt32(svalue.Trim());
                                else if (sname == "AccessLevelCount") AccessLevelCount = Convert.ToInt32(svalue.Trim());
                            }
                        }

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public bool LoadFromXmlString(string xmlString)
        {
            return parseXML(xmlString);
        }
    }
}