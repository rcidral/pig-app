using Database;

namespace Models
{

    public class Guest
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public int Payment { get; set; }

        public int Document { get; set; }

        public string MothersName { get; set; }
        public string Password { get; set; }

        public Guest(string name, DateTime birth, int payment, int document, string mothersName, string password)
        {
            this.Name = name;
            this.Birth = birth;
            this.Payment = payment;
            this.Document = document;
            this.MothersName = mothersName;
            this.Password = password;
        }

        public static void store(Guest guest)
        {
            try
            {
                using (Context context = new Context())
                {
                    context.Guests.Add(guest);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Guest> index()
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Guests.ToList();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Guest> show(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Guests.Where(guest => guest.Id == id).ToList();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void update(int id, Guest guest)
        {
            try
            {
                using (Context context = new Context())
                {
                    Guest oldGuest = context.Guests.Find(id);
                    oldGuest.Name = guest.Name;
                    oldGuest.Birth = guest.Birth;
                    oldGuest.Payment = guest.Payment;
                    oldGuest.Document = guest.Document;
                    oldGuest.MothersName = guest.MothersName;
                    oldGuest.Password = guest.Password;
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
                    Guest guest = context.Guests.Find(id);
                    context.Guests.Remove(guest);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static Models.Guest Login(string name, string password)
        {
            try
            {
                using (Context context = new Context())
                {
                    Guest guest = context.Guests.Where(gue => gue.Name == name && gue.Password == password).FirstOrDefault();
                    if (guest == null)
                    {
                        throw new Exception("Usuário ou senha incorretos");
                    }
                    return guest;
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
