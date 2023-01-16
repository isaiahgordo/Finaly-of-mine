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
    class Lock
    {
        private Texture2D _texture;
        private Color _colour;
        private bool _locked;
        private Rectangle _bounds,_cicumf;
        public Texture2D Texture
        {
            get { return _texture; }
        }
        public Color Colour
        {
            get { return _colour; }
        }
        public Rectangle Bounds
        {
            get { return _bounds; }
            set{ _bounds = value; }
        }
        public bool locked(Player.Room room,MouseState ms,int t,int n, int i)
        {
            ms = Mouse.GetState();
            if (room == Player.Room.Start && ms.LeftButton == ButtonState.Pressed)
            { 
                Bounds=new Rectangle(Bounds.X,Bounds.Y,200,200);
                return true;
            }
            else
                return false;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, Bounds, Colour);
        }
        public Lock(Texture2D texture, Color colour, Rectangle bounds)
        {
            _texture = texture;
            _colour = colour;            
            _bounds = bounds;
        }
    }
}
