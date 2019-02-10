using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using GDIPaint;

namespace WindowsFormsApplication1
{
    public partial class PointForm : Form
    {
        private int startX = 0;

        private int startY = 0;

        private int endX = 0;

        private int endY = 0;

        private bool isDraw = false;

        private Pen pen = new Pen(Color.Blue, 2);

        private SolidBrush brush = new SolidBrush(Color.Blue);

        private Graphics g;

        private Bitmap bitmap;

        private Point startLocation = new Point(0, 0);

        private Point startPoint = new Point(0, 0);

        private Point point2 = new Point();
        private Point point3 = new Point();
        private Point point4 = new Point();

        private List<Point> m_listPoints = new List<Point>();

        private int count = 0;

        private string m_type;
        private int type = 0;
        private int m_radius = 50;//半径
        private Arc arc = null;

        private Dictionary<string, string> dictionary;

        public PointForm()
        {
            InitializeComponent();

            int width = this.pictureBox1.Width;
            int height = this.pictureBox1.Height;
            bitmap = new Bitmap(width, height);

            g = Graphics.FromImage(bitmap);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //减少闪烁  
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.SetStyle(ControlStyles.UserPaint, true);

            InitGraphics();

            dictionary = new Dictionary<string, string>();

            startPoint = startLocation = this.labstart.Location;
            startX = startPoint.X;
            startY = startPoint.Y;

            //g.DrawRectangle(pen, new Rectangle(169 / 2, 77 / 2, 200, 200));
            pictureBox1.Image = bitmap;

        }

