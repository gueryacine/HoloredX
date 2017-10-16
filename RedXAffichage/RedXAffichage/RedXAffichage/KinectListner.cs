using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovementWatcher; 

namespace RedXAffichage
{
    class KinectListner : IObserver<KinectEvent>
    {
        private KinectEvent _currentEvent = KinectEvent.None;
        public KinectEvent CurrentEvent
        {
            get
            {
                return _currentEvent;
            }

            set
            {
                _currentEvent = value;
            }
        }

        public void OnCompleted()
        {
            Console.WriteLine("L'observer a fini son travail");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(KinectEvent value)
        {
            CurrentEvent = value;
        }
    }
}
