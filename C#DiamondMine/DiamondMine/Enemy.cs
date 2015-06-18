using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondMine
{
    class Enemy : Character
    {
        Player goal;

        public Enemy(Level l, DrawEngine de, int index, float x, float y, int lives) :
            base(l, de, index, x, y, lives)
        {
            
        }

        public bool move(float x, float y)
        {
            int xpos = (int)(position.x + x);
            int ypos = (int)(position.y + y);

            if(isValidLevelMove(xpos, ypos))
            {
                // don't run into other enemies

                
		        for (int i = 0; i < Level.npc.Count; i++)
		        {
                    if (Level.npc[i] != this && (int)Level.npc[i].getX() == xpos && (int)Level.npc[i].getY() == ypos)
			        {
				        return false;
			        }

		        }

                erase(position.x, position.y);

                position.x += x;
                position.y += y;

                direction.x = x;
                direction.y = y;

                draw(position.x, position.y);

                if((int)goal.getX() == xpos && (int)goal.getY() == ypos)
                {
                    goal.addLives(-1);
                }

                return true;
            }

            return false;
        }

        override public void idleUpdate()
        {
            if(goal != null)
            {
                simulateAI();
            }
        }

        public void addGoal(Player g)
        {
            goal = g;
        }

        public void simulateAI()
        {
            Vector goalPosition = goal.getPosition();
            Vector direction;

            direction.x = goalPosition.x - this.position.x;
            direction.y = goalPosition.y - this.position.y;

            float magnitude = (float)Math.Sqrt(direction.x * direction.x + direction.y * direction.y);
            direction.x = direction.x / (magnitude * 6);
            direction.y = direction.y / (magnitude * 6);
            
            Random rand = new Random();
            if(!move(direction.x, direction.y))
            {
                while(!move(rand.Next(0, 3) - 1, rand.Next(0,3) - 1))
                {

                }
            }
        }
    }
}
