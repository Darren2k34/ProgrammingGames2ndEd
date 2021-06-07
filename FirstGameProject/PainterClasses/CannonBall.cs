using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstGameProject.PainterClasses
{
    public class CannonBall : GameObject
    {
        public enum BallColour
        {
            Red,
            Green,
            Blue
        }

        private Texture2D _cannonBallTexture;

        public Texture2D Texture {
            get { return _cannonBallTexture; }
            set { _cannonBallTexture = value; }
        }

        public CannonBall(Texture2D texture) : base()
        {
            _cannonBallTexture = texture;
            Origin = new Vector2( _cannonBallTexture.Width * 0.5f, _cannonBallTexture.Height * 0.5f );
        }
    }
}
