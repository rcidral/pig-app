using Database;

namespace Models
{

    public class Employee
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public int Payment { get; set; }

        public int Document { get; set; }

        public string MothersName { get; set; }
        public string Password { get; set; }

        public Boolean Type { get; set; }

        public Employee(string name, DateTime birth, int payment, int document, string mothersName, string password, Boolean type)
        {
            this.Name = name;
            this.Birth = birth;
            this.Payment = payment;
            this.Document = document;
            this.MothersName = mothersName;
            this.Password = password;
            this.Type = type;
        }

        public static void store(Employee employee)
        {
            try
            {
                using (Context context = new Context())
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Employee> index()
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Employees.ToList();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static List<Employee> show(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    return context.Employees.Where(employee => employee.Id == id).ToList();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void update(int id, Employee employee)
        {
            try
            {
                using (Context context = new Context())
                {
                    Employee oldEmployee = context.Employees.Find(id);
                    oldEmployee.Name = employee.Name;
                    oldEmployee.Birth = employee.Birth;
                    oldEmployee.Payment = employee.Payment;
                    oldEmployee.Document = employee.Document;
                    oldEmployee.MothersName = employee.MothersName;
                    oldEmployee.Password = employee.Password;
                    oldEmployee.Type = employee.Type;
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
                    Employee employee = context.Employees.Find(id);
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public static void Login(string name, string password)
        {
            try
            {
                using (Context context = new Context())
                {
                    Employee employee = context.Employees.Where(employee => employee.Name == name && employee.Password == password).FirstOrDefault();
                    if (employee == null)
                    {
                        throw new Exception("Usuário ou senha incorretos");
                    }
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}