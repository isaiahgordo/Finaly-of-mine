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
        
        public void thelock(bool b)
        {
            if (b == true)
                _locked = b;
        }
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
        public Point Centur
        {
            get { return _cicumf.Center; }
        }
        public bool locked(Player.Room room,MouseState ms,int t,int n, int i)
        {
            ms = Mouse.GetState();
            if (room == Player.Room.Start && ms.LeftButton == ButtonState.Pressed)
            { 
                Bounds=new Rectangle(Bounds.X,Bounds.Y,200,200);
                Cicumf cicumf=new Cicumf(_cicumf,t);
                return true;
            }
            else
                return false;
        }
        class Cicumf 
        {
            private Rectangle _bounds;
            private int _i, _n, _t;
            private Point[] _p= new Point[3];
            public Cicumf(Rectangle cicumf,int i) 
            {
                i = _i;                
                cicumf = _bounds;
                foreach(Point p in _p)
                { 
                    if (_i == 15)
                        _p[0] = new Point(_bounds.Right, _bounds.Center.Y);
                    else if (_i == 45 )
                        _p[0] = new Point(_bounds.Left, _bounds.Center.Y);
                    else if (i == 30)
                        _p[0] = new Point(_bounds.Center.X, _bounds.Bottom);
                    else if (i == 0)
                        _p[0] = new Point(_bounds.Center.X / 2, _bounds.Top);
                    else
                    {
                        if (_i == 7)
                            _p[0] = new Point(_bounds.Right, _bounds.Top);
                        else if (_i == 22)
                            _p[0] = new Point(_bounds.Right, _bounds.Bottom);
                        else if (_i == 37)
                            _p[0] = new Point(_bounds.Left, _bounds.Bottom);
                        else if (i == 52)
                            _p[0] = new Point(_bounds.Left, _bounds.Top);
                        else
                        {
                            if (_i == 3)
                                _p[0] = new Point(_bounds.Right / 2, _bounds.Top);
                            else if (i == 11)
                                _p[0] = new Point(_bounds.Right / 2, _bounds.Top / 2);
                            else if (i == 18)
                                _p[0] = new Point(_bounds.Right, _bounds.Top / 2);
                            else if (i == 26)
                                _p[0] = new Point(_bounds.Right / 2, _bounds.Bottom);
                            else if (i == 33)
                                _p[0] = new Point(_bounds.Left / 2, _bounds.Bottom);
                            else if (i == 41)
                                _p[0] = new Point(_bounds.Right / 2, _bounds.Bottom / 2);
                            else if (i == 48)
                                _p[0] = new Point()
                        }
                    }
                }
            }

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
