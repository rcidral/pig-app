using Models;
using Controllers;

namespace Views
{
    public enum Option {Update, Delete}
    public class ListEmployee : Form
    {
        ListView listEmployee;

        private void AddListView(Models.Employee employee)
        {
            string[] row = {
                employee.Id.ToString(),
                employee.Name
            };

            ListViewItem item = new ListViewItem(row);
            listEmployee.Items.Add(item);
        }

        public void RefreshList()
        {
            listEmployee.Items.Clear();

            List<Models.Employee> list = Controllers.Employee.index();

            foreach (Models.Employee employee in list)
            {
                AddListView(employee);
            }
        }

        public Models.Employee GetSelectedEmployee(Option option)
        {
            if (listEmployee.SelectedItems.Count > 0)
            {
                int selectedEmployeeId = int.Parse(listEmployee.SelectedItems[0].Text);
                List<Models.Employee> employees = Controllers.Employee.show(selectedEmployeeId);
                return employees.FirstOrDefault();
            }
            else
            {
                throw new Exception($"Select a Employee for {(option == Option.Update ? "udpate" : "delete")}");
            }
        }

        private void btCrt_Click(object sender, EventArgs e)
        {
            var Create = new Views.EmployeeCreate();
            Create.Show();
        }

        private void btUpd_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Employee employee = GetSelectedEmployee(Option.Update);
                RefreshList();
                var EmployeeUpdateView = new Views.UpdateEmployee(employee);
                if (EmployeeUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Employee updated successfully.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Employee employee = GetSelectedEmployee(Option.Delete);
                DialogResult result = MessageBox.Show("Do you want to delete this Employee?", "Confirm delection", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.Product.destroy(employee.Id);
                    RefreshList();
                }
            }
            catch (Exception err)
            {
                if (err.InnerException != null)
                {
                    MessageBox.Show(err.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListEmployee()
        {
            this.Icon = new Icon("Assets/logoUm.ico", 52, 52);

            this.Text = "Employees";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            Color color = System.Drawing.ColorTranslator.FromHtml("#E7E7E7");
            this.ShowIcon = true;
            this.ShowInTaskbar = false;

            listEmployee = new ListView();
            listEmployee.Size = new Size(680, 260);
            listEmployee.Location = new Point(50, 50);
            listEmployee.View = View.Details;
            listEmployee.Columns.Add("Id", -2, HorizontalAlignment.Left);
            listEmployee.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listEmployee.Columns[0].Width = 30;
            listEmployee.Columns[1].Width = 100;
            listEmployee.FullRowSelect = true;
            this.Controls.Add(listEmployee);

            RefreshList();
            
            Button btCrt = new Button();
            btCrt.Text = "Add";
            btCrt.Size = new Size(100, 30);
            btCrt.Location = new Point(50, 330);
            btCrt.Click += new EventHandler(btCrt_Click);
            this.Controls.Add(btCrt);

            Button btUpd = new Button();
            btUpd.Text = "Update";
            btUpd.Size = new Size(100, 30);
            btUpd.Location = new Point(170, 330);
            btUpd.Click += new EventHandler(btUpd_Click);
            this.Controls.Add(btUpd);

            Button btDelete = new Button();
            btDelete.Text = "Delete";
            btDelete.Size = new Size(100, 30);
            btDelete.Location = new Point(290, 330);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Return";
            btClose.Size = new Size(100, 30);
            btClose.Location = new Point(410, 330);
            btClose.Click += new EventHandler(btClose_Click);
            this.Controls.Add(btClose);
        }
    }
}