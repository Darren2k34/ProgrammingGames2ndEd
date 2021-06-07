using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstGameProject.PainterClasses
{
    public abstract class GameObject
    {
        private Vector2 _position;
        private Vector2 _origin;

        public Vector2 Position {
            get { return _position; }
            set { _position = value; }
        }
        public Vector2 Origin {
            get { return _origin; }
            set { _origin = value; }
        }

        public GameObject()
        {
            this._position = new Vector2( 72, 405 );
        }
    }
}
