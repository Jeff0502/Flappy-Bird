using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FlappyBird.Entities;
using FlappyBird.Menus;

namespace FlappyBird
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private Texture2D pipetexture;

        private Texture2D playerTexture;

        private EntityManager entityManager;

        private Texture2D background;

        private Texture2D Deathscreen;

        private Texture2D menuTexture;

        private KeyboardState oldState;

        private bool isEnabled = false;

        private MenuState menuState;

        private Menu menu;

        private bool InGame;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            menuState = MenuState.InMenus;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pipetexture = Content.Load<Texture2D>("Pipe Concept");
            playerTexture = Content.Load<Texture2D>("Bird Concept");
            background = Content.Load<Texture2D>("FlappyBird_Background");
            Deathscreen = Content.Load<Texture2D>("Death Screen");
            menuTexture = Content.Load<Texture2D>("Start menu");


            Load();
            menu = new Menu(menuTexture);
        }

        protected override void Update(GameTime gameTime)
        {

            var newState = Keyboard.GetState();

            if (!InGame)
            {
                if (menu.playIsPressed)
                {
                    menuState = MenuState.InGame;
                    Load();

                }

                if (menu.quitIsPressed)
                    Exit();

                menu.Update(gameTime);
            }


            if (InGame)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && !isEnabled && entityManager.player.State != PlayerState.Died)
                {
                    isEnabled = true;
                    entityManager.player.Jump();
                }

                if (entityManager.player.State == PlayerState.Died)
                {
                    isEnabled = false;

                    if (newState.IsKeyDown(Keys.Space) && !oldState.IsKeyDown(Keys.Space))
                    {
                        isEnabled = true;
                        entityManager.player.State = PlayerState.Idle;
                        Load();
                    }

                }

                if (isEnabled)
                {
                    entityManager.Update(gameTime);
                }

                oldState = newState;
            }

            if(entityManager.player.State == PlayerState.Died && Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                menuState = MenuState.InMenus;
                menu.playIsPressed = false;
            }

            CheckState();
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (menuState == MenuState.InMenus)
            {
                menu.Draw(_spriteBatch);
            }

            if (menuState == MenuState.InGame)
            {
                _spriteBatch.Draw(background, new Rectangle(0, -256, 1024, 768), Color.White);
                entityManager.Draw(_spriteBatch);

                if (entityManager.player.State == PlayerState.Died)
                {
                    _spriteBatch.Draw(Deathscreen, new Rectangle(0, -80, 800, 600), Color.White);
                }
            }

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void CheckState()
        {
            if (menuState == MenuState.InGame)
            {
                InGame = true;
            }

            else
            {
                InGame = false;
            }
        }

        public void Load()
        {
            entityManager = new EntityManager(playerTexture, pipetexture);
        }
    }
}
