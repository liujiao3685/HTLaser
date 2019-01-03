using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace HuaTianProject.Core
{
    /// <summary>
    /// XML助手
    /// </summary>
    public class XMLHelper
    {
        /// <summary>
        /// XML配置文件路径
        /// </summary>
        public static string SSettingXmlPath = Application.StartupPath + @"\" + "AxisSettings.xml";

        /// <summary>
        /// 创建XML
        /// </summary>
        public static void CreateAppSettingsXml()
        {
            if (File.Exists(SSettingXmlPath)) return;

            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(dec);
            //创建一个根节点（一级） 
            XmlElement root = xmlDoc.CreateElement("axisSettings");
            xmlDoc.AppendChild(root);
            xmlDoc.Save(SSettingXmlPath);
            xmlDoc.Clone();
            xmlDoc = null;
        }

        /// <summary>
        /// 加载所有配置信息
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadAppSettings()
        {
            if (!File.Exists(SSettingXmlPath))
            {
                CreateAppSettingsXml();
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(SSettingXmlPath);
            XmlNode root = xmlDoc.SelectSingleNode("axisSettings");
            XmlNodeList appSettingsList = root.ChildNodes;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < appSettingsList.Count; i++)
            {
                dic.Add(Convert.ToString(appSettingsList[i].Attributes["key"].Value),
                       Convert.ToString(appSettingsList[i].Attributes["value"].Value));
            }
            return dic;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="dicAppSettings">所有要添加或修改的配置信息</param>
        public static void SaveAppSetting(Dictionary<string, string> dicAppSettings)
        {
            if (!File.Exists(SSettingXmlPath))
            {
                CreateAppSettingsXml();
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(SSettingXmlPath);
            XmlNode root = xmlDoc.SelectSingleNode("axisSettings");
            XmlNodeList appSettingsList = root.ChildNodes;
            foreach (var appSeting in dicAppSettings)
            {
                bool bIsExistKey = false;
                for (int i = 0; i < appSettingsList.Count; i++)
                {
                    Console.WriteLine(appSettingsList[i].Name);
                    if (Convert.ToString(appSettingsList[i].Attributes["key"].Value) == appSeting.Key)
                    {
                        appSettingsList[i].Attributes["value"].Value = Convert.ToString(appSeting.Value);
                        bIsExistKey = true;
                    }
                }
                if (bIsExistKey == false)
                {
                    XmlElement xe = xmlDoc.CreateElement("add");
                    xe.SetAttribute("key", appSeting.Key);
                    xe.SetAttribute("value", appSeting.Value);
                    root.AppendChild(xe);
                }
            }

            xmlDoc.Save(SSettingXmlPath);
            xmlDoc.Clone();
            xmlDoc = null;
        }
    }
}
