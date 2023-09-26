using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class CreateScreen : BaseScreen
    {
        public CreateScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override Screens Display()
        {
            AnsiConsole.Clear();

            var header = ScreenHelper.InitHeader("Adicionar aluno");
            AnsiConsole.Write(header);
            //ScreenHelper.helperText($"digite {returnCommand} para voltar");

            string nome = AnsiConsole.Prompt<string>(
                new TextPrompt<string>(" Nome : ")
                );
            Turmas turma = AnsiConsole.Prompt(
                new SelectionPrompt<Turmas>()
                    .Title(" Turma : ")
                    .PageSize(3)
                    .AddChoices(new[]
                    {
                        Turmas.EAD,
                        Turmas.manha_1,
                        Turmas.manha_2,
                        Turmas.tarde,
                        Turmas.noite_1,
                        Turmas.noite_2
                    })
                ) ;
            int periodo = AnsiConsole.Prompt<int>(
                new TextPrompt<int>(" Periodo : ")
                );
            bool aprovado = AnsiConsole.Confirm(" Aprovado ");

            var foco = new Aluno(nome, periodo, turma, aprovado);
            data.Add(foco);

            return Screens.details;
            
        }
    }
}
