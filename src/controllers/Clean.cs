using Models;

namespace Controllers
{
    public class Clean
    {
        public static void store(Models.Clean clean)
        {
            try
            {
                Models.Clean.store(clean);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static void update(int id, Models.Clean clean)
        {
            try
            {
                Models.Clean.update(id, clean);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static void destroy(int id)
        {
            try
            {
                Models.Clean.destroy(id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static List<Models.Clean> index()
        {
            try
            {
                return Models.Clean.index();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static Models.Clean show(int id)
        {
            try
            {
                return Models.Clean.show(id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static Models.Clean findByNumberRoom(int numberRoom)
        {
            try
            {
                return Models.Clean.findByNumberRoom(numberRoom);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}