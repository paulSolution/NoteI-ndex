using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DataHistory
{
    public class SaveDataHstry
    {
        private static XmlDocument _xmlDoc;

        private static List<string> _indexLst = new List<string>() { "!!   Empty   !!" };

        private static XmlNodeList elementList;

        private static string _filePath;
        /// <summary>
        /// Initialize Save Data Class
        /// </summary>
        /// <param name="FilePath">Full Path of the file including name and extention
        /// which will be create or load for Read and Write</param>
        public SaveDataHstry(string FilePath)
        {
            _filePath = @FilePath;
            LoadFile();
        }

        private void LoadFile()
        {
            _xmlDoc = new XmlDocument();
            if (File.Exists(_filePath))
            {
                _xmlDoc.Load(_filePath);
            }
            else
            {
                _xmlDoc.LoadXml(
                    "<?xml version=\"1.0\"?> \n" +
                    "<IndexList xmlns=\"AllIndex\"> \n" +
                    "</IndexList>" );
                _xmlDoc.Save(_filePath);
                _xmlDoc.Load(_filePath);
            }
        }

        /// <summary>
        /// Save All Data to Local XML File of The List
        /// </summary>
        /// <param name="Infolist">The list of the string values which have to store local</param>
        public void SaveIndexInfo(List<int> Infolist)
        {                
                string uid = DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss.tt");
                string date = DateTime.Now.ToString("dd-MMM-yyyy");
                string time = DateTime.Now.ToString("hh:mm:ss tt");

                XmlNode ele = AddNewIndex(uid, date, time, Infolist);
                _xmlDoc.DocumentElement.AppendChild(ele);
                _xmlDoc.Save(_filePath);            
        }

        private static XmlElement AddNewIndex(string _uid, string _dt, string _time, List<int> IndeInfoList)
        {
            // Create a new book element.
            XmlElement IndexElement = _xmlDoc.CreateElement("Index");

            // Create attributes for book and append them to the book element.
            XmlAttribute attribute = _xmlDoc.CreateAttribute("NI_id");
            attribute.Value = _uid;
            IndexElement.Attributes.Append(attribute);

            attribute = _xmlDoc.CreateAttribute("Date");
            attribute.Value = _dt;
            IndexElement.Attributes.Append(attribute);

            attribute = _xmlDoc.CreateAttribute("Time");
            attribute.Value = _time;
            IndexElement.Attributes.Append(attribute);

            // Create and append a child element for the title of the book.
            XmlElement Element_2000 = _xmlDoc.CreateElement("D_2000");
            Element_2000.InnerText = IndeInfoList[0].ToString();
            IndexElement.AppendChild(Element_2000);

            // Create and append a child element for the price of the book.
            XmlElement element_500 = _xmlDoc.CreateElement("D_500");
            element_500.InnerText = IndeInfoList[1].ToString();
            IndexElement.AppendChild(element_500);

            // Create and append a child element for the title of the book.
            XmlElement Element_200 = _xmlDoc.CreateElement("D_200");
            Element_200.InnerText = IndeInfoList[2].ToString();
            IndexElement.AppendChild(Element_200);

            // Create and append a child element for the price of the book.
            XmlElement element_100 = _xmlDoc.CreateElement("D_100");
            element_100.InnerText = IndeInfoList[3].ToString();
            IndexElement.AppendChild(element_100);

            // Create and append a child element for the title of the book.
            XmlElement Element_50 = _xmlDoc.CreateElement("D_50");
            Element_50.InnerText = IndeInfoList[4].ToString();
            IndexElement.AppendChild(Element_50);

            // Create and append a child element for the price of the book.
            XmlElement element_20 = _xmlDoc.CreateElement("D_20");
            element_20.InnerText = IndeInfoList[5].ToString();
            IndexElement.AppendChild(element_20);


            // Create and append a child element for the price of the book.
            XmlElement element_10 = _xmlDoc.CreateElement("D_10");
            element_10.InnerText = IndeInfoList[6].ToString();
            IndexElement.AppendChild(element_10);

            // Create and append a child element for the price of the book.
            XmlElement element_1 = _xmlDoc.CreateElement("D_1");
            element_1.InnerText = IndeInfoList[7].ToString();
            IndexElement.AppendChild(element_1);

            return IndexElement;
        }

        public List<string> GetAllIndexList()
        {
            elementList = _xmlDoc.GetElementsByTagName("Index");

            _indexLst.Clear();
            for (int i = 0; i < elementList.Count; i++)
            {
                _indexLst.Add("     Date :  " + elementList[i].Attributes["Date"].Value + "\t" +
                    "Time  " + elementList[i].Attributes["Time"].Value);
            }

            return _indexLst;
        }

        public static List<int> GetIndexInformation(int IndexNumber)
        {
            XmlElement IndexElement = (XmlElement)elementList[elementList.Count - 1 - IndexNumber];
            List<int> info = new List<int>() { 0 };
            // Get the attributes of a book.

            info.Clear();
            info.Add(Convert.ToInt32(IndexElement["D_2000"].InnerText));
            info.Add(Convert.ToInt32(IndexElement["D_500"].InnerText));
            info.Add(Convert.ToInt32(IndexElement["D_200"].InnerText));
            info.Add(Convert.ToInt32(IndexElement["D_100"].InnerText));
            info.Add(Convert.ToInt32(IndexElement["D_50"].InnerText));
            info.Add(Convert.ToInt32(IndexElement["D_20"].InnerText));
            info.Add(Convert.ToInt32(IndexElement["D_10"].InnerText));
            info.Add(Convert.ToInt32(IndexElement["D_1"].InnerText));

            return info;
        }
    }
}
