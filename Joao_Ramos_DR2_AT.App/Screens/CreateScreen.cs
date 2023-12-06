using AlunosLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Screens
{
    internal class CreateScreen : BaseScreen
    {
        internal override Screens Display()
        {

            Console.Clear();

            ScreenHelper.PrintHeader("Adicionar aluno");
            ScreenHelper.helperText($"digite {returnCommand} para voltar");

            Console.Write(" Nome :\t");
            string nome = Console.ReadLine();

            if (nome == returnCommand)
            {
                currentScreen = lastScreen;
                return;
            }

            while (true)
            {
                Console.Write("Preço :\t");
                string preco = Console.ReadLine();
                preco = preco.Replace(".", ",");

                if (preco == returnCommand)
                {
                    currentScreen = lastScreen;
                    return;
                }

                lastScreen = Screens.create;
                if (Decimal.TryParse(preco, out decimal d))
                {
                    Aluno p = new Aluno(nome, d);
                    alunos.Add(p);
                    alunoEmFoco = p;
                    currentScreen = Screens.details;
                    return;
                }
                else
                {
                    ScreenHelper.PrintError("Este não é um preço válido");
                }
            }
        }
    }
}
