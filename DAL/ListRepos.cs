using AlunosLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ListRepos : IRepository
    {
        private List<Aluno> AlunosList;
        public ListRepos() {
            AlunosList = new List<Aluno>();
        }

        public ICollection<Aluno> Load()
        {
            return AlunosList;
        }

        public void Save(ICollection<Aluno> alunoList)
        {
            AlunosList = alunoList.ToList();
        }
    }
}
