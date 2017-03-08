using System;
//JaJuan Webster
//Professor Cascioli
//Basic Collision Detection

namespace Webster_BasicCollisionDetection
{
    class Circle
    {
        //Fields
        private float x;
        private float y;
        private float radius;

        //Get Set Properties for X, Y, and Radius
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

        //Constructor
        public Circle(float x2, float y2, float radi)
        {
            x = x2;
            y = y2;
            radius = radi;
        }

        //Checks if two circles are intersecting and returning a boolean
        public bool Intersects(Circle other)
        {
            double distance = Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
            if (distance > (radius + other.radius))
            {
                return false;
            }

            return true;
        }
    }
}
