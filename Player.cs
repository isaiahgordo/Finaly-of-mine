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
        private Texture2D _texture;
        private Rectangle _bounds;
        private Color _color;
        private Vector2 _speed;
        int o = 0;
        public Player(Texture2D texture, Rectangle bounds, Color color, Vector2 speed)
        {
            _texture = texture;
            _bounds = bounds;
            _color = color;
            _speed = speed;
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
        public Vector2 speed
        {
            get { return _speed; }
        }
        public int oget
        {
            get { return o; }
        }
        public void Move(GraphicsDeviceManager graphic,KeyboardState kstate,Point p,Rectangle rect)
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
            else if (kstate.IsKeyDown(Keys.W))
                if (bounds.Top - _speed.Y < 0)
                    _bounds.Y = 0;
                else _bounds.Y -= (int)_speed.Y;
            else if (kstate.IsKeyDown(Keys.S))
                if (bounds.Bottom + speed.Y > graphic.PreferredBackBufferHeight)
                    _bounds.Y = graphic.PreferredBackBufferHeight - _bounds.Height;
                else _bounds.Y += (int)_speed.Y;
            else if (kstate.IsKeyDown(Keys.E))
                if (bounds.Contains(p))
                    o = 5;
        }
        public void Draw(SpriteBatch sB,int i)
        {
          sB.Draw(texture, bounds, color);
        }
    }
}
