using Database;

namespace Models
{

    public class Clean
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public Clean(int roomId, int employeeId)
        {
            this.RoomId = roomId;
            this.EmployeeId = employeeId;
            this.Date = DateTime.Now;
        }

        public static void store(Clean clean)
        {
            try
            {
                using (Context context = new Context())
                {
                    context.Cleans.Add(clean);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Clean> index()
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Cleans.ToList();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static Clean show(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Cleans.Find(id);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void update(int id, Clean clean)
        {
            try
            {
                using (Context context = new Context())
                {
                    Clean oldClean = context.Cleans.Find(id);
                    oldClean.RoomId = clean.RoomId;
                    oldClean.EmployeeId = clean.EmployeeId;
                    oldClean.Date = clean.Date;
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
                    Clean clean = context.Cleans.Find(id);
                    context.Cleans.Remove(clean);
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