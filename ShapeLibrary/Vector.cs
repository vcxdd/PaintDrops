using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public struct Vector
    {
        public float X { get; }
        public float Y { get; }

        public Vector(float x, float y)
        {
            if (float.IsNaN(x) || float.IsNaN(y)) throw new ArgumentException("NaN values not allowed");

            this.X = x;
            this.Y = y;
        }

        public Vector(Vector v)
        {
            this.X = v.X;
            this.Y = v.Y;
        }

        public static Double Magnitude(Vector v)
        {
            return Math.Sqrt((Math.Pow(v.X, 2) + Math.Pow(v.Y, 2)));
        }

        public static Vector Normalize(Vector v)
        {
            float length = (float)Magnitude(v);
            float x = v.X / length;
            float y = v.Y / length;

            return new Vector(x, y);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            float x = a.X + b.X;
            float y = a.Y + b.Y;

            return new Vector(x, y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            float x = a.X + -(b.X);
            float y = a.Y + -(b.Y);

            return new Vector(x, y);
        }

        public static Vector operator *(Vector v, float scalar)
        {
            if (float.IsNaN(scalar)) throw new ArgumentException("NaN values not allowed");

            float x = v.X * scalar;
            float y = v.Y * scalar;

            return new Vector(x, y);
        }

        public static Vector operator *(Vector v, int scalar)
        {
            float x = v.X * scalar;
            float y = v.Y * scalar;

            return new Vector(x, y);
        }

        public static Vector operator /(Vector v, float scalar)
        {
            if (float.IsNaN(scalar)) throw new ArgumentException("NaN values not allowed");
            if(scalar == 0) throw new ArgumentException("Cannot divide by 0");

            float x = v.X / scalar;
            float y = v.Y / scalar;

            return new Vector(x, y);
        }

        public static Vector operator /(Vector v, int scalar)
        {
            float x = v.X / (float)scalar;
            float y = v.Y / (float)scalar;

            return new Vector(x, y);
        }

        public override String ToString()
        {
            return $"({this.X},{this.Y})";
        }
    }
}
