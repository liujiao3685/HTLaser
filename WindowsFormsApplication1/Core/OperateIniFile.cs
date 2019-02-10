using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Core
{
    public class OperateIniFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key, string def, Byte[] retVal, int size, string filePath);

        public Dictionary<string, Dictionary<string, string>> Items;

        public string Last_Error_Msg = string.Empty;

        private string m_filePath = string.Empty;

        public OperateIniFile()
        {
            Items = new Dictionary<string, Dictionary<string, string>>();
        }

        public bool LoadIniFile(string filePath)
        {
            try
            {
                m_filePath = filePath;
                Items.Clear();
                if (!File.Exists(filePath))
                {
                    Last_Error_Msg = "Ini 文件未找到！";
                    return false;
                }

                List<string> Sections = ReadSections();

                foreach (var s in Sections)
                {
                    List<string> keys = ReadKeys(s);
                    Dictionary<string, string> temp = new Dictionary<string, string>();

                    foreach (var k in keys)
                    {
                        string v = ReadIniData(s, k, "");
                        temp.Add(k, v);
                    }
                    Items.Add(s, temp);
                }
                return true;
            }
            catch (Exception ex)
            {
                Last_Error_Msg = ex.Message;
                return false;
            }
        }

        public List<string> ReadKeys(string sectionName)
        {
            return ReadKeys(sectionName, m_filePath);
        }

        public List<string> ReadKeys(string sectionName, string iniFileName)
        {
            List<string> keys = new List<string>();

            Byte[] buf = new Byte[ushort.MaxValue + 1];
            uint len = GetPrivateProfileStringA(sectionName, null, null, buf, buf.Length, iniFileName);
            int j = 0;
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    keys.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            }
            return keys;
        }

        public List<string> ReadSections()
        {
            return ReadSections(m_filePath);
        }

        public List<string> ReadSections(string iniFilePath)
        {
            List<string> result = new List<string>();
            Byte[] buf = new Byte[ushort.MaxValue + 1];
            uint len = GetPrivateProfileStringA(null, null, null, buf, buf.Length, iniFilePath);

            int j = 0;
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            }
            return result;
        }

        #region 读取ini文件
        public string ReadIniData(string section, string key, string noText)
        {
            return ReadIniData(section, key, noText, m_filePath);
        }

        public string ReadIniData(string section, string key, string noText, string iniPath)
        {
            if (File.Exists(iniPath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(section, key, noText, temp, 1024, iniPath);
                return temp.ToString();
            }
            return string.Empty;
        }
        #endregion

        #region 写入ini文件

        public bool WriteIniData(string section, string key, string value)
        {
            return WriteIniData(section, key, value, m_filePath);
        }
        public bool WriteIniData(string section, string key, string value, string iniFile)
        {
            if (File.Exists(iniFile))
            {
                long OpStation = WritePrivateProfileString(section, key, value, iniFile);
                if (OpStation == 0) return false;
            }
            return true;
        }
        #endregion
    }

}
