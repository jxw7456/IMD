//JaJuan Webster
//Professor Cascioli
//Basic Collision Detection

namespace Webster_BasicCollisionDetection
{
    class AABB
    {
        private float x;
        private float y;
        private float width;
        private float height;

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

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public float MinX
        {
            get { return x; }
        }

        public float MinY
        {
            get { return y; }
        }

        public float MaxX
        {
            get { return x + width; }
        }

        public float MaxY
        {
            get { return y + height; }
        }

        public AABB(float x2, float y2, float wid, float heig)
        {
            x = x2;
            y = y2;
            width = wid;
            height = heig;
        }

        public bool Intersects(AABB other)
        {
            if (MaxX < other.MinX)
            {
                return false;
            }

            if (MinX > other.MaxX)
            {
                return false;
            }

            if (MinY < other.MaxY)
            {
                return false;
            }

            if (MaxY > other.MinY)
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
