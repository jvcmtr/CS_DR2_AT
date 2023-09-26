using AlunosLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class DeleteScreen : BaseScreen
    {
        public DeleteScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override BaseScreen Display()
        {

            Console.Clear();

            ScreenHelper.PrintHeader("Adicionar aluno");
            ScreenHelper.helperText($"digite {returnCommand} para voltar");
            ScreenHelper.helperText($"deixe em branco para manter o mesmo valor");

            Console.Write(" Nome :\t");
            string nome = ScreenHelper.getInputWithDefault(alunoEmFoco.nome);

            if (nome == returnCommand)
            {
                currentScreen = lastScreen;
                return;
            }

            while (true)
            {
                Console.Write("Preço :\t");
                string preco = ScreenHelper.getInputWithDefault(alunoEmFoco.nome);
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
                    alunos.Remove(alunoEmFoco);
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
