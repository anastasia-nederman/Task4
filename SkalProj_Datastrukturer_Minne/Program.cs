using System;
using System.Net.Sockets;
using System.Threading.Tasks;

/*
1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion.

Stacken och heapen är två minnetyper. 
Stacken är som en hög med många böcker som ligger på varandra. Man kan bara använda den boken som ligger på toppen.
Om man vill använda en bok som ligger under de andra böcker så måste man ta bort alla böckerna ovan.
Stacken hanterar minnet automatiskt och man behöver inte göra något.
Heapen är som en bokhylla där böcker står bredvid varandra. Man kan enkelt ta vilken bok som helst och använda den.
Stacken hanterar inte minne automatiskt och man behöver ta bort gamla böcker som man inte vill ha längre ("garbage collection").

2. Vad är Value Types respektive Reference Types och vad skiljer dem åt? 

Value Types är t.ex. bool, char, double. 
När man förändrar en variabel, det påverkar inte andra variablar.
Reference Types är t.ex. string, array, class. 
Reference är som address. Två variablar kan visa på sammma address. 
Om man försöker då förändra en variabel, förändras den annan automatiskt.

3. Följande metoder (se bild) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?

För att den första bilden visar value types och den andra bilden visar reference types.
I den första metoden finns det x och y - två olika int. När y får ett annat värde, det påverkar inte x.
I den andra metoden x och y fungerar som reference types. De visar på samma objekt. 
Så när man förändrar y, x förändras också automatiskt på samma sätt.
*/

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("Please type + and a word of your choice to add it in the list or - and a word to remove it from the list");
                Console.WriteLine("Type 0 if you want to return to the main menu");

                string input = Console.ReadLine();

                if (input == "0")
                    break;

                if (input.Length < 2)
                {
                    Console.WriteLine("You entered something wrong. Please use only + or - followed by a word.");
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"You added: {value}");
                        Console.WriteLine($"List count: {theList.Count}, List capacity: {theList.Capacity}");
                        break;
                    case '-':
                        if (theList.Remove(value))
                        {
                            Console.WriteLine($"You removed: {value}");
                            Console.WriteLine($"List count: {theList.Count}, List capacity: {theList.Capacity}");
                        }
                        else
                        {
                            Console.WriteLine($"Could not find: {value}");
                        }
                        break;
                    default:
                        Console.WriteLine("You entered something wrong. Please use only + or - followed by a word.");
                        break;
                }
            }

        }

        /*
        2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
        När listan är full och jag försöker lägga till ett element.

        3. Med hur mycket ökar kapaciteten? 
        Listen blir dubbel så stor.

        4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
        För att det behövs inte. Listan är tillräckligt stor för att lägga till några fler element. 

        5. Minskar kapaciteten när element tas bort ur listan?
        Nej.

        6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
        När vi vet precis hur stor en array måste vara. Om vi vet att vi inte kommer att förändra storleken.
        */

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

