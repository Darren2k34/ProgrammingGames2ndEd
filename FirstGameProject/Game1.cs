using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        SpriteBatch _spriteBatch;
        GameState _game;

        DiscoWorld _discoWorld;
        Painter _painter;
        public Game1()
        {
            Content.RootDirectory = "Content";
            _graphics = new GraphicsDeviceManager( this );
            _game = GameState.Painter; // set startup game here;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch( GraphicsDevice );
            _discoWorld = new DiscoWorld( GraphicsDevice );
            _painter = new Painter( GraphicsDevice, _spriteBatch, Content );
            base.Initialize();
        }
        protected override void LoadContent()
        {
            switch ( _game ) {
                case GameState.DiscoWorld:
                    break;
                case GameState.Painter:
                    _painter.LoadContent();
                    break;
                default:
                    break;
            }
            base.LoadContent();
        }
        protected override void UnloadContent()
        {
            switch ( _game ) {
                case GameState.DiscoWorld:
                    break;
                case GameState.Painter:
                    break;
                default:
                    break;
            }
            base.UnloadContent();
        }
        protected override void Update( GameTime gameTime )
        {
            switch ( _game ) {
                case GameState.DiscoWorld:
                    _discoWorld.Update( gameTime );
                    break;
                case GameState.Painter:
                    _painter.Update( gameTime );
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
                    _painter.Draw( gameTime );
                    break;
                default:
                    break;
            }

            base.Draw( gameTime );
        }
    }
}
