using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lez4TicTacToe {
    class Program {

        static void initializeGameScheme(string[,] gameScheme, int rows, int coloumns) {
            //initializing multidimensional array with character "_" inside it
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < coloumns; j++) {
                    gameScheme[i, j] = "_";
                }
            }
        }

        //printing new game scheme with free cells
        static void printGameScheme(string[,] gameScheme, int rows, int coloumns, int freeCells, bool playerWin) {

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

        //a player move
        static bool makeMove(string[,] gameScheme, int rows, int coloumns, string player) {
            int rowSelected, coloumnSelected;
            bool result;

            Console.WriteLine("Player " + player);

            //player input row with checking if it is a number
            Console.WriteLine("Insert the row number");
            if (int.TryParse(Console.ReadLine(), out rowSelected) == false) {
                Console.Clear();
                Console.WriteLine("Wrong input, insert a number");
                result = false;
            } else {

                //check if player's input is a correct number of row
                if (rowSelected <= 0 || rowSelected > rows) {
                    Console.Clear();
                    Console.WriteLine("The row inserted is wrong");
                    result = false;
                } else {
                    //player input coloumn with checking if it is a number
                    Console.WriteLine("Insert the coloumn number");
                    if (int.TryParse(Console.ReadLine(), out coloumnSelected) == false) {
                        Console.Clear();
                        Console.WriteLine("Wrong input, insert a number");
                        result = false;
                    } else {

                        //check if player's input is a correct number of coloumn
                        if (coloumnSelected <= 0 || coloumnSelected > coloumns) {
                            Console.Clear();
                            Console.WriteLine("The coloumn inserted is wrong");
                            result = false;
                        } else {
                            //correct the player's input to use it in the array
                            rowSelected--;
                            coloumnSelected--;

                            if (gameScheme[rowSelected, coloumnSelected] != "_") {
                                Console.Clear();
                                Console.WriteLine("Position of the scheme occupied");
                                result = false;
                            } else {
                                //insert player move in the game scheme
                                gameScheme[rowSelected, coloumnSelected] = player;
                                result = true;
                            }
                        }
                    }
                }
            }
            return result;
        }

        //check a winning condition in the scheme for player X or player O
        static bool checkWin(string[,] gameScheme, int rows, int coloumns, string player) {
            bool playerWin = false;

            for (int j = 0; j < coloumns && playerWin == false; j++) {
                int i = 0;
                if (gameScheme[i, j] == player && gameScheme[i + 1, j] == player && gameScheme[i + 2, j] == player) {
                    playerWin = true;
                }
            }
            for (int i = 0; i < rows && playerWin == false; i++) {
                int j = 0;
                if (gameScheme[i, j] == player && gameScheme[i, j + 1] == player && gameScheme[i, j + 2] == player) {
                    playerWin = true;
                }
            }
            if (playerWin == false && gameScheme[0, 0] == player && gameScheme[1, 1] == player && gameScheme[2, 2] == player) {
                playerWin = true;
            }
            if (playerWin == false && gameScheme[0, 2] == player && gameScheme[1, 1] == player && gameScheme[2, 0] == player) {
                playerWin = true;
            }
            return playerWin;
        }

        //change player's turn
        static string changePlayerTurn(int freeCells) {
            if (freeCells % 2 == 0) {
                return "O";
            } else {
                return "X";
            }
        }

        static void Main(string[] args) {
            string[,] gameScheme;
            string player;
            int rows, coloumns, freeCells, countMoves;
            bool playerWin;

            //initializing rows and coloumns of our game scheme
            rows = 3;
            coloumns = 3;

            //initializing multidimensional array with character "_" inside it
            gameScheme = new string[rows, coloumns];
            initializeGameScheme(gameScheme, rows, coloumns);

            //initializing which player start
            player = "X";

            //initializing variables to use in printGameScheme and in the for cycle
            freeCells = rows * coloumns;
            playerWin = false;

            //printing game scheme
            printGameScheme(gameScheme, rows, coloumns, freeCells, playerWin);

            //for cycle until there will be no more cells free or a player win, counting the number of moves in the game
            for (countMoves = 0; freeCells > 0 && playerWin==false; countMoves++) {

                if (makeMove(gameScheme,rows,coloumns,player)) {
                    //insert ok, decrement the value of the freeCells in the gameScheme and clear the console for the next input
                    freeCells--;
                    Console.Clear();

                    if (checkWin(gameScheme, rows, coloumns, player)) {
                        playerWin = true;
                    } else {
                        //change player's turn
                        player = changePlayerTurn(freeCells);
                    }
                }

                //printing new game scheme with free cells
                printGameScheme(gameScheme,rows,coloumns,freeCells,playerWin);

            }

            if (playerWin == false) {
                Console.WriteLine("The Game end with a DRAW");
            } else {
                Console.WriteLine("Player " + player + " WIN in " + countMoves + " moves");
            }

            Console.WriteLine("--- Press any key to continue ---");
            Console.ReadLine();

        }
    }
}