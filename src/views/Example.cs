namespace Views
{
    public class Menu
    {
        public static void index()
        {
            Form menu = new Form();

            menu.Text = "Menu";
            menu.Size = new Size(300, 500);
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.MaximizeBox = false;
            menu.MinimizeBox = false;
            menu.ShowIcon = false;
            menu.ShowInTaskbar = false;

            Button btPrt = new Button();
            btPrt.Text = "Product";
            btPrt.Size = new Size(100, 30);
            btPrt.Location = new Point(100, 100);
            btPrt.Click += (sender, e) => {
                menu.Hide();
                var listProduct = new List();
                listProduct.ShowDialog();
                menu.Show();
            };

            Button btGuest = new Button();
            btGuest.Text = "Guest";
            btGuest.Size = new Size(100, 30);
            btGuest.Location = new Point(100, 150);
            btGuest.Click += (sender,e) => {
                menu.Hide();
                var listGuest = new ListGuest();
                listGuest.ShowDialog();
                menu.Show();
            };

            Button btRoom = new Button();
            btRoom.Text = "Room";
            btRoom.Size = new Size(100, 30);
            btRoom.Location = new Point(100, 200);
            btRoom.Click += (sender,e) => {
                menu.Hide();
                var listRoom = new ListRoom();
                listRoom.ShowDialog();
                menu.Show();
            };

            Button btEmp = new Button();
            btEmp.Text = "Employee";
            btEmp.Size = new Size(100, 30);
            btEmp.Location = new Point(100, 250);
            btEmp.Click += (sender, e) => {
                menu.Hide();
                var listEmployee = new ListEmployee();
                listEmployee.ShowDialog();
                menu.Show();
            };

            Button sair = new Button();
            sair.Text = "Sair";
            sair.Size = new Size(100, 30);
            sair.Location = new Point(100, 300);
            sair.Click += (sender, e) => {
                menu.Close();
            };

            menu.Controls.Add(btGuest);
            menu.Controls.Add(btPrt);
            menu.Controls.Add(btRoom);
            menu.Controls.Add(btEmp);
            menu.Controls.Add(sair);
            menu.ShowDialog();
        }
    }
}