using Database;

namespace Models {

    public class Guest {

        public int Id { get; set; }

        public string Name { get; set; }

        public Date Birth { get; set; }

        public int Payment { get; set; }

        public int Document { get; set; }

        public string MothersName { get; set; }

        public Guest (string name, Date birth, int payment, int document, string mothersName) {
            this.Name = name;
            this.Birth = birth;
            this.Payment = payment;
            this.Document = document;
            this.MothersName = mothersName;
        }

        public static void store(Guest guest) {
            try {
                using(Context context = new Context()) {
                    context.Guests.Add(guest);
                    context.SaveChanges();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }

        public static List<Guest> index() {
            try {
                using(Context context = new Context()) {
                    return context.Guests.ToList();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }

        public static List<Guest> show(int id) {
            try {
                using(Context context = new Context()) {
                    return context.Guests.Where(guest => guest.Id == id).ToList();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }

        public static void update(int id, Guest guest) {
            try {
                using(Context context = new Context()) {
                    Guest oldGuest = context.Guests.Find(id);
                    oldGuest.Name = guest.Name;
                    oldGuest.Birth = guest.Birth;
                    oldGuest.Payment = guest.Payment;
                    oldGuest.Document = guest.Document;
                    oldGuest.MothersName = guest.MothersName;
                    context.SaveChanges();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }

        public static void destroy(int id) {
            try {
                using(Context context = new Context()) {
                    Guest guest = context.Guests.Find(id);
                    context.Guests.Remove(guest);
                    context.SaveChanges();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }
    }
}
    