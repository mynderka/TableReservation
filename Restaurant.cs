using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public class Restaurant
    {
        public string Name { get; }
        private readonly List<Table> _tables;

        public Restaurant(string name, int tableCount)
        {
            Name = name;
            _tables = new List<Table>();

            for (int i = 0; i < tableCount; i++)
            {
                _tables.Add(new Table(i + 1));
            }
        }

        public List<string> GetFreeTables(DateTime date)
        {
            var freeTables = new List<string>();

            foreach (var table in _tables)
            {
                if (!table.IsBooked(date))
                {
                    freeTables.Add($"{Name} - Table {table.Number}");
                }
            }

            return freeTables;
        }

        public bool BookTable(DateTime date, int tableNumber)
        {
            if (tableNumber <= 0 || tableNumber > _tables.Count)
            {
                Console.WriteLine("Invalid table number.");
                return false;
            }

            return _tables[tableNumber - 1].Book(date);
        }

        /*public List<int> GetBookedTables(DateTime date)
        {
            var bookedTables = new List<int>();

            foreach (var table in _tables)
            {
                if (table.IsBooked(date))
                {
                    bookedTables.Add(table.Number);
                }
            }

            return bookedTables;
        }*/

        public List<string> GetBookedTablesWithDates()
        {
            var bookedDetails = new List<string>();

            foreach (var table in _tables)
            {
                foreach (var date in table.GetBookedDates())
                {
                    bookedDetails.Add($"Table {table.Number} booked on {date:yyyy-MM-dd}");
                }
            }

            return bookedDetails;
        }

        public int GetAvailableTableCount(DateTime date)
        {
            int count = 0;

            foreach (var table in _tables)
            {
                if (!table.IsBooked(date))
                {
                    count++;
                }
            }

            return count;
        }
    }

}