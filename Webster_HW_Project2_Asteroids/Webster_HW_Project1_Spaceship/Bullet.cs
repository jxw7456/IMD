using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//JaJuan Webster
//Professor Cascioli
//Asteroids!

namespace Webster_HW_Project2_Asteroids
{
    class Bullet
    {
        //Fields
        public Vector2 bulletPos;
        public Vector2 origin;
        public Vector2 velocity;
        float radius;

        public bool isActive;

        //Constructor
        public Bullet()
        {
            origin = new Vector2(0, 0);
            isActive = false;
        }

        //Update moving and removing bullets from list
        public void UpdateBullets(List<Bullet> bullets, Spaceship spaceShip)
        {
            foreach (Bullet b in bullets)
            {
                b.bulletPos += b.velocity;

                if (Vector2.Distance(b.bulletPos, spaceShip.position) > 900)
                {
                    b.isActive = false;
                }

            }

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isActive)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        //Update method
        public void Shoot(List<Bullet> bullets, Spaceship spaceShip)
        {
            Bullet newBullet = new Bullet();
            newBullet.velocity = new Vector2((float)(Math.Cos(spaceShip.rotation)), (float)Math.Sin(spaceShip.rotation)) * 5.0f + spaceShip.velocity;
            newBullet.bulletPos.X += ((spaceShip.Position.X - 20) + newBullet.velocity.X * 15.0f);
            newBullet.bulletPos.Y += (spaceShip.Position.Y + newBullet.velocity.Y * 15.0f);
            newBullet.isActive = true;

            if (bullets.Count < 20)
            {
                bullets.Add(newBullet);
            }
        }

        //Checks if bullet intersects with asteroid
        public bool Intersects(Follower asteroid)
        {
            double distance = Math.Sqrt(Math.Pow(asteroid.position.X - bulletPos.X, 2) + Math.Pow(asteroid.position.Y - bulletPos.Y, 2));
            if (distance > (radius + asteroid.radius))
            {
                return false;
            }

            return true;
        }

        //Draw method
        public void Draw(SpriteBatch spriteBatch, Texture2D bullet, Spaceship s)
        {
            spriteBatch.Draw(bullet, bulletPos, null, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
