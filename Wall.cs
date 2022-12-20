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
        private List<Rectangle> levelone=new List<Rectangle>();
        int i,n=0;
        public Wall(Texture2D texture,Rectangle bounds, Color color)
        {
            _bounds = bounds;
            _texture = texture;
            _color = color;
            while (n < 10)
            { levelone.Add(_bounds);n++; }            
        }
        public Texture2D Texture
        { get { return _texture; } }
        public Rectangle Bounds 
        { 
            get { return _bounds; }
            set { _bounds = value; } 
        }
        public void WallBounds(GraphicsDeviceManager graph)
        {
            for (i = 0; i < levelone.Count; i++)
            { 
                Rectangle temp = levelone[i];
                temp.Y = 100;
                switch (i)
                {
                    case 0:                        
                            temp.X = graph.PreferredBackBufferWidth - temp.Width;                            
                            break;                        
                    case 1:                        
                            temp.X = graph.PreferredBackBufferWidth - 2*temp.Width;
                            break;                        
                    case 2:
                        temp.X = graph.PreferredBackBufferWidth - 3*temp.Width;
                        break;
                    case 3:
                        temp.X = graph.PreferredBackBufferWidth - 4*temp.Width;
                        break;
                    case 4:
                        temp.X = graph.PreferredBackBufferWidth - 5*temp.Width;
                        break;
                    case 5:
                        temp.X = graph.PreferredBackBufferWidth - 6*temp.Width;
                        break;
                    case 6:
                        temp.X = 0;
                        break;
                    case 7:
                        temp.X = temp.Width;
                        break;
                    case 8:
                        temp.X = 2*temp.Width;
                        break ;
                        default:
                        { 
                            temp.X = 2 * temp.Width; 
                            temp.Y = 0;
                        }
                        break;
                }
                levelone[i] = temp;
            }
        }        
        public Color Color
        { 
            get { return _color; }
            set { _color = value; }
        }
        public void Draw(SpriteBatch sB)
        {
            foreach(var wb in levelone)
                sB.Draw(Texture, wb, Color);
        }
        
    }
}