        //GDI重绘时不闪烁,消除锯齿
        private void InitGraphics()
        {
            g.SmoothingMode = SmoothingMode.AntiAlias; //使绘图质量最高，即消除锯齿
            g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (count == 4)
            {
                count = 0;
            }
            count++;

            if (e.Button == MouseButtons.Left)
            {
                startPoint.X = startX = e.X;
                startPoint.Y = startY = e.Y;
                isDraw = true;

            }

            if (e.Button == MouseButtons.Right)
            {
                ClickDraw(e);
            }

            if (GetShapeType() == 1)
            {
                this.txt1.Text = String.Concat(startX, ",", startY);
            }
            else
            {
                SetTextPoint();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ClickDraw(e);
        }

        private void ClickDraw(MouseEventArgs e)
        {
            g = Graphics.FromImage(bitmap);
            InitGraphics();

            type = GetShapeType();
            switch (type)
            {
                case 0:
                    g.DrawLine(pen, startX, startY, e.X, e.Y);
                    break;
                case 1:
                    g.DrawEllipse(pen, startX - m_radius, startY - m_radius, 2 * m_radius, 2 * m_radius);
                    break;
                case 2:
                    DrawArc();
                    break;
                case 3:
                    DrawPie();
                    break;
            }
            pictureBox1.Image = bitmap;

            startX = e.X;
            startY = e.Y;
            endX = e.X;
            endY = e.Y;

        }

        private void DrawPie()
        {
            int width = Convert.ToInt32(txtWidth.Text.Trim());
            int height = Convert.ToInt32(txtHeight.Text.Trim());
            float sAngle = Convert.ToInt32(txtStartAngle.Text.Trim());
            float eAngle = Convert.ToInt32(txtEndAngle.Text.Trim());
            Rectangle rec = new Rectangle(startX - m_radius, startY - m_radius, width, height);
            g.DrawPie(pen, rec, sAngle, eAngle);
        }

        private void DrawArc()
        {
            int width = Convert.ToInt32(txtWidth.Text.Trim());
            int height = Convert.ToInt32(txtHeight.Text.Trim());
            float sAngle = Convert.ToInt32(txtStartAngle.Text.Trim());
            float eAngle = Convert.ToInt32(txtEndAngle.Text.Trim());
            Rectangle rec = new Rectangle(startX - m_radius, startY - m_radius, width, height);
            g.DrawArc(pen, rec, sAngle, eAngle);

            arc = new Arc();
            arc.StartAngle = sAngle;
            arc.EndAngle = eAngle;
            arc.Width = width;
            arc.Height = height;
        }

        private void DrawArc(Arc arc)
        {
            InitBitmap();
            InitGraphics();

            Rectangle rec = new Rectangle(arc.StartX - m_radius, arc.StartY - m_radius, arc.Width, arc.Height);
            g.DrawArc(pen, rec, arc.StartAngle, arc.EndAngle);

            g.Dispose();
            pictureBox1.Image = bitmap;
        }

        private void DrawEllipse(Point[] points)
        {
            InitBitmap();
            InitGraphics();
            int r = 50;
            g.DrawEllipse(pen, points[0].X, points[0].Y, 2 * r, 2 * r);
            g.Dispose();
            pictureBox1.Image = bitmap;

        }

        private void DrawRectangle(Point[] points)
        {
            InitBitmap();
            InitGraphics();

            g.DrawLine(pen, points[0], points[1]);
            g.DrawLine(pen, points[1], points[2]);
            g.DrawLine(pen, points[2], points[3]);
            g.DrawLine(pen, points[3], points[0]);
            g.Dispose();

            //pictureBox1.Invalidate();
            pictureBox1.Image = bitmap;
        }

        private int GetShapeType()
        {
            if (rabRectangle.Checked)
            {
                m_type = "Rectangle";
                return 0;
            }
            if (rabCircle.Checked)
            {
                m_type = "Ellipse";
                return 1;
            }
            if (rabArc.Checked)
            {
                m_type = "Arc";
                return 2;
            }
            if (rabPie.Checked)
            {
                //m_type = "Pie";
                return 3;
            }
            return 0;
        }

        private void SetTextPoint()
        {
            switch (count)
            {
                case 1:
                    startPoint.X = startX;
                    startPoint.Y = startY;
                    this.txt1.Text = String.Concat(startX, ",", startY);
                    break;
                case 2:
                    point2.X = startX;
                    point2.Y = startY;
                    this.txt2.Text = String.Concat(startX, ",", startY);
                    break;
                case 3:
                    point3.X = startX;
                    point3.Y = startY;
                    this.txt3.Text = String.Concat(startX, ",", startY);
                    break;
                case 4:
                    point4.X = startX;
                    point4.Y = startY;
                    this.txt4.Text = String.Concat(startX, ",", startY);
                    break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.txtCurPoint.Text = String.Concat(e.X, ",", e.Y);
        }

        //重绘
        private void button1_Click(object sender, EventArgs e)
        {
            InitBitmap();
            pictureBox1.Image = bitmap;
        }

        //解析
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "打开文件";
            dialog.Filter = "xml files(*.xml)|*.xml|All files(*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = Path.Combine(Application.StartupPath);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                XmlHelper.XmlSavePath = fileName;

                dictionary = XmlHelper.LoadPointSetting();
                m_type = XmlHelper.ShapeType;
                arc = new Arc();

                Point p;
                Point[] points = new Point[4];
                int i = 0;
                foreach (var item in dictionary)
                {
                    //圆弧
                    if (m_type == "Arc")
                    {
                        switch (i)
                        {
                            case 0:
                                arc.StartX = Convert.ToInt32(item.Value);
                                break;
                            case 1:
                                arc.StartY = Convert.ToInt32(item.Value);
                                break;
                            case 2:
                                arc.Width = Convert.ToInt32(item.Value);
                                break;
                            case 3:
                                arc.Height = Convert.ToInt32(item.Value);
                                break;
                            case 4:
                                arc.StartAngle = Convert.ToInt32(item.Value);
                                break;
                            case 5:
                                arc.EndAngle = Convert.ToInt32(item.Value);
                                break;
                        }
                        i++;
                    }
                    else
                    {
                        if (i == 4)
                        {
                            break;
                        }
                        p = new Point();
                        string value = item.Value;
                        p = StringToPoint(value);
                        m_listPoints.Add(p);
                        points[i] = p;
                        i++;
                    }
                }

                switch (m_type)
                {
                    case "Rectangle":
                        DrawRectangle(points);
                        break;
                    case "Ellipse":
                        DrawEllipse(points);
                        break;
                    case "Arc":
                        DrawArc(arc);
                        break;
                }

                ShowTextPoint(points);

                // MessageBox.Show("解析成功！");
            }
        }

