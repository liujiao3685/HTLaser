using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace GDIPaint
{
    public class XmlHelper
    {
        /// <summary>
        /// 配置文件保存路径
        /// </summary>
        public static string XmlSavePath = Application.StartupPath + @"\" + "PaintSetting.xml";

        /// <summary>
        /// 形状
        /// </summary>
        public static string ShapeType = "Rectangle";

        /// <summary>
        /// 若文件不存在则重新创建
        /// </summary>
        /// <returns></returns>
        public static bool CreatePointsXmlFile()
        {
            if (File.Exists(XmlSavePath)) return false;

            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(dec);
            //创建一个一级根节点
            XmlElement root = xmlDoc.CreateElement("points");
            root.SetAttribute("type", ShapeType);
            xmlDoc.AppendChild(root);
            xmlDoc.Save(XmlSavePath);
            xmlDoc.Clone();
            xmlDoc = null;

            return true;
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadPointSetting()
        {
            Dictionary<string, string> dicPoint = new Dictionary<string, string>();

            if (!File.Exists(XmlSavePath))
            {
                CreatePointsXmlFile();
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(XmlSavePath);
                XmlNode root = xmlDoc.SelectSingleNode("points");
                ShapeType = root.Attributes["type"].Value;
                XmlNodeList pointList = root.ChildNodes;
                for (int i = 0; i < pointList.Count; i++)
                {
                    dicPoint.Add(Convert.ToString(pointList[i].Attributes["key"].Value),
                        Convert.ToString(pointList[i].Attributes["value"].Value));
                }

            }
            catch (Exception)
            {
                return null;
            }
            return dicPoint;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dicPoints"></param>
        /// <returns></returns>
        public static bool SavePointSetting(Dictionary<string, string> dicPoints)
        {
            if (!File.Exists(XmlSavePath))
            {
                CreatePointsXmlFile();
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(XmlSavePath);
                XmlNode root = xmlDoc.SelectSingleNode("points");
                root.Attributes["type"].Value = ShapeType;
                if (root != null)
                {
                    XmlNodeList pointsList = root.ChildNodes;
                    foreach (var point in dicPoints)
                    {
                        bool isExitKey = false;
                        for (int i = 0; i < pointsList.Count; i++)
                        {
                            if (Convert.ToString(pointsList[i].Attributes["key"].Value) == point.Key)
                            {
                                pointsList[i].Attributes["value"].Value = Convert.ToString(point.Value);
                                isExitKey = true;
                            }
                        }
                        if (!isExitKey)
                        {
                            XmlElement xe = xmlDoc.CreateElement("add");
                            xe.SetAttribute("key", point.Key);
                            xe.SetAttribute("value", point.Value);
                            root.AppendChild(xe);
                        }
                    }
                }
                xmlDoc.Save(XmlSavePath);
                xmlDoc.Clone();
                xmlDoc = null;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


    }
}
