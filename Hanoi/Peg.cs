using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Peg
    {
        private Disc[] discs;
        private int left;
        private int top;
        private int bot;
        private int index;
        private int size;
        
        // Create a peg with the following parameters:
        // maxDisc: the maximum number of discs in the game
        // left, top, bot:
        // the peg is draw as a line of two pipes (||)
        // from <left, top> to <left, bot> 
        public Peg(int maxDisc, int left, int top, int bot)
        {
            discs = new Disc[maxDisc];
            index = -1;
            this.left = left;
            this.top = top;
            this.bot = bot;
            size = maxDisc;
        }

        // Pushes dsc into the peg
        // if the peg is empty
        // or dsc.Size < size of the top disc in peg
        public bool Push(Disc dsc)
        {
            if (DiscCount() == 0 || dsc.Size < Peek().Size)
            {
                index++;
                discs[index] = dsc;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Pops a Disc from the peg and return
        public Disc Pop()
        {
            if(size > 0)
            {
                Disc disc = discs[index];
                discs[index] = null;

                index--;

                return disc;
            }

            return null;
        }

        // Returns the top most Disc without popping
        public Disc Peek()
        {
            if (index >= 0)
            {
                return discs[index];
            }

            return null;
        }

        // Draw the peg and all the discs in it.
        public void Draw()
        {
            // draw the pole
            for (int row = 0; row < 8; row++)
            {
                Console.SetCursorPosition(left, top + row);
                Console.Write("{0}", "||");
            }

            // draw the discs
            for(int row = index; row >= 0; row--)
            {
                discs[row].Draw();
            }
        }

        // Returns the number of discs in the peg
        public int DiscCount()
        {
            return index+1;
        }
    }
}
