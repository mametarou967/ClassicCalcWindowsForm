using ClassicCalcWindowsForm.Common;
using ClassicCalcWindowsForm.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalcWindowsForm
{
    class CalcManager : IObservable<CalcResultEvent> , IObserver<InputNumberEvent>
    {
        List<IObserver<CalcResultEvent>> calcResultList = new List<IObserver<CalcResultEvent>>();
        int tempValue = 0;


        public void OnNext(InputNumberEvent value)
        {
            if(value.InputStatus == InputStatus.Inputed)
            {
                if (value.InputOperation == InputOperation.Add) tempValue += value.Number;
                else if (value.InputOperation == InputOperation.Sub) tempValue -= value.Number;
                if (value.InputOperation == InputOperation.Mult) tempValue *= value.Number;
                if (value.InputOperation == InputOperation.Div) tempValue /= value.Number;

                calcResultList.ForEach(x => x.OnNext(new CalcResultEvent() { Number = tempValue }));
            }
        }

        public IDisposable Subscribe(IObserver<CalcResultEvent> observer)
        {
            if (!calcResultList.Contains(observer))
                calcResultList.Add(observer);
            //購読解除用のクラスをIDisposableとして返す
            return new Unsubscriber<CalcResultEvent>(calcResultList, observer);
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
