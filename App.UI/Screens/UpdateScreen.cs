using AlunosLib;
using Spectre.Console;
using Spectre.Console.Rendering;
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
            AnsiConsole.Clear();
            Aluno Editado = new Aluno(foco.Nome, foco.Periodo, foco.Turma, foco.Aprovado, foco.GUID.ToString());

            Renderable editedTable = ScreenHelper.AlunoInfoTable(Editado);
            Renderable editedPanel = ScreenHelper.InitPanel(editedTable, "EDITADO");

            Renderable f = ScreenHelper.AlunoInfoTable(foco);
            Renderable originalPanel = ScreenHelper.InitPanel(f, "ORIGINAL");

            var render = ScreenHelper.groupHorizontal(originalPanel, editedPanel);
            AnsiConsole.Write(render);

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
                editedPanel = ScreenHelper.InitPanel(editedTable, "EDITADO");
                AnsiConsole.Clear();

                render = ScreenHelper.groupHorizontal(originalPanel, editedPanel);
                AnsiConsole.Write(render);
            }

            if (option == options[4])
            {
                foco = Editado;
                var nList = new List<Aluno>();
                foreach (var al in data)
                {
                    if (al.GUID != foco.GUID)
                        nList.Add(al);
                    else
                        nList.Add(foco);
                }
                data = nList;
            }

            return Screens.details;
        }
    }
}
