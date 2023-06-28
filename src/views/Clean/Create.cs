using Controllers;
using Models;

namespace Views
{
    public class CreateCLean : Form
    {
        public Label lblTitle;
        public Label lblRoom;
        public ComboBox cboRoom;
        public Label lblEmployee;
        public ComboBox cboEmployee;
        public Button btCrt;
        public Button btClose;
        public TableLayoutPanel buttonsLayoutPanel;


        public static List<Models.Room> GetRoomsToComboBox(){
            List<Models.Room> rooms = new List<Models.Room>();
            foreach(Models.Room room in Controllers.Room.index()){
                if(room.Number != 0){
                    rooms.Add(room);
                }
            }

            return rooms;
        }

        public static List<Models.Employee> GetEmployeesToComboBox(){
            List<Models.Employee> employees = new List<Models.Employee>();
            foreach(Models.Employee employee in Controllers.Employee.index()){
                if((employee.Id != 0) && (employee.Name != null)){
                    employees.Add(employee);
                }
            }

            return employees;
        }

        public void btCrt_Click(object sender, EventArgs e)
        {
            try
            {
                int idRoom = Convert.ToInt32(cboRoom.SelectedValue);;
                int idEmployee = Convert.ToInt32(cboEmployee.SelectedValue);

                Models.Clean clean = new Models.Clean(
                    idRoom,
                    idEmployee
                );

                Controllers.Clean.store(clean);

                MessageBox.Show("Product registered successfully.");
                ClearForm();
            }catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            List Product = Application.OpenForms.OfType<List>().FirstOrDefault();
            if (Product != null)
            {
                Product.RefreshList();
            }
            this.Close();
        }

        private void ClearForm()
        {
            cboRoom.SelectedIndex = -1;
            cboEmployee.SelectedIndex = -1;
        }

        public CreateCLean()
        {
            this.Text = "Cadastro Limpeza";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            this.BackColor = color;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(300, 380);

            this.lblTitle = new Label();
            this.lblTitle.Text = "Agendamento de limpeza";
            this.lblTitle.Font = new Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new Point(40, 30);
            this.lblTitle.Size = new Size(250, 40);

            this.lblRoom = new Label();
            this.lblRoom.Text = "Quarto";
            this.lblRoom.Location = new Point(33, lblTitle.Bottom + 10);
            this.lblRoom.Size = new Size(70, 20);

            this.cboRoom = new ComboBox();
            this.cboRoom.Location = new Point(33, lblRoom.Bottom + 5);
            this.cboRoom.Size = new Size(220, 20);
            this.cboRoom.Items.Add("Selecione um quarto");
            this.cboRoom.ValueMember = "Number";
            this.cboRoom.DisplayMember = "Number";
            this.cboRoom.DataSource = GetRoomsToComboBox();
            if (this.cboRoom.Items.Count > 0)
            {
                this.cboRoom.SelectedIndex = 0;
            }


            this.lblEmployee = new Label();
            this.lblEmployee.Text = "Funcionário";
            this.lblEmployee.Location = new Point(33, cboRoom.Bottom + 10);
            this.lblEmployee.Size = new Size(70, 20);

            this.cboEmployee = new ComboBox();
            this.cboEmployee.Location = new Point(33, lblEmployee.Bottom + 5);
            this.cboEmployee.Size = new Size(220, 20);
            this.cboEmployee.Items.Add("Selecione um funcionário");
            this.cboEmployee.ValueMember = "Id";
            this.cboEmployee.DisplayMember = "Name";
            this.cboEmployee.DataSource = GetEmployeesToComboBox();
            if (this.cboEmployee.Items.Count > 0)
            {
                this.cboEmployee.SelectedIndex = 0;
            }


            this.buttonsLayoutPanel = new TableLayoutPanel();
            this.buttonsLayoutPanel.Dock = DockStyle.Bottom;
            this.buttonsLayoutPanel.AutoSize = true;
            this.buttonsLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.buttonsLayoutPanel.Padding = new Padding(10, 10, 10, 10);
            this.buttonsLayoutPanel.BackColor = ColorTranslator.FromHtml("#3C4858");
            this.buttonsLayoutPanel.ColumnCount = 4;
            this.buttonsLayoutPanel.RowCount = 1;
            this.buttonsLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < buttonsLayoutPanel.ColumnCount; i++)
            {
                buttonsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            this.btCrt = new Button();
            this.btCrt.Text = "Add";
            // this.btCrt.Location = new Point(80, cboType.Bottom + 10);
            this.btCrt.Size = new Size(110, 35);
            this.btCrt.Font = new Font("Roboto", 8, FontStyle.Regular);
            this.btCrt.FlatStyle = FlatStyle.Flat;
            this.btCrt.FlatAppearance.BorderSize = 0;
            this.btCrt.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btCrt.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.btCrt.Dock = DockStyle.Fill;
            this.btCrt.Click += new EventHandler(this.btCrt_Click);

            this.btClose = new Button();
            this.btClose.Text = "Close";
            // this.btClose.Location = new Point(80, btCrt.Bottom + 10);
            this.btClose.Size = new Size(110, 35);
            this.btClose.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            this.btClose.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            this.btClose.Font = new Font("Roboto", 8, FontStyle.Regular);
            this.btClose.FlatStyle = FlatStyle.Flat;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.Dock = DockStyle.Fill;
            this.btClose.Click += (sender, s) =>
            {
                this.Close();
            };

            this.buttonsLayoutPanel.Controls.Add(btCrt, 2, 0); // Mudar o segundo parâmetro para 0
            this.buttonsLayoutPanel.Controls.Add(btClose, 3, 0); // Mudar o segundo parâmetro para 0

            this.Controls.Add(buttonsLayoutPanel);

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblRoom);
            this.Controls.Add(cboRoom);
            this.Controls.Add(lblEmployee);
            this.Controls.Add(cboEmployee);
        }
    }
}