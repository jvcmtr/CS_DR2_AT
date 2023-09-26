using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class DetailsScreen : BaseScreen
    {
        public DetailsScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override BaseScreen Display()
        {
            Console.Clear();
            ScreenHelper.PrintHeader("Detalhes do aluno");

            Table list = new Table("Nome,Preço", tableWidth);
            list.addEntry($"{alunoEmFoco.nome}|{alunoEmFoco.nome}");
            list.printTable();

            string[] options = new string[]{
        "inicio",
        "editar",
        "deletar"
    };
            string chosen = ScreenHelper.GetOption(options);


            lastScreen = Screens.details;
            if (chosen == options[0])
            {
                currentScreen = Screens.main;
            }
            else if (chosen == options[1])
            {
                currentScreen = Screens.update;
            }
            else if (chosen == options[2])
            {
                currentScreen = Screens.delete;
            }
        }
    }
}
