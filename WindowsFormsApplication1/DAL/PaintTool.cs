using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GDIPaint
{
    public class PaintTool
    {
        // 圆角代码
        public void PaintBead(Region region, Graphics g)
        {
            if (region == null) throw new ArgumentNullException("region");
            GraphicsPath oPath = new GraphicsPath();
            int x = 0;
            int y = 0;
            int thisWidth = 60;
            int thisHeight = 60;
            int angle = 60;
            if (angle > 0)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                oPath.AddArc(x, y, angle, angle, 180, 90);                                 // 左上角
                oPath.AddArc(thisWidth - angle, y, angle, angle, 270, 90);                 // 右上角
                oPath.AddArc(thisWidth - angle, thisHeight - angle, angle, angle, 0, 90);  // 右下角
                oPath.AddArc(x, thisHeight - angle, angle, angle, 90, 90);                 // 左下角
                oPath.CloseAllFigures();
                region = new Region(oPath);
            }
            else
            {
                oPath.AddLine(x + angle, y, thisWidth - angle, y);                         // 顶端
                oPath.AddLine(thisWidth, y + angle, thisWidth, thisHeight - angle);        // 右边
                oPath.AddLine(thisWidth - angle, thisHeight, x + angle, thisHeight);       // 底边
                oPath.AddLine(x, y + angle, x, thisHeight - angle);                        // 左边
                oPath.CloseAllFigures();
                region = new Region(oPath);
            }
        }
    }
}
