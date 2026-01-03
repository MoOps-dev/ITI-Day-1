/**************************************
Written by Mohamed Khaled Tawfeek
mohamed.ibraham98@gmail.com
ITI Intensive Code Camp 2025-2026 R2
Full Stack .NET Zagazig DAY 1
***************************************/

namespace ITI_Day_1;

class Program
{
    private static bool IsRunning = true; // loop control boolean

    static void Main(string[] args)
    {
        while (IsRunning)
        {
            Console.WriteLine(@"
        ***************************************************
        ** Welcome to Day-1, Choose an action to continue:
        ***************************************************
        ** 1. Get ASCII/UNICODE Value.
        ** 2. Capture Pressed Key.
        ** 3. Convert a Decimal into Binary.
        ** 4. Convert a Binary into Decimal.
        ** 5. C# Operators Quiz.
        ** Or press ANY other key to exit the program.
        ***************************************************
            ");

            String? MenuAction = Console.ReadLine();
            switch(MenuAction)
            {
                case "1":
                    GetUnicode();
                    break;

                case "2":
                    CapturePressedKey();
                    break;

                case "3":
                    BinaryToDecimal();
                    break;
                
                case "4":
                    DecimalToBinary();
                    break;

                case "5":
                    OperatorsQuiz();
                    break;

                default: // Executed if no other cases match
                    IsRunning = false;
                    break;
            }
        }

        /* 1. Console.Read()::returns the ASCII/UNICODE value for the first character in the line*/
        static void GetUnicode()
        {
            Console.WriteLine("Enter a character to get the UNICODE value: ");
            int? InputChar = Console.Read();
            Console.WriteLine($"UNICODE value: {InputChar}\n");

            // CRITICAL: Clear the newline character left in the buffer by Console.Read()
            Console.ReadLine();
        }
        
        /* 2. Console.ReadKey()::returns an instance of the pressed key info for simplicity: capture key inputs,
              Stepping into the ConsoleKeyInfo getters we can use input.Key to get the key index or input.KeyChar to get the exact key character value*/
        static void CapturePressedKey()
        {
            Console.WriteLine("Enter a character to get pressed key info: ");
            // Passing the 'true' argument will hide user input from the console(useful in password inputs such as in linux login prompt)
            ConsoleKeyInfo InputKey = Console.ReadKey(true);
            Console.WriteLine($"Pressed key index: {InputKey.Key}");
            Console.WriteLine($"Pressed key character: {InputKey.KeyChar}\n");
        }

        /* 3. Convert.toInt32::used to convert decimals to binary*/
        static void BinaryToDecimal()
        {
            Console.WriteLine("Enter a binary to convert to decimal: ");
            String? InputBinary = Console.ReadLine();
            // passing 2 as fromBase argument tells the system to convert this value from Base 2 (Binary)
            int DecimalValue = Convert.ToInt32(InputBinary, 2);
            Console.WriteLine($"Decimal Value: {DecimalValue}\n");
        }

        /* 4. Convert.toString::used to convert decimals to binary*/
        static void DecimalToBinary()
        {
            Console.WriteLine("Enter a decimal to convert to binary: ");
            String? InputDecimal = Console.ReadLine();
            // passing 2 as toBase argument tells the system to convert this value to Base 2 (Binary)
            String BinaryValue = Convert.ToString(Convert.ToInt32(InputDecimal), 2);
            Console.WriteLine($"Binary Value: {BinaryValue}\n");
        }

        /* 5. Quick Quiz on operator types in C#*/
        static void OperatorsQuiz()
        {   
            // Setting up a map for quiz operators
            Dictionary<string, string> operators = new()
            {
                ["Addition"] = "+",
                ["Substraction"] = "-",
                ["Multiplication"] = "*",
                ["Division"] = "/",
                ["Remainder"] = "%",
                ["Increment"] = "++",
                ["Decrement"] = "--",
                ["Equal to"] = "==",
                ["Not Equal to"] = "!=",
                ["Greater than"] = ">",
                ["Greater than OR Equal to"] = ">=",
                ["Less than"] = "<",
                ["Less than OR Equal to"] = "<=",
                ["conditional AND"] = "&&",
                ["conditional OR"] = "||",
                ["NOT"] = "!"
            };
            
            // Shuffle quiz selection
            string[] keys = [.. operators.Keys];
            Random.Shared.Shuffle(keys);
        
            // Iterate over the map keys using foreach loop
            foreach (string key in keys)
            {
                Console.WriteLine($"\nEnter the operator representing this expression '{key}' (Enter operator sign): ");
                String? answer = Console.ReadLine();

                // Using ternary operators to validate the answer
                string validation = (answer == operators[key]) ? "Your answer is CORRECT!" : $"Your answer is WRONG, The right answer is : {operators[key]}";

                Console.WriteLine(validation);

                // Remove the key:value pair from the map
                operators.Remove(key);

            }

        }
        
    }
}
