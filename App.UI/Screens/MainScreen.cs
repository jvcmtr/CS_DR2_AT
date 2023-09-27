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

        public MainScreen(List<Aluno> Data) : base(null, Data)
        {
            foco = new Aluno("", 0, Turmas.ERRO, false);
        }

        public override Screens Display()
        {
            AnsiConsole.Clear();
            var aprovados = new BreakdownChart()
                .Compact(true)
                .AddItem("Aprovados", data.FindAll(aluno => aluno.Aprovado).Count, Color.Green)
                .AddItem("Reprovados", data.FindAll(aluno => !aluno.Aprovado).Count, Color.Red)
                .Width(Config.width);


            var p = ScreenHelper.InitPanel(aprovados, "Cadastro de Alunos");
            AnsiConsole.Write(p);

            return AnsiConsole.Prompt(
                new SelectionPrompt<Screens>()
                {
                    Converter = value => {
                        return (value == Screens.search) ? " Pesquisar" :
                            (value == Screens.create) ? " Adicionar aluno" :
                            (value == Screens.list) ? " Ver todos os alunos" :
                            (value == Screens.exit) ? " Sair" : value.ToString();
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
