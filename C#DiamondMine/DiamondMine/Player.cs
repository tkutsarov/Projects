using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondMine
{
    class Player : Character
    {

        public Player(Level lv, DrawEngine de, int characterIndex, float x = 1, float y = 1, 
            int lives = 3) : base(lv, de, characterIndex, x, y, lives)
        {
                               
        }

        public bool keyPressed(ConsoleKeyInfo key)
        {           
            if(key.Key == ConsoleKey.W)
            {
                return move(0, -1);
            }
            else if (key.Key == ConsoleKey.S)
            {
                return move(0, 1);
            }
            else if (key.Key == ConsoleKey.A)
            {
                return move(-1, 0);
            }
            else if (key.Key == ConsoleKey.D)
            {
                return move(1, 0);
            }
            else if (key.Key == ConsoleKey.Spacebar)
            {
                shootBullet();
                return true;
            }

            return false;
        }

        public void shootBullet()
        {
            // if player is not facing the border walls
            if(!((position.x == 1 && direction.x == -1) || (position.x == this.drawField.ScreenWidth -2 && direction.x == 1) ||
                (position.y == 1 && direction.y == -1) || (position.y == this.drawField.ScreenHeight - 2 && direction.y == 1)))
            {
                //if player is not facing an inner wall
                if(this.level.Lvl[(int)(position.x + direction.x), (int)(position.y + direction.y)] != 
                    this.drawField.TileImage[(int)Tiles.wall])
                {
                    Bullet temp = new Bullet(level, drawField, (int)CharacterType.bullet, (int)position.x + direction.x,
                    (int)position.y + direction.y, direction.x, direction.y, 1);

                    Level.bullets.Add(temp);
                }            
            }          
        }
    }
}
