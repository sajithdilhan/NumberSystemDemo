
using System.Numerics;

Console.WriteLine("Enter Number System: 1 - Binary, 2 - Octal, 3 - Hexa");
string systemType = Console.ReadLine()!;
Console.WriteLine("Enter Decimal Number");
string decimalNumber = Console.ReadLine()!;

if (string.IsNullOrEmpty(decimalNumber) || string.IsNullOrEmpty(systemType))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Invalid Input!");
    Console.ForegroundColor = ConsoleColor.White;
    Thread.Sleep(300);
    Environment.Exit(0);
}

try
{
    Stack<long> output = new Stack<long>();

    if (systemType == "1")
    {
        output = ConvertToBinary(decimalNumber);
        Console.Write("Binary number:");
        foreach (var item in output)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(item);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    else if (systemType == "2")
    {
        output = ConvertToOctal(decimalNumber);
        Console.Write("Octal number:");
        foreach (var item in output)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(item);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    else if (systemType == "3")
    {
        Stack<string> hexaOutput = ConvertToHexa(decimalNumber);
        Console.Write("Hexa number:");
        foreach (var item in hexaOutput)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(item);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ForegroundColor = ConsoleColor.White;
    throw;
}

static Stack<long> ConvertToBinary(string decimalNumber)
{  
    long decNumber = 0;
    long.TryParse(decimalNumber, out decNumber);
    //Console.WriteLine(Convert.ToString(decNumber, 2)); // .NET out of the box support
    Stack<long> output = new Stack<long>();

    while (decNumber >= 2)
    {
        int remainder = ((int)(decNumber % 2));
        output.Push(remainder);
        decNumber = decNumber / 2;
        if (decNumber == 1)
        {
            output.Push(decNumber);
        }
    }

    return output;
}

static Stack<long> ConvertToOctal(string decimalNumber)
{
    long decNumber = 0;
    long.TryParse(decimalNumber, out decNumber);
    //Console.WriteLine(Convert.ToString(decNumber, 8)); // .NET out of the box support
    Stack<long> output = new Stack<long>();

    while (decNumber >= 8)
    {
        int remainder = (int)(decNumber % 8);
        output.Push(remainder);
        decNumber = decNumber / 8;
        if (decNumber < 8)
        {
            output.Push(decNumber);
        }
    }

    return output;
}

static Stack<string> ConvertToHexa(string decimalNumber)
{
    BigInteger decNumber = 0;
    BigInteger.TryParse(decimalNumber, out decNumber);
    //Console.WriteLine(Convert.ToString(Convert.ToInt32(decimalNumber), 16)); // .NET out of the box support
    Stack<string> output = new Stack<string>();
    string remainderStr = string.Empty;

    while (decNumber >= 16)
    {
        int remainder = (int)(decNumber % 16);

        if (remainder > 9)
        {
            switch (remainder)
            {
                case 10:
                    remainderStr = "A";
                    break;
                case 11:
                    remainderStr = "B";
                    break;
                case 12:
                    remainderStr = "C";
                    break;
                case 13:
                    remainderStr = "D";
                    break;
                case 14:
                    remainderStr = "E";
                    break;
                case 15:
                    remainderStr = "F";
                    break;
                default:
                    break;
            }
            output.Push(remainderStr);
        }
        else
        {
            output.Push(remainder.ToString());
        }

        decNumber = decNumber / 16;
        int integer;
        if (decNumber < 16)
        {
            integer = int.Parse(decNumber.ToString());
            if (integer > 9)
            {
                switch (integer)
                {
                    case 10:
                        remainderStr = "A";
                        break;
                    case 11:
                        remainderStr = "B";
                        break;
                    case 12:
                        remainderStr = "C";
                        break;
                    case 13:
                        remainderStr = "D";
                        break;
                    case 14:
                        remainderStr = "E";
                        break;
                    case 15:
                        remainderStr = "F";
                        break;
                    default:
                        break;
                }
                output.Push(remainderStr);
            }
            else
            {
                output.Push(decNumber.ToString());
            }
        }
    }

    return output;
}