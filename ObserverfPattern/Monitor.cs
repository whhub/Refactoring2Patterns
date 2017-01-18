using System;

namespace ObserverfPattern
{
    class Monitor : IMonitor
    {
        private string _monitorState = "Stop!"; // 观察者初始状态，会随着被观察者变化而变化
        private string _name;                   // 观察者名称，用于标记不同的观察者
        private IObject _subject;               // 被观察者

        public Monitor(string name, IObject subject)    // 在构造观察者时，传入被观察者对象，以及标识观察者的名称
        {
            _name = name;
            _subject = subject;
            Console.WriteLine("我是观察者{0}, 我的初始状态是{1}", _name, _monitorState);
        }

        #region Implementation of IMonitor

        public void Update()    // 当被观察者转台改变，观察者需要随之改变，  这里是Pull模式
        {
            _monitorState = _subject.SubjectState;
            Console.WriteLine("我是观察者{0}, 我的状态是{1}", _name, _monitorState);
        }

        #endregion
    }
}
