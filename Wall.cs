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
        public Wall(Texture2D texture,Rectangle bounds, Color color)
        {
            _bounds = bounds;
            _texture = texture;
            _color = color;
            
        }
        public void Draw(SpriteBatch sB)
        {

        }
        
    }
}
