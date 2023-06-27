using Database;

namespace Models
{

    public class Reservation
    {

        public int Id { get; set; }

        public virtual Guest Guest { get; set; }
        public virtual Room Room { get; set; }
        public int GuestId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime Date { get; set; }
        public int DaysOfStay { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double Total { get; set; }

        public Reservation(int guestId, int roomNumber, int daysOfStay, DateTime checkIn, double total)
        {
            this.GuestId = guestId;
            this.RoomNumber = roomNumber;
            this.Date = DateTime.Now;
            this.DaysOfStay = daysOfStay;
            this.CheckIn = checkIn;
            this.CheckOut = this.CheckIn.AddDays(this.DaysOfStay);
            this.Total = total;
        }

        public static void store(Reservation reservation)
        {
            try
            {
                using (Context context = new Context())
                {
                    context.Reservations.Add(reservation);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Reservation> index()
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Reservations.ToList();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Reservation> show(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Reservations.Where(reservation => reservation.Id == id).ToList();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void update(int id, Reservation reservation)
        {
            try
            {
                using (Context context = new Context())
                {
                    Reservation oldReservation = context.Reservations.Find(id);
                    oldReservation.Guest = reservation.Guest;
                    oldReservation.Room = reservation.Room;
                    oldReservation.Date = reservation.Date;
                    oldReservation.DaysOfStay = reservation.DaysOfStay;
                    oldReservation.CheckIn = reservation.CheckIn;
                    oldReservation.CheckOut = reservation.CheckOut;
                    oldReservation.Total = reservation.Total;
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void destroy(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    Reservation reservation = context.Reservations.Find(id);
                    context.Reservations.Remove(reservation);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static Models.Reservation findByNumberRoom(int numberRoom)
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Reservations.FirstOrDefault(reservation => reservation.RoomNumber == numberRoom);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}