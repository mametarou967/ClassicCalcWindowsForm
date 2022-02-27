using ClassicCalcWindowsForm.Common;
using ClassicCalcWindowsForm.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalcWindowsForm
{
    // 現在の入力状況を管理して通知する人
    class InputManager : IObservable<InputNumberEvent>
    {
        List<IObserver<InputNumberEvent>> inputNumberList = new List<IObserver<InputNumberEvent>>();

        string tempNumber = string.Empty;
        InputOperation tempOperation = InputOperation.Add;

        public void InputNum(string num)
        {
            // 入力された値を追加
            tempNumber += num;

            // 入力中の値を通知
            inputNumberList.ForEach(x => x.OnNext(
                new InputNumberEvent() {
                    InputStatus = InputStatus.Inputting,
                    Number = Int32.Parse(tempNumber),
                    InputOperation = null }
                ));
        }

        public void InputOpp(InputOperation inputOperation)
        {
            // 符号が確定した時点で前回までの入力状態を確定させる
            if (tempNumber != string.Empty)
            {
                inputNumberList.ForEach(x => x.OnNext(
                    new InputNumberEvent() {
                        InputStatus = InputStatus.Inputed,
                        Number = Int32.Parse(tempNumber) ,
                        InputOperation  = tempOperation
                    }));
            }

            // 今回の符号を保持
            tempOperation = inputOperation;
            // 値は初期化
            tempNumber = string.Empty;
        }

        public IDisposable Subscribe(IObserver<InputNumberEvent> observer)
        {
            if (!inputNumberList.Contains(observer))
                inputNumberList.Add(observer);
            //購読解除用のクラスをIDisposableとして返す
            return new Unsubscriber<InputNumberEvent>(inputNumberList, observer);
        }
    }
}
