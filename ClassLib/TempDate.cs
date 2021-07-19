using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib
{
    public class TempDate
    {
        private int _dateHours;
        private float _tempC;
        private DateTime _dateTime;

        public TempDate() { }

        public TempDate(float tempC)
        {
            _dateTime = DateTime.Now;
            _tempC = tempC;
            InitDateHours();
        }

        public TempDate(float tempC, DateTime dt)
        {
            _dateTime = dt;
            _tempC = tempC;
            InitDateHours();
        }

        public int DateHours
        {
            get { return _dateHours; }
            set { _dateHours = value; }
        }

        public void InitDateHours()
        {
            int year = _dateTime.Year * 1000000;
            int month = _dateTime.Month * 10000;
            int date = _dateTime.Day * 100;
            _dateHours = year + month + date + _dateTime.Hour;
        }

        public DateTime Datetime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public float TempCelcius
        {
            get { return _tempC; }
            set { _tempC = value; }
        }

        public static int FromDateTimeToDateHours(DateTime dt)
        {
            int year = dt.Year * 1000000;
            int month = dt.Month * 10000;
            int date = dt.Day * 100;
            return year + month + date + dt.Hour;
        }

        public float TempFahrenheit
        {
            get
            {
                return (_tempC * 9 / 5) + 32;
            }
        }

        public int Hour
        {
            get
            {
                return _dateHours % 100;
            }
        }

        public int Day
        {
            get
            {
                return ((_dateHours % 10000) - this.Hour) / 100;
            }
        }

        public int Month
        {
            get
            {
                return ((_dateHours % 1000000) - this.Day - this.Hour) / 10000;
            }
        }

        public int Year
        {
            get
            {
                return (_dateHours - this.Month - this.Day - this.Hour) / 1000000;
            }
        }
        
    }
}
