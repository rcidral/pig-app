using Controllers;

namespace Tests {
    public class RoomController {
        public static void store() {
            try {
                Controllers.Room.store(new Models.Room(1, 101, "Quarto de casal", 100, "Azul"));
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void index() {
            try {
                List<Models.Room> rooms = Controllers.Room.index();
                
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
                List<Models.Room> rooms = Controllers.Room.show(id);

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
        public static void update(int id, Models.Room room) {
            try {
                Controllers.Room.update(id, new Models.Room(1, 99, "Quarto de solteiro", 100, "Azul"));
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static void destroy(int id) {
            try {
                Controllers.Room.destroy(id);
            } catch (System.Exception e) {
                throw e;
            }
        }
    }
}