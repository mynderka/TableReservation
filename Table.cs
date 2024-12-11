using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class Table
    {
        public int Number { get; }
        private readonly HashSet<DateTime> _bookedDates;

        public Table(int number)
        {
            Number = number;
            _bookedDates = new HashSet<DateTime>();
        }

        public bool Book(DateTime date)
        {
            if (_bookedDates.Contains(date))
            {
                Console.WriteLine($"Table {Number} is already booked on {date:yyyy-MM-dd}.");
                return false;
            }

            _bookedDates.Add(date);
            return true;
        }

        public bool IsBooked(DateTime date)
        {
            return _bookedDates.Contains(date);
        }

        public IEnumerable<DateTime> GetBookedDates()
        {
            return _bookedDates;
        }
    }
}

