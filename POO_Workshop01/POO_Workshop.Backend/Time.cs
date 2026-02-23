using System;

namespace POO_Workshop.Backend
{
    public class Time
    {

        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;


        public int Hour
        {
            get => _hour;
            set => _hour = ValidHour(value);
        }

        public int Minute
        {
            get => _minute;
            set => _minute = ValidMinute(value);
        }

        public int Second
        {
            get => _second;
            set => _second = ValidSecond(value);
        }

        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = ValidMillisecond(value);
        }

        public Time()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
            Millisecond = 0;
        }

        public Time(int h)
        {
            Hour = h;
        }

        public Time(int h, int m)
        {
            Hour = h;
            Minute = m;
        }

        public Time(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;
        }

        public Time(int h, int m, int s, int ms)
        {
            Hour = h;
            Minute = m;
            Second = s;
            Millisecond = ms;
        }

        private int ValidHour(int value)
        {
            if (value < 0 || value > 23)
                throw new Exception($"The hour: {value}, is not valid.");

            return value;
        }

        private int ValidMinute(int value)
        {
            if (value < 0 || value > 59)
                throw new Exception("Minute is not valid.");

            return value;
        }

        private int ValidSecond(int value)
        {
            if (value < 0 || value > 59)
                throw new Exception("Second is not valid.");

            return value;
        }

        private int ValidMillisecond(int value)
        {
            if (value < 0 || value > 999)
                throw new Exception("Millisecond is not valid.");

            return value;
        }

        public long ToMilliseconds()
        {
            return (((_hour * 60) + _minute) * 60 + _second) * 1000 + _millisecond;
        }

        public long ToSeconds()
        {
            return _hour * 3600 + _minute * 60 + _second;
        }

        public long ToMinutes()
        {
            return _hour * 60 + _minute;
        }

        public bool IsOtherDay(Time t)
        {
            long total = this.ToMilliseconds() + t.ToMilliseconds();

            return total >= 86400000;
        }

        public Time Add(Time t)
        {
            long total = this.ToMilliseconds() + t.ToMilliseconds();

            total = total % 86400000;

            int h = (int)(total / 3600000);
            total %= 3600000;

            int m = (int)(total / 60000);
            total %= 60000;

            int s = (int)(total / 1000);
            int ms = (int)(total % 1000);

            return new Time(h, m, s, ms);
        }

        public override string ToString()
        {
            int h12 = _hour % 12;

            if (h12 == 0)
                h12 = 12;

            string tt = _hour >= 12 ? "PM" : "AM";

            return h12.ToString("00") + ":" +
                   _minute.ToString("00") + ":" +
                   _second.ToString("00") + "." +
                   _millisecond.ToString("000") +
                   " " + tt;
        }

    }
}