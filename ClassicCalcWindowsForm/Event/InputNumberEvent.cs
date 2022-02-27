using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalcWindowsForm.Event
{
    public enum InputStatus
    {
        Inputting,
        Inputed
    }

    public enum InputOperation
    {
        Add,
        Sub,
        Div,
        Mult,
        Equal,
    }

    public struct InputNumberEvent
    {
        public InputStatus InputStatus { get; set; }

        public InputOperation? InputOperation  { get; set;}

        public int Number { get; set; }
    }
}
