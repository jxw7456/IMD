//JaJuan Webster
//Professor Cascioli
//Basic Collision Detection

namespace Webster_BasicCollisionDetection
{
    class AABB
    {
        //Fields
        private float x;
        private float y;
        private float width;
        private float height;

        //Get Set Property for x, y, width, height
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

        //Get properties for MinX, MinY, MaxX, MaxY
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

        //Constructor
        public AABB(float x2, float y2, float wid, float heig)
        {
            x = x2;
            y = y2;
            width = wid;
            height = heig;
        }

        //Checks if two rectangles are intersecting and returning a boolean
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

            if (MinY > other.MaxY)
            {
                return false;
            }

            if (MaxY < other.MinY)
            {
                return false;
            }

            return true;
        }
    }
}
