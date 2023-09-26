using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class MainScreen : BaseScreen
    {
        public MainScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override Screens Display()
        {
            AnsiConsole.Clear();
            var header = ScreenHelper.InitHeader("Cadastro de Alunos");
            AnsiConsole.Write(header);

            return AnsiConsole.Prompt(
                new SelectionPrompt<Screens>()
                {
                    Converter = value => {
                        return (value == Screens.search) ? " Pesquisar" :
                            (value == Screens.create) ? "Adicionar aluno" :
                            (value == Screens.list) ? "Ver todos os alunos" :
                            (value == Screens.exit) ? "Sair" : value.ToString();
                    }
                }
                .AddChoices(new[] {
                                Screens.create,
                                Screens.search,
                                Screens.list,
                                Screens.exit
                })
                );
        }
    }
}
