//Intro
Console.WriteLine("Welcome to the Grand Circus Casino!");
int sides;
int roll1;
int roll2;
int total;
bool runAgain = true;

while (runAgain)
{

    while (true)
    {

            //Collecting valid input from user
            Console.WriteLine("How many sides should the dice have?  Enter a number below");
            if (int.TryParse(Console.ReadLine(), out sides) && sides >= 1)
            {
                //a valid entry rolls the dice and leaves the loop
                Console.WriteLine($"Rolling dice with {sides} sides each...");
                break;
            }
            else
            {
                //invalid entry = user asked again for number
                Console.WriteLine("Please enter a valid number");
            }

    }
    //if user selects 6 sides this section will run, if anything other than 6 the else portion will run
    if (sides == 6)
    {
        roll1 = Roller(sides);
        roll2 = Roller(sides);
        total = roll1 + roll2;
        Console.WriteLine($"You rolled a {roll1} and a {roll2} for a total of {total}!");
        Console.WriteLine(sixSidedRoller(roll1, roll2));
    }
    else
    {
        roll1 = Roller(sides);
        roll2 = Roller(sides);
        total = roll1 + roll2;
        Console.WriteLine($"You rolled a {roll1} and a {roll2} for a total of {total}!");
    }
    runAgain = GoAgain();
}

//Methods
//This method rolls the die between 1 and the desired number
static int Roller(int s)
{
    Random roll = new Random();
    return roll.Next(s) + 1;
}

//This method is only used when the user rolls a six sided die
//This determines any combinations + win and loss
static string sixSidedRoller(int r1, int r2)
{
    string message = " ";
    if(r1 == 1 && r2 == 1)
    {
        message = "Snake eyes and craps!";
    }
    if((r1 == 2 && r2 == 1) || (r1 == 1 && r2 == 2))
    {
        message = "Ace deuce and craps!";
    }
    if(r1 == 6 && r2 == 6)
    {
        message = "Box Cars and craps!";
    }
    if(r1 + r2 == 7)
    {
        message = "Winner winner chicken dinner!";
    }
    if(r1 + r2 == 11)
    {
        message = "WINNER!!!";
    }
    return message;
}

static bool GoAgain()
{
    while (true)
    {
        Console.WriteLine("Do you want to go again(y/n)?");
        string input = Console.ReadLine();
        try
        {
            if (input.ToLower().Trim() == "y")
            {
                return true;
            }
            else if (input.ToLower().Trim() == "n")
            {
                return false;
            }
            else
            {
                throw new Exception("Not a valid option, please try again.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
Console.WriteLine("Thanks for your money... the house always wins!");