using Models;

namespace Controllers {
    public class Room {
        public static void store(Models.Room room) {
            try {
                Models.Room.store(room);
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static List<Models.Room> index() {
            try {
                return Models.Room.index();
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static List<Models.Room> show(int id) {
            try {
                return Models.Room.show(id);
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void update(int id, Models.Room room) {
            try {
                Models.Room.update(id, room);
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void destroy(int id) {
            try {
                Models.Room.destroy(id);
            } catch (System.Exception e) {
                throw e;
            }
        }
    }
}