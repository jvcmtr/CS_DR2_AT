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

            Table editedTable = ScreenHelper.AlunoInfoTable(Editado);
            Panel editedPanel = ScreenHelper.InitPanel(editedTable, "EDITADO");

            Table f = ScreenHelper.AlunoInfoTable(foco);
            Panel originalPanel = ScreenHelper.InitPanel(f, "ORIGINAL");

            var layout = new Layout("root")
                .SplitColumns(
                    new Layout("left"),
                    new Layout("right")
                    );
            layout["left"].Update(editedPanel);
            layout["right"].Update(editedPanel);
            AnsiConsole.Write(layout);

            string[] options = new string[]{
                "Nome",
                "Turma",
                "Periodo",
                "Aprovado",
                "salvar",
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
                    Editado.Nome = ScreenHelper.getNome();

                if (option == options[1])
                    Editado.Turma = ScreenHelper.getTurma();

                if (option == options[2])
                    Editado.Periodo = ScreenHelper.getPeriodo();

                if (option == options[3])
                    Editado.Aprovado = ScreenHelper.getAprovado();

                editedTable = ScreenHelper.AlunoInfoTable(Editado);
                editedPanel = ScreenHelper.InitPanel(editedPanel, "EDITADO");
                layout["right"].Update(editedTable);
                AnsiConsole.Clear();
                AnsiConsole.Write(layout);
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
