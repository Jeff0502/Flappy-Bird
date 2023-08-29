using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird.Menus
{
    class Menu
    {
        private Rectangle playHitBox = new Rectangle(330, 207, 140, 48);

        private Rectangle quitHitBox = new Rectangle(330, 267, 140, 48);

        private Rectangle mouseRectangle;

        private Texture2D menuTexture;

        public bool playIsPressed;

        public bool quitIsPressed;

        public Menu(Texture2D texture)
        {
            menuTexture = texture;
        }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 5, 5);

            if (mouseRectangle.Intersects(playHitBox) && mouseState.LeftButton == ButtonState.Pressed)
            {
                playIsPressed = true;
            }

            if (mouseRectangle.Intersects(quitHitBox) && mouseState.LeftButton == ButtonState.Pressed)
            {
                quitIsPressed = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuTexture, new Rectangle(0, -40, 800, 600), Color.White);
        }
    }
}
