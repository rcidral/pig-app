using Models;

namespace Tests {
    public class Room {
        public static void store() {
            try {
                Models.Room room = new Models.Room(1, "101", "Quarto de casal", 100);
                Models.Room.store(room);
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void index() {
            try {
                List<Models.Room> rooms = Models.Room.index();
                
                Form form = new Form();
                form.Width = 500;
                form.Height = 500;

                DataGridView dataGridView = new DataGridView();
                dataGridView.Width = 500;
                dataGridView.Height = 500;
                dataGridView.DataSource = rooms;

                form.Controls.Add(dataGridView);
                form.ShowDialog();
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void show(int id) {
            try {
                List<Models.Room> rooms = Models.Room.show(id);

                Form form = new Form();
                form.Width = 500;
                form.Height = 500;

                DataGridView dataGridView = new DataGridView();
                dataGridView.Width = 500;
                dataGridView.Height = 500;
                dataGridView.DataSource = rooms;

                form.Controls.Add(dataGridView);
                form.ShowDialog();
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void update(int id) {
            try {
                Models.Room room = new Models.Room(1, "99", "Quarto de solteiro", 100);
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