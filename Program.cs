namespace Converter
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please type '1' to convert decimal to binary, or type '2' to convert binary to decimal");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Enter decimal number:");
                        DecimalToBinary();
                        break;

                    case "2":
                        Console.WriteLine("Enter binary number:");
                        BinaryToDecimal();
                        break;

                    default:
                        Console.WriteLine("Your choice is wrong. Please try again.");
                        break;
                }
                Console.WriteLine("Would you like to try again? y/n");
                if (Console.ReadKey(true).Key != ConsoleKey.Y)
                    break;
            }
        }

        private static void DecimalToBinary(int round = 10)
        {
            int intPart;
            int fractPart;
            string binary = string.Empty;

            string _decimal = Console.ReadLine();

            if (!decimal.TryParse(_decimal, out _))
            {
                Console.WriteLine("Value entered is not a decimal number. Please try again.");
                return;
            }

            string[] parts = _decimal.Split(new char[] { '.', ',' });

            //convert integer part of decimal
            intPart = Convert.ToInt32(parts[0]); 
            int remainder;
            while (intPart > 0)
            {
                remainder = intPart % 2;
                intPart /= 2;
                binary = remainder.ToString() + binary;
            }

            if (parts.Count() > 1)
            {
                //convert fractional part of decimal
                fractPart = Convert.ToInt32(parts[1]);
                if (fractPart != 0)
                {
                    binary += '.';
                    int count = parts[1].Length;

                    for (int i = 0; i < round; i++)
                    {
                        fractPart = fractPart * 2;
                        if (fractPart.ToString().Length > count)
                        {
                            string buf = fractPart.ToString();
                            buf = buf.Remove(0, 1);
                            fractPart = Convert.ToInt32(buf);

                            binary += '1';
                        }
                        else
                        {
                            binary += '0';
                        }
                    }
               }
            }

            Console.WriteLine($"Binary is: {binary}\n");
        }

        private static void BinaryToDecimal()
        {
            int i;
            double _decimal = 0;
            string binary = Console.ReadLine();
            for (i = 0; i < binary.Length; i++)
            {
                if ((binary[i] != '1') && (binary[i] != '0') && (binary[i] != '.') && (binary[i] != ','))
                {
                    Console.WriteLine("Value entered is not a binary number. Please try again.");
                    return;
                }
            }

            string[] parts = binary.Split(new char[] { '.', ',' });

            binary = parts[0]; //convert integer part of binary
            for (i = 0; i < binary.Length; i++)
            {
                if (binary[binary.Length - i - 1] == '0') continue;
                _decimal += (double)Math.Pow(2, i);
            }

            if (parts.Length > 1)
            {
                binary = parts[1]; //convert fractional part of binary
                for (i = 1; i <= binary.Length; i++)
                {
                    if (binary[i - 1] == '0') continue;
                    _decimal += (double)Math.Pow(2, -i);
                }
            }

            Console.WriteLine($"Decimal is {_decimal}");
        }
    }
}
