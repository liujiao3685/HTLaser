using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace WindowsFormsApplication1
{
    class ResourceCulture
    {
        public static void SetCurrentCulture(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "en-US";
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(name);
        }

        public static string GetString(string id)
        {
            string strCurLanguage = "";

            try
            {
                ResourceManager rm = new ResourceManager("WindowsFormsApplication1.Properties.Resource", 
                    Assembly.GetExecutingAssembly());
                CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                strCurLanguage = rm.GetString(id, ci);
            }
            catch (Exception ex)
            {
                strCurLanguage = "No id:" + id + ", please add.";
            }

            return strCurLanguage;
        }
    }

}
