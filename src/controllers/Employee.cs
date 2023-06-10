using Models;

namespace Controllers {

    public class Employee {
        public static void store(Models.Employee employee) {
            try {
                List<Models.Employee> existingEmployees = Controllers.Employees.index();

                foreach (Models.Employee existingEmployee in existingEmployees) {
                    if (existingEmployee.Document == employee.Document) {
                        throw new System.Exception("Employee exists");
                    }
                }
                Models.Employee.store(employee);
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static List<Models.Employee> index() {
            try {
                return Models.Employee.index();
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static List<Models.Employee> show(int id) {
            try {
                return Models.Employee.show(id);
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void update(int id, Models.Employee employee) {
            try {
                Models.Employee.update(id, employee);
            } catch (System.Exception e) {
                throw e;
            }
        } 
        public static void destroy(int id) {
            try {
                Models.Employee.destroy(id);
            } catch (System.Exception e) {
                throw e;
            }
        }
    }
}

