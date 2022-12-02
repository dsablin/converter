namespace Converter
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please type '0' to convert decimal to binary, or type '1' to convert binary to decimal");

                switch (Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("Enter decimal integer number:");
                        DecimalToBinary();
                        break;

                    case "1":
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

        private static void DecimalToBinary()
        {
            int _decimal;
            try
            {
                _decimal = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Value entered is not a decimal integer number. Please try again.");
                return;
            }
            string binary = string.Empty;
            if (_decimal < 2)
                binary = _decimal.ToString();
            else
            {
                int remainder;
                while (_decimal > 0)
                {
                    remainder = _decimal % 2;
                    _decimal /= 2;
                    binary = remainder.ToString() + binary;
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
                if ((binary[i] != '1') && (binary[i] != '0'))
                {
                    Console.WriteLine("The number entered is incorrect. Please try again.");
                    return;
                }
            }

            if (int.Parse(binary) < 2)
                _decimal = int.Parse(binary);
            else
            {
                for (i = 0; i < binary.Length; i++)
                {
                    if (binary[binary.Length - i - 1] == '0') continue;
                    _decimal += (int)Math.Pow(2, i);
                }
            }

            Console.WriteLine("Decimal number = " + _decimal);
        }
    }
}
