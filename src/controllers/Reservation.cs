using Models;

namespace Controllers
{

    public class Reservation
    {

        public static void store(Models.Reservation reservation)
        {
            try
            {
                Models.Reservation.store(reservation);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static List<Models.Reservation> index()
        {
            try
            {
                return Models.Reservation.index();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static List<Models.Reservation> show(int id)
        {
            try
            {
                return Models.Reservation.show(id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static void update(int id, Models.Reservation reservation)
        {
            try
            {
                Models.Reservation.update(id, reservation);
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
                Models.Reservation.destroy(id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void findByNumberRoom(int numberRoom)
        {
            try
            {
                Models.Reservation.findByNumberRoom(numberRoom);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}

