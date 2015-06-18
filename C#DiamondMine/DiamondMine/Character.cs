using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondMine
{
    class Character
    {
        
        protected Vector position = new Vector();
        protected Vector direction = new Vector();
        protected Level level;
        protected DrawEngine drawField;
        private int characterIndex;
        protected int lives;
        

        public Character(Level l, DrawEngine field, int charIndex, float x = 1, float y = 1, int charLives = 1)
        {
            drawField = field;
            characterIndex = charIndex;
            position.x = x;
            position.y = y;
            direction.x = 1;
            direction.y = 0;
            lives = charLives;           
            level = l;
        }

        public Vector getPosition()
        {
            return position;
        }

        public float getX()
        {
            return position.x;
        }

        public float getY()
        {
            return position.y;
        }

        public void addLives(int num)
        {
            lives += num;

            // used for lives more than 1. If more characters have multiple lives redo
            // the game has only one player and the concept is that everyone else has 1.
            if (this.isAlive())
            {
                this.position.x = 1;
                this.position.y = 1;
                move(0, 0);
            }
        }
        
        public int getLives()
        {
            return lives;
        }

        public bool isAlive()
        {
            return (lives > 0);
        }

        public bool move(float x, float y)
        {
            int xpos = (int)(position.x + x);
            int ypos = (int)(position.y + y);

            if(isValidLevelMove(xpos, ypos))
            {
                erase(position.x, position.y);

                position.x += x;
                position.y += y;

                direction.x = x;
                direction.y = y;

                draw(position.x, position.y);
                return true;
            }
           
            return false;
           
        }

        public void draw(float x, float y)
        {
            drawField.drawCharacter(characterIndex, (int)x, (int)y);
        }

        public void erase(float x, float y)
        {
            drawField.eraseCharacter((int)x, (int)y);
        }

        public bool isValidLevelMove(int posX, int posY)
        {
            if(level.Lvl[posX,posY] != drawField.TileImage[(int)Tiles.wall])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        virtual public void idleUpdate(){}       
    }
}
