using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    namespace Engine
    {
        abstract class Vector
        {
            public abstract void Scale(float scale);

            public abstract float Length();

            public abstract Vector Normalize();

            public abstract float Scalar(Vector Other);

            public float Angle(Vector other)
            {
                return (float)Math.Acos(Scalar(other) / (Length() * other.Length()));
            }
        }
    }
}