        /// <summary>
        /// 初始化bitmap
        /// </summary>
        private void InitBitmap()
        {
            int width = this.pictureBox1.Width;
            int height = this.pictureBox1.Height;
            bitmap = new Bitmap(width, height);
            g = Graphics.FromImage(bitmap);
        }

        private void ShowTextPoint(Point[] points)
        {
            this.txt1.Text = String.Concat(points[0].X, ",", points[0].Y);
            this.txt2.Text = String.Concat(points[1].X, ",", points[1].Y);
            this.txt3.Text = String.Concat(points[2].X, ",", points[2].Y);
            this.txt4.Text = String.Concat(points[3].X, ",", points[3].Y);
        }

        private void SaveTextPoint()
        {
            m_listPoints.Add(StringToPoint(txt1.Text));
            m_listPoints.Add(StringToPoint(txt2.Text));
            m_listPoints.Add(StringToPoint(txt3.Text));
            m_listPoints.Add(StringToPoint(txt4.Text));
        }

        private Point StringToPoint(string spoint)
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

        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存文件";
            dialog.Filter = "xml files(*.xml)|*.xml|All files(*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.InitialDirectory = Path.Combine(Application.StartupPath);
            dialog.RestoreDirectory = true;//保存对话框是否记忆上次打开目录

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dictionary.Clear();
                m_listPoints.Clear();
                SaveTextPoint();

                XmlHelper.ShapeType = m_type;
                XmlHelper.XmlSavePath = dialog.FileName;
                if (m_type == "Arc")
                {
                    if (arc != null)
                    {
                        dictionary.Add("startX", startX.ToString());
                        dictionary.Add("startY", startY.ToString());
                        dictionary.Add("width", arc.Width.ToString());
                        dictionary.Add("height", arc.Height.ToString());
                        dictionary.Add("startAngle", arc.StartAngle.ToString());
                        dictionary.Add("endAngle", arc.EndAngle.ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < m_listPoints.Count; i++)
                    {
                        Point point = m_listPoints[i];
                        dictionary.Add("Point" + i, String.Join(",", point.X, point.Y));
                    }
                }

                bool result = XmlHelper.SavePointSetting(dictionary);
                if (result)
                {
                    MessageBox.Show("保存成功！");
                }
            }
        }

        private void MulationMove()
        {
            type = GetShapeType();
            InitBitmap();
            InitGraphics();
            Point endPoint = new Point(startX, startY + 60);
            Point endPoint2 = new Point(startX - 60, startY + 60);
            Point endPoint3 = new Point(startX - 60, startY);

            switch (type)
            {
                case 0:
                    g.DrawLine(pen, startPoint, endPoint);
                    g.DrawLine(pen, endPoint, endPoint2);
                    g.DrawLine(pen, endPoint2, endPoint3);
                    g.DrawLine(pen, endPoint3, startPoint);
                    break;
                case 1:
                    g.DrawEllipse(pen, startPoint.X, startPoint.Y, 2 * m_radius, 2 * m_radius);
                    break;
                case 2:
                    DrawArc();
                    break;
                case 3:
                    DrawPie();
                    break;
            }
            pictureBox1.Image = bitmap;
        }

        //模拟轨迹
        private void btnsimulation_Click(object sender, EventArgs e)
        {
            MulationMove();
        }


    }
}
