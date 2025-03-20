﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class HighLowGame
{
    // Function to display Foreground Colors
    private static void ShowMessageToPlayer(ConsoleColor color, string msg)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    static void Main()
    {
        bool playAgain = true;

        // Game loop for playing multiple times
        while (playAgain)
        {
            // Introduce the game
            Console.BackgroundColor = ConsoleColor.White;
            ShowMessageToPlayer(ConsoleColor.Black, "WELCOME TO THE HIGH-LOW G1 GUESSING GAME!\n");

            //Ask the player name
            Console.WriteLine("What's your name, please?");
            string username = Console.ReadLine();

            // Ask if user is brave enough yo play and validate if the input is valid or not
            string braveResponse = "";
            while (braveResponse != "y" && braveResponse != "n")
            {
                Console.Write("\nHi " + username + ", are you brave enough to play? (y/n): ");
                braveResponse = Console.ReadLine().ToLower(); // Convert to lowercase

                if (braveResponse != "y" & braveResponse != "n")
                {
                    Console.WriteLine("Invalid input! Please enter 'y' or 'n'.");
                }
            }

            if (braveResponse == "n")
            {
                Console.WriteLine("\nOk! Maybe next time! Goodbye " + username + ".\nComing soon a multiplayer version!");
                break; // Exit the game if the player is not brave enough
            }

            // Game logic starts here
            Random random = new Random();

            // Game loop for multiple rounds
            do
            {
                // Randomly choose a range for the mystery number
                int minRange = random.Next(1, 51);  // Random minimum between 1 and 50
                int maxRange = random.Next(minRange + 1, 101);  // Random maximum, must be greater than minRange

                // Generate a random number between the selected range
                int mysteryNumber = random.Next(minRange, maxRange + 1);

                // Variable to hold the user's guess
                int userGuess = 0;

                // Number of attempts the user has made
                int attempts = 0;

                // Display the range of numbers
                Console.WriteLine($"\nThe mystery number is between {minRange} and {maxRange}. Try to guess it!");

                // Game loop for guessing
                while (userGuess != mysteryNumber)
                {
                    // Ask the user for their guess
                    Console.Write(username + " enter your guess: ");
                    string input = Console.ReadLine();

                    // Check if the input is a valid number
                    if (int.TryParse(input, out userGuess))
                    {
                        // Check if the guess is within the valid range
                        if (userGuess < minRange)
                        {
                            ShowMessageToPlayer(ConsoleColor.Yellow,username + $", your guess is below the minimum allowed. Please enter a number between {minRange} and {maxRange}.");
                            continue;
                        }
                        else if (userGuess > maxRange)
                        {
                            ShowMessageToPlayer(ConsoleColor.Yellow, username + $", your guess is above the maximum allowed. Please enter a number between {minRange} and {maxRange}.");
                            continue;
                        }

                        attempts++;

                        // Check if the guess is too high, too low, or correct
                        if (userGuess < mysteryNumber)
                        {
                            ShowMessageToPlayer(ConsoleColor.Blue,"Too low! Try again.");
                        }
                        else if (userGuess > mysteryNumber)
                        {
                            ShowMessageToPlayer(ConsoleColor.Red,"Too high! Try again.");
                        }
                        else
                        {
                            ShowMessageToPlayer(ConsoleColor.Green,$"\nCorrect! The mystery number was {mysteryNumber}.");
                            Console.WriteLine(username + $", it took you {attempts} attempt(s) to guess it.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a valid number.");
                    }
                }

                // Ask the player if he wants to play again and validate if the response is valid
                string playAgainInput = "";
                while (playAgainInput != "y" && playAgainInput != "n")
                {
                    Console.Write("\n" + username + ", do you want to play again? (y/n): ");
                    playAgainInput = Console.ReadLine().ToLower(); // Convert to lowercase

                    if (playAgainInput != "y" & playAgainInput != "n")
                    {
                        Console.WriteLine("Invalid input! Please enter 'y' or 'n'.");
                    }
                }

                if (playAgainInput == "n")
                {
                    playAgain = false;
                    Console.WriteLine("Thanks " + username + " for playing! Goodbye.\nComing soon a multiplayer version!");
                }
            }
            while (playAgain); // Loop again if the player wants to play again
        }
        Console.ReadLine();
    }
}