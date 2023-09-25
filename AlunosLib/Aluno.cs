using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunosLib
{
    public class Aluno
    {
        public readonly Guid GUID;

        public string Nome { get; set; }
        public Turmas Turma { get; set; }
        public int Periodo { get; set; }
        public bool Aprovado { get; set; }

        public Aluno(string nome, int periodo, Turmas turma, bool aprovado, string GUID = "")
        {
            this.Periodo = periodo;
            this.Nome = nome;
            this.Turma = turma;
            this.Aprovado = aprovado;
            this.GUID = (GUID == "") ? Guid.NewGuid() : new Guid(GUID);
        }
    }
}
