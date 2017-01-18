using System.Collections;
using System.Collections.Generic;

namespace ObserverfPattern
{
    class Subject : IObject
    {
        private IList<IMonitor> _monitors = new List<IMonitor>();

        #region Implementation of IObject

        public IList<IMonitor> Monitors
        {
            get { return _monitors; }
            set { _monitors = value; }
        }

        public string SubjectState { get; set; }

        public void AddMonitor(IMonitor monitor)
        {
            _monitors.Add(monitor);
        }

        public void RemoveMonitor(IMonitor monitor)
        {
            _monitors.Remove(monitor);
        }

        public void SendMessage()
        {
            foreach (var monitor in _monitors)
            {
                monitor.Update();
            }
        }

        #endregion
    }
}
