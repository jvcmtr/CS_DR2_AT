using AlunosLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository
    {
        ICollection<Aluno> Load();
        void Save(ICollection<Aluno> alunoList);
    }
}
