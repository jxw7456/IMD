using System;
//JaJuan Webster
//Professor Cascioli
//Basic Collision Detection

namespace Webster_BasicCollisionDetection
{
    class Circle
    {
        private float x;
        private float y;
        private float radius;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Circle(float x2, float y2, float radi)
        {
            x = x2;
            y = y2;
            radius = radi;
        }

        public bool Intersects(Circle other)
        {
            double result = Math.Sqrt((x * x) + (y * y));
            radius = (float)result;
            double result2 = Math.Sqrt((other.x * other.x) + (other.y * other.y));
            other.radius = (float)result2;
            double distance = Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
            if (distance > (radius + other.radius))
            {
                return false;
            }
            else
            {
                return true;
            }            
        }
    }
}
