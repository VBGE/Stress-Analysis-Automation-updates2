using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCAD
{
    public class Vector3
    {
        private double x = 0.0;
        private double y = 0.0;
        private double z = 0.0;
                         
        public Vector3(double x = 0.0, double y = 0.0)
        {
            this.X = x;
            this.Y = y;
            this.z = 0.0;
        }

        public Vector3(double x, double y, double z)
            : this(x,y)
        {
            this.Z = z;
        }
        
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public static Vector3 UnitX
        {
            get { return new Vector3(1, 0, 0); }
        }

        public static Vector3 UnitY
        {
            get { return new Vector3(0, 1, 0); }
        }

        public static Vector3 UnitZ
        {
            get { return new Vector3(0, 0, 1); }
        }

        public static Vector3 NaN
        {
            get { return new Vector3(double.NaN, double.NaN, double.NaN); }
        }

        public double this[int index]
        {
            get
            {
                switch(index)
                {
                    case 0:
                        return this.x;
                    case 1:
                        return this.y;
                    case 2:
                        return this.z;
                    default:
                        throw (new ArgumentOutOfRangeException(nameof(index)));
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.x = value;
                        break;
                    case 1:
                        this.y = value;
                        break;
                    case 2:
                        this.z = value;
                        break;
                    default:
                        throw (new ArgumentOutOfRangeException(nameof(index)));
                }
            }
        }

        public static double DotProduct(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static Vector3 CrossProduct(Vector3 v1, Vector3 v2)
        {
            double vx = v1.Y * v2.Z - v1.Z * v2.Y;
            double vy = v1.Z * v2.X - v1.X * v2.Z;
            double vz = v1.X * v2.Y - v1.Y * v2.X;
            return new Vector3(vx, vy, vz);
        }

        public Vector3 Round(int numDigits)
        {
            return new Vector3(
                Math.Round(this.X, numDigits), 
                Math.Round(this.y, numDigits), 
                Math.Round(this.z, numDigits));
        }

        public void Normalize()
        {
            double m = Modulus();
            if (Methods.Method.IsZero(m, Methods.Method.Epsilon))
                throw new ArithmeticException("Cannot normalize a zero vector");
            double m_inv = 1 / m;
            this.x *= m_inv;
            this.y *= m_inv;
            this.z *= m_inv;
        }

        public double Modulus()
        {
            return Math.Sqrt(DotProduct(this, this));
        }

        public double AngleWith(Vector3 v)
        {
            double angle = Math.Atan2((v.Y - this.y), (v.X - this.x)) * 180.0 / Math.PI;
            if (angle < 0)
                angle += 360.0;
            return angle;
        }

        public bool Equals(Vector3 v, double threshold)
        {
            return (Methods.Method.IsEqual(v.X, this.x, threshold) && 
                Methods.Method.IsEqual(v.Y, this.y, threshold) && 
                Methods.Method.IsEqual(v.Z, this.z, threshold));
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3)
                return this.Equals((Vector3)obj, Methods.Method.Epsilon);
            return false;
        }

        public System.Drawing.PointF ToPointF
        {
            get
            {
                return new System.Drawing.PointF((float)X, (float)Y);
            }
        }

        public static Vector3 Zero
        {
            get { return new Vector3(0.0, 0.0, 0.0); }
        }

        public double DistanceFrom(Vector3 v)
        {
            double dx = v.X - X;
            double dy = v.Y - Y;
            double dz = v.Z - Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public Vector3 CopyOrMove(Vector3 fromPoint, Vector3 toPoint)
        {
            double dx = toPoint.X - fromPoint.X;
            double dy = toPoint.Y - fromPoint.Y;
            double dz = toPoint.Z - fromPoint.Z;

            return new Vector3(this.x + dx, this.y + dy, this.z + dz);
        }

        public static Vector3 GetUnitVector(Vector3 startP, Vector3 endP)
        {
            double d = GetDistanceBetweenPoints(startP, endP);
            double ux = (endP.X - startP.X) / d;
            double uy = (endP.Y - startP.Y) / d;
            double uz = (endP.Z - startP.Z) / d;
            return new Vector3(ux, uy, uz);
        }

        public static Vector3 GetTranslatedPoint(Vector3 point, double translation1, double translation2, double translation3)
        {
            double x = point.X + translation1;
            double y = point.Y + translation2;
            double z = point.Z + translation3;
            return new Vector3(x, y, z);
        }

        public static double GetDistanceBetweenPoints(Vector3 startPoint, Vector3 endPoint)
        {
            double dx = endPoint.X - startPoint.X;
            double dy = endPoint.Y - startPoint.Y;
            double dz = endPoint.Z - startPoint.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

    }
}
