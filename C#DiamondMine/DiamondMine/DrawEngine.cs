using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondMine
{
    class DrawEngine
    {        
        private int screenWidth;
        private int screenHeight;
        private char[] characterImage = new Char[16];
        private char[] tileImage = new Char[16];
        
        public DrawEngine(int width, int height)
        {
            this.ScreenWidth = width;
            this.ScreenHeight = height;
            Console.CursorVisible = false;
            
        }

        public int ScreenWidth 
        {
            get { return this.screenWidth; }
            set
            {
                if(value < 10 || value > 80)
                {
                    Console.WriteLine("The screen width can not be less than 10 and more than 80!");
                }
                else
                {
                    this.screenWidth = value;
                }
            }
        }

        public int ScreenHeight
        {
            get { return this.screenHeight; }
            set
            {
                if (value < 5 || value > 50)
                {
                    Console.WriteLine("The screen height can not be less than 5 and more than 50!");
                }
                else
                {
                    this.screenHeight = value;
                }
            }
        }

        public char[] TileImage 
        {
            get { return this.tileImage; }
        }

        public int createCharacter(char charSymbol, int index)
        {
            if(index >= 0 && index < 16)
            {
                characterImage[index] = charSymbol;
                return index;
            }

            return -1;
        }

        public void deleteCharacter(int index)
        {

        }

        public void drawCharacter(int index, int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(characterImage[index]);
        }

        public void eraseCharacter(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(" ");
        }

        public void createBackgroundTile(int index, char c)
        {
            if(index >= 0 && index < 16)
            {
                tileImage[index] = c;
            }
        }

        public void drawBackground(char[,] map)
        {           
            if(map.Length > 0)
            {
                for (int h = 0; h < screenHeight; h++)
                {
                    Console.SetCursorPosition(0, h);
                    for (int w = 0; w < screenWidth; w++)
                    {
                        Console.Write("{0}", map[w,h]);
                    }
                }
            }
        }
    }
}
