using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using FirstGameProject.PainterClasses;
using static FirstGameProject.PainterClasses.CannonBall;

namespace FirstGameProject
{
    public class Painter
    {
        private GraphicsDevice _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager Content { get; }

        private Texture2D _background;
        private Cannon _cannon;
        private BallColour _currentColour;

        private bool _cannonFollowsMouse;

        private MouseState _currentMouseState, _previousMouseState;
        private KeyboardState _currentKeyboardState, _previousKeyboardState;

        private CannonBall currentCannonBall;

        public Painter( GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, ContentManager contentManager )
        {
            _graphics = graphicsDevice;
            _spriteBatch = spriteBatch;
            Content = new ContentManager( contentManager.ServiceProvider, contentManager.RootDirectory );
        }
        public void LoadContent()
        {
            MediaPlayer.Play( Content.Load<Song>( "snd_music" ) );
            _background = Content.Load<Texture2D>( "spr_background" );

            var cannonBalls = new Dictionary<BallColour, CannonBall>( new KeyValuePair<BallColour, CannonBall>[] {
                    new KeyValuePair<BallColour, CannonBall>( BallColour.Red, new CannonBall( Content.Load<Texture2D>( "spr_cannon_red" ) )),
                    new KeyValuePair<BallColour, CannonBall>( BallColour.Green, new CannonBall( Content.Load<Texture2D>( "spr_cannon_green" ) )),
                    new KeyValuePair<BallColour, CannonBall>( BallColour.Blue, new CannonBall( Content.Load<Texture2D>( "spr_cannon_blue" ) )),
            } );
            _cannon = new Cannon( Content.Load<Texture2D>( "spr_cannon_barrel" ), cannonBalls );
        }

        public void Update( GameTime gameTime )
        {
            HandleInput();

            if ( _currentColour == BallColour.Red )
                currentCannonBall = _cannon.CannonBalls[ BallColour.Red ];
            else if ( _currentColour == BallColour.Green )
                currentCannonBall = _cannon.CannonBalls[ BallColour.Green ];
            else
                currentCannonBall = _cannon.CannonBalls[ BallColour.Blue ];
        }
        public void Draw( GameTime gameTime )
        {
            _graphics.Clear( Color.CornflowerBlue );

            _spriteBatch.Begin();
            _spriteBatch.Draw( _background, Vector2.Zero, Color.White );
            _spriteBatch.Draw( _cannon.Texture, _cannon.Position, null, Color.White, _cannon.Angle, _cannon.Origin, 1.0f, SpriteEffects.None, 0 );
            _spriteBatch.Draw( currentCannonBall.Texture, currentCannonBall.Position, null, Color.White, 0f, currentCannonBall.Origin, 1.0f, SpriteEffects.None, 0 );
            _spriteBatch.End();
        }

        public void HandleInput()
        {

            _currentMouseState = Mouse.GetState();
            _currentKeyboardState = Keyboard.GetState();

            bool keyboard_R_KeyPressed = _currentKeyboardState.IsKeyDown( Keys.R ) && _previousKeyboardState.IsKeyUp( Keys.R );
            bool keyboard_G_KeyPressed = _currentKeyboardState.IsKeyDown( Keys.G ) && _previousKeyboardState.IsKeyUp( Keys.G );
            bool keyboard_B_KeyPressed = _currentKeyboardState.IsKeyDown( Keys.B ) && _previousKeyboardState.IsKeyUp( Keys.B );

            if ( keyboard_R_KeyPressed )
                _currentColour = BallColour.Red;
            else if ( keyboard_G_KeyPressed )
                _currentColour = BallColour.Green;
            else if ( keyboard_B_KeyPressed )
                _currentColour = BallColour.Blue;

            bool mouseButtonClicked = _currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released;
            bool mouseButtonReleased = _currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed;

            if ( mouseButtonClicked || mouseButtonReleased )
                _cannonFollowsMouse = !_cannonFollowsMouse;

            if ( _cannonFollowsMouse ) {

                double opposite = _currentMouseState.Y - _cannon.Position.Y;
                double adjacent = _currentMouseState.X - _cannon.Position.X;

                _cannon.Angle = ( float ) Math.Atan2( opposite, adjacent );
            } else {
                _cannon.Angle = 0;
            }

            _previousMouseState = _currentMouseState;
            _previousKeyboardState = _currentKeyboardState;
        }
    }
}
