using System;
using System.Threading;

namespace Homework_do
{
    class Program
    {
        /// <summary>
        /// The execution method of our code
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Creating a game mode selection
            Console.WriteLine("Choose the game mode: 1 - 1vs1, 2 - vs PC");
            byte gamemode;
            gamemode = Convert.ToByte(Console.ReadLine());

            // Create enter nicknames for the first player and, in the appropriate game mode, for the second player
            Console.WriteLine("\nPlayer #1, write your nickname");
            string player1 = Console.ReadLine();
            string player2 = "PC";
            if (gamemode == 1)
            {
                Console.WriteLine("Player #2, write your nickname");
                player2 = Console.ReadLine();
            }

            // Creating a subtraction number variable for the player and number of step
            int userTry;
            byte NumbOfStep = 1;

            // Create a subtraction number span
            Console.WriteLine("\nEnter the initial limit of the number of subtractions for the player");
            int earlynumberTry = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the final limit of the number of subtractions for the player");
            int endnumberTry = Convert.ToInt32(Console.ReadLine());

            // Creating limits for generating a game number
            Console.WriteLine("\nEnter the number from which the game number will be generated");
            int earlynumberGameNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number up to which the game number will be generated");
            int endnumberGameNumber = Convert.ToInt32(Console.ReadLine());

            // Creating a random game number
            Random number = new Random();
            int gameNumber = number.Next(earlynumberGameNumber, endnumberGameNumber);

            // Creation of an endless loop of the game, until it ends
            for (; ; )
            {              
                // Create step loop for the first player
                Console.WriteLine($"\nStep №{NumbOfStep} \nGame number = {gameNumber} \nPlayer turn: {player1}");
                while (true)
                {
                    // Implementing a set of subtraction numbers
                    Console.Write($"Enter your subtraction number, {player1}:");
                    userTry = Convert.ToSByte(Console.ReadLine());
                    if (userTry > endnumberTry)
                        Console.WriteLine($"You entered a value greater than the allowed value, enter a number from {earlynumberTry} to {endnumberTry}");
                    else if (userTry < earlynumberTry)
                        Console.WriteLine($"You entered a value less than the allowed value, enter a number from {earlynumberTry} to {endnumberTry}");
                    else
                    {
                        // End of turn implementation
                        gameNumber -= userTry;
                        NumbOfStep++;
                        break;
                    }
                }

                // Checking the game number and ending the game
                if (gameNumber <= 0)
                {
                    Console.WriteLine($"\nCongratulations, player {player1}! You won {player2} on {NumbOfStep} step");
                    break;
                }

                // Create step loop for the second player
                Console.WriteLine($"\nStep №{NumbOfStep} \nGame number = {gameNumber} \nPlayer turn: {player2}");
                while (true)
                {
                    // Game number check
                    if (gamemode == 1) // implementation of a step for player
                    {
                        // Implementing a set of subtraction numbers
                        Console.Write($"Enter your subtraction number, {player2}:");
                        userTry = Convert.ToSByte(Console.ReadLine());
                        if (userTry > endnumberTry)
                            Console.WriteLine($"You entered a value greater than the allowed value, enter a number from {earlynumberTry} to {endnumberTry}");
                        else if (userTry < earlynumberTry)
                            Console.WriteLine($"You entered a value less than the allowed value, enter a number from {earlynumberTry} to {endnumberTry}");
                        else
                        {
                            // End of turn implementation
                            gameNumber -= userTry;
                            NumbOfStep++;
                            break;
                        }
                    }
                    else  // implementation of a step for PC
                    {
                        userTry = number.Next(earlynumberTry, endnumberTry);
                        gameNumber -= userTry;
                        NumbOfStep++;
                        break;
                    }
                }

                // Checking the game number and ending the game
                if (gameNumber <= 0)
                {
                    Console.WriteLine($"\nCongratulations, player {player2}! You won {player1} on {NumbOfStep} step");
                    break;
                }


            }
        }
    }
}
