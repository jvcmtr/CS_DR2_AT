using AlunosLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Screens
{
    internal class SearchScreen : BaseScreen
    {
        new Screens Display()
        {
            Aluno encontrado = null;
            ScreenHelper.helperText($"digite {returnCommand} para voltar");

            while (encontrado == null)
            {
                Console.Write("Digite o nome do aluno : ");
                string UserSearch = Console.ReadLine();
                encontrado = alunos.Find((Aluno p) => p.nome == UserSearch);

                ScreenHelper.PrintError("aluno não encontrado");

                if (UserSearch == "ESC")
                {
                    currentScreen = lastScreen;
                    return;
                }
            }

            alunoEmFoco = encontrado;
            currentScreen = Screens.details;
        }
    }
}
