using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using csLTDMC;
using HuaTianProject.Entity.Paint;

namespace HuaTianProject.Test
{
    public partial class test : Form
    {
        private double vectorChabu = FormMain.HomeSpeed;

        private static int width = 100;

        private static int height = 100;

        private Bitmap bitmap;
        private Graphics g;

        public test()
        {
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
        }

        private void DrawMarkPoint(Graphics g, double x, double y, string txt)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            float nx = 2000f / 80f;
            float ny = 2000f / 80f;
            float _x = (float)(x / nx + width / 2);
            float _y = (float)(y / ny + height / 3);
            g.FillEllipse(new SolidBrush(Color.Blue), new RectangleF(_x - 2f, _y - 2f, 4f, 4f));
            //
            Matrix matrix = g.Transform;
            g.ResetTransform();
            g.DrawString(txt, this.Font, new SolidBrush(Color.Blue), _x, height - _y);
            g.Transform = matrix;
        }

        private void DrawPosImage()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            //
            Bitmap bm = new Bitmap(width, height);
            //
            Graphics g = Graphics.FromImage(bm);
            Matrix matrix = new Matrix(1, 0, 0, -1, 0, height);
            g.Transform = matrix;
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            ////网格绘制
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, new Point(0, height / 3), new Point(width, height / 3));
            g.DrawLine(pen, new Point(width / 2, 0), new Point(width / 2, height));
            //
            SolidBrush brush = new SolidBrush(Color.Black);
            g.ResetTransform();
            g.DrawString("0", this.Font, brush, width / 2 + 5, height * 2 / 3 + 5);
            g.Transform = matrix;
            DrawMarkPoint(g, -3000, 3000, "A");
            DrawMarkPoint(g, 1000, 6000, "B");
            DrawMarkPoint(g, 2000, 6000, "C");
            DrawMarkPoint(g, 3000, 6000, "D");
            DrawMarkPoint(g, 4000, 0, "E");
            g.Dispose();
            pictureBox1.Image = bm;
        }

        private void DrawLine()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            //
            Bitmap bm = new Bitmap(width, height);
            //
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(width / 3, height / 3);
            Point B = new Point(width * 2 / 3, height / 3);
            Point C = new Point(width * 5 / 6, height / 3 + width / 6);
            Point D = new Point(width * 5 / 6, height * 5 / 6);
            Pen penRed = new Pen(Color.Red, 2);
            g.DrawLine(penRed, A, B);
            //  g.DrawEllipse(penRed,);
            //    Rectangle myrec = new Rectangle(width / 6, width / 6, width / 6, width / 6);
            //   g.DrawLine(penRed,B ,C );
            g.DrawArc(pen, width * 1 / 2, height / 3, width / 3, width / 3, 0, -90);
            g.DrawLine(penRed, C, D);
            g.DrawLine(penRed, D, A);
            g.Dispose();
            pictureBox1.BackgroundImage = bm;
            pictureBox1.Refresh();
        }

        private void DrawLine2()
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            //
            Bitmap bm = new Bitmap(width, height);
            //
            Graphics g = Graphics.FromImage(bm);
            Pen pen = new Pen(Color.Black, 4);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(10, 10);
            Point B = new Point(50, 10);
            Point C = new Point(70, 30);
            Point D = new Point(70, 70);
            Pen penRed = new Pen(Color.Red, 4);
            g.DrawLine(penRed, A, B);
            //  g.DrawEllipse(penRed,);
            //    Rectangle myrec = new Rectangle(width / 6, width / 6, width / 6, width / 6);
            //   g.DrawLine(penRed,B ,C );
            g.DrawArc(penRed, 30, 10, 40, 40, 0, -90);
            // g.DrawArc(penRed,  20, 20, 100, 100, 100, 360);

            g.DrawLine(penRed, C, D);
            g.DrawLine(penRed, D, A);
            //DrawMarkPoint(g, width / 3,height / 3,"A");
            //DrawMarkPoint(g, width * 2 / 3,height / 3, "B");
            //DrawMarkPoint(g, width * 5 / 6, height / 3 + width / 6, "C");
            //DrawMarkPoint(g, width * 5 / 6, height * 5 / 6, "D");
            g.Dispose();
            pictureBox1.Image = bm;
        }

        private void btnDrawing_Click(object sender, EventArgs e)
        {
            //  Round(this.Region);
            DrawLine();
            //  DrawPosImage1();
            //    DrawPosImage();

        }

        private void StumpProgramForm_Paint(object sender, PaintEventArgs e)
        {
            //DrawLine();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Line line = new Line();
            
            /*line.StartPoint = new Point(100, 200);
            line.EndPoint = new Point(200, 200);
            line.Draw(pictureBox1);

            line.StartPoint = new Point(200, 300);
            line.EndPoint = new Point(100, 300);
            line.Draw(pictureBox1);*/

            //A
            g = Graphics.FromImage(bitmap);
            line.Draw(ref g);
            pictureBox1.BackgroundImage = bitmap;
            pictureBox1.Refresh();

            //B
            g = Graphics.FromImage(bitmap);
            g.DrawLine(new Pen(Color.Aqua, 2), 300, 100, 100, 200);
            pictureBox1.BackgroundImage = bitmap;
            pictureBox1.Refresh();

            //line.Load();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            int width = 700, hight = 700;
            Bitmap image = new Bitmap(width, hight);
            Graphics g = Graphics.FromImage(image);  //创建画布
            try
            {
                g.Clear(Color.YellowGreen);   //清空背景色
                Font font1 = new Font("宋体", 12);   //设置字体类型和大小
                Brush brush = new SolidBrush(Color.Blue);  //设置画刷颜色
                Pen pen = new Pen(Color.Blue, 1);  //创建画笔对象
                g.DrawString("GDI+绘制圆形", font1, brush, 40, 20);
                g.DrawEllipse(pen, 10, 10, 550, 550);  //绘制圆形
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                pictureBox1.Image = image;
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void cbxMotionTrail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMotionTrail.SelectedIndex == 0)
            {
                DrawMotionTrail1();
            }
            if (cbxMotionTrail.SelectedIndex == 1)
            {
                DrawMotionTrail2();
            }
            if (cbxMotionTrail.SelectedIndex == 2)
            {
                DrawMotionTrail3();
            }
            if (cbxMotionTrail.SelectedIndex == 3)
            {
                DrawMotionTrail4();
            }
        }
        private void DrawMotionTrail1()
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(width / 3, height / 3);
            Point B = new Point(width * 2 / 3, height / 3);
            Point C = new Point(width * 5 / 6, height / 3 + width / 6);
            Point D = new Point(width * 5 / 6, height * 5 / 6 - 50);
            Pen penRed = new Pen(Color.Red, 2);
            //g.DrawLine(penRed, A, B);
            g.DrawArc(pen, width * 1 / 2, height / 3, width / 3, width / 3, 0, -90);
           // g.DrawLine(penRed, C, D);
            g.DrawLine(penRed, D, A);
            Line line = new Line();
            line.StartPoint = C;
            line.EndPoint = D;
            line.Draw(pictureBox1);
            Line line1 = new Line();
            line1.StartPoint = A;
            line1.EndPoint = B;
            line1.Draw(pictureBox1);
            //DrawMarkPoint(g, width / 3,     height / 3,"A");
            //DrawMarkPoint(g, width * 2 / 3, height / 3, "B");
            //DrawMarkPoint(g, width * 5 / 6, height / 3 + width / 6, "C");
            //DrawMarkPoint(g, width * 5 / 6, height * 5 / 6, "D");
            g.Dispose();
            pictureBox1.Image = bm;
        }
        private void DrawMotionTrail2()
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(width / 3, height / 3);
            Point B = new Point(width * 2 / 3, height / 3);
            Point C = new Point(width * 5 / 6, height / 3 + width / 6);
            Point D = new Point(width * 5 / 6, height * 5 / 6 + 50);
            Pen penRed = new Pen(Color.Red, 2);
            g.DrawLine(penRed, A, B);
            g.DrawArc(pen, width * 1 / 2, height / 3, width / 3, width / 3, 0, -90);
            g.DrawLine(penRed, C, D);
            g.DrawLine(penRed, D, A);
            //DrawMarkPoint(g, width / 3,     height / 3,"A");
            //DrawMarkPoint(g, width * 2 / 3, height / 3, "B");
            //DrawMarkPoint(g, width * 5 / 6, height / 3 + width / 6, "C");
            //DrawMarkPoint(g, width * 5 / 6, height * 5 / 6, "D");
            g.Dispose();
            pictureBox1.Image = bm;
        }
        private void DrawMotionTrail3()
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(width / 3 - 10, height / 3);
            Point B = new Point(width * 2 / 3, height / 3);
            Point C = new Point(width * 5 / 6, height / 3 + width / 6);
            Point D = new Point(width * 5 / 6, height * 5 / 6);
            Pen penRed = new Pen(Color.Red, 2);
            g.DrawLine(penRed, A, B);
            g.DrawArc(pen, width * 1 / 2, height / 3, width / 3, width / 3, 0, -90);
            g.DrawLine(penRed, C, D);
            g.DrawLine(penRed, D, A);
            //DrawMarkPoint(g, width / 3,     height / 3,"A");
            //DrawMarkPoint(g, width * 2 / 3, height / 3, "B");
            //DrawMarkPoint(g, width * 5 / 6, height / 3 + width / 6, "C");
            //DrawMarkPoint(g, width * 5 / 6, height * 5 / 6, "D");
            g.Dispose();
            pictureBox1.Image = bm;
        }
        private void DrawMotionTrail4()
        {
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(0, 0), new Point(width, 0));
            g.DrawLine(pen, new Point(width, 0), new Point(width, height));
            g.DrawLine(pen, new Point(width, height), new Point(0, height));
            g.DrawLine(pen, new Point(0, height), new Point(0, 0));
            Point A = new Point(width / 3 + 10, height / 3);
            Point B = new Point(width * 2 / 3, height / 3);
            Point C = new Point(width * 5 / 6, height / 3 + width / 6);
            Point D = new Point(width * 5 / 6, height * 5 / 6 + 50);
            Pen penRed = new Pen(Color.Red, 2);
            g.DrawLine(penRed, A, B);
            g.DrawArc(pen, width * 1 / 2, height / 3, width / 3, width / 3, 0, -90);
            g.DrawLine(penRed, C, D);
            g.DrawLine(penRed, D, A);
            //DrawMarkPoint(g, width / 3,     height / 3,"A");
            //DrawMarkPoint(g, width * 2 / 3, height / 3, "B");
            //DrawMarkPoint(g, width * 5 / 6, height / 3 + width / 6, "C");
            //DrawMarkPoint(g, width * 5 / 6, height * 5 / 6, "D");
            g.Dispose();
            pictureBox1.Image = bm;
        }
    }
}
