using System;
using System.Collections.Generic;
using System.Globalization;

namespace KVector.Vector
{
    public class Vector : BaseVector,IEquatable<Vector>, IFormattable
    {
        public int X
        {
            get { return Coordinates[0]; }
            set { Coordinates[0] = value; }
        }

        public int Y
        {
            get { return Coordinates[1]; }
            set { Coordinates[1] = value; }
        }

        public int Z
        {
            get { return Coordinates[2]; }
            set { Coordinates[2] = value; }
        }

        public double Length
        {
            get
            {
                double sum = 0;
                foreach (var coordinate in Coordinates)
                {
                    sum += Math.Pow(coordinate, 2);
                }
                return Math.Round(Math.Sqrt(sum), 2);
            }
        }

        public Vector() : this(0, 0, 0)
        {
        }

        public Vector(int x, int y, int z) : base(new [] {x, y, z})
        {
        }

        public static Vector operator +(Vector firstVector, Vector secondVector)
        {
            var result = Addition(new List<BaseVector>() {firstVector, secondVector}, 3);
            return new Vector(result.Coordinates[0], result.Coordinates[1], result.Coordinates[2]);
        }

        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            var result = Subtraction(new List<BaseVector>() { firstVector, secondVector }, 3);
            return new Vector(result.Coordinates[0], result.Coordinates[1], result.Coordinates[2]);
        }

        public static double operator *(Vector firstVector, Vector secondVector)
        {
            return Multiply(new List<BaseVector>(){firstVector,secondVector},3 );
        }

        public Vector CrossProduct(Vector other)
        {
            return new Vector()
            {
                X = Coordinates[1] * other.Coordinates[2] -
                    Coordinates[2] * other.Coordinates[1],
                Y = 0 - (Coordinates[0] * other.Coordinates[2] -
                         Coordinates[2] * other.Coordinates[0]),
                Z = Coordinates[0] * other.Coordinates[1] -
                    Coordinates[1] * other.Coordinates[0],
            };
        }

        public double TripleProduct(Vector secondVector, Vector thirdVector)
        {
            return Coordinates[0] * secondVector.Coordinates[1] * thirdVector.Coordinates[2] +
                   Coordinates[1] * secondVector.Coordinates[2] * thirdVector.Coordinates[0] +
                   Coordinates[2] * secondVector.Coordinates[0] * thirdVector.Coordinates[1] -
                   Coordinates[2] * secondVector.Coordinates[1] * thirdVector.Coordinates[0] -
                   Coordinates[1] * secondVector.Coordinates[0] * thirdVector.Coordinates[2] -
                   Coordinates[0] * secondVector.Coordinates[2] * thirdVector.Coordinates[1];
        }

        public double AngleBetweenVectors(Vector other)
        {
            return Math.Round((this * other) /(Length* other.Length),2);
        }

        public bool Equals(Vector other)
        {
            if (other != null && (X == other.X && Y == other.Y && Z == other.Z))
            {
                return true;
            }
                return false;
        }

        public override string ToString()
        {
            return ToString("",CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"X={X}, Y={Y}, Z={Z}";
        }
    }
}
