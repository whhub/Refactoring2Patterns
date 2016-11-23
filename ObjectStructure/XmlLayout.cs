using System;

namespace ObjectStructure
{
    internal class XmlLayout : Layout
    {
        private string _xml;

        public XmlLayout(string xml)
        {
            _xml = xml;
            Capacity = CalculateCapacity(xml);
        }

        public override sealed int Capacity { get; protected set; }

        private int CalculateCapacity(string xml)
        {
            throw new NotImplementedException();
        }
    }
}