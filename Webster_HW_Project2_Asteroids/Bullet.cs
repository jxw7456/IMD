using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webster_HW_Project2_Asteroids
{
    class Bullet
    {
        //Fields
        Vector2 bulletPos;
        Vector2 velocity;
        Vector2 direction;
        float rotation;
        float speed;

        //Constructor
        public Bullet(Spaceship spaceship)
        {
            speed = 7.0f;
            direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            velocity = direction * speed;
            bulletPos = new Vector2((float)(144 * Math.Cos(rotation) + (spaceship.position.X - 50)), (float)(145 * Math.Sin(rotation) + spaceship.position.Y));


        }

        //Update method
        public void Update(Spaceship spaceship)
        {
            //Rotate Left
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                rotation -= 0.03f;
                direction = new Vector2((float)Math.Cos(rotation) * speed, (float)Math.Sin(rotation) * speed);
            }

            //Rotate Right
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                rotation += 0.03f;
                direction = new Vector2((float)Math.Cos(rotation) * speed, (float)Math.Sin(rotation) * speed);
            }

            velocity = direction * speed;
            bulletPos = new Vector2((float)(144 * Math.Cos(rotation) + (spaceship.position.X - 55)), (float)(145 * Math.Sin(rotation) + (spaceship.position.Y + 2)));
            //bulletPos += velocity;
        }

        //Draw method
        public void Draw(SpriteBatch spriteBatch, Texture2D bullet, Spaceship spaceship, Color color)
        {

            spriteBatch.Draw(bullet, null, new Rectangle((int)bulletPos.X, (int)bulletPos.Y, (bullet.Width / 5), (bullet.Height / 5)),
                null, new Vector2((bullet.Width / 2), (bullet.Height / 2)), rotation, null, color, SpriteEffects.None, 0.0f);
        }
    }
}
