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
            AnsiConsole.Write(ScreenHelper.InitHeader("Alunos cadastrados"));

            Markup aprov(bool aprovado) {
                return new Markup(foco.Aprovado ?
                    "[green invert]Aprovado[/]" : "[red invert]Reprovado[/]");
            };

            var table = new Table()
                .Border(TableBorder.HeavyEdge)
                .Expand()
                .AddColumn("[bold yellow]Nome[/]")
                .AddColumn("[bold yellow]Turma[/]")
                .AddColumn("[bold yellow]Periodo[/]")
                .AddColumn("[bold yellow]Aprovado[/]")
                .AddColumn("[bold yellow]Matricula[/]");

            foreach (var aluno in data)
            {
                table.AddRow(
                    new Markup(aluno.Nome),
                    new Markup(aluno.Turma.ToString()),
                    new Markup(aluno.Periodo.ToString()),
                    aprov(aluno.Aprovado),
                    new Markup(aluno.GUID.ToString())
                );
            };


            AnsiConsole.Write(table);

            return AnsiConsole.Prompt(
                new SelectionPrompt<Screens>()
                {
                    Converter = value => {
                        return (value == Screens.search) ? " Pesquisar" :
                            (value == Screens.create) ? "Adicionar aluno" :
                            (value == Screens.main) ? "Voltar ao inicio" : value.ToString();
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
