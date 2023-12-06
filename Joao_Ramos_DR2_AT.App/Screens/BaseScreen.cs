using AlunosLib;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Screens
{
    internal abstract class BaseScreen
    {
        protected BaseScreen previous;
        protected List<Aluno> data;
        protected BaseScreen next;

        public BaseScreen(BaseScreen previous, List<Aluno> data)
        {
            this.previous = previous;
            this.data = data;
        }

        internal abstract Screens Display();
    }
}
