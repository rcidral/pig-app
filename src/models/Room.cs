using System.ComponentModel.DataAnnotations;
using Database;

namespace Models {
    public class Room {
        [Key]
        public int Number { get; set; }
        public int Floor { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }

        public Room(int floor, int number, string description, int value, string color) {
            this.Floor = floor;
            this.Number = number;
            this.Description = description;
            this.Value = value;
            this.Color = color;
        }
        public static void store(Room room) {
            try {
                using(Context context = new Context()) {
                    context.Rooms.Add(room);
                    context.SaveChanges();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static List<Room> index() {
            try {
                using(Context context = new Context()) {
                    return context.Rooms.ToList();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static List<Room> show(int number) {
            try {
                using(Context context = new Context()) {
                    return context.Rooms.Where(room => room.Number == number).ToList();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void update(int number, Room room) {
            try {
                using(Context context = new Context()) {
                    Room oldRoom = context.Rooms.Find(number);
                    oldRoom.Floor = room.Floor;
                    oldRoom.Number = room.Number;
                    oldRoom.Description = room.Description;
                    oldRoom.Value = room.Value;
                    context.SaveChanges();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void destroy(int number) {
            try {
                using(Context context = new Context()) {
                    Room room = context.Rooms.Find(number);
                    context.Rooms.Remove(room);
                    context.SaveChanges();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }
    }
}