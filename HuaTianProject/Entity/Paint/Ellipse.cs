using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using HuaTianProject.Core;

namespace HuaTianProject.Entity.Paint
{
    public class Ellipse : TrajectoryChatBase
    {
        /// <summary>
        /// 圆弧、扇形起始角度
        /// </summary>
        public float StartAngle { set; get; }

        /// <summary>
        /// 圆弧、扇形停止角度
        /// </summary>
        public float EndAngle { set; get; }

        private Bitmap m_bitmap;

        public Dictionary<string, string> MDictionary;

        public Ellipse()
        {
            TrackType = "Ellipse";
            XmlHelperPaint.XmlSavePath = Application.StartupPath + @"\" + TrackType + ".xml";
            MDictionary = new Dictionary<string, string>();
        }

        public override void Draw(PictureBox pb)
        {
            m_bitmap = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(m_bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawEllipse(this.Pen, this.Rectangle);
            g.Dispose();
            pb.BackgroundImage = m_bitmap;
            pb.Refresh();
        }

        public override void Draw(ref Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawEllipse(this.Pen, this.Rectangle);
            graphics.Dispose();
        }

        /// <summary>
        /// 画圆弧
        /// </summary>
        /// <param name="graphics"></param>
        public void DrawPie(ref Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawArc(this.Pen, this.Rectangle, StartAngle, EndAngle);
            graphics.Dispose();
        }

        public override void Save()
        {
            MDictionary.Clear();
            XmlHelperPaint.ShapeType = TrackType;

            MDictionary.Add("RecX", Rectangle.X.ToString());
            MDictionary.Add("RecY", Rectangle.Y.ToString());
            MDictionary.Add("RecW", Rectangle.Width.ToString());
            MDictionary.Add("RecH", Rectangle.Height.ToString());
            MDictionary.Add("StartAngle", StartAngle.ToString());
            MDictionary.Add("EndAngle", EndAngle.ToString());
            XmlHelperPaint.SavePaintSetting(MDictionary);
        }

        public override void Load()
        {
            SavePath = XmlHelperPaint.XmlSavePath;
            MDictionary = XmlHelperPaint.LoadPaintSetting();
            int i = 0;
            foreach (var item in MDictionary)
            {
                switch (i)
                {
                    case 0:
                        Rectangle.X = Convert.ToInt32(item.Value);
                        break;
                    case 1:
                        Rectangle.Y = Convert.ToInt32(item.Value);
                        break;
                    case 2:
                        Rectangle.Width = Convert.ToInt32(item.Value);
                        break;
                    case 3:
                        Rectangle.Height = Convert.ToInt32(item.Value);
                        break;
                    case 4:
                        StartAngle = Convert.ToInt32(item.Value);
                        break;
                    case 5:
                        EndAngle = Convert.ToInt32(item.Value);
                        break;
                }
                i++;
            }

        }

        public override Point StringToPoint(string spoint)
        {
            Point point = new Point();
            if (!String.IsNullOrEmpty(spoint))
            {
                string[] points = spoint.Split(',');
                point.X = Convert.ToInt32(points[0]);
                point.Y = Convert.ToInt32(points[1]);
            }
            return point;
        }
    }
}
