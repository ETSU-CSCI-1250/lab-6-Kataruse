using System;

ShowCharacter("", 0);

Console.WriteLine($"Your retail price is {CalculateRetail(0, 0)}.");
Console.WriteLine("");

double fahrenheit = 80;
double celsius = 0;
do
{
    Console.WriteLine(Math.Round(TempTable(fahrenheit), 2));
    fahrenheit = fahrenheit + 1;
} while (fahrenheit <= 100);
Console.WriteLine("");

int number = 1;
bool primeCheck = false;
for (int i = 1; i <= 100; i++)
{
    primeCheck = IsPrime(number);
    if (primeCheck == true)
    {
        Console.WriteLine($"{number} is a prime number.");
    } else
    {
        Console.WriteLine($"{number} is not a prime number.");
    }
    number++;
}

static void ShowCharacter(string word, int num)
{
    //Below prompts user for a word
    do
    {
        Console.Write("Enter any word: ");
        word = Console.ReadLine();
        Console.WriteLine("");

        //Below checks to see if word is blank
        if (word == "")
        {
            Console.WriteLine("ERROR - must enter a character - ERROR");
        }
    } while (word == "");

    //Below prompt sthe user for a number
    var tempNum = "";
    bool numCheck;
    do
    {  
        Console.Write($"Enter any number less than or equal to {word.Length}: ");
        tempNum = Console.ReadLine();
        Console.WriteLine("");

        //this checks to see if the temp is a integer and if so then num is set
        //to it and the do while loop breaks
        numCheck = int.TryParse(tempNum, out num);
        if (numCheck == false)
        {
            Console.WriteLine("ERROR - Not a Integer - ERROR");
        }
        
        //this checks to make sure the number is less than or equal to the
        //amount of letters in the word and or if its 0
        if (num > word.Length || num == 0)
        {
            Console.WriteLine("ERROR - Integer is out of range - ERROR");
            numCheck = false;
        }
    } while(!numCheck);

    Console.WriteLine($"{word[num - 1]} is {num} spaces from the beginning of {word}.\n");
}

static double CalculateRetail(double wholesaleCost, double markupPercent)
{
    //Below prompts the user for a wholesaleCost
    var tempWhole = "";
    bool numCheck;
    do
    {
        Console.Write($"Enter the wholesale cost: ");
        tempWhole = Console.ReadLine();
        Console.WriteLine("");

        //this checks to see if the temp is a integer and if so then num is set
        //to it and the do while loop breaks
        numCheck = double.TryParse(tempWhole, out wholesaleCost);
        if (numCheck == false)
        {
            Console.WriteLine("ERROR - Not a Integer - ERROR");
        }

    } while (!numCheck);

    //Below prompts the user for a wholesaleCost
    var tempMark = "";
    numCheck = false;
    do
    {
        Console.Write($"Enter the markup percent (do not include a %): ");
        tempMark = Console.ReadLine();
        Console.WriteLine("");

        //this checks to see if the temp is a integer and if so then num is set
        //to it and the do while loop breaks
        numCheck = double.TryParse(tempMark, out markupPercent);
        if (numCheck == false)
        {
            Console.WriteLine("ERROR - Not a Integer - ERROR");
        }

    } while (!numCheck);

    markupPercent = markupPercent / 100;
    double retailCost = wholesaleCost * markupPercent + wholesaleCost;

    return retailCost;
}

static double TempTable(double fahrenheit)
{
    double celsius = 0;
    celsius = (fahrenheit - 32) * 5 / 9;
    return celsius;
}

static bool IsPrime(int number)
{
    //formula provided by the following because I can't think straight at 2am VVVV 
    //https://www.w3resource.com/csharp-exercises/function/csharp-function-exercise-9.php
    for (int i = 2; i < number; i++)
        if (number % i == 0)
            return false;
    return true;
}