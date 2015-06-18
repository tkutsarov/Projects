using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondMine
{
    class Level
    {
        private int width;
        private int height;
        private char[,] lvl;
        private DrawEngine drawField;       
        private Random rand = new Random();
        public static List<Character> npc = new List<Character>();
        public static List<Bullet> bullets = new List<Bullet>();
        public Player player;
        
        public Level(DrawEngine de, int w, int h)
        {
            drawField = de;
            width = w;
            height = h;
            lvl = new char[width,height];

            createLevel();                        
        }

        public char[,] Lvl 
        { 
            get { return lvl; } 
        }

        // make the level map
        public void createLevel()
        {                        
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    int tile = rand.Next(0, 100);

                    if(h == 0 || h == height - 1 || w == 0 || w == width - 1)
                    {
                        lvl[w, h] = drawField.TileImage[(int)Tiles.wall];
                    }
                    else
                    {
                        if (tile < 90 || (w < 3 && h < 3))
                        {
                            lvl[w, h] = drawField.TileImage[(int)Tiles.empty];
                        }
                        else
                        {
                            lvl[w, h] = drawField.TileImage[(int)Tiles.wall];
                        }
                    }                  
                }
            }
        }


        // drow the constant level map
        public void draw()
        {
            drawField.drawBackground(lvl);
        }        

        public void update()
        {
            //update bullets
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].isAlive() == false)
                {
                    bullets.Remove(bullets[i]);     
               
                    if(i != 0)
                    {
                        i--;
                    }
                }
                else
                {
                    bullets[i].idleUpdate();
                }               
            }

            //update npc
            for(int i = 0; i < npc.Count; i++)
            {
                if (npc[i].isAlive() == false)
                {
                    npc.Remove(npc[i]);
                    if(i != 0)
                    {
                        i--;
                    }
                }
                else
                {
                    npc[i].idleUpdate();   
                }                            
            }
        }

        public void addPlayer(Player p)
        {
            player = p;
        }


        // Managey key press from the level class
        public bool keyPressed(ConsoleKeyInfo key)
        {
            if(player != null)
            {
                if(player.keyPressed(key))
                {
                    return true;
                }
            }

            return false;
        }

        public void addEnemies(int number)
        {
            int i = number;

            while(i > 0)
            {
                int xpos = (int)(((float)(rand.Next(0, 100)) / 100) * (width - 2) + 1);
                int ypos = (int)(((float)rand.Next(0, 100) / 100) * (height - 2) + 1);

                if(lvl[xpos, ypos] != drawField.TileImage[(int)Tiles.wall])
                {
                    Enemy temp = new Enemy(this, drawField, (int)CharacterType.enemy, (float)xpos, (float)ypos, 1);
                    
                    temp.addGoal(player);
                    addNPC((Character)temp);

                    i--;
                }
            }
        }

        public void addNPC(Character ch)
        {
            npc.Add(ch);
        }

        public void gameOver()
        {
            if(!player.isAlive())
            {

            }
        }
    }
}
