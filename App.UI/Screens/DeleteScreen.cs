using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class DeleteScreen : BaseScreen
    {
        public DeleteScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override Screens Display()
        {
            AnsiConsole.Foreground = Config.regular;
            if (AnsiConsole.Confirm("[red bold] TEM CERTEZA QUE DESEJA DELETAR O ALUNO [/]", false))
            {
                data.Remove(foco);
                return Screens.main;
            }
            return Screens.details;
        }
    }
}
