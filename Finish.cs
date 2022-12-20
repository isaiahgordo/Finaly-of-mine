using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finaly_of_mine
{
    class Finish
    {
        private Texture2D _texture;
        private Rectangle _bounds;
        private Color _color;
        public Finish(Texture2D texture, Rectangle bounds, Color color)
        {
            _texture = texture;
            _bounds = bounds;
            _color = color;
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
        public Point centure
        {
            get { return _bounds.Center; }
        }
        public void Draw(SpriteBatch sB)
        {
            sB.Draw(texture,bounds,color);
        }
    }
}
