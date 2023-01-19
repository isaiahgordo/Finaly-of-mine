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
        public enum Room { Start,Left,Right,End}
        private Room _room;
        public Player(Vector2 speed)
        {                             
            _bounds= new Rectangle(_position,new Point(5,5));    
            _speed = speed;
        }       
        public Room TheRoom
        {
            get { return _room; }
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
            if (kstate.IsKeyDown(Keys.A) && (_room == Room.Start || _room == Room.Left || _room == Room.Right || _room == Room.End))
            {
                if (_room == Room.Start)
                    _room = Room.Left;
                else if (_room == Room.Left)
                    _room = Room.End;
                else if (_room == Room.End)
                    _room = Room.Right;
                else _room = Room.Start;
            }
            else if (kstate.IsKeyDown(Keys.D) && (_room == Room.Start || _room == Room.Left || _room == Room.Right || _room == Room.End))
            {
                if (_room == Room.Start)
                    _room = Room.Right;
                else if (_room == Room.Left)
                    _room = Room.Start;
                else if (_room == Room.End)
                    _room = Room.Left;
                else _room= Room.End;
            }            
        }
        public int Click(MouseState mouse)
        {
            mouse= Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed)
                return 0;
            else return 1;
        }
        public void Find(MouseState mouse)
        {
           mouse=  Mouse.GetState();
            _position.X = mouse.X;
            _position.Y = mouse.Y;
        }        
    }
}