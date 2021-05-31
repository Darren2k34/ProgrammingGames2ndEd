using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstGameProject
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager( this );
        }

        protected override void Initialize()
        {
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
            base.Update( gameTime );
        }
        protected override void Draw( GameTime gameTime )
        {
            GraphicsDevice.Clear( Color.Chocolate );

            base.Draw( gameTime );
        }
    }
}
