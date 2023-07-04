using Database;

namespace Models
{

    public class Expenses
    {

        public int Id { get; set; }

        public virtual Product Product { get; set; }
        public virtual Reservation Reservation { get; set; }
        public int ProductId { get; set; }
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public Expenses(int productId, int reservationId, double value)
        {
            this.ProductId = productId;
            this.ReservationId = reservationId;
            this.Date = DateTime.Now;
            this.Value = value;
        }

        public static void store(Expenses expenses)
        {
            try
            {
                using (Context context = new Context())
                {
                    context.Expenses.Add(expenses);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Expenses> index()
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Expenses.ToList();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Expenses> show(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Expenses.Where(expenses => expenses.Id == id).ToList();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void update(int id, Expenses expenses)
        {
            try
            {
                using (Context context = new Context())
                {
                    Expenses oldExpenses = context.Expenses.Find(id);
                    oldExpenses.Product = expenses.Product;
                    oldExpenses.Reservation = expenses.Reservation;
                    oldExpenses.Date = expenses.Date;
                    oldExpenses.Value = expenses.Value;
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
                    Expenses expenses = context.Expenses.Find(id);
                    context.Expenses.Remove(expenses);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}