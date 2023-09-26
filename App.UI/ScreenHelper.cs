using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UI
{
    public static class ScreenHelper
    {

        public static Table InitHeader( string header)
        {
            var r = new Table()
                .AddColumn(new TableColumn($"[bold blue]\t{header}[/]").Centered())
                .Expand()
                .Border(TableBorder.Horizontal);
            return r;
        }


    }
}
