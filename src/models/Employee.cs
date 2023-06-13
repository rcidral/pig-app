using Database;

namespace Models {

    public class Employee {

        public int Id { get; set; }

        public string Name { get; set; }

        public Employee (string name) {
            this.Name = name;
        }

        public static void store(Employee employee) {
            try {
                using(Context context = new Context()) {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }

        public static List<Employee> index() {
            try {
                using(Context context = new Context()) {
                    return context.Employees.ToList();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }

        public static List<Employee> show(int id) {
            try {
                using(Context context = new Context()) {
                    return context.Employees.Where(employee => employee.Id == id).ToList();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }

        public static void update(int id, Employee employee) {
            try {
                using(Context context = new Context()) {
                    Employee oldEmployee = context.Employees.Find(id);
                    oldEmployee.Name = employee.Name;
                }
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void destroy(int id) {
            try {
                using(Context context = new Context()) {
                    Employee employee = context.Employees.Find(id);
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }
    }
}