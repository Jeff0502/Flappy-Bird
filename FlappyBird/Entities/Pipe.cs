using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FlappyBird.Entities
{
    class Pipe : ICollidable, IEntity
    {
        public Vector2 position;

        private Texture2D texture;

        public Random random = new Random();

        public bool Remove;

        private int destroyCoords;

        public Rectangle CollisionboxTop
        {
            get
            {
                Rectangle box = new Rectangle((int)position.X, (int)position.Y, texture.Width, 604);

                return box;
            }
        }

        public Rectangle CollisonboxMiddle
        {
            get
            {
                Rectangle box = new Rectangle((int)position.X, ((int)position.Y + 605), texture.Width, 121);

                return box;
            }

        }

        public Rectangle CollisionboxBottom
        {
            get
            {
                Rectangle box = new Rectangle((int)position.X, ((int)position.Y + 726), texture.Width, 606);

                return box;
            }
        }

        public Pipe(Vector2 Position, Texture2D Texture)
        {
            int rng = random.Next(0, 101);

            position = Position;

            position.Y += rng;

            texture = Texture;

            destroyCoords = 0 - texture.Width;
        }

        public void Update(GameTime gameTime)
        {
            position.X -= 1;

            if (position.X <= destroyCoords)
            {
                Remove = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
