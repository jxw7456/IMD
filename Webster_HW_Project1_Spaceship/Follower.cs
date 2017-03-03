using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//JaJuan Webster
//Professor Cascioli
//Spaceship!

namespace Webster_HW_Project1_Spaceship
{
    class Follower
    {
        //Fields
        float astSpeed;
        public Vector2 astPosition;        
        public Texture2D asteroids;
        Spaceship spaceShip;

        //Constructor
        public Follower()
        {
            astSpeed = 0.0f;
            astPosition = new Vector2(0, 0);            
            spaceShip = new Spaceship();
        }

        public void Update()
        {
            astPosition = spaceShip.position - spaceShip.velocity;
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(asteroids, astPosition, color);
        }
    }
}
