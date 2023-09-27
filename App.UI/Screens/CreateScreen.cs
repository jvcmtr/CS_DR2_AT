using AlunosLib;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public class CreateScreen : BaseScreen
    {
        public CreateScreen(BaseScreen previous, List<Aluno> data) : base(previous, data)
        {
        }

        public override Screens Display()
        {
            var t = new Table()
                .AddColumn("Nome : ")
                .Border(TableBorder.None);
            updatePanel(t);

            string nome = ScreenHelper.getNome();
            t.AddColumn(nome);
            updatePanel(t);


            Turmas turma = ScreenHelper.getTurma();
            t.AddRow(new[] { "Turma", turma.ToString() });
            updatePanel(t);



            int periodo = ScreenHelper.getPeriodo();
            t.AddRow(new[] { "Periodo", periodo.ToString() });
            updatePanel(t);

            bool aprovado = AnsiConsole.Confirm(" Aprovado ");

            foco = new Aluno(nome, periodo, turma, aprovado);
            data.Add(foco);

            return Screens.details;
            
        }

        internal void updatePanel(Table t)
        {
            AnsiConsole.Background = Config.background;
            AnsiConsole.Clear();
            var header = ScreenHelper.InitPanel(t, "Adicionar aluno");
            AnsiConsole.Write(header);
        }
    }
}
