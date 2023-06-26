using Models;

namespace Controllers
{
    public class Guest
    {
        public static void store(Models.Guest guest)
        {
            try
            {
                List<Models.Guest> existingGuests = Controllers.Guest.index();

                foreach (Models.Guest existingGuest in existingGuests)
                {
                    if (existingGuest.Document == guest.Document)
                    {
                        throw new System.Exception("Guest already exists");
                    }
                }
                Models.Guest.store(guest);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static List<Models.Guest> index()
        {
            try
            {
                return Models.Guest.index();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static List<Models.Guest> show(int id)
        {
            try
            {
                return Models.Guest.show(id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static void update(int id, Models.Guest guest)
        {
            try
            {
                Models.Guest.update(id, guest);
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
                Models.Guest.destroy(id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void login(string name, string password) {
            try
            {
                Models.Guest.Login(name, password);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
