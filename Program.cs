/*
This game is done for learning, in the lesson named PBL(Project Based Learning 
*/

using System;
using System.Threading;
using System.IO;
namespace Project2

{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            bool menu_bool = true;
            while (menu_bool)
            {
                //Main Menu starts here

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═════════════════════ Welcome to The Binary Sudoku Game... ═══════════════════╗");
                for (int i = 0; i <= 7; i++)
                    Console.WriteLine("║                                                                              ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(3, 1);
                Console.WriteLine("  Enter '1' to  Start Game\n");
                Console.SetCursorPosition(3, 2);
                Console.WriteLine("  Enter '2' to About the Game\n");
                Console.SetCursorPosition(3, 3);
                Console.WriteLine("  Enter '3' to High Score Table \n");
                Console.SetCursorPosition(3, 4);
                Console.WriteLine("  Enter '4' to Exit The Game\n");
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("╔══════╗");
                Console.SetCursorPosition(5, 6);
                Console.WriteLine("║      ║");
                Console.SetCursorPosition(5, 7);
                Console.WriteLine("║      ║");
                Console.SetCursorPosition(5, 8);
                Console.WriteLine("╚══════╝");
                Console.SetCursorPosition(7, 6);
                Console.ResetColor();

                int menu = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║                                                            ║");
                            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                            Console.SetCursorPosition(1, 1);
                            Console.WriteLine("Please enter your name:");
                            Console.SetCursorPosition(24, 1);
                            string name = Console.ReadLine();

                            Console.Clear();
                            //Creating some variables, Board(as an array), boolean to end game etc.
                            bool game_over = false;
                            int[,] Board = new int[9, 9];
                            int[,] Piece_elements = new int[3, 3];
                            int piece_number = 1;
                            int score = 0;

                            /*
                            Making all elements of Board 3 
                            3 is used randomly to avoid the calculating and outputs error
                            because element's values comes 0 as default 
                            */
                            for (int i = 0; i < Board.GetLength(0); i++)
                                for (int k = 0; k < Board.GetLength(1); k++)
                                    Board[i, k] = 3;
                            int piece = rd.Next(0, 10);

                            //Creating a while loop depends the boolean named game_over
                            while (!(game_over))
                            {
                                //Getting piece randomly
                                //Creating a for loop to setting the outputs
                                //Cursorx is constant but cursory depends the k 
                                int cursorx = 3; int cursory = 3;
                                Console.SetCursorPosition(cursorx, cursory);
                                //Setting the pieces of Game board
                                Console.Write("1  2  3  4  5  6  7  8  9");
                                for (int i = 0; i < 20; i += 6)
                                {
                                    Console.SetCursorPosition(cursorx - 1, cursory + 1 + i);
                                    Console.WriteLine("+--------+--------+--------+");
                                }

                                for (int c = 2; c < 20; c += 2)
                                {
                                    Console.SetCursorPosition(cursorx - 2, cursory + c);
                                    Console.WriteLine((c / 2) + (1 / 2));
                                    Console.WriteLine();
                                }
                                for (int c = 0; c < 17; c++)
                                {
                                    if (c == 5 || c == 11)
                                    {
                                        Console.SetCursorPosition(cursorx - 1, cursory + 2 + c);
                                        Console.WriteLine("+");
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(cursorx - 1, cursory + 2 + c);
                                        Console.WriteLine("|");
                                        Console.SetCursorPosition(cursorx + 8, cursory + 2 + c);
                                        Console.WriteLine("|");
                                        Console.SetCursorPosition(cursorx + 17, cursory + 2 + c);
                                        Console.WriteLine("|");
                                        Console.SetCursorPosition(cursorx + 26, cursory + 2 + c);
                                        Console.WriteLine("|");
                                    }
                                }

                                //WRITING BOARD
                                //y is used to set the rows and t for columns
                                int t = 0;
                                int y = 0;
                                for (int i = 0; i < Board.GetLength(0); i++)
                                {
                                    y = 0;
                                    for (int l = 0; l < Board.GetLength(1); l++)
                                    {
                                        Console.SetCursorPosition(cursorx + y, cursory + 2 + t);

                                        if (!(Board[i, l] == 3))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine(Board[i, l] + "  ");
                                            y = y + 3;
                                        }
                                        else if (Board[i, l] == 3)
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("." + "  ");
                                            y = y + 3;
                                        }
                                    }
                                    t += 2;
                                }

                                //Making all of elements of Piece_elements 3
                                //3 is used randomly to avoid the calculating and outputs error
                                //because elements value comes 0 as default
                                for (int i = 0; i < Piece_elements.GetLength(0); i++)
                                    for (int j = 0; j < Piece_elements.GetLength(1); j++)
                                        Piece_elements[i, j] = 3;

                                //Creating Piece_elements_0 to assign a value randomly to the Piece_elements matrix
                                int Piece_elements_0;
                                switch (piece)
                                {
                                    case 0:
                                        Piece_elements_0 = rd.Next(0, 2);
                                        Piece_elements[0, 0] = Piece_elements_0;
                                        break;
                                    case 1:
                                        for (int i = 0; i < 2; i++)
                                        {
                                            Piece_elements_0 = rd.Next(0, 2);
                                            Piece_elements[0, i] = Piece_elements_0;
                                        }
                                        break;
                                    case 2:
                                        for (int i = 0; i < 2; i++)
                                        {
                                            Piece_elements_0 = rd.Next(0, 2);
                                            Piece_elements[i, 0] = Piece_elements_0;
                                        }
                                        break;
                                    case 3:
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Piece_elements_0 = rd.Next(0, 2);
                                            Piece_elements[0, i] = Piece_elements_0;
                                        }
                                        break;
                                    case 4:
                                        for (int i = 0; i < 3; i++)
                                        {
                                            Piece_elements_0 = rd.Next(0, 2);
                                            Piece_elements[i, 0] = Piece_elements_0;
                                        }
                                        break;
                                    case 5:
                                        for (int i = 0; i < 2; i++)
                                        {
                                            Piece_elements_0 = rd.Next(0, 2);
                                            Piece_elements[0, i] = Piece_elements_0;
                                        }
                                        Piece_elements_0 = rd.Next(0, 2);
                                        Piece_elements[1, 0] = Piece_elements_0;
                                        break;
                                    case 6:
                                        for (int i = 0; i < 2; i++)
                                        {
                                            Piece_elements_0 = rd.Next(0, 2);
                                            Piece_elements[0, i] = Piece_elements_0;
                                        }
                                        Piece_elements_0 = rd.Next(0, 2);
                                        Piece_elements[1, 1] = Piece_elements_0;
                                        break;
                                    case 7:
                                        Piece_elements_0 = rd.Next(0, 2);
                                        Piece_elements[0, 0] = Piece_elements_0;
                                        for (int i = 0; i < 2; i++)
                                        {
                                            Piece_elements_0 = rd.Next(0, 2);
                                            Piece_elements[1, i] = Piece_elements_0;
                                        }
                                        break;
                                    case 8:
                                        Piece_elements_0 = rd.Next(0, 2);
                                        Piece_elements[0, 1] = Piece_elements_0;
                                        for (int i = 0; i < 2; i++)
                                        {
                                            Piece_elements_0 = rd.Next(0, 2);
                                            Piece_elements[1, i] = Piece_elements_0;
                                        }
                                        break;
                                    case 9:
                                        for (int i = 0; i < 2; i++)
                                            for (int j = 0; j < 2; j++)
                                            {
                                                Piece_elements_0 = rd.Next(0, 2);
                                                Piece_elements[i, j] = Piece_elements_0;
                                            }
                                        break;
                                    default:
                                        break;
                                }

