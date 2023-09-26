using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal static class ReposInitializer
    {
        internal static IRepository? getRepoFromArgs(string[] args)
        {
            if (args[0] == "list")
                return new ListRepos();

            string path = Path.GetFullPath(args[0]);

            if (path.EndsWith(".json"))
                return getCSVRepos(path);

            if (path.EndsWith(".csv"))
                return getCSVRepos(path);

            return null;
        }



        internal static IRepository getRepos()
        {
            string path = Path.GetFullPath("./data");
            int i = -1;

            while (i >= 0 && i <= 3)
            {
                Console.WriteLine("\n  Qual tipo de persistencia deseja usar ?");
                Console.WriteLine("\t[1] Arquivo JSON");
                Console.WriteLine("\t[2] Arquivo CSV");
                Console.WriteLine("\t[3] lista");
                Console.WriteLine("\t[0] sair");

                string s = Console.ReadLine();
                int.TryParse(s, out i);
            }

            switch (i)
            {
                case 1:
                    return getJSONRepos(path);
                    break;
                case 2:
                    return getCSVRepos(path);
                    break;
                case 3:
                    return new ListRepos();
                    break;
                default:
                    return null;
                    break;
            }
        }

        private static IRepository getJSONRepos(string path)
        {
            return new FileRepos(path, FileHelper.JSONSerialize, FileHelper.JSONDeserialize);
        }

        private static IRepository getCSVRepos(string path)
        {
            return new FileRepos(path, FileHelper.CSVSerialize, FileHelper.CSVDeserialize);
        }

    }
}
