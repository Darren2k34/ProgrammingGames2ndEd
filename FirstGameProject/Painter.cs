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
        //private Texture2D _balloon;
        //private Vector2 _balloonPosition;
        //private Vector2 _balloonOrigin;

        //private Texture2D _cannonBarrel;
        //private Texture2D _colourRed;
        //private Texture2D _colourGreen;
        //private Texture2D _colourBlue;

        //private Vector2 _colourOrigin;

        //private Vector2 _cannonBarrelPosition;
        //private Vector2 _cannonBarrelOrigin;
        //private float _cannonBarrelAngle;



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
            //_balloon = Content.Load<Texture2D>( "spr_lives" );
            //_cannonBarrel = Content.Load<Texture2D>( "spr_cannon_barrel" );
            //_colourRed = Content.Load<Texture2D>( "spr_cannon_red" );
            //_colourGreen = Content.Load<Texture2D>( "spr_cannon_green" );
            //_colourBlue = Content.Load<Texture2D>( "spr_cannon_blue" );

            //_balloonPosition = Vector2.Zero;
            //_balloonOrigin = new Vector2( _balloon.Width * 0.5f, _balloon.Height /* * 0.5f */ );

            //_cannonBarrelPosition = new Vector2( 72, 405 );
            //_cannonBarrelOrigin = new Vector2( _cannonBarrel.Height * 0.5f, _cannonBarrel.Height * 0.5f );

            //_colourOrigin = new Vector2( _colourRed.Width * 0.5f, _colourRed.Height * 0.5f );
            //_currentColour = Color.Blue;

            var cannonBalls = new Dictionary<BallColour, CannonBall>( new KeyValuePair<BallColour, CannonBall>[] {
                    new KeyValuePair<BallColour, CannonBall>( BallColour.Red, new CannonBall( Content.Load<Texture2D>( "spr_cannon_red" ) )),
                    new KeyValuePair<BallColour, CannonBall>( BallColour.Green, new CannonBall( Content.Load<Texture2D>( "spr_cannon_green" ) )),
                    new KeyValuePair<BallColour, CannonBall>( BallColour.Blue, new CannonBall( Content.Load<Texture2D>( "spr_cannon_blue" ) )),
            } );
            _cannon = new Cannon( Content.Load<Texture2D>( "spr_cannon_barrel" ), cannonBalls );
        }

        public void Update( GameTime gameTime )
        {
            /* var yPosition = 480 - gameTime.TotalGameTime.Milliseconds / 2;
             * var xPosition = gameTime.TotalGameTime.Milliseconds / 2;
             * _balloonPosition = new Vector2(xPosition, yPosition );
            */

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
            //_spriteBatch.Draw( _balloon, _balloonPosition, null, Color.White, 0.0f, _balloonOrigin, 1.0f, SpriteEffects.None, 0 );
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

            //_balloonPosition = new Vector2( _currentMouseState.X, _currentMouseState.Y );

            _previousMouseState = _currentMouseState;
            _previousKeyboardState = _currentKeyboardState;
        }
    }
}
