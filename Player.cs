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
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Finaly_of_mine
{
    class Player
    {
        private Texture2D _texture;
        private Rectangle _bounds;
        private Color _color;
        private Vector2 _speed;
        public Player(Texture2D texture, Rectangle bounds, Color color, Vector2 speed)
        {
            _texture = texture;
            _bounds = bounds;
            _color = color;
            _speed = speed;
        }
        public void Move(GraphicsDeviceManager graphic,KeyboardState kstate)
        {
            _bounds.Offset(_speed);
            if (kstate.IsKeyDown(Keys.A))
                if (_bounds.Left - _speed.X < 0)
                    _bounds.X = 0;
                else _bounds.X -= (int)_speed.X;
            else if (kstate.IsKeyDown(Keys.D))
                if (_bounds.Right + _speed.X > graphic.PreferredBackBufferWidth)
                    _bounds.X = graphic.PreferredBackBufferWidth - _bounds.Width;
                else _bounds.X += (int)_speed.X;
            else if (kstate.IsKeyDown(Keys.W))
                if (_bounds.Top - _speed.Y < 0)
                    _bounds.Y = 0;
                else _bounds.Y -= (int)_speed.Y;
            else if (kstate.IsKeyDown(Keys.S))
                if (_bounds.Bottom + _speed.Y > graphic.PreferredBackBufferHeight)
                    _bounds.Y = graphic.PreferredBackBufferHeight - _bounds.Height;
                else _bounds.Y += (int)_speed.Y;
            else if (kstate.IsKeyDown(Keys.E)) ;

        }
        public void Draw(SpriteBatch sB,int i)
        {
            
            sB.Draw(_texture, _bounds, _color);
        }
    }
}
