using AlunosLib;
using App.UI;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class BLL
    {
        ICollection<Aluno> Data;
        IRepository Repos;
        
        BaseScreen currentScreen;
        Screens next = Screens.main;

        public BLL(IRepository repos)
        {
            this.Repos = repos;
            this.Data = Repos.Load();
            this.currentScreen = new MainScreen(Data.ToList());
        }


        public void run()
        {
            while (next != Screens.exit)
            {
                next = currentScreen.Display();
                Data = currentScreen.getData();
                updateCurrentScreen();
            }

            Repos.Save(Data);
        }

        private void updateCurrentScreen()
        {
            switch (next)
            {
                case Screens.main:
                    currentScreen = new MainScreen(currentScreen, Data.ToList());
                    break;
                case Screens.create:
                    currentScreen = new CreateScreen(currentScreen, Data.ToList());
                    break;
                case Screens.update:
                    currentScreen = new UpdateScreen(currentScreen, Data.ToList());
                    break;
                case Screens.delete:
                    currentScreen = new DeleteScreen(currentScreen, Data.ToList());
                    break;
                case Screens.list:
                    currentScreen = new ListScreen(currentScreen, Data.ToList());
                    break;
                case Screens.details:
                    currentScreen = new DetailsScreen(currentScreen, Data.ToList());
                    break;
                case Screens.search:
                    currentScreen = new SearchScreen(currentScreen, Data.ToList());
                    break;
                default:
                    break;
            }
        }
    }
}
