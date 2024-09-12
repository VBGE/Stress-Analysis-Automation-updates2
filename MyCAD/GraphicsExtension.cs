using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using MyCAD.Entities;

namespace MyCAD
{
    public static class GraphicsExtension
    {
        private static float Height;
        private static Pen extpen = new Pen(Color.Gray, 0);
        
        public static void SetParameters(this System.Drawing.Graphics g, float height)
        {
            Height = height;
            extpen.DashPattern = new float[] { 1.0f, 2.0f };
        }

        public static void SetTransform(this System.Drawing.Graphics g)
        {
            g.PageUnit = System.Drawing.GraphicsUnit.Millimeter;
            g.TranslateTransform(0, Height);
            g.ScaleTransform(1.0f, -1.0f);
        }

        public static void DrawPoint(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Point point)
        {
            g.SetTransform();
            System.Drawing.PointF p = point.Position.ToPointF;
            if (!point.IsSelected)
                g.DrawEllipse(pen, p.X - 1, p.Y - 1, 2, 2);
            else
                g.DrawEllipse(extpen, p.X - 1, p.Y - 1, 2, 2);
            g.ResetTransform();
        }

        public static void DrawLine(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Line line)
        {
            g.SetTransform();
            if(!line.IsSelected)
                g.DrawLine(pen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
            else
                g.DrawLine(extpen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
            g.ResetTransform();
        }

        public static void DrawEntity(this Graphics g, Pen pen, EntityObject entity)
        {
            switch (entity.Type)
            {
                case EntityType.Line:
                    g.DrawLine(pen, entity as Entities.Line);
                    break;
                case EntityType.Point:
                    g.DrawPoint(pen, entity as Entities.Point);
                    break;
            }
        }
    }
}
