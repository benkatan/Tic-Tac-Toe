using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToePrg
{
    class GameEngine 
    {
         const int endGame = 9;
        
        private int diffuclty = 6;

        public void Game()
        {
             bool currentply = true;
             diffuclty = 0;
            AI comp = new AI();
            Node n = new Node();
            Player tmp = new Player(false);
            Console.Title = "Tic Tac Toe";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to the tic tac toe game ");
            Board board = new Board();
            Console.WriteLine();
            Console.WriteLine("Player 1 please enter your name");
            Player player1 = new Player(true);            
            Player player2 = new Player(false);
            Console.WriteLine("Choose a number from the menu:");
            Console.WriteLine("1.Player vs Player\n2.Player vs Comp\n3.exit");
            int num = ValidSwichInput(tmp);
            switch (num)
            {
                case 1:
                    player1.Isplayer = true;
                    Console.WriteLine("Player 2 please enter your name");
                    player2.GetPlayerName = Console.ReadLine();

                    break;
                case 2:
                    player2.Isplayer = false;
                    
                    player2.GetPlayerName = "COMP";
                    Console.WriteLine("Pls choos diffucolty:\n1.Easy\n2.Medium\n3.Impossible");
                    int choose = ValidChoos();
                    switch (choose)
                    {
                        case 1:
                            diffuclty = 4;
                            break;
                        case 2:
                            diffuclty = 6;
                            break;
                        case 3:
                            diffuclty = 12;
                            break;
                    }

                    break;
                case 3:
                    EndGame(10);
                    return;


            }

           
            Console.ResetColor();
            int i;
            for ( i = 0; i < endGame; i++)
            {
                board.DrawBoard();
                Console.WriteLine("Pleas enter a number from the board");
                CurrentPlayerMove(player1, player2, board);
                if (currentply)
                {
                    board.PutSymbol(player1,n,comp,diffuclty);
                    currentply = false;
                }else
                {
                    board.PutSymbol(player2,n,comp,diffuclty);
                    currentply = true;

                }
                
                
                    if (board.CheakWinning())
                    {
                        this.PrintWinner(player1, player2, board);
                        break;
                    }
                    
                    
                
                Console.Clear();
                
            }
            board.DrawBoard();
            EndGame(i);






        }//Game - Method that lops the game.

        private void EndGame(int iterasion)
        {
            if (iterasion == endGame)
            {
                Console.WriteLine("it is a Tie");
            }

            Console.WriteLine("The game is ended if you want to play againg pls enter 'Y' if not press 'N'");
            string input = Console.ReadLine();
            if (input == "Y" || input == "y") { Game(); }
            if (input == "N" || input == "n") { return; }
        }//endgame

        private void CurrentPlayerMove(Player player1, Player player2,Board board)
        {
            if (board.GetCurrentSymbol() == 'X')
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0} your turn! :)", player1.GetPlayerName);
                Console.ResetColor();
                
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("{0} your turn! :)", player2.GetPlayerName);
                Console.ResetColor();
            }
        }//print the players name in  the currnet move

        public void PrintWinner(Player s, Player t, Board brd)
        {
            if (brd.GetCurrentSymbol() == 'O')
            {
                Console.WriteLine("^^^^^^^^^^^^^^^^^");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} is the winner", s.GetPlayerName);
                Console.ResetColor();
                Console.WriteLine("^^^^^^^^^^^^^^^^^");

            }
            else
            {
                Console.WriteLine("^^^^^^^^^^^^^^^^");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} is the winner", t.GetPlayerName);
                Console.ResetColor();
                Console.WriteLine("^^^^^^^^^^^^^^^^");
            }
        }//PrintWinne
        public int ValidSwichInput(Player n )
        {
             
            int num = 0;
            if (n.Isplayer)
            {
                
                while (int.TryParse(Console.ReadLine(), out num))
                {
                    if (num < 1 || num > 3)
                    {
                        Console.WriteLine("ONLY NUMBERS FROM THE MENU CAN WORK :)");
                    }
                    else
                    {
                        break;
                    }

                }
                
            }
            return num;
        }
        public int ValidChoos()//ValidChoos
        {
            int num = 0;
            while ( int.TryParse(Console.ReadLine(), out num))
            {
                if (num < 1 || num > 3)
                {
                    Console.WriteLine("ONLY NUMBERS FROM THE MENU CAN WORK :)");
                }
                else
                {
                    break;
                }
                
            }
            return num;
        }

    }//GameEngine

}//TicTacToePrg
