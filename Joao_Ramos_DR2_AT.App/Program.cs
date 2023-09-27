using AlunosLib;
using App;
using DAL;

namespace Joao_Ramos_DR2_AT.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Console.BackgroundColor = ConsoleColor.Black;
            
            //IRepository? repos = (args.Length != 0)? ReposInitializer.getRepoFromArgs(args) : ReposInitializer.getRepos();

            IRepository repos = new ListRepos();
            Console.WriteLine("repos : ");
            Console.WriteLine(repos);

            if (repos is not null)
            {
                BLL app = new BLL(repos);
                app.run();
            }

        }
    }
}