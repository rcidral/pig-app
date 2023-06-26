using Models;
using Controllers;

namespace Views
{
    public class EmployeeCreate : Form
    {
        public Label lblName;
        public TextBox txtName;
        public Button btCrt;

        public void btCrt_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Employee employee = new Models.Employee
                (
                    txtName.Text
                );

                Controllers.Employee.store(employee);

                MessageBox.Show("Employee registered successfully.");
                ClearForm();
            }catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
            ListEmployee EmployeeList = Application.OpenForms.OfType<ListEmployee>().FirstOrDefault();
            if (EmployeeList != null)
            {
                EmployeeList.RefreshList();
            } 
            this.Close();
        }

        private void ClearForm()
        {
            txtName.Clear();
        }

        public EmployeeCreate()
        {
            this.Text = "Register room";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            this.BackColor = color;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 300);

            this.lblName = new Label();
            this.lblName.Text = "Name";
            this.lblName.Location = new Point(10, 70);
            this.lblName.Size = new Size(70, 20);

            this.txtName = new TextBox();
            this.txtName.Location = new Point(80, 70);
            this.txtName.Size = new Size(150, 20);

            this.btCrt = new Button();
            this.btCrt.Text = "Add";
            this.btCrt.Location = new Point(80, 160);
            this.btCrt.Size = new Size(150, 25);
            this.btCrt.Click += new EventHandler(this.btCrt_Click);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btCrt);
        }
    }
}