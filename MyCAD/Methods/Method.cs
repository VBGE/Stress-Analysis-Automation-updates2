using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MyCAD.Entities;

namespace MyCAD.Methods
{
    public static class Method
    {
        public static double LineAngle(Vector3 start, Vector3 end)
        {
            double angle = Math.Atan2((end.Y - start.Y), (end.X - start.X)) * 180.0 / Math.PI;
            if (angle < 0.0) angle += 360;
            return angle;
        }

        public static Vector3 LineLineIntersection(Entities.Line line1, Entities.Line line2, bool extended = false)
        {
            Vector3 result;
            Vector3 p1 = line1.StartPoint;
            Vector3 p2 = line1.EndPoint;
            Vector3 p3 = line2.StartPoint;
            Vector3 p4 = line2.EndPoint;

            double dx12 = p2.X - p1.X;
            double dy12 = p2.Y - p1.Y;
            double dx34 = p4.X - p3.X;
            double dy34 = p4.Y - p3.Y;

            double denominator = (dy12 * dx34 - dx12 * dy34);
            double k1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;

            if (double.IsInfinity(k1))
                return new Vector3(double.NaN, double.NaN);

            result = new Vector3(p1.X + dx12 * k1, p1.Y + dy12 * k1);

            if (extended)
                return result;
            else
            {
                if (IsPointOnLine(line1, result) && IsPointOnLine(line2, result))
                    return result;
                else
                    return new Vector3(double.NaN, double.NaN);
            }

        }
        private static bool IsPointOnLine(Line line1, Vector3 point)
        {
            return IsEqual(line1.Length, line1.StartPoint.DistanceFrom(point)+line1.EndPoint.DistanceFrom(point));
        }
        public static double Epsilon = 1e-12;
        private static bool IsEqual(double d1, double d2)
        {
            return IsEqual(d1, d2, Epsilon);
        }
        public static bool IsEqual(double d1, double d2, double epsilon)
        {
            return IsZero(d1 - d2, epsilon);
        }
        public static bool IsZero(double d, double epsilon)
        {
            return d >= -epsilon && d <= epsilon;
        }
        public static Bitmap SetCursor(int index, float size, Color color)
        {
            Bitmap bmp = new Bitmap((int)size + 1, (int)size + 1);
            float cx = size / 2;
            float cy = size / 2;
            PointF[] points;

            using(Graphics gr = Graphics.FromImage(bmp))
            {
                gr.Clear(Color.Transparent);
                switch (index)
                {
                    case 0: //default cursor
                        break;
                    case 1: // drawing cursor
                        points = new PointF[]
                        {
                            new PointF(cx,0),
                            new PointF(2*cx, cy),
                            new PointF(cx, 2*cy),
                            new PointF(0, cy)
                        };
                        gr.DrawLine(new Pen(color, 2.0f), points[0], points[2]);
                        gr.DrawLine(new Pen(color, 2.0f), points[1], points[3]);
                        break;
                    case 2: //editing cursor
                        points = new PointF[]
                        {
                            new PointF(1,1),
                            new PointF(2*cx-1,1),
                            new PointF(2*cx-1, 2*cy-1),
                            new PointF(1, 2*cy-1)
                        };

                        gr.DrawPolygon(new Pen(color, 2.0f), points);
                        break;
                }
                return bmp;
            }
        }

        public static double DistanceFromLine(Line line, Vector3 point, out Vector3 closest, bool IsExtended = false)
        {
            double x1 = line.StartPoint.X;
            double y1 = line.StartPoint.Y;
            double x2 = line.EndPoint.X;
            double y2 = line.EndPoint.Y;

            double x = point.X;
            double y = point.Y;

            double dx = x2 - x1;
            double dy = y2 - y1;

            if((dx == 0) && (dy == 0))
            {
                closest = line.StartPoint;
                dx = x - x1;
                dy = y - y1;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            double k = ((x - x1) * dx + (y - y1) * dy) / (dx * dx + dy * dy);

            closest = new Vector3(x1 + k * dx, y1 + k * dy);
            dx = x - closest.X;
            dy = y - closest.Y;

            if (!IsExtended)
            {
                if (k < 0)
                {
                    closest = new Vector3(x1, y1);
                    dx = x - x1;
                    dy = y - y1;
                }
                else if (k > 1)
                {
                    closest = new Vector3(x2, y2);
                    dx = x - x2;
                    dy = y - y2;
                }
            }
            return Math.Sqrt(dx * dx + dy * dy);

        }
        
        #region Get entity index
        public static bool IsMouseOnEntity(List<EntityObject> entities, Vector3 mousePosition, PointF[] cursor_rect, out int index)
        {
            Vector3 poSegment = new Vector3();

            for (int i = 0; i < entities.Count; i++)
            {
                switch (entities[i].Type)
                {
                    case EntityType.Line:
                        double d = DistanceFromLine(entities[i] as Line, mousePosition, out poSegment);
                        break;
                    case EntityType.Point:
                        poSegment = (entities[i] as Entities.Point).Position;
                        break;
                }
                if (IsPointInPolyline(cursor_rect, poSegment))
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        #endregion

        private static bool IsPointInPolyline(PointF[] rect, Vector3 point)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddPolygon(rect);
            return path.IsVisible(point.ToPointF);
        }
        
        public static void ModifySelection(int modifyIndex, List<EntityObject> entities, Vector3 fromPoint, Vector3 toPoint)
        {
            for(int i=0; i< entities.Count(); i++)
            {
                if (entities[i].IsSelected)
                {
                    switch (modifyIndex)
                    {
                        case 0: //Copy
                            entities.Add(entities[i].CopyOrMove(fromPoint, toPoint) as EntityObject);
                            break;
                        case 1: //Move
                            entities.Add(entities[i].CopyOrMove(fromPoint, toPoint) as EntityObject);
                            entities[i].DeSelect();
                            break;
                    }
                }
            }
        }
    }
}
