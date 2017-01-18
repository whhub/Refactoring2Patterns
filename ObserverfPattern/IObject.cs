using System.Collections;
using System.Collections.Generic;

namespace ObserverfPattern
{
    public interface IObject
    {
        IList<IMonitor> Monitors { get; set; }  // 定义观察者集合，因为多个观察者观察一个对象，所以这里用集合
        string SubjectState { get; set; }       // 被观察者的状态

        void AddMonitor(IMonitor monitor);      // 添加一个观察者
        void RemoveMonitor(IMonitor monitor);   // 移除一个观察者

        void SendMessage();                     // 向所有观察者发送消息
    }
}