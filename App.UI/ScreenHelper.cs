using AlunosLib;
using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public static class ScreenHelper
    {
        public static Renderable InitPanel(IRenderable content, string header = "")
        {
            header = "[bold yellow] " + header + " [/]";
            var r = new Panel(content)
                .Header(header)
                .Collapse()
                .Padding(Config.padding, 1)
                .Border(BoxBorder.Double);
            r.Width = Config.width;
            return r;
        }

        public static string getNome(string prompt = "[bold] Nome : [/]")
        {
            return AnsiConsole.Prompt<string>(new TextPrompt<string>(prompt));
        }

        public static Turmas getTurma()
        {
            Turmas t = AnsiConsole.Prompt(
                new SelectionPrompt<Turmas>()
                    .Title(" Turma : ")
                    .PageSize(4)
                    .MoreChoicesText("[dim]...[/]")
                    .HighlightStyle(new Style(foreground: Config.highlight))
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
            AnsiConsole.WriteLine("[bold] Turma : [/]" + t.ToString() );
            return t;
        }

        public static int getPeriodo(string prompt = "[bold] Periodo : [/]")
        {
            return AnsiConsole.Prompt<int>(
                new TextPrompt<int>(prompt)
                );
        }

        public static bool getAprovado()
        {
            return AnsiConsole.Confirm(" Aprovado ");
        }

        public static Renderable AlunoInfoTable(Aluno foco)
        {
            return new Table()
                .AddColumn(new TableColumn($"[bold yellow]Aluno[/]").RightAligned())
                .AddColumn(new TableColumn($"[bold yellow]{foco.Nome}[/]"))
                .Border(TableBorder.Rounded)
                .AddRow(new Markup("Matricula"), new Markup(foco.GUID.ToString()))
                .AddRow(new Markup("Turma"), new Markup(foco.Turma.ToString()))
                .AddRow(new Markup("Periodo"), new Markup(foco.Periodo.ToString()))
                .AddRow(new Markup("Aprovado"), aprov(foco.Aprovado));
        }

        public static Markup aprov(bool aprovado)
        {
            return new Markup(aprovado ?
                "[green invert]Aprovado[/]" : "[red invert]Reprovado[/]");
        }


        public static Renderable AlunoList(List<Aluno> list, int size = -1)
        {
            var table = new Table()
                .Border(TableBorder.HeavyEdge)
                .AddColumn("[bold yellow]Nome[/]")
                .AddColumn("[bold yellow]Turma[/]")
                .AddColumn("[bold yellow]Periodo[/]")
                .AddColumn("[bold yellow]Aprovado[/]")
                .AddColumn("[bold yellow]Matricula[/]");
            
            bool empty = false;
            if (list == null || list.Count <= 0)
                empty = true;
            else if (size > list.Count || size == -1)
                size = list.Count;
            if (empty)
                return table.AddRow("  Não existem Alunos registrados ainda.");

            for (int i = 0; i < size; i++)
            {
                var aluno = list[i];
                table.AddRow(
                    new Markup(aluno.Nome),
                    new Markup(aluno.Turma.ToString()),
                    new Markup(aluno.Periodo.ToString()),
                    aprov(aluno.Aprovado),
                    new Markup(aluno.GUID.ToString())
                );
            };


            table.AddRow("[dim] ... [/]", "[dim] ... [/]", "[dim] ... [/]", "[dim] ... [/]", "[dim] ... [/]");

            return table.Collapse();
        }

        public static Renderable TurmaGraph(List<Aluno> alunos)
        {
            int m1,m2, t, n1, n2, ead;
            m1 = m2 = t =n1 = n2 = ead = 0;

            foreach(var aluno in alunos)
            {
                switch (aluno.Turma)
                {
                    case Turmas.manha_1:
                        m1++;break;
                    case Turmas.manha_2:
                        m2++; break;
                    case Turmas.tarde:
                        t++; break;
                    case Turmas.noite_1:
                        n1++;  break;
                    case Turmas.noite_2:
                        n2++;  break;
                    case Turmas.EAD:
                        ead++; break;
                    default:
                        break;
                }
            }

            var chart = new BreakdownChart()
                .AddItem(Turmas.manha_1.ToString(), m1, Color.LightGoldenrod1)
                .AddItem(Turmas.manha_2.ToString(), m2, Color.SkyBlue2)
                .AddItem(Turmas.tarde.ToString(), t, Color.SlateBlue1) //pink_3
                .AddItem(Turmas.noite_1.ToString(), n1, Color.NavyBlue)
                .AddItem(Turmas.noite_2.ToString(), n2, Color.DeepSkyBlue4_2)
                .AddItem(Turmas.EAD.ToString(), t, Color.Yellow4_1);

            return chart.Collapse();
        }

        public static Renderable AprovadosGraph(List<Aluno> alunos)
        {
            int nAprovados = 0;

            foreach (var aluno in alunos)
            {
                if (aluno.Aprovado) nAprovados++;
            }

            var chart = new BarChart()
                .AddItem(" Aprovados ", nAprovados, Color.Green3)
                .AddItem(" Reprovados ", alunos.Count - nAprovados, Color.Red3);

            return chart;
        }

        public static Renderable groupVertical(IRenderable r1, IRenderable r2)
        {
            return new Table()
                .Border(TableBorder.None)
                .AddColumns("")
                .AddRow(r1)
                .AddRow(r2);
        }
        public static Renderable groupHorizontal(IRenderable r1, IRenderable r2)
        {
            return new Table()
                .Border(TableBorder.None)
                .AddColumns("", "")
                .AddRow(r1, r2);
        }
    }
}