                                //Writing Piece
                                for (int i = 0; i < Piece_elements.GetLength(0); i++)
                                {
                                    for (int j = 0; j < Piece_elements.GetLength(1); j++)
                                    {
                                        //3 is important for writing
                                        if (Piece_elements[i, j] != 3)
                                        {
                                            Console.SetCursorPosition(cursorx + 58 + j, cursory + 5 + i);
                                            Console.Write(Piece_elements[i, j]);
                                        }
                                    }
                                }
                                //Creating and writing Score and piece to give info the user
                                Console.SetCursorPosition(cursorx + 100, cursory);
                                Console.WriteLine($"Score: {score}");
                                Console.SetCursorPosition(cursorx + 100, cursory + 2);
                                Console.WriteLine($"Piece: {piece_number}");
                                piece_number += 1;
                                Console.SetCursorPosition(cursorx + 55, cursory);
                                Console.WriteLine("New Piece");

                                //Moving on the board
                                //For while loop, a loop named moving_end is created
                                bool moving_end = false;
                                ConsoleKeyInfo cki;
                                //Currently active cursorx-y is assigned to temp_cursorx-y 
                                //Because to reach which elements user selected
                                int temp_cursor_x = cursorx;
                                int temp_cursor_y = cursory;
                                cursorx += 25;
                                cursory += 10;
                                Console.SetCursorPosition(cursorx, cursory);
                                Console.Write("X");

