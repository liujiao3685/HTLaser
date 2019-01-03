using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaTianProject.Libs
{
    public class StreamFile
    {
        public string FilePath { set; get; }

        private bool m_fileExist;

        private bool m_recordDate;

        private static object obj;

        /// <summary>
        /// 初始化文件读写流
        /// </summary>
        /// <param name="strPath">文件路径</param>
        /// <param name="addTime">是否增加写入时间</param>
        public StreamFile(string strPath, bool addTime)
        {
            m_fileExist = false;
            m_recordDate = true;
            obj = new object();

            try
            {
                if (!File.Exists(strPath))
                {
                    File.CreateText(strPath);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                error = "日志文件初始化错误 " + error;
                MessageBox.Show(error);
                return;
            }

            FilePath = strPath;
            m_fileExist = true;
            m_recordDate = addTime;

        }

        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="text"></param>
        public bool AppendText(string text)
        {
            if (!m_fileExist)
            {
                return false;
            }

            lock (obj)
            {
                try
                {
                    //利用using语句避免文件系统错误，程序运行完主动调用dispose关闭流
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        string time = string.Empty;
                        if (m_recordDate)
                        {
                            time = DateTime.Now.ToString();
                        }
                        text = time + text;
                        sw.WriteLine(text);
                    }
                    //sw.Close();
                }

                catch (Exception ex)
                {
                }
            }

            return true;
        }

        /// <summary>
        /// 读取日志文件
        /// </summary>
        /// <returns></returns>
        public List<string> ReadText()
        {
            List<string> list = new List<string>();

            if (!m_fileExist)
            {
                return null;
            }

            lock (obj)
            {
                try
                {
                    StreamReader sr = File.OpenText(FilePath);

                    string str = string.Empty;

                    while ((str = sr.ReadLine()) != null)
                    {
                        str.Trim();
                        list.Add(str);
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return list;
        }

        /// <summary>
        /// 删除日志文件
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool DeleteText(string txt)
        {
            if (!m_fileExist)
            {
                return false;
            }

            lock (obj)
            {
                try
                {
                    List<string> lines = new List<string>(File.ReadAllLines(FilePath));
                    lines.Remove(txt);
                    File.WriteAllLines(FilePath, lines.ToArray());

                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    error = "删除日志文件失败！异常：" + error;
                    MessageBox.Show(error);
                    return false;
                }
            }

            return true;
        }


    }
}
