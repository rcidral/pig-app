using Models;

namespace Controllers
{

    public class Expenses
    {

        public static void store(Models.Expenses expenses)
        {
            try
            {
                Models.Expenses.store(expenses);
                Controllers.Room.updateValue(expenses.Reservation.RoomId, expenses.Value);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static List<Models.Expenses> index()
        {
            try
            {
                return Models.Expenses.index();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static List<Models.Expenses> show(int id)
        {
            try
            {
                return Models.Expenses.show(id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static void update(int id, Models.Expenses expenses)
        {
            try
            {
                Models.Expenses.update(id, expenses);
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
                Models.Expenses.destroy(id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}

