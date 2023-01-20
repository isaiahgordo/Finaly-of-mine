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
    class Box
    {
        private Texture2D _texture;
        private Rectangle _bounds;
        private Color _color;
        int t = 0;
        public Box(Texture2D texture, Rectangle bounds, Color color)
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
        public Vector2 Emyvec
        {
            get { return new Vector2(_bounds.Center.X, _bounds.Top); }
        }        
        public void Zoom(int i)
        {            
            while (t == 0)
            {
                if (i == 1)
                    bounds = new Rectangle(bounds.Location - new Point(50, 50), new Point(200, 200));
                else
                    bounds = new Rectangle(bounds.Location + new Point(50, 50), new Point(100, 100));
                t = 1;
            }
        }
        public void Draw(SpriteBatch sB)
        {            
            sB.Draw(texture,bounds,color);            
        }
    }
}