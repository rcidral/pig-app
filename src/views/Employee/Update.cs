using Models;
using Controllers;

namespace Views
{
    public class UpdateEmployee : Form
    {
        public Label lblId;
        public TextBox txtId;
        public Label lblName;
        public TextBox txtName;
        public Button btUpd;

        public Models.Employee employee;

        private void btUpd_Click(object sender, EventArgs e)
        {
            Models.Employee employeeToUpdate = this.employee;
            employee.Id = Convert.ToInt32(this.txtId.Text);
            employeeToUpdate.Name = this.txtName.Text;

            Controllers.Employee.update(employeeToUpdate.Id, employeeToUpdate);

            ListEmployee EmployeeList = Application.OpenForms.OfType<ListEmployee>().FirstOrDefault();
            if (EmployeeList != null)
            {
                EmployeeList.RefreshList();
            }
            this.Close();
        }

        public UpdateEmployee(Models.Employee employee)
        {
            this.employee = employee;

            this.Text = "Register a employee";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#E7E7E7");
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 250);

            this.lblId = new Label();
            this.lblId.Text = "Id";
            this.lblId.Location = new Point(10, 40);
            this.lblId.Size = new Size(150, 20);

            this.txtId = new TextBox();
            this.txtId.Text = employee.Id.ToString();
            this.txtId.Location = new Point(80, 40);
            this.txtId.Size = new Size(150, 20);

            this.lblName = new Label();
            this.lblName.Text = "Name";
            this.lblName.Location = new Point(10, 70);
            this.lblName.Size = new Size(70, 20);

            this.txtName = new TextBox();
            this.txtName.Text = employee.Name;
            this.txtName.Location = new Point(80, 70);
            this.txtName.Size = new Size(150, 20);

            this.btUpd = new Button();
            this.btUpd.Text = "Add";
            this.btUpd.Location = new Point(10, 15);
            this.btUpd.Size = new Size(50, 20);

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btUpd);
        }
    }
}