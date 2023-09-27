using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class SearchScreen : BaseScreen
    {
        public SearchScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override Screens Display()
        {
            if(data.Count <= 0) {
                return Screens.main;
            }

            Aluno encontrado = null;
            string search = AnsiConsole.Prompt(new TextPrompt<string>("[dim] Digite o nome do aluno : [/]"));

            data.Sort((a1, a2) => {
                int s1 = 0;
                int s2 = 0;
                for (int i = 1; i <= search.Length; i++)
                {
                    string s = search.Substring(0, i);
                    bool b1 = (a1.Nome.Contains(s));
                    bool b2 = (a2.Nome.Contains(s));

                    if (b1) s1++;
                    if (b2) s2++;
                }
                int r = s2 - s1;
                return r;
            });


            foco = data[0];
            if (foco.Nome == search)
            {
                return Screens.details;
            }
            return Screens.list;
        }
    }
}
