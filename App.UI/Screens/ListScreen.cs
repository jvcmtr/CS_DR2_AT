using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class ListScreen : BaseScreen
    {
        public ListScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override Screens Display()
        {
            AnsiConsole.Clear();

            var layout = new Layout("root")
                .SplitColumns(
                    new Layout("left"),
                    new Layout("right")
                    .SplitRows(
                         new Layout("uper"),
                         new Layout("midle"),
                         new Layout("bottom")
                        )
                    );

            var table = ScreenHelper.AlunoList(data);
            var p1 = ScreenHelper.InitPanel(table.Collapse(), "Relatorio de Alunos");
            layout["left"].Update(p1);

            var p2 = ScreenHelper.InitPanel(ScreenHelper.TurmaGraph(data).Collapse(), "Alunos por turma");
            layout["midle"].Update(p2);

            AnsiConsole.Write(layout);
            AnsiConsole.Console.WriteLine();

            return AnsiConsole.Prompt(
                new SelectionPrompt<Screens>()
                {
                    Converter = value => {
                        return (value == Screens.search) ? " Pesquisar" :
                            (value == Screens.create) ? " Adicionar aluno" :
                            (value == Screens.main) ? " Voltar ao inicio" : value.ToString();
                    }
                }
                .AddChoices(new[] {
                    Screens.main,
                    Screens.create,
                    Screens.search
                })
                );

        }
    }
}
