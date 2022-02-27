using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalcWindowsForm.Common
{
    //購読解除用内部クラス
    class Unsubscriber<T> : IDisposable
    {
        //発行先リスト
        private List<IObserver<T>> m_observers;
        //DisposeされたときにRemoveするIObserver<int>
        private IObserver<T> m_observer;

        public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            m_observers = observers;
            m_observer = observer;
        }

        public void Dispose()
        {
            //Disposeされたら発行先リストから対象の発行先を削除する
            m_observers.Remove(m_observer);
        }
    }
}
