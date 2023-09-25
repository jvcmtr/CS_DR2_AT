using AlunosLib;
using DAL;

namespace Joao_Ramos_DR2_AT.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> list = new List<Aluno>();
            list.Add(new Aluno("jao", 4, Turmas.EAD, false));
            list.Add(new Aluno("pepi", 2, Turmas.manha1, false));

            IRepository repos = new FileRepos("./data.txt", FileHelper.CSVSerialize, FileHelper.CSVDeserialize);

            repos.Save(list);

            list = repos.Load().ToList();

            Console.WriteLine(FileHelper.CSVSerialize(list));
         }

    }
}