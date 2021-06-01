using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstGameProject
{
    public class DiscoWorld
    {
        GraphicsDevice _graphics;
        private Color _background;
        public DiscoWorld(GraphicsDevice graphicsDevice)
        {
            _graphics = graphicsDevice;
        }

        public void Update( GameTime gameTime )
        {
            int redComponent = gameTime.TotalGameTime.Milliseconds;

            _background = new Color( redComponent, 0, 0 );
        }
        public void Draw( GameTime gameTime )
        {
            _graphics.Clear( _background );
        }
    }
}
