using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Views
{
    public class InitialScreen : Form
    {

        public static PictureBox pictureBox1;
        public static Label nameLabel;
        public static TextBox nameTextBox;
        public static Label passwordLabel;
        public static TextBox passwordTextBox;
        public static TableLayoutPanel buttonsLayoutPanel;
        public static Button btnToMainScreen;  
        public static Button btnExit;  




        public static bool IsRegistered()
        {
            try
            {
                string login = nameTextBox.Text;
                string password = passwordTextBox.Text;

                Controllers.Guest.login(
                    login,
                    password
                );

            }
            catch( System.Exception e )
            {
                MessageBox.Show(
                    e.Message,
                    "Senha ou Login Incorreto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }           
            return true;

        }
        public static void Index()
        {
            Form initialScreen = new Form();

            initialScreen.Icon = new Icon("Assets/logoUm.ico", 30, 30);
            initialScreen.Text = "Seja Bem-vindo";
            initialScreen.Size = new Size(350, 500);
            initialScreen.StartPosition = FormStartPosition.CenterScreen;
            initialScreen.FormBorderStyle = FormBorderStyle.FixedSingle;
            initialScreen.MaximizeBox = false;
            initialScreen.MinimizeBox = false;
            initialScreen.ShowIcon = false;
            initialScreen.ShowInTaskbar = false;
            initialScreen.BackColor = ColorTranslator.FromHtml("#ffffff");


            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(350, 180); 
            pictureBox1.Location = new Point((initialScreen.ClientSize.Width - pictureBox1.Width) / 2, 20); 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; 
            pictureBox1.Padding = new Padding(0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.BorderStyle = BorderStyle.None;
            initialScreen.Controls.Add(pictureBox1);


            string imageLogo = "Assets/logoUm.ico";
            Image imagem = Image.FromFile(imageLogo);
            pictureBox1.Image = imagem;


            nameLabel = new Label();
            nameLabel.Text = "Nome:";
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point((initialScreen.ClientSize.Width - nameLabel.Width) / 4, pictureBox1.Bottom + 30);
            initialScreen.Controls.Add(nameLabel);

            nameTextBox = new TextBox();
            nameTextBox.Multiline = true; 
            nameTextBox.ScrollBars = ScrollBars.None; 
            nameTextBox.Size = new Size(213, 35); 
            nameTextBox.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            nameTextBox.Location = new Point((initialScreen.ClientSize.Width - nameTextBox.Width) / 2, nameLabel.Bottom + 3);
            nameTextBox.BorderStyle = BorderStyle.FixedSingle;
            initialScreen.Controls.Add(nameTextBox);

            passwordLabel = new Label();
            passwordLabel.Text = "Senha:";
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point((initialScreen.ClientSize.Width - passwordLabel.Width) / 4, nameTextBox.Bottom + 10);
            initialScreen.Controls.Add(passwordLabel);

            passwordTextBox = new TextBox();
            passwordTextBox.Multiline = true; 
            passwordTextBox.ScrollBars = ScrollBars.None; 
            passwordTextBox.Size = new Size(213, 35); 
            passwordTextBox.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            passwordTextBox.Location = new Point((initialScreen.ClientSize.Width - passwordTextBox.Width) / 2, passwordLabel.Bottom + 3);
            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.PasswordChar = '*';
            initialScreen.Controls.Add(passwordTextBox);

            buttonsLayoutPanel = new TableLayoutPanel();
            buttonsLayoutPanel.Dock = DockStyle.Bottom;
            buttonsLayoutPanel.AutoSize = true;
            buttonsLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonsLayoutPanel.Padding = new Padding(10, 10, 10, 10);
            buttonsLayoutPanel.BackColor = ColorTranslator.FromHtml("#3C4858");
            buttonsLayoutPanel.ColumnCount = 4;
            buttonsLayoutPanel.RowCount = 1;
            buttonsLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < buttonsLayoutPanel.ColumnCount; i++)
            {
                buttonsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            }

            btnToMainScreen = new Button();
            btnToMainScreen.Text = "Entrar";
            btnToMainScreen.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btnToMainScreen.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnToMainScreen.Size = new Size(110, 35);
            btnToMainScreen.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnToMainScreen.FlatStyle = FlatStyle.Flat;
            btnToMainScreen.FlatAppearance.BorderSize = 0;
            btnToMainScreen.Dock = DockStyle.Fill;
            btnToMainScreen.Click += (sender, e) =>
            {
                if (!IsRegistered())
                {
                    MessageBox.Show(
                        "Você não está cadastrado",
                        "Cadastro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                initialScreen.Hide();
                var mainScreen = new MainScreen();
                mainScreen.ShowDialog();
                initialScreen.Close();
            };

            btnExit = new Button();
            btnExit.Text = "Sair";
            btnExit.BackColor = ColorTranslator.FromHtml("#E0E6ED");
            btnExit.ForeColor = ColorTranslator.FromHtml("#1c1c1e");
            btnExit.Size = new Size(110, 35);
            btnExit.Font = new Font("Roboto", 8, FontStyle.Regular);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Click += (sender, e) =>
            {
                initialScreen.Close();
            };

            buttonsLayoutPanel.Controls.Add(btnToMainScreen, 1, 0);
            buttonsLayoutPanel.Controls.Add(btnExit, 2, 0);
            initialScreen.Controls.Add(buttonsLayoutPanel);

            initialScreen.ShowDialog();
        }
    }
}