                                while (!(moving_end))
                                {
                                    if (Console.KeyAvailable)
                                    {
                                        //Cleaning the area of calculations
                                        for (int y1 = 0; y1 < 20; y1++)
                                            for (int x = 0; x < 10; x++)
                                            {
                                                Console.SetCursorPosition(temp_cursor_x + 38 + y1, temp_cursor_y + 15 + x);
                                                Console.WriteLine(" ");
                                            }

                                        cki = Console.ReadKey(true);
                                        //In the below, note the condition on the right-side
                                        //It avoids to go out of Game Board
                                        if (cki.Key == ConsoleKey.UpArrow && cursory > temp_cursor_y + 2)
                                            if (cursorx == temp_cursor_x + 25)
                                            {
                                                Console.SetCursorPosition(cursorx, cursory);
                                                Console.WriteLine(" ");
                                                cursory -= 2;
                                                cursorx -= 1;
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(cursorx, cursory);
                                                Console.WriteLine(" ");
                                                cursory -= 2;
                                            }

                                        if (cki.Key == ConsoleKey.DownArrow && cursory < temp_cursor_y + 18)
                                        {
                                            if (cursorx == temp_cursor_x + 25)
                                            {
                                                Console.SetCursorPosition(cursorx, cursory);
                                                Console.WriteLine(" ");
                                                cursory += 2;
                                                cursorx -= 1;
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(cursorx, cursory);
                                                Console.WriteLine(" ");
                                                cursory += 2;
                                            }
                                        }
                                        if (cki.Key == ConsoleKey.RightArrow && cursorx < temp_cursor_x + 24)
                                        {
                                            Console.SetCursorPosition(cursorx, cursory);
                                            Console.WriteLine(" ");
                                            cursorx += 3;

                                        }
                                        if (cki.Key == ConsoleKey.LeftArrow && cursorx > temp_cursor_x)
                                        {
                                            if (cursorx == temp_cursor_x + 25)
                                            {
                                                Console.SetCursorPosition(cursorx, cursory);
                                                Console.WriteLine(" ");
                                                cursorx -= 1;
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(cursorx, cursory);
                                                Console.WriteLine(" ");
                                                cursorx -= 3;
                                            }
                                        }

                                        if (cki.Key == ConsoleKey.Spacebar && cursorx != temp_cursor_x + 25)
                                        {
                                            //Creating some variables to find which elements of Board user decides
                                            int row = 0;
                                            int column = 0;

                                            //Finding column
                                            for (int i = 0; i < Board.GetLength(0); i++)
                                            {
                                                if (cursorx == temp_cursor_x + (3 * i))
                                                column = i;
                                                if (cursory == temp_cursor_y + 2 + (2 * i))
                                                    row = i;
              
                                            }


                                            bool overload = false;

                                            //Changing the value
                                            //Checking for exceptionals 
                                            if (piece == 8 && column == 8)
                                            {
                                                overload = true;
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(temp_cursor_x + 45, temp_cursor_y + 10);
                                                Console.WriteLine("Please Be Careful! Try again");
                                            }
                                            else if ((piece != 0 && piece != 2 && piece != 4) && (column == 8))
                                            {
                                                overload = true;
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(temp_cursor_x + 45, temp_cursor_y + 10);
                                                Console.WriteLine("Please Be Careful! Try again");
                                            }
                                            else if (piece == 3 && column == 7)
                                            {
                                                overload = true;
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(temp_cursor_x + 45, temp_cursor_y + 10);
                                                Console.WriteLine("Please Be Careful! Try again");
                                            }
                                            else if ((piece == 2 || piece == 4 || piece == 6 || piece == 5 || piece == 7 || piece == 8 || piece == 9) && (row == 8))
                                            {
                                                overload = true;
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(temp_cursor_x + 45, temp_cursor_y + 10);
                                                Console.WriteLine("Please Be Careful! Try again");
                                            }
                                            else if (piece == 4 && row == 7)
                                            {
                                                overload = true;
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(temp_cursor_x + 45, temp_cursor_y + 10);
                                                Console.WriteLine("Please Be Careful! Try again");
                                            }

                                            //Creating collision bool for being row or column to already filled
                                            bool collision = false;

                                            if (overload == false)
                                            {
                                                //Checking collision
                                                for (int i = 0; i < Piece_elements.GetLength(0); i++)
                                                {
                                                    for (int j = 0; j < Piece_elements.GetLength(1); j++)
                                                    {
                                                        if (Piece_elements[i, j] != 3 && (Board[row + i, column + j] != 3))
                                                        {
                                                            collision = true;
                                                        }
                                                    }
                                                }
                                            }
                                            if (collision == true)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.SetCursorPosition(temp_cursor_x + 45, temp_cursor_y + 10);
                                                Console.WriteLine("Please Be Careful! Try again");
                                            }
                                            if (overload == false && collision == false)
                                            {
                                                for (int i = 0; i < Piece_elements.GetLength(0); i++)
                                                {
                                                    //Cleaning the warning after given right keyboard input
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.SetCursorPosition(temp_cursor_x + 45, temp_cursor_y + 10);
                                                    Console.WriteLine("                            ");

                                                    for (int j = 0; j < Piece_elements.GetLength(1); j++)
                                                        if (Piece_elements[i, j] != 3)
                                                            Board[row + i, column + j] = Piece_elements[i, j];
                                                }

                                                //Cleaning the old piece
                                                for (int i = 0; i < Piece_elements.GetLength(0); i++)
                                                {
                                                    for (int j = 0; j < Piece_elements.GetLength(1); j++)
                                                    {
                                                        Console.SetCursorPosition(temp_cursor_x + 58 + j, temp_cursor_y + 5 + i);
                                                        Console.Write(" ");
                                                    }
                                                }
                                                moving_end = true;
                                                break;
                                            }

                                        }
                                        //Writing the Board after every input coming the keyboard 
                                        t = 0;
                                        for (int i = 0; i < Board.GetLength(0); i++)
                                        {
                                            y = 0;
                                            for (int l = 0; l < Board.GetLength(1); l++)
                                            {
                                                Console.SetCursorPosition(temp_cursor_x + y, temp_cursor_y + 2 + t);
                                                if (!(Board[i, l] == 3))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.WriteLine(Board[i, l] + "  ");
                                                    y = y + 3;
                                                }
                                                else if (Board[i, l] == 3)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("." + "  ");
                                                    y = y + 3;
                                                }
                                            }
                                            t = t + 2;
                                        }
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.SetCursorPosition(temp_cursor_x, temp_cursor_y);
                                        Console.Write("1  2  3  4  5  6  7  8  9");
                                        for (int i = 0; i < 20; i += 6)
                                        {
                                            Console.SetCursorPosition(temp_cursor_x - 1, temp_cursor_y + 1 + i);
                                            Console.WriteLine("+--------+--------+--------+");
                                        }

                                        for (int c = 2; c < 20; c += 2)
                                        {
                                            Console.SetCursorPosition(temp_cursor_x - 2, temp_cursor_y + c);
                                            Console.WriteLine((c / 2) + (1 / 2));
                                            Console.WriteLine();
                                        }
                                        for (int c = 0; c < 17; c++)
                                        {
                                            if (c == 5 || c == 11)
                                            {
                                                Console.SetCursorPosition(temp_cursor_x - 1, temp_cursor_y + 2 + c);
                                                Console.WriteLine("+");
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(temp_cursor_x - 1, temp_cursor_y + 2 + c);
                                                Console.WriteLine("|");
                                                Console.SetCursorPosition(temp_cursor_x + 8, temp_cursor_y + 2 + c);
                                                Console.WriteLine("|");
                                                Console.SetCursorPosition(temp_cursor_x + 17, temp_cursor_y + 2 + c);
                                                Console.WriteLine("|");
                                                Console.SetCursorPosition(temp_cursor_x + 26, temp_cursor_y + 2 + c);
                                                Console.WriteLine("|");
                                            }
                                        }
                                        Console.SetCursorPosition(cursorx, cursory);
                                        Console.Write("X");
                                    }

                                }

                                //Calculating score
                                int sum = 0;
                                int sum_score = 0;
                                int wroten = 0;
                                int score_times = 0;
                                //For specifizing elements to delete, creating an array 
                                int[] deleting_elements = new int[6];
                                int index = 0;
                                //Making all of elements array named deleting_elements 10
                                for (int i = 0; i < deleting_elements.Length; i++)
                                    deleting_elements[i] = 10;
                                //Checking the rows
                                for (int i = 0; i < Board.GetLength(0); i++)
                                {
                                    int counter = 0;
                                    for (int j = 0; j < Board.GetLength(1); j++)
                                    {
                                        if (Board[i, j] != 3)
                                        {
                                            counter += 1;
                                            if (counter == 9)
                                            {
                                                deleting_elements[index] = i;
                                                index++;
                                                score_times++;
                                                string[] calculations = new string[2];
                                                string calculations_0 = "";
                                                for (int s = 0; s < Board.GetLength(1); s++)
                                                {
                                                    sum += (Board[i, s] * Convert.ToInt32(Math.Pow(2, 8 - s)));
                                                    calculations_0 += Convert.ToString(Board[i, s]);
                                                }
                                                sum_score += sum;
                                                calculations[1] = Convert.ToString(sum);
                                                calculations[0] = calculations_0;
                                                Console.SetCursorPosition(temp_cursor_x + 38, temp_cursor_y + 15 + wroten);
                                                Console.WriteLine($"({calculations[0]})2 = ({calculations[1]})10 ");
                                                wroten++;
                                            }
                                        }

                                    }
                                }
                                index = 3;
                                sum = 0;
                                //Checking the Columns
                                for (int i = 0; i < Board.GetLength(0); i++)
                                {
                                    int counter = 0;
                                    for (int j = 0; j < Board.GetLength(1); j++)
                                    {
                                        if (Board[j, i] != 3)
                                        {
                                            counter += 1;
                                            if (counter == 9)
                                            {
                                                deleting_elements[index] = i;
                                                index++;
                                                score_times++;
                                                string[] calculations = new string[2];
                                                string calculations_0 = "";
                                                for (int s = 0; s < Board.GetLength(1); s++)
                                                {
                                                    sum += (Board[s, i] * Convert.ToInt32(Math.Pow(2, 8 - s)));
                                                    calculations_0 += Convert.ToString(Board[s, i]);
                                                }
                                                sum_score += sum;
                                                calculations[1] = Convert.ToString(sum);
                                                calculations[0] = calculations_0;
                                                Console.SetCursorPosition(temp_cursor_x + 38, temp_cursor_y + 15 + wroten);
                                                Console.WriteLine($"({calculations[0]})2 = ({calculations[1]})10 ");
                                                wroten++;
                                            }
                                        }

                                    }
                                }

                                //Checking 3X3 blocks
                                int block_row = 0;
                                int block_column = 0;
                                sum = 0;
                                for (int i = 0; i < 9; i++)
                                {

                                    if (i == 1 || i == 2 ||
                                        i == 4 || i == 5 ||
                                        i == 7 || i == 8)
                                    {
                                        block_column += 3;
                                    }
                                    if (i == 3 || i == 6)
                                    {
                                        block_row += 3;
                                        block_column = 0;
                                    }
                                    int counter = 0;
                                    for (int j = 0; j < 3; j++)
                                        for (int k = 0; k < 3; k++)
                                        {
                                            if (Board[block_row + j, block_column + k] != 3)
                                                counter++;

                                            if (counter == 9)
                                            {
                                                score_times++;
                                                string[] calculations = new string[2];
                                                string calculations_0 = "";
                                                int pow = 0;
                                                for (int r = 0; r < 3; r++)
                                                    for (int c = 0; c < 3; c++)
                                                    {
                                                        sum += (Board[block_row + r, block_column + c] * Convert.ToInt32(Math.Pow(2, 8 - pow)));
                                                        calculations_0 += Convert.ToString(Board[block_row + r, block_column + c]);
                                                        Board[block_row + r, block_column + c] = 3;
                                                        pow += 1;
                                                    }

                                                sum_score += sum;
                                                calculations[1] = Convert.ToString(sum);
                                                calculations[0] = calculations_0;
                                                Console.SetCursorPosition(temp_cursor_x + 38, temp_cursor_y + 15 + wroten);
                                                Console.WriteLine($"({calculations[0]})2 = ({calculations[1]})10 ");
                                                wroten++;
                                            }
                                        }
                                }
                                if (score_times > 1)
                                {
                                    Console.SetCursorPosition(temp_cursor_x + 38, temp_cursor_y + 16 + wroten);
                                    Console.WriteLine($"Because of {score_times} point at the same time");
                                    Console.SetCursorPosition(temp_cursor_x + 38, temp_cursor_y + 17 + wroten);
                                    Console.WriteLine($"{sum_score} * {score_times} = {(score_times) * sum_score}");
                                }
                                score += ((score_times) * sum_score);

                                //Deleting elements
                                for (int i = 0; i < deleting_elements.Length; i++)
                                {
                                    if (deleting_elements[i] != 10)
                                    {
                                        if (i == 0 || i == 1 || i == 2)
                                            for (int k = 0; k < Board.GetLength(0); k++)
                                                Board[deleting_elements[i], k] = 3;

                                        if (i == 3 || i == 4 || i == 5)
                                            for (int k = 0; k < Board.GetLength(1); k++)
                                                Board[k, deleting_elements[i]] = 3;
                                    }
                                }

                                //Below is done to give the user a time for reading calculations
                                if (wroten > 0)
                                {
                                    Console.SetCursorPosition(temp_cursor_x + 50, temp_cursor_y + 10);
                                    Console.WriteLine("Please Enter To Continue");
                                    Console.ReadLine();
                                    for (int i = 0; i < 24; i++)
                                    {
                                        Console.SetCursorPosition(temp_cursor_x + 50 + i, temp_cursor_y + 10);
                                        Console.WriteLine(" ");
                                    }
                                }

                                //Cleaning the are of calculations
                                for (int y1 = 0; y1 < 36; y1++)
                                    for (int x = 0; x < 10; x++)
                                    {
                                        Console.SetCursorPosition(temp_cursor_x + 38 + y1, temp_cursor_y + 15 + x);
                                        Console.WriteLine(" ");
                                    }

                                //Checking the game is over
                                //Creating some variables
                                game_over = true;

                                int number_Piece_elements = 0;
                                for (int j = 0; j < Piece_elements.GetLength(0); j++)
                                    for (int r = 0; r < Piece_elements.GetLength(1); r++)
                                        if (Piece_elements[j, r] != 3)
                                            number_Piece_elements++;
                                piece = rd.Next(0, 10);
                                for (int j = 0; j < Board.GetLength(0); j++)
                                {
                                    for (int r = 0; r < Board.GetLength(1); r++)
                                    {
                                        int counter_0 = 0;
                                        for (int j1 = 0; j1 < Piece_elements.GetLength(0); j1++)
                                        {
                                            for (int r1 = 0; r1 < Piece_elements.GetLength(1); r1++)
                                            {
                                                if (j + j1 < 9 && r + r1 < 9)
                                                {
                                                    if (Piece_elements[j1, r1] != 3 && Board[j + j1, r + r1] == 3)
                                                    {
                                                        counter_0++;
                                                        if (counter_0 == number_Piece_elements)
                                                        {
                                                            game_over = false;

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if (game_over == true)
                                {
                                    Console.Clear();
                                    for (int i = 0; i < 27; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.SetCursorPosition(temp_cursor_x + 105 - (4 * i), temp_cursor_y + i - 1);
                                        Console.WriteLine("                          ");
                                        Console.SetCursorPosition(temp_cursor_x + 106 - (4 * i), temp_cursor_y + i);
                                        Console.WriteLine("! ! !GAME OVER ! ! !");
                                        System.Threading.Thread.Sleep(80);
                                    }
                                    //Writing the scores obtained to file
                                    if (!(File.Exists("highscore.txt")))
                                    {
                                        StreamWriter f = File.CreateText("highscore.txt");
                                        f.Close();
                                    }
                                    StreamWriter b = File.AppendText("highscore.txt");
                                    b.WriteLine(name + ":" + score);
                                    b.Close();
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════╗");
                            for (int i = 0; i <= 6; i++)
                                Console.WriteLine("║                                                                              ║");
                            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.SetCursorPosition(2, 2);
                            Console.WriteLine(">>The game is played on a 9*9 board.\n");
                            Console.SetCursorPosition(2, 3);
                            Console.WriteLine(">>The board will be filled with 10 different game elements by the player.\n");
                            Console.SetCursorPosition(2, 4);
                            Console.WriteLine(">>The aim of the game is to fill a row, a column or a 3*3 block with the game\n");
                            Console.SetCursorPosition(2, 5);
                            Console.WriteLine("elements and reaching the highest score.\n");
                            Console.SetCursorPosition(2, 7);
                            Console.ResetColor();
                            Console.WriteLine(">>To go main menu, please enter<<");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            if (!(File.Exists("highscore.txt")))
                            {
                                StreamWriter f = File.CreateText("highscore.txt");
                                f.Close();
                            }
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("╔══════════════════════════════ High Score Table ══════════════════════════════╗");
                            for (int i = 0; i <= 6; i++)
                                Console.WriteLine("║                                                                              ║");
                            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");

                            //Find the number of lines in the text file
                            StreamReader files = File.OpenText("highscore.txt");
                            string lines;
                            int line = 0;
                            while (!files.EndOfStream)
                            {
                                lines = files.ReadLine();
                                line++;
                            }
                            files.Close();

                            string str;
                            string[] names = new string[line];
                            int[] scores = new int[line];
                            StreamReader c = File.OpenText("highscore.txt");
                            for (int f = 0; f < (line); f++)
                            {
                                str = c.ReadLine();
                                string[] Scoretables = str.Split(':');
                                names[f] = Scoretables[0];
                                scores[f] = Convert.ToInt32(Scoretables[1]);
                            }
                            c.Close();
                            //  Ranking of scores
                            int temporary;
                            string temporarary_name;
                            for (int m = 0; m < (line); m++)
                            {
                                for (int j = 0; j < scores.Length; j++)
                                {
                                    if (scores[m] > scores[j])
                                    {
                                        temporary = scores[j];
                                        scores[j] = scores[m];
                                        scores[m] = temporary;

                                        temporarary_name = names[j];
                                        names[j] = names[m];
                                        names[m] = temporarary_name;
                                    }
                                }
                            }

                            //Writing scores on the high score table
                            int v = 0;
                            for (int d = 0; d < (line); d++)
                            {
                                Console.SetCursorPosition(2, 1 + v);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine((d + 1) + "." + names[d] + ":" + scores[d]);
                                v += 1;
                            }

                            Console.ResetColor();
                            Console.SetCursorPosition(2, 7);
                            Console.WriteLine(">>To go main menu, please enter<<");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        menu_bool = false;
                        break;
                }
            }
        }
    }
}