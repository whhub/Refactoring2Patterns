using System;

namespace ObserverfPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new Subject();

            subject.AddMonitor(new Monitor("Monitor1", subject));
            subject.AddMonitor(new Monitor("Monitor2", subject));
            subject.AddMonitor(new Monitor("Monitor3", subject));

            subject.SubjectState = "Start!";
            subject.SendMessage();

            Console.ReadKey();
        }
    }
}
