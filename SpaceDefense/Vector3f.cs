using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    namespace Engine
    {
        class Vector3f
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }

            public Vector3f(float x, float y, float z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public Vector3f() : this(0, 0, 0) { }

            public Vector3f(Vector3f clone) : this(clone.X, clone.Y, clone.Z) { }

            public Vector3f(Vector3f clone, float scale) :
                this(clone.X * scale, clone.Y * scale, clone.Z * scale) { }

            public void Scale(float scale)
            {
                X *= scale;
                Y *= scale;
                Z *= scale;
            }

            public float Length()
            {
                return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            }

            public Vector3f Normalize()
            {
                return new Vector3f(this, 1 / Length());
            }

            public float Scalar(Vector3f other)
            {
                return X * other.X + Y * other.Y + Z * other.Z;
            }

            public float Angle(Vector3f other)
            {
                return Scalar(other) / (Length() * other.Length());
            }
        }
    }
}
