using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird.Entities
{
    class Player : ICollidable, IEntity
    {
        private readonly Texture2D texture;

        private Color colour = Color.White;
        public PlayerState State { get; set; }

        private Vector2 position = new Vector2(50, 100);

        public Rectangle CollisionBox;

        private float velY = 0f, acceleration = 0.1f;

        public Player(Texture2D Texture)
        {
            texture = Texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, colour);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Jump();
            }

            velY += acceleration;

            position.Y += velY;

            CollisionBox = new Rectangle((int)position.X, (int)position.Y, (texture.Width - 3), (texture.Height - 3));

            if (position.Y >= 422 || position.Y <= 0)
            {
                State = PlayerState.Died;
            }
        }

        public void Jump()
        {
            velY = 0;
            velY -= 1.5f;
        }
    }
}
