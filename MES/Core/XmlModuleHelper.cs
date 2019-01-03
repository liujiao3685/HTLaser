using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace MES.Core
{
    public class XmlModuleHelper : XmlHelperBase
    {
#pragma warning disable CS0108 // “XmlModuleHelper.XmlDirPath”隐藏继承的成员“XmlHelperBase.XmlDirPath”。如果是有意隐藏，请使用关键字 new。
        /// <summary>
        /// 文件夹保存路径
        /// </summary>
        public static string XmlDirPath = Application.StartupPath + @"\Module\";
#pragma warning restore CS0108 // “XmlModuleHelper.XmlDirPath”隐藏继承的成员“XmlHelperBase.XmlDirPath”。如果是有意隐藏，请使用关键字 new。

        /// <summary>
        /// 模板名称
        /// </summary>
        public static string ModuleName = string.Empty;

        /// <summary>
        /// 文件后缀名
        /// </summary>
        public static string XmlSuffix = ".xml";

#pragma warning disable CS0108 // “XmlModuleHelper.XmlFilePath”隐藏继承的成员“XmlHelperBase.XmlFilePath”。如果是有意隐藏，请使用关键字 new。
        /// <summary>
        /// 模板文件地址
        /// </summary>
        public static string XmlFilePath = string.Empty;
#pragma warning restore CS0108 // “XmlModuleHelper.XmlFilePath”隐藏继承的成员“XmlHelperBase.XmlFilePath”。如果是有意隐藏，请使用关键字 new。

#pragma warning disable CS0108 // “XmlModuleHelper.CreateXmlDir()”隐藏继承的成员“XmlHelperBase.CreateXmlDir()”。如果是有意隐藏，请使用关键字 new。
        /// <summary>
        /// 判断模板文件夹是否存在，不存在则创建
        /// </summary>
        /// <returns></returns>
        public static bool CreateXmlDir()
#pragma warning restore CS0108 // “XmlModuleHelper.CreateXmlDir()”隐藏继承的成员“XmlHelperBase.CreateXmlDir()”。如果是有意隐藏，请使用关键字 new。
        {
            if (Directory.Exists(XmlDirPath)) return false;

            Directory.CreateDirectory(XmlDirPath);

            return true;
        }

#pragma warning disable CS0108 // “XmlModuleHelper.CreateXmlFile()”隐藏继承的成员“XmlHelperBase.CreateXmlFile()”。如果是有意隐藏，请使用关键字 new。
        public static bool CreateXmlFile()
#pragma warning restore CS0108 // “XmlModuleHelper.CreateXmlFile()”隐藏继承的成员“XmlHelperBase.CreateXmlFile()”。如果是有意隐藏，请使用关键字 new。
        {
            if (String.IsNullOrEmpty(ModuleName)) XmlFilePath = XmlDirPath + ModuleName + XmlSuffix;

            if (File.Exists(XmlFilePath)) return false;

            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);

            xmlDoc.AppendChild(xmlDec);

            XmlElement root = xmlDoc.CreateElement("Module");
            root.SetAttribute("Name", ModuleName);
            xmlDoc.AppendChild(root);
            xmlDoc.Save(XmlFilePath);
            xmlDoc.Clone();
            xmlDoc = null;

            return true;
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadModuleFile()
        {
            Dictionary<string, string> dicModule = new Dictionary<string, string>();

            if (!Directory.Exists(XmlDirPath)) CreateXmlDir();

            if (!File.Exists(XmlFilePath)) CreateXmlFile();

            try
            {
                if (String.IsNullOrEmpty(ModuleName)) XmlFilePath = XmlDirPath + ModuleName + XmlSuffix;

                XmlDocument doc = new XmlDocument();
                doc.Load(XmlFilePath);
                XmlNode root = doc.SelectSingleNode("Module");
                ModuleName = root.Attributes["Name"].Value;
                XmlNodeList list = root.ChildNodes;

                for (int i = 0; i < list.Count; i++)
                {
                    dicModule.Add(Convert.ToString(list[i].Attributes["key"].Value),
                        Convert.ToString(list[i].Attributes["value"].Value));
                }
            }
            catch (Exception ex)
            {
                Program.LogNet.WriteError("异常", ex.Message);
                return null;
            }

            return dicModule;
        }

        /// <summary>
        /// 保存模板文件
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static bool SaveModuleFile(Dictionary<string, string> dic)
        {
            if (!Directory.Exists(XmlDirPath)) CreateXmlDir();

            if (!File.Exists(XmlFilePath)) CreateXmlFile();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlFilePath);
                XmlNode root = doc.SelectSingleNode("Module");
                root.Attributes["Name"].Value = ModuleName;
                if (root != null)
                {
                    XmlNodeList list = root.ChildNodes;
                    foreach (var item in dic)
                    {
                        bool isExitKey = false;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (Convert.ToString(list[i].Attributes["key"].Value) == item.Key)
                            {
                                list[i].Attributes["value"].Value = Convert.ToString(item.Value);
                                isExitKey = true;
                            }
                        }
                        if (!isExitKey)
                        {
                            XmlElement xe = doc.CreateElement("Item");
                            xe.SetAttribute("key", item.Key);
                            xe.SetAttribute("value", item.Value);
                            root.AppendChild(xe);
                        }

                    }

                }
                doc.Save(XmlFilePath);
                doc.Clone();
                doc = null;

            }
            catch (Exception ex)
            {
                Program.LogNet.WriteError("异常", ex.Message);
                return false;
            }
            return true;
        }


    }
}
