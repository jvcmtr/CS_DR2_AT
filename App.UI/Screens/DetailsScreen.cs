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
            var alunoInfo = ScreenHelper.AlunoInfoTable(foco);


            var p = ScreenHelper.InitPanel(alunoInfo, "Detalhes do aluno");
                
            AnsiConsole.Write(p);

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
