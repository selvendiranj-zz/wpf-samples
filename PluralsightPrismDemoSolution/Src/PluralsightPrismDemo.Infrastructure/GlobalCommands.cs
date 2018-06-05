using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPrismDemo.Infrastructure
{
    public static class GlobalCommands
    {
        public static CompositeCommand SaveAllCommand = new CompositeCommand();
    }
}
