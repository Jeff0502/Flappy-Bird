using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using FlappyBird.Menus;

namespace FlappyBird.Entities
{
    class EntityManager
    {
        private readonly List<IEntity> _entities = new List<IEntity>();

        public PipeManager _pipeManager;

        public Player player;

        private Texture2D _playerTexture;

        private Texture2D _pipeTexture;

        public EntityManager(Texture2D PlayerTexture, Texture2D PipeTexture)
        {
            _playerTexture = PlayerTexture;

            _pipeTexture = PipeTexture;

            player = new Player(_playerTexture);

            _pipeManager = new PipeManager(_pipeTexture, player);

            _entities.Add(_pipeManager);
            _entities.Add(player);
        }

        public void Update(GameTime gameTime)
        {
            foreach (IEntity entitiy in _entities)
            {
                entitiy.Update(gameTime);
            }

            if (player.State == PlayerState.Died)
            {
                _entities.Clear();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEntity entitiy in _entities)
            {
                entitiy.Draw(spriteBatch);
            }
        }


    }
}
