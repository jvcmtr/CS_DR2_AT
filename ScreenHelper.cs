
namespace Joao_Ramos_DR2_TP2
{

    public  static class ScreenHelper
    {

        public static void PrintHeader(string text)
        {
            int l = text.Length + 6;

            Console.Write("  ");
            for (int i = 0; i < l; i++)
                Console.Write("═");
            Console.WriteLine();

            Console.WriteLine("    ♦ " + text); //▬♦═

            Console.Write("  ");
            for (int i = 0; i < l; i++)
                Console.Write("═");
            Console.WriteLine();
        }

        public static void helperText(string text)
        {
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.WriteLine("--" + text + "--");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string getInputWithDefault(string defaultInput)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(defaultInput);
            int currentLeft = Console.CursorLeft;
            Console.ForegroundColor = ConsoleColor.White;

            Console.CursorLeft -= defaultInput.Length;
            string input = Console.ReadLine();

            if (input == "")
            {
                Console.CursorTop -= 1;
                Console.CursorLeft = currentLeft - defaultInput.Length;
                Console.WriteLine(defaultInput);
                input = defaultInput;
            }

            return input;
        }

        public static string GetOption(string[] options)
        {
            Console.WriteLine();
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"  [{i+1}]\t{options[i]}");
            }

            int result = -1;
            while(result == -1)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    if ( 0 < value && value <= options.Length)
                    {
                        result = value - 1;
                        break;
                    }
                }

                ScreenHelper.PrintError($"# ({input}) NÃO É UMA OPÇÃO VALIDA");
            }

            return options[result];
        }

        public static void PrintError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int currentLeft = Console.CursorLeft;
            Console.CursorLeft = 0;

            Console.Write(text);
            
            Console.CursorTop = Console.CursorTop - 1;
            Console.CursorLeft = currentLeft;
            Console.ForegroundColor= ConsoleColor.White;
        }

    }
}
