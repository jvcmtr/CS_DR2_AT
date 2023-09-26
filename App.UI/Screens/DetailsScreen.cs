using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class DetailsScreen : BaseScreen
    {
        public DetailsScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override Screens Display()
        {
            AnsiConsole.Clear();
            var alunoInfo = new Table()
                .AddColumn(new TableColumn($"[bold yellow]Aluno[/]").Centered())
                .AddColumn(new TableColumn($"[bold yellow]{foco.Nome}[/]"))
                .Expand()
                .Border(TableBorder.Rounded)
                .AddRow( new Markup( "Matricula" ), new Markup( foco.GUID.ToString() ) )
                .AddRow(new Markup("Turma"), new Markup( foco.Turma.ToString() ) )
                .AddRow(new Markup("Periodo"), new Markup(foco.Periodo.ToString() ) )
                .AddRow(new Markup("Aprovado"), new Markup(foco.Aprovado ? "[green invert]Aprovado[/]" : "[red invert]Reprovado[/]"));

            var info = new Panel(alunoInfo)
                .Border(BoxBorder.Rounded)
                .Header("[bold blue] Detalhes do aluno [/]");
                
            AnsiConsole.Write(info);

            return AnsiConsole.Prompt(
                new SelectionPrompt<Screens>(){ 
                    Converter = value =>{
                        return (value == Screens.delete) ? "Deletar" :
                            (value == Screens.update) ? "Editar" :
                            (value == Screens.main) ? "Voltar ao inicio" : value.ToString();
                    }
                }
                .AddChoices(new[] { 
                    Screens.main,
                    Screens.update,
                    Screens.delete
                })
                );
        }
    }
}
