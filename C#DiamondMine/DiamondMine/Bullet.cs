using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondMine
{
    class Bullet : Character
    {
        

        public Bullet(Level l, DrawEngine de, int index, float x, float y, float xDir, float yDir,
            int lives) : base(l, de, index, x, y, lives)
        {
            direction.x = xDir;
            direction.y = yDir;            
        }

        override public void idleUpdate()
        {
            if(move(direction.x, direction.y))
            {               
                for (int i = 0; i < Level.npc.Count; i++)
                {
                    for (int j = 0; j < Level.bullets.Count; j++)
                    {
                        if((int)Level.npc[i].getX() == (int)Level.bullets[j].getX() && 
                            (int)Level.npc[i].getY() == (int)Level.bullets[j].getY())
                        {
                            Level.npc[i].addLives(-1);                            
                            Level.bullets[j].addLives(-1);
                            Level.bullets[j].erase(Level.bullets[j].position.x, Level.bullets[j].position.y);
                        }
                    }
                }
            }
            else
            {
                this.addLives(-1);
                this.erase(this.position.x, this.position.y);
            }           
        }
    }  
}
