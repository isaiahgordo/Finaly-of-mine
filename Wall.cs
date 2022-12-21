using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finaly_of_mine
{
    class Wall
    {
        private Rectangle _bounds;
        private Texture2D _texture;
        private Color _color;
        private List<Rectangle> _wallBounds;
        public Wall(Texture2D texture,Rectangle bounds, Color color)
        {
            _bounds = bounds;
            _texture = texture;
            _color = color;
            _wallBounds=new List<Rectangle> { _bounds, };
        }
        public Texture2D Texture
        { get { return _texture; } }
        public Rectangle Bounds 
        { 
            get { return _bounds; }
            set { _bounds = value; } 
        }
        public Point onlyxy
        {
            get { return new  (_bounds.X,_bounds.Y); }
            set {_bounds.X = value.X; _bounds.Y = value.Y; }
        }
        public Color Color
        { 
            get { return _color; }
            set { _color = value; }
        }
        //te frick
        public void Draw(SpriteBatch sB)
        {// ta frick
            foreach(var wb in _wallBounds)
                sB.Draw(Texture, wb, Color);
        }
        
    }
}
