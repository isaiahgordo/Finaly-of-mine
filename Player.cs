using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Finaly_of_mine
{
    class Player
    {       
        private Rectangle _bounds;        
        private Vector2 _speed;
        private Point _position;
        public Player(Vector2 speed)
        {                             
            _bounds= new Rectangle(_position,new Point(5,5));    
            _speed = speed;
        }       
        public Rectangle bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }        
        public Vector2 speed
        {
            get { return _speed; }
        }                    
        public void Move(GraphicsDeviceManager graphic,KeyboardState kstate)
        {            
            bounds.Offset(_speed);
            if (kstate.IsKeyDown(Keys.A))
                if (bounds.Left - _speed.X < 0)
                    _bounds.X = 0;
                else _bounds.X -= (int)_speed.X;
            else if (kstate.IsKeyDown(Keys.D))
                if (bounds.Right + speed.X > graphic.PreferredBackBufferWidth)
                    _bounds.X = graphic.PreferredBackBufferWidth - _bounds.Width;
                else _bounds.X += (int)_speed.X;            
        }
        public void Find(MouseState mouse)
        {
            
        }
        
    }
}
