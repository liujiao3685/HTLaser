using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using HuaTianProject.Core;

namespace HuaTianProject.Entity.Paint
{
    public class Line : TrajectoryChatBase
    {
        /// <summary>
        /// 直线起始点
        /// </summary>
        public Point StartPoint { set; get; }

        /// <summary>
        /// 直线终止点
        /// </summary>
        public Point EndPoint { set; get; }

        private Bitmap m_bitmap;

        public Dictionary<string, string> MDictionary;

        public Line()
        {
            TrackType = "Line";
            XmlHelperPaint.XmlSavePath = Application.StartupPath + @"\" + TrackType + ".xml";
            MDictionary = new Dictionary<string, string>();
        }

        public override void Draw(PictureBox pb)
        {
            m_bitmap = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(m_bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(this.Pen, this.StartPoint, this.EndPoint);
            g.Dispose();
            pb.BackgroundImage = m_bitmap;
            pb.Refresh();
        }

        public override void Draw(ref Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(this.Pen, this.StartPoint, this.EndPoint);
            g.Dispose();
        }

        public override void Save()
        {
            MDictionary.Clear();
            XmlHelperPaint.ShapeType = TrackType;

            MDictionary.Add("StartPoint", string.Join(",", StartPoint.X, StartPoint.Y));
            MDictionary.Add("EndPoint", string.Join(",", EndPoint.X, EndPoint.Y));
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
                        StartPoint = StringToPoint(item.Value);
                        break;
                    case 1:
                        EndPoint = StringToPoint(item.Value);
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
