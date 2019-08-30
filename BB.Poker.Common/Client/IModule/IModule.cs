using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BB.Poker.Common
{
    public interface IModule<T> where T : IModuleHost
    {
        string Name { get; }

        void Focus(Control target);

        T Host { get; }
    }
}
