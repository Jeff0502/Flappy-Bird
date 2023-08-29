using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird.Entities
{
    interface IEntity
    {
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
