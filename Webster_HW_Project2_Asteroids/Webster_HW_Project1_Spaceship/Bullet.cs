using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

//JaJuan Webster
//Professor Cascioli
//Asteroids!

namespace Webster_HW_Project2_Asteroids
{
    class Bullet
    {
        //Fields
        Vector2 bulletPos;
        Vector2 shipFront;
        Vector2 velocity;
        float rotation;
        float speed;

        //Constructor
        public Bullet(Spaceship spaceship)
        {
            speed = 3.0f;
            rotation = 4.75f;
            velocity = spaceship.forward * speed;
            shipFront = new Vector2(spaceship.position.X, spaceship.position.Y);
            bulletPos = new Vector2(shipFront.X, shipFront.Y);
        }

        //Update method
        public void Update(Spaceship spaceship)
        {
            //Rotate Left
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                rotation -= 0.04f;
            }

            //Rotate Right
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                rotation += 0.04f;
            }

            velocity = spaceship.forward * speed;
            bulletPos = new Vector2((float)(Math.Cos(rotation) + shipFront.X), (float)(Math.Sin(rotation) + shipFront.Y));
            //bulletPos += velocity;
        }

        //Draw method
        public void Draw(SpriteBatch spriteBatch, Texture2D bullet, Spaceship spaceship, Color color)
        {

            spriteBatch.Draw(bullet, null, new Rectangle((int)bulletPos.X, (int)bulletPos.Y, (bullet.Width / 5), (bullet.Height / 5)),
                null, new Vector2((spaceship.ship.Width /2), (spaceship.ship.Height / 2)), rotation, null, color, SpriteEffects.None, 0.0f);
        }
    }
}
