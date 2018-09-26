using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurveSelectionClient
{
    /// <summary>
    /// Methods used for Exporting XML data
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Download Xml file to the path specified.
        /// Creates filenames with the current timestamp
        /// </summary>
        public static void DownloadFile(XmlDocument doc)
        {
            doc.Save(@Settings.DownloadPath+"_"+ DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." +Settings.FileExtension);
        }
        /// <summary>
        /// Create XML file in the format specified
        /// </summary>
        public static XmlDocument CreateXMLFile(List<string> curveSelected, ExportData exportData)
        {
            XmlDocument xmlDocument = new XmlDocument();

            /*****************************************
             Create xml node
            <?xml version="1.0" encoding="utf-8"?>
            ****************************************/
            XmlDeclaration declarationNode = (XmlDeclaration)xmlDocument.CreateNode(XmlNodeType.XmlDeclaration, "xml", string.Empty);
            declarationNode.Encoding = Encoding.UTF8.HeaderName;
            xmlDocument.InsertBefore(declarationNode, xmlDocument.FirstChild);


            /*****************************************
             Create the <log> Node
             <log>
            ****************************************/
            XmlElement rootLogElement = xmlDocument.CreateElement("log");
            xmlDocument.AppendChild(rootLogElement);

            /*****************************************
            // Create the <logCurveInfo> Node
            //< logCurveInfo id =”index”>
            //< typeLogData > long </ typeLogData >
            //</ logCurveInfo >
            ****************************************/
            XmlElement logCurveInfoElement = xmlDocument.CreateElement("logCurveInfo");
            logCurveInfoElement.SetAttribute("id", "index");
            XmlElement typeLogElement = xmlDocument.CreateElement("typeLogData");
            typeLogElement.AppendChild(xmlDocument.CreateTextNode("long"));
            logCurveInfoElement.AppendChild(typeLogElement);
            // Add the logCurveInfo node to the root log.
            rootLogElement.AppendChild(logCurveInfoElement);

            /*****************************************
            //Create curve elements
            //< logCurveInfo id =”A”>
            //< minIndex > 100 </ minIndex >
            //< maxIndex > 150 </ maxIndex >
            //< typeLogData > double </ typeLogData >
            //</ logCurveInfo >
            ****************************************/
            foreach (var curve in curveSelected)
            {
            XmlElement logCurveElement = xmlDocument.CreateElement("logCurveInfo");
            logCurveElement.SetAttribute("id", curve);

            XmlElement minElement = xmlDocument.CreateElement("minIndex");
            minElement.AppendChild(xmlDocument.CreateTextNode(exportData.MinCurve[curve]));
            logCurveElement.AppendChild(minElement);

            XmlElement maxElement = xmlDocument.CreateElement("maxIndex");
            maxElement.AppendChild(xmlDocument.CreateTextNode(exportData.MaxCurve[curve]));
            logCurveElement.AppendChild(maxElement);

            XmlElement typeLogDataElement = xmlDocument.CreateElement("typeLogData");
            typeLogDataElement.AppendChild(xmlDocument.CreateTextNode("double"));
            logCurveElement.AppendChild(typeLogDataElement);

            // Add the logCurveInfo node to the root log.
            rootLogElement.AppendChild(logCurveElement);
            }

            /*****************************************
            //Create node logData
            //< logData >
            //< header > index,A,B </ header >
            //< data > 100,150.0,44.0 </ data >
            //< data > 110,750.0,58.0 </ data >
            //< data > 120,750.0,44.0 </ data >
            //< data > 130,150.0,</ data >
            //< data > 140,,58.0 </ data >
            //< data > 150,222.0,</ data >
            //</ logData >
            ****************************************/
            XmlElement logDataElement = xmlDocument.CreateElement("logData");

            XmlElement headerElement = xmlDocument.CreateElement("header");
            string headerText = "index";
            foreach (var curve in curveSelected)
            {
            headerText += "," + curve;
            }
            headerElement.AppendChild(xmlDocument.CreateTextNode(headerText));
            logDataElement.AppendChild(headerElement);

            foreach (var curData in exportData.ExportList)
            {
            XmlElement dataElement = xmlDocument.CreateElement("data");
            string dataText = curData["index"];
            foreach (var curve in curveSelected)
            {
            dataText += "," + curData[curve];
            }
            dataElement.AppendChild(xmlDocument.CreateTextNode(dataText));
            logDataElement.AppendChild(dataElement);
            }
            // Add the logCurveInfo node to the root log.
            rootLogElement.AppendChild(logDataElement);

            return xmlDocument;
        }
    }
}
