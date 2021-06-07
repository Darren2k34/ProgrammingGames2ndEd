using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static FirstGameProject.PainterClasses.CannonBall;

namespace FirstGameProject.PainterClasses
{
    public class Cannon : GameObject
    {
        private Texture2D _cannonTexture;
        private Dictionary<BallColour, CannonBall> _cannonBalls;
        private float _angle;

        public Texture2D Texture {
            get { return _cannonTexture; }
        }
        public Dictionary<BallColour, CannonBall> CannonBalls {
            get { return _cannonBalls; }
        }
        public float Angle {
            get { return _angle; }
            set { _angle = value; }
        }

        public Cannon( Texture2D cannonTexture, Dictionary<BallColour, CannonBall> cannonBalls ) : base()
        {
            _cannonTexture = cannonTexture;
            _cannonBalls = cannonBalls;

            Origin = new Vector2( _cannonTexture.Height * 0.5f, _cannonTexture.Height * 0.5f );
        }
    }
}
