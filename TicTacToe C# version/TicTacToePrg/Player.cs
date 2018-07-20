using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToePrg
{
    class Player
    {
        public bool Isplayer = true;
        
        private string player;

        public Player(bool flag)
        {
            if(flag)
            GetPlayerName = Console.ReadLine();    
            
        }//C-tor   
        


        public string GetPlayerName
        {
            get { return player; }
            set { player = value; }
        }//prop - GetPlayerName


        private void ValidBoardPlce(int x, int y,Board brd)
        {
            if (brd.CharMatrix[x, y] == 'X' || brd.CharMatrix[x, y] == 'O')
            {
                throw new Exception("you cant put a symbole in this place");
            }
        }//ValidBoardPlce
        

        public int GetPlayerInput(Board brd,Node n,AI comp,int depght)
        {
            int num = 0;
            if (Isplayer)
            {

                do
                {

                    int.TryParse(Console.ReadLine(), out num);
                } while (num < 1 || num > 9);
            }
            else
            {
                
                 n = comp.MiniMax(brd, depght, false);
                num = 1+(n.X * 3 + n.Y);
                //iplement x and y cordinents to single number.              

            }
            
            

            try
            {
                switch (num)
                {
                    case 1:
                        ValidBoardPlce(0, 0, brd);
                        break;
                    case 2:
                        ValidBoardPlce(0, 1, brd);
                        break;
                    case 3:
                        ValidBoardPlce(0, 2, brd);
                        break;
                    case 4:
                        ValidBoardPlce(1, 0, brd);
                        break;
                    case 5:
                        ValidBoardPlce(1, 1, brd);
                        break;
                    case 6:
                        ValidBoardPlce(1, 2, brd);
                        break;
                    case 7:
                        ValidBoardPlce(2, 0, brd);
                        break;
                    case 8:
                        ValidBoardPlce(2, 1, brd);
                        break;
                    case 9:
                        ValidBoardPlce(2, 2, brd);
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                num = GetPlayerInput(brd,n,comp,depght);
            }

            return num;
        }//GetPlayerInput - validet the number from the player.

        

    }//Player

}//TicTacToePrg
