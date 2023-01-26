using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Finale_of_mine
{
    class Gold
    {
        private Texture2D _texture;
        private Rectangle _bounds;
        private Color _color;
        public Gold(Texture2D texture, Rectangle bounds, Color color)
        {
            _texture = texture;
            _bounds = bounds;
            _color = color;
        }
        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Rectangle Bounds 
        { 
            get { return _bounds; } 
        }
        public Color Color 
        {
            get { return _color; }
        }
        public void Draw(SpriteBatch sb,bool b)
        {
            if (b==true)
                sb.Draw(Texture, Bounds, Color);
        }
    }
}
