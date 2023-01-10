using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Xna.Framework.Graphics.SpriteFont;

namespace Finaly_of_mine
{
    class Enimy
    {
        private Texture2D _texture;
        private Rectangle _bounds;
        private Color _color;
        private Vector2 _speed;
        public Enimy(Texture2D texture, Rectangle bounds, Color color, Vector2 speed)
        {
            _texture = texture;
            _bounds = bounds;
            _color = color;
            _speed = speed;
        }
        public Texture2D texture
        {
            get { return _texture; }
        }
        public Rectangle bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }
        public Color color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Vector2 speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public Point centure
        {
            get { return _bounds.Center; }
        }
        public void Move(GraphicsDeviceManager graph,int i)
        {            
            if(i>=1||i<=4)
                bounds.Offset(_speed);
            if (bounds.Right > graph.PreferredBackBufferWidth || bounds.Left < 0)
            {
                if (i == 1)
                    _speed.X *= -1;
                else
                    _speed.X *= -i;
            }
            _bounds.X += (int)speed.X;
            if (bounds.Bottom > graph.PreferredBackBufferHeight || bounds.Top < 0)
            {
                if (i == 1)
                    _speed.Y *= -1;
                else
                    _speed.Y *= -i;
            }
            _bounds.Y += (int)speed.Y;               
        }        
        public void Draw(SpriteBatch sB)
        {
            
                sB.Draw(texture,bounds,color);
            
        }
    }
}
