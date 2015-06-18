using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DiamondMine
{
    class Game
    {        
        private DrawEngine drawField = new DrawEngine(30,20);
        
        public Game()
        {

        }

        public DrawEngine DrawField 
        { 
            get { return this.drawField; }
            set { this.drawField = value; }
        }

        public bool run()
        {
            drawField.createBackgroundTile((int)Tiles.wall, '+');
            drawField.createBackgroundTile((int)Tiles.empty, ' ');

            Level level = new Level(drawField, 30, 20);
            Player player = new Player(level, drawField, 0);

            //player
            drawField.createCharacter('$', 0);
            //enemy
            drawField.createCharacter('@', 1);
            //bullet
            drawField.createCharacter('*', 2);

            level.draw();
            level.addPlayer(player);
            level.addEnemies(4);
                  
            // loop until Escape is pressed

            while (true)
            {               
                if(!player.isAlive())
                {
                    Console.SetCursorPosition(0, level.Lvl.GetLength(1) + 1);
                    Console.CursorVisible = true;
                    Console.WriteLine("Game over!!!");
                    break;
                }

                // If all enemies are dead
                if(Level.npc.Count == 0)
                {
                    Console.SetCursorPosition(0, level.Lvl.GetLength(1) + 1);
                    Console.WriteLine("You win!!!");
                    break;
                }

                drawField.eraseCharacter((int)player.getX(), (int)player.getY());
                level.update();            
    
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if(key.Key != ConsoleKey.Escape)
                    {
                        level.keyPressed(key);
                    }
                    else if(key.Key == ConsoleKey.Escape)
                    {
                        // position the cursor one row under the map
                        Console.SetCursorPosition(0, level.Lvl.GetLength(1) + 1);
                        Console.CursorVisible = true;                       
                        break;
                    }
                   
                }
                              
                drawField.drawCharacter(0, (int)player.getX(), (int)player.getY());
                
                Thread.Sleep(70);   
            }

            return true;
        }               
    }
}
