using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToePrg
{
    class Board
    {
        public Board()
        {
            CleanBoard();
        }//C-tor
        
        private char _symbol;
        
        private int _turnOf = (int)_players.PLAYER1;

        public char[,] CharMatrix = new char[3, 3];       

        public enum _players
        {
            PLAYER1 = 1,
            PLAYER2 = 2
        };//enum

        public void CleanBoard()
        {
            CharMatrix[0,0] = '1';
            CharMatrix[0,1] = '2';
            CharMatrix[0,2] = '3';
            CharMatrix[1,0] = '4';
            CharMatrix[1,1] = '5';
            CharMatrix[1,2] = '6';
            CharMatrix[2,0] = '7';
            CharMatrix[2,1] = '8';
            CharMatrix[2,2] = '9';

        }//CleanBoard

        public bool CheakWinning()
        {
            bool flag = false;

            // horizontal rows
            if (CharMatrix[0, 0] == CharMatrix[0, 1] && CharMatrix[0, 1] == CharMatrix[0, 2]) { flag = true; }
            if (CharMatrix[1, 0] == CharMatrix[1, 1] && CharMatrix[1, 1] == CharMatrix[1, 2]) { flag = true; }
            if (CharMatrix[2, 0] == CharMatrix[2, 1] && CharMatrix[2, 1] == CharMatrix[2, 2]) { flag = true; }

            //vertical rows
            if (CharMatrix[0, 0] == CharMatrix[1,0] && CharMatrix[1,0] == CharMatrix[2,0]) { flag = true; }
            if (CharMatrix[0, 1] == CharMatrix[1, 1] && CharMatrix[1, 1] == CharMatrix[2, 1]) { flag = true; }
            if (CharMatrix[0, 2] == CharMatrix[1, 2] && CharMatrix[1, 2] == CharMatrix[2, 2]) { flag = true; }

            //diagonal rows
            if (CharMatrix[0, 0] == CharMatrix[1, 1] && CharMatrix[1, 1] == CharMatrix[2, 2]) { flag = true; }
            if (CharMatrix[0, 2] == CharMatrix[1, 1] && CharMatrix[1, 1] == CharMatrix[2, 0]) { flag = true; }

            return flag;

        }//CheakWinning

        public void DrawBoard()
        {
            for (int i = 0; i < CharMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < CharMatrix.GetLength(1); j++)
                {
                    if (CharMatrix[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|{0}|", CharMatrix[i, j]);
                        Console.ResetColor();
                    }
                    else if (CharMatrix[i, j] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("|{0}|", CharMatrix[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("|{0}|", CharMatrix[i, j]);
                        Console.ResetColor();
                    }

                }
                Console.WriteLine();

            }
        }//DrowBoard

        public void PutSymbol(Player ply,Node n, AI comp,int depght)
        {
            int num  = ply.GetPlayerInput(this,n,comp,depght);
            _symbol = GetCurrentSymbol();

            switch (num)
            {
                case 1:
                    CharMatrix[0, 0] = _symbol;
                    break;
                case 2:
                    CharMatrix[0, 1] = _symbol;
                    break;
                case 3:
                    CharMatrix[0, 2] = _symbol;
                    break;
                case 4:
                    
                    CharMatrix[1, 0] = _symbol;
                    break;
                case 5:
                    
                    CharMatrix[1, 1] = _symbol;
                    break;
                case 6:
                    
                    CharMatrix[1, 2] = _symbol;
                    break;
                case 7:
                    
                    CharMatrix[2, 0] = _symbol;
                    break;
                case 8:
                    
                    CharMatrix[2, 1] = _symbol;
                    break;
                case 9:
                    
                    CharMatrix[2, 2] = _symbol;
                    break;

            }

            // Sets the _turnOf variable for the next player to play
            _turnOf = _turnOf == (int)_players.PLAYER1 ? (int)_players.PLAYER2 : (int)_players.PLAYER1;


        }//PutSymbol

        public char GetCurrentSymbol()
        {
            return _turnOf == (int)_players.PLAYER1 ? 'X' : 'O';
        } // GetCurrentSymbol
        
        public bool IsBoardFull()
        {
            int count = 0;

            foreach (char item in CharMatrix)
            {
                if (item == 'X' || item == 'O')
                    count++;

            }
            if (count == 9)
            return true;

            return false;
        }//IsBoardFull
        public Board CopyBoardMatrix()
        {
            Board nrbd = new Board();
            for (int i = 0; i < CharMatrix.GetLength(0); i++)
            {
                for (int y = 0; y < CharMatrix.GetLength(1); y++)
                {
                    nrbd.CharMatrix[i, y] = CharMatrix[i, y];

                }
            }
            return nrbd;
        }//CopyBoardMatrix - copy the matrix to a new one.

    }//Board
}//TicTacToePrg
