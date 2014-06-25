using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDefense
{
    namespace Engine
    {
        class Vector2f : Vector
        {
            public float X { get; set; }
            public float Y { get; set; }

            public Vector2f(float x, float y)
            {
                X = x;
                Y = y;
            }

            public Vector2f() : this(0, 0) { }

            public Vector2f(Vector2f clone) : this(clone.X, clone.Y) { }

            public Vector2f(Vector2f clone, float scale) :
                this(clone.X * scale, clone.Y * scale) { }

            public override void Scale(float scale)
            {
                X *= scale;
                Y *= scale;
            }

            public override float Length()
            {
                return (float)Math.Sqrt(X * X + Y * Y);
            }

            public override Vector Normalize()
            {
                return new Vector2f(this, 1 / Length());
            }

            public override float Scalar(Vector other)
            {
                if(other is Vector2f)
                    return X * (other as Vector2f).X + Y * (other as Vector2f).Y;
                return 0;
            }
        }
    }
}
