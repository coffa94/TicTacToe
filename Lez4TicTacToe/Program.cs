using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lez4TicTacToe {
    class Program {
        static void Main(string[] args) {
            string[,] gameScheme;
            string player;
            int rows, coloumns, freeCells, rowSelected, coloumnSelected, countMoves;
            bool playerWin;

            //initializing rows and coloumns of our game scheme
            rows = 3;
            coloumns = 3;

            //initializing multidimensional array with character "_" inside it
            gameScheme = new string[3, 3];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < coloumns; j++) {
                    gameScheme[i, j] = "_";
                }
            }

            //initializing which player start
            player = "X";

            //printing game scheme
            for (int i = 0; i < rows; i++) {
                Console.WriteLine("-------------");
                for (int j = 0; j < coloumns; j++) {
                    if (j < coloumns - 1) {
                        Console.Write("| " + gameScheme[i, j] + " ");
                    } else {
                        Console.WriteLine("| " + gameScheme[i, j] + " |");
                    }
                }
            }
            Console.WriteLine("-------------");
            Console.WriteLine("");

            freeCells = rows * coloumns;
            playerWin = false;

            //for cycle until there will be no more cells free or a player win, counting the number of moves in the game
            for (countMoves = 1; freeCells > 0 && playerWin==false; countMoves++) {
                Console.WriteLine("Player " + player);

                //player input row with checking if it is a number
                Console.WriteLine("Insert the row number");
                if (int.TryParse(Console.ReadLine(), out rowSelected)==false) {
                    Console.WriteLine("");
                    Console.WriteLine("Wrong input, insert a number");
                } else {

                    //check if player's input is a correct number of row
                    if (rowSelected<=0 || rowSelected > rows) {
                        Console.WriteLine("");
                        Console.WriteLine("The row inserted is wrong");
                    } else {
                        //player input coloumn with checking if it is a number
                        Console.WriteLine("Insert the coloumn number");
                        if (int.TryParse(Console.ReadLine(), out coloumnSelected) == false) {
                            Console.WriteLine("");
                            Console.WriteLine("Wrong input, insert a number");
                        } else {

                            //check if player's input is a correct number of coloumn
                            if (coloumnSelected<=0 || coloumnSelected > coloumns) {
                                Console.WriteLine("");
                                Console.WriteLine("The coloumn inserted is wrong");
                            } else {
                                //correct the player's input to use it in the array
                                rowSelected--;
                                coloumnSelected--;

                                if (gameScheme[rowSelected, coloumnSelected] != "_") {
                                    Console.WriteLine("");
                                    Console.WriteLine("Position of the scheme occupied");
                                } else {
                                    //insert player move in the game scheme
                                    gameScheme[rowSelected, coloumnSelected] = player;
                                    freeCells--;

                                    //check a winning condition in the scheme for player X or player O
                                        for (int j = 0; j < coloumns && playerWin == false; j++) {
                                            int i = 0;
                                            if (gameScheme[i, j] == player && gameScheme[i + 1, j] == player && gameScheme[i + 2, j] == player) {
                                                playerWin = true;
                                                Console.WriteLine("");
                                                Console.WriteLine("Player " + player +  " WIN in " + countMoves + " moves");
                                            }
                                        }
                                        for (int i = 0; i < rows && playerWin == false; i++) {
                                            int j = 0;
                                            if (gameScheme[i, j] == player && gameScheme[i, j + 1] == player && gameScheme[i, j + 2] == player) {
                                                playerWin = true;
                                                Console.WriteLine("");
                                                Console.WriteLine("Player " + player + " WIN in " + countMoves + " moves");
                                            }
                                        }
                                        if (playerWin == false && gameScheme[0, 0] == player && gameScheme[1, 1] == player && gameScheme[2, 2] == player) {
                                            playerWin = true;
                                            Console.WriteLine("");
                                            Console.WriteLine("Player " + player + " WIN in " + countMoves + " moves");
                                        }
                                        if (playerWin == false && gameScheme[0, 2] == player && gameScheme[1, 1] == player && gameScheme[2, 0] == player) {
                                            playerWin = true;
                                            Console.WriteLine("");
                                            Console.WriteLine("Player " + player + " WIN in " + countMoves + " moves");
                                        }

                                    //change player's turn
                                    if (player == "X") {
                                        player = "O";
                                    } else {
                                        player = "X";
                                    }

                                }
                            }
                        }
                    }
                }

                //printing new game scheme with free cells
                Console.WriteLine("");
                for (int i = 0; i < rows; i++) {
                    Console.WriteLine("-------------");
                    for (int j = 0; j < coloumns; j++) {
                        if (j < coloumns - 1) {
                            Console.Write("| " + gameScheme[i, j] + " ");
                        } else {
                            Console.WriteLine("| " + gameScheme[i, j] + " |");
                        }
                    }
                }
                Console.WriteLine("-------------");
                if (playerWin == false) {
                    Console.WriteLine("Cells free: " + freeCells);
                }
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------");

            }

            if (playerWin == false) {
                Console.WriteLine("The Game end with a DRAW");
            }

            Console.WriteLine("--- Press any key to continue ---");
            Console.ReadLine();



        }
    }
}