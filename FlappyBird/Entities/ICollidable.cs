using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.Entities
{
    interface ICollidable
    {
        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);
    }
}
