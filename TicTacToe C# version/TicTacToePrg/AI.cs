using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToePrg
{
    class AI
    {
        
        Board tmp_board = new Board(); 

        public Node MiniMax(Board brd , int depht ,bool turnof)
        {
            int[,] score = new int [3,3];
            Node v = new Node();
            Node bestvalue = new Node();
            Board Nbrd = brd.CopyBoardMatrix();
            
            if (depht == 0 || brd.IsBoardFull())
            {
                bestvalue.score = 0;
                return bestvalue;
            }
            

            if (Nbrd.CheakWinning())
            {
              if (turnof)
                {
                    bestvalue.score = -10;
                    return bestvalue;
                }
                else
                {
                    bestvalue.score = 10;
                    return bestvalue;
                }

            }

            if (turnof)
            {

                bestvalue.score = -10000;
                int tmp = bestvalue.score;

                for (int i = 0; i < Nbrd.CharMatrix.GetLength(0); i++)
                {
                    for (int y = 0; y < Nbrd.CharMatrix.GetLength(1); y++)
                    {
                        if (!(Nbrd.CharMatrix[i, y] == 'X' || Nbrd.CharMatrix[i, y] == 'O'))
                        {
                            char z = Nbrd.CharMatrix[i, y];
                            Nbrd.CharMatrix[i, y] = 'X';
                           
                            v = MiniMax(Nbrd, depht - 1, false);
                            
                            bestvalue.score = Max(bestvalue, v).score;
                            if (bestvalue.score != tmp)
                            {
                                bestvalue.X = i;
                                bestvalue.Y = y;
                                tmp = bestvalue.score;
                            }

                            Nbrd.CharMatrix[i, y] = z;
                            score[i, y] = bestvalue.score;

                            
                        }
                    }
                }
                
                
                return bestvalue;
            }
            else
            {

                bestvalue.score = +10000;
                int tmp = bestvalue.score;

                for (int i = 0; i < Nbrd.CharMatrix.GetLength(0); i++)
                {
                    for (int y = 0; y < Nbrd.CharMatrix.GetLength(1); y++)
                    {
                        if (!(Nbrd.CharMatrix[i, y] == 'X' || Nbrd.CharMatrix[i, y] == 'O'))
                        {
                            char z = Nbrd.CharMatrix[i, y];
                            Nbrd.CharMatrix[i, y] = 'O';
                            
                            v = MiniMax(Nbrd, depht - 1, true);
                            
                            bestvalue.score = Min(bestvalue,v).score;
                            if (bestvalue.score != tmp)
                            {
                                bestvalue.X = i;
                                bestvalue.Y = y;
                                tmp = bestvalue.score;
                            }

                            Nbrd.CharMatrix[i, y] = z;

                        }
                    }
                }
                
                return bestvalue;
            }
                                  

        }//MiniMax


        public Node Max (Node n1, Node n2)
        {

            if (n1.score < n2.score)
            {
                return n2;
            }
                return n1;                      
            
            
        }//max 
        public Node Min(Node n1,Node n2)
        {
            if (n1.score < n2.score)
            {
                return n1;
            }
            return n2;
            
        }//min


    }
}
