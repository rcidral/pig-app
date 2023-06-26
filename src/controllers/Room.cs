using Models;

namespace Controllers
{
    public class Room
    {
        public static void store(Models.Room room)
        {
            try
            {
                List<Models.Room> existingRooms = Controllers.Room.index();

                foreach (Models.Room existingRoom in existingRooms)
                {
                    if (existingRoom.Number == room.Number && existingRoom.Floor == room.Floor)
                    {
                        throw new System.Exception("Room already exists");
                    }
                }
                Models.Room.store(room);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static List<Models.Room> index()
        {
            try
            {
                return Models.Room.index();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static List<Models.Room> show(int id)
        {
            try
            {
                return Models.Room.show(id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static void update(int number, Models.Room room)
        {
            try
            {
                Models.Room.update(number, room);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        
        public static void updateValue(int number,double value)
        {
            try
            {
                Models.Room.updateValue(number,value);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static void destroy(int number)
        {
            try
            {
                Models.Room.destroy(number);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}