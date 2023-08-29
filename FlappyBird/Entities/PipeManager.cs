using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace FlappyBird.Entities
{
    class PipeManager : IEntity
    {
        public readonly List<Pipe> pipes = new List<Pipe>(8);

        private readonly List<Pipe> _pipesToAdd = new List<Pipe>();

        private readonly List<Pipe> _pipesToRemove = new List<Pipe>();

        private Player _player;

        private readonly Texture2D texture;

        private readonly Random random = new Random();

        private Vector2 position = new Vector2(900, -450);

        public PipeManager(Texture2D Texture, Player player)
        {
            texture = Texture;
            _player = player;
        }

        public void CreatePipe()
        {

            Pipe pipe;

            pipe = new Pipe(position, texture);
            AddPipe(pipe);

        }

        public void AddPipe(Pipe pipe)
        {
            _pipesToAdd.Add(pipe);

        }

        public void RemovePipe(Pipe pipe)
        {
            _pipesToRemove.Add(pipe);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Pipe pipe in pipes)
            {
                pipe.Draw(spriteBatch);
            }
        }

        public void CreateInitial()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                for (int i = 0; i < 11; i++)
                {
                    CreatePipe();
                    position.X += 150;
                }
                position.X -= (150 * 11);
                position.X = 150;
            }

        }

        public void CreateRepeat()
        {
            position.X += 750;
            for (int i = 0; i < 11; i++)
            {
                CreatePipe();
                position.X += 150;
            }
            position.X -= (150 * 10);
            position.X -= 900;
            // Multiply the distance between the pipes with the number of pipes
        }


        public void Update(GameTime gameTime)
        {
            if (pipes.Count == 0)
            {
                CreateInitial();
            }

            else if (pipes.Count < 6)
            {
                CreateRepeat();
            }

            foreach (Pipe pipe in pipes)
            {

                if (pipe.Remove)
                {
                    _pipesToRemove.Add(pipe);

                }

                CheckCollision(pipe);

                pipe.Update(gameTime);

            }


            foreach (Pipe pipe in _pipesToAdd)
            {
                pipes.Add(pipe);
            }

            foreach (Pipe pipe in _pipesToRemove)
            {
                pipes.Remove(pipe);
            }

            _pipesToAdd.Clear();
            _pipesToRemove.Clear();

        }

        private void CheckCollision(Pipe pipe)
        {
            if (pipe.CollisionboxTop.Intersects(_player.CollisionBox) || pipe.CollisionboxBottom.Intersects(_player.CollisionBox))
            {
                _player.State = PlayerState.Died;
            }
        }
    }
}
