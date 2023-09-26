using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class UpdateScreen : BaseScreen
    {
        public UpdateScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override Screens Display()
        {
            Aluno Editado = foco;
            string[] options = new string[]{
                "Nome",
                "Turma",
                "Periodo",
                "Aprovado",
                "salvar alterações",
                "cancelar"
            };
            string option = "";

            while (option != options[4] && option != options[5])
            {
                option = AnsiConsole.Prompt(
                  new SelectionPrompt<string>()
                      .Title(" Editar ")
                      .AddChoices(options)
                  );

                if (option == options[0])
                    Editado.Nome = AnsiConsole.Prompt<string>( new TextPrompt<string>(" Nome : "));

                if (option == options[1])
                    Editado.Turma = AnsiConsole.Prompt(
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
                        );

                if (option == options[2]) 
                    Editado.Periodo = AnsiConsole.Prompt<int>(
                        new TextPrompt<int>(" Periodo : ")
                        );

                if (option == options[3])
                    Editado.Aprovado = AnsiConsole.Confirm(" Aprovado ");
                
            }

            if (option == options[4])
            {
                foco = Editado;
                var r = data.Find(a1 => a1.GUID == foco.GUID);
                r = foco;
            }

            return Screens.details;
        }
    }
}
