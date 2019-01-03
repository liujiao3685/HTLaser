using System.Drawing;
using System.Windows.Forms;
using HuaTianProject.Core;

namespace HuaTianProject.Entity.Paint
{
    /// <summary>
    /// 轨迹图基类
    /// </summary>
    public abstract class TrajectoryChatBase
    {
        /// <summary>
        /// 画笔
        /// </summary>
        public Pen Pen;

        /// <summary>
        /// 轨迹类型
        /// </summary>
        public string TrackType;

        /// <summary>
        /// 轨迹图配置文件保存路径
        /// </summary>
        public string SavePath;

        /// <summary>
        /// 矩形
        /// </summary>
        public Rectangle Rectangle;

        /// <summary>
        /// 画轨迹-1
        /// </summary>
        /// <param name="pictureBox">PictureBox控件</param>
        public abstract void Draw(PictureBox pictureBox);

        /// <summary>
        /// 画轨迹-2
        /// </summary>
        /// <param name="graphics">GDI</param>
        public abstract void Draw(ref Graphics graphics);

        /// <summary>
        /// 保存轨迹图
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// 加载轨迹图
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// 将字符转成Point对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public abstract Point StringToPoint(string str);

        protected TrajectoryChatBase()
        {
            Pen = new Pen(Color.Blue, 2);
            TrackType = "Line";
            SavePath = XmlHelperPaint.XmlSavePath;
            Rectangle = new Rectangle(0, 0, 100, 100);
        }

    }
}
