using AlunosLib;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public abstract class BaseScreen
    {
        protected BaseScreen previous;
        protected List<Aluno> data;
        protected Aluno foco;
        protected BaseScreen next;

        public BaseScreen(BaseScreen previous, List<Aluno> data)
        {
            this.previous = previous;
            this.data = data;
            foco = previous.foco;
        }

        public List<Aluno> getData()
        {
            return data;
        }

        public abstract Screens Display();
    }
}
