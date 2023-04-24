using ReserveRoverDAL.Entities;

namespace ReserveRoverBLL.Helpers.Models;

public class TablesHelper
{
    public class Table
    {
        public List<Reservation> Reservations { get; set; }

        public Table()
        {
            Reservations = new List<Reservation>();
        }

        public bool HasTimeFor(Reservation newReservation)
        {
            var hasFreeTime = true;

            foreach (var reservation in Reservations)
            {
                if (reservation.ReservDate == newReservation.ReservDate &&
                    ((reservation.BeginTime <= newReservation.BeginTime &&
                      reservation.EndTime > newReservation.BeginTime) ||
                     (reservation.BeginTime >= newReservation.BeginTime && reservation.BeginTime < newReservation.EndTime)))
                {
                    hasFreeTime = false;
                    break;
                }
            }

            return hasFreeTime;
        }
    }
    
    public static List<Table> TablesReservationsFromTableSets(TableSet tableSet, List<Reservation> reservations)
    {
        var tables = Enumerable.Range(1, tableSet.TablesNum).Select(_ => new Table()).ToList();
        for (var index = 0; index < reservations.Count; index++)
        {
            var reservation = reservations[index];
            for (var i = 0; i < tables.Count; i++)
            {
                var table = tables[i];
                if (table.HasTimeFor(reservation))
                {
                    table.Reservations.Add(reservation);
                    reservations.RemoveAt(index);
                    index--;
                    break;
                }
            }
        }

        return tables;
    }
}