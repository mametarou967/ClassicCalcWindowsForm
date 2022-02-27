using ClassicCalcWindowsForm.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicCalcWindowsForm
{
    class DispManager : IObserver<InputNumberEvent> , IObserver<CalcResultEvent>
    {
        TextBox textBox;
        public DispManager(TextBox textBox)
        {
            this.textBox = textBox;
            textBox.Text = "0";
        }

        public void OnNext(InputNumberEvent value)
        {
            textBox.Text = value.Number.ToString();
        }

        public void OnNext(CalcResultEvent value)
        {
            textBox.Text = value.Number.ToString();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

    }
}
