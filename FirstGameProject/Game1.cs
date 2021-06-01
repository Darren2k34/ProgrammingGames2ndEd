using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstGameProject
{
    public enum GameState
    {
        DiscoWorld,
        Painter
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        GameState _game;

        DiscoWorld _discoWorld;
        Painter _painter;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager( this );
            _game = GameState.Painter; // set startup game here;
        }

        protected override void Initialize()
        {
            _discoWorld = new DiscoWorld(GraphicsDevice);
            _painter = new Painter( GraphicsDevice );

            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        protected override void Update( GameTime gameTime )
        {
            switch ( _game ) {
                case GameState.DiscoWorld:
                    _discoWorld.Update( gameTime );
                    break;
                case GameState.Painter:
                    break;
                default:
                    break;
            }

            base.Update( gameTime );
        }
        protected override void Draw( GameTime gameTime )
        {
            switch ( _game ) {
                case GameState.DiscoWorld:
                    _discoWorld.Draw( gameTime );
                    break;
                case GameState.Painter:
                    break;
                default:
                    break;
            }

            base.Draw( gameTime );
        }
    }
}
