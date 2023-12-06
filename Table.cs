
namespace Joao_Ramos_DR2_TP2
{
    internal class Table
    {
        private int columnWidth;
        private ConsoleColor bg;
        private ConsoleColor fg;
        private string[] nextLine;
        private string[] header;
        private List<string[]> content;

        const string spacing = " ";

        public Table(string[] header, int columnWidth = 5, ConsoleColor bg = ConsoleColor.Black, ConsoleColor fg = ConsoleColor.White)
        {
            this.header = header;
            this.columnWidth = columnWidth;
            this.bg = bg;
            this.fg = fg;
            content= new List<string[]>();
        }

        public Table(string header, int columnWidth = 5, ConsoleColor bg = ConsoleColor.Black, ConsoleColor fg = ConsoleColor.White)
        {
            this.header = header.Split(",");
            this.columnWidth = columnWidth;
            this.bg = bg;
            this.fg = fg;
            content = new List<string[]>();
        }

        public void addEntry(string[] entry ) {
            content.Add( entry );
        }

        public void addEntry(string entries, string split = "|")
        {
            string[] entry = entries.Split(split);
            content.Add(entry);
        }



        public void printTable()
        {

            Console.Write(spacing);
            Console.ForegroundColor = bg;
            Console.BackgroundColor = fg;
            printEntry(header, true);

            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
            foreach (string[] entry in content)
            {
                tableBreak();
                printEntry(entry);
            }

            tableBreak(true);
        }


        public void printEntry(string[] entry, bool isHeader = false)
        {
            if (!isHeader) 
                Console.Write(spacing);
            nextLine = null;

            string s = isHeader ? "  " : "║ ";
            Console.Write(s);

            for (int i = 0; i < entry.Length; i++)
            {
                string columnName = entry[i];

                for (int j = 0; j < columnName.Length; j++)
                {
                    Console.Write(columnName[j]);
                    if ((j+1)%columnWidth == 0)
                    {
                        string remainder = columnName.Substring(j+1);
                        addToNextLine(remainder, i);
                        break;
                    }
                }

                int space = columnWidth - columnName.Length;   
                for(int j = 0; j< space; j++)
                {
                    Console.Write(" ");
                }

                if (i == entry.Length - 1)
                {
                    if(isHeader) Console.Write("  ");
                    else Console.Write(" ║ ");
                }
                else
                {
                    Console.Write(" │ ");
                }
            }
            Console.WriteLine();
            if(nextLine !=null)
            {
                string[] nxt = new string[nextLine.Length];
                nextLine.CopyTo(nxt, 0);
                printEntry(nxt, isHeader);
            }
        }


        private void tableBreak( bool isLast = false)
        {
            // ╟ ╢ ║ ╚ ╝ ═ ┼    
            string right = isLast ? "╚═" : "╟─";
            string line = isLast ? "═" : "─";
            string midle = isLast ? "═╧═" : "─┼─";
            string left = isLast ? "═╝" : "─╢";

            Console.Write(spacing);
            Console.Write(right);
            for (int i = 0; i < header.Length; i++)
            {
                for (int j = 0; j < columnWidth; j++)
                {

                    Console.Write(line);
                }

                if (i == header.Length - 1)
                    Console.WriteLine(left);
                else
                    Console.Write(midle);
            }
        }

        private void addToNextLine(string text, int column)
        {
            if(nextLine== null)
            {
                nextLine = new string[header.Length];
                for (int i = 0; i < nextLine.Length; i++)
                {
                    nextLine[i] = " ";
                }
            }
            nextLine[column] = text;
        }
    }
}
