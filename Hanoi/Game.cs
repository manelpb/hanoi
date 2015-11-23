using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Game
    {
        private int moves;
        private int nDisc;
        private Peg[] pegs;

        // Constructor :
        // takes the number of discs ( nDisc ) in the game.
        // 1. Creates 3 pegs
        // 2. Creates n discs with size 1, 2, 3 etc. and pushes them to peg 0
        // 3. Sets Console size to Map.MaxLeft and Map.MaxTop
        // 4. Push the discs in Pegs[0]
        public Game(int nDisc)
        {
            pegs = new Peg[3];
            pegs[0] = new Peg(nDisc, Map.PegLeft[0], Map.PegTop, Map.PegBot);
            pegs[1] = new Peg(nDisc, Map.PegLeft[1], Map.PegTop, Map.PegBot);
            pegs[2] = new Peg(nDisc, Map.PegLeft[2], Map.PegTop, Map.PegBot);

            for (int i = nDisc-1, index = 0; i >= 0; i--, index++)
            {
                pegs[0].Push(new Disc(i+1, Map.PegLeft[0], Map.PegBot - index, Map.DiskColors[i]));
            }

            Console.SetWindowSize(Map.MaxLeft, Map.MaxTop);

            this.nDisc = nDisc;
            moves = 0;
        }

        // Computer solve the game
        public void ComputerPlays(int discs, int src, int aux, int dst)
        {
            if(discs > 0)
            {
                ComputerPlays(discs - 1, src, dst, aux);
                Move(src, dst);
                ComputerPlays(discs - 1, aux, src, dst);
            }
        }

        // Moves top disk of Pegs[src] to Pegs[dst] if 
        // IF src and dst are in [0...2] and
        // Pegs[src] has a disc and
        // (Pegs[dst] is empty or
        // top disc in Pegs[dst] > top disc in Pegs[src])
        // returns true if the move was  done
        // Does not redraw the board
        public bool Move(int src, int dst)
        {
            try
            {
                // update movements number
                moves++;

                // proceed with moves
                if (src >= 0 && src <= 2 && dst >= 0 && dst <= 2 && pegs[src].DiscCount() > 0)
                {
                    if(pegs[dst].Push(pegs[src].Peek()))
                    {
                        pegs[dst].Peek().Move(Map.PegLeft[dst], Map.PegBot - pegs[dst].DiscCount()+1);

                        pegs[src].Pop();

                        return true;
                    }
                } 

                return false;
            }
            catch
            {
                return false;
            }            
        }

        // Prints msg to Map.MsgLeft, Map.MsgTop location
        // in yellow text on dark red background
        public void Message(string msg)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Map.MsgLeft, Map.MsgTop);

            Console.Write(msg);

            Console.ResetColor();
        }

        // Draws the followings:
        // 0. Clear the screen first
        // 1. Base line from <Map.Baseleft, Map.BaseTop> to
        // <Map.BaseRight, Map.BaseTop>
        // 2. Three pegs and the discs in them
        // 3. Number of moves at <Map.MovesLeft, Map.MovesTop>
        public void Draw()
        {
            Console.Clear();

            // create the base
            Console.SetCursorPosition(Map.BaseLeft, Map.BaseTop);
            for(int i = Map.BaseLeft; i <= Map.BaseRight; i++)
            {
                Console.Write("=");
            }

            // create the pegs
            for(int i = 0; i < pegs.Length; i++)
            {
                pegs[i].Draw();
            }
            
            // create moves
            Console.SetCursorPosition(Map.MovesLeft, Map.MovesTop);
            Console.Write("Moves: {0}", moves);
        }

        // Checks if the game is over,
        // i.e. right peg has all the discs
        public bool Win()
        {
            return (pegs[2].DiscCount() == nDisc);
        }

        // Prints source peg prompt "Src peg (1,2,3,q):"
        // at position <Map.SrcLeft, Map.SrcTop>
        public void SrcPegPrompt()
        {
            Console.SetCursorPosition(Map.SrcLeft, Map.SrcTop);
            Console.Write("Src peg (1,2,3,q): ");
        }

        // Prints destination peg prompt "Dst peg (1,2,3,q): "
        // at position <Map.DstLeft, Map.DstTop>
        public void DstPegPrompt()
        {
            Console.SetCursorPosition(Map.DstLeft, Map.DstTop);
            Console.Write("Dst peg (1,2,3,q): ");
        }
    }
}
