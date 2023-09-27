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

            var table = ScreenHelper.AlunoList(data)    ;
            var list = ScreenHelper.InitPanel(table, "Relatorio de Alunos");

            var graph = ScreenHelper.TurmaGraph(data);
            var p2 = ScreenHelper.InitPanel(graph, "Distribuicao por Turma");

            var graph2 = ScreenHelper.AprovadosGraph(data);
            var p3 = ScreenHelper.InitPanel(graph2, "Distribuicao por Turma");

            var metrics = ScreenHelper.groupVertical(p2, p3);
            var render = ScreenHelper.groupHorizontal(list, metrics);

            AnsiConsole.Write(render);



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
