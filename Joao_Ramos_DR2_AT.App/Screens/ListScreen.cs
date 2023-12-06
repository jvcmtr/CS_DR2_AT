using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Screens
{
    internal class ListScreen : BaseScreen
    {
        internal override Screens Display()
        {
            Console.Clear();
            ScreenHelper.PrintHeader("Alunos cadastrados");
            Console.WriteLine();

            string[] TableHeader = new string[] { "Nome", "Preço" };
            Table list = new Table(TableHeader, tableWidth);
            foreach (var item in alunos)
            {
                list.addEntry($"{item.nome}|{item.nome}");
            }
            list.printTable();


            string[] options = new string[]{
        "inicio",
        "adicionar",
        "pesquisar",
    };
            string chosen = ScreenHelper.GetOption(options);


            lastScreen = Screens.list;
            if (chosen == options[0])
            {
                currentScreen = Screens.main;
            }
            else if (chosen == options[1])
            {
                currentScreen = Screens.create;
            }
            else if (chosen == options[2])
            {
                currentScreen = Screens.search;
            }
        }
    }
}
