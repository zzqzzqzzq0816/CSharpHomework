using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clock
{
    public delegate void ClockHandler(Clock clock, ClockEventArgs args);
    public class ClockEventArgs
    {
        public int Hour { get; set; }
        public int Min { get; set; }
        public  int Sec { get; set; }
    }
    public class Clock
    {
        public event ClockHandler OnTick;
        public event ClockHandler OnAlarm;
        public int AlarmHour { get; set; }
        public int AlarmMin { get; set; }
        public int AlarmSec { get; set; }
        public void InitClock(int hour,int min,int sec)
        {
            Console.WriteLine("init clock with " + hour + ":" + min + ":" + sec);
            ClockEventArgs args = new ClockEventArgs() { Hour=hour,Min=min,Sec=sec };
            while (true)
            {
                OnTick(this, args);
                OnAlarm(this, args);
                Thread.Sleep(1000);
            }
        }
        
    }
    public class Person
    {
        public Person()
        {
            clock.OnTick += ClockOnTick;
            clock.OnAlarm += ClockOnAlarm;
        }
        public Clock clock = new Clock();
        public void SetAlarm(int hour,int min,int sec)
        {
            clock.AlarmHour = hour;
            clock.AlarmMin = min;
            clock.AlarmSec = sec;
        }
        //在用户按下闹钟开关后，闹钟才可以开始走
        public void ClockOnTick(Clock clock,ClockEventArgs args)
        {
            args.Sec++;
            if (args.Sec == 60)
            {
                args.Sec = 0;
                args.Min++;
            }
            if (args.Min == 60)
            {
                args.Min = 0;
                args.Hour = 0;
            }
            if(args.Hour==24)
            {
                args.Hour = 0;
            }
            Console.WriteLine("Tick..." + args.Hour + ":" + args.Min + ":" + args.Sec);
        }
        public void ClockOnAlarm(Clock clock,ClockEventArgs args)
        {
            if (clock.AlarmHour == args.Hour && clock.AlarmMin == args.Min && clock.AlarmSec == args.Sec)
            {
                Console.WriteLine("Alarm..." + args.Hour + ":" + args.Min + ":" + args.Sec);
            }
        }
        public void Start(int hour,int min,int sec)
        {
            clock.InitClock(hour,min,sec);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.SetAlarm(3, 2, 25);
            person.Start(3, 2, 10);
        }
    }
}
