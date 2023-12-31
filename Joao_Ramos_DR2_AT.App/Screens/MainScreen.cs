﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Screens
{
    internal class MainScreen : BaseScreen
    {
        internal override Screens Display()
        {
            Console.Clear();
            ScreenHelper.PrintHeader("Cadastro de Alunos");
            Console.WriteLine(" Digite a opção que deseja");

            string[] options = new string[]{
        "adicionar",
        "Pesquisar",
        "lista de alunos",
        "sair"
    };
            string chosen = ScreenHelper.GetOption(options);


            lastScreen = Screens.main;
            if (chosen == options[0])
            {
                currentScreen = Screens.create;
            }
            else if (chosen == options[1])
            {
                currentScreen = Screens.search;
            }
            else if (chosen == options[2])
            {
                currentScreen = Screens.list;
            }
            else if (chosen == options[3])
            {
                currentScreen = Screens.exit;
            }
        }
    }
}
