using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    public partial class BaseGameTable
    {
        protected abstract class BaseGameRoutine : IGameRoutine
        {
            public BaseGameTable Table { get; protected set; }

            public TableState RoutineState { get; protected set; }

            public BaseGameRoutine(BaseGameTable table, TableState newState)
            {
                Table = table;

                RoutineState = newState;
            }

            public virtual void Run()
            {
                Table.CurrentState = RoutineState;
            }
        }
    }
}
