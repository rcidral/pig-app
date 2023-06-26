namespace Views{

    public class RegisterRoom : Form{

        public RegisterRoom(){

            this.Text = "Cadastro";
            this.Size = new System.Drawing.Size(400, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = ColorTranslator.FromHtml("#f7f7f7");
            
            Label lblTitle = new Label();
            lblTitle.Text = "Cadastrar Quarto";
            lblTitle.Location = new System.Drawing.Point(30, 30);
            lblTitle.Size = new System.Drawing.Size(400, 60);
            lblTitle.Font = new Font("Tahoma", 25, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));
            lblTitle.ForeColor = ColorTranslator.FromHtml("#1c1c1e");

            Label lblLevel = new Label();
            lblLevel.Text = "Andar";
            lblLevel.Location = new Point((this.ClientSize.Width - lblLevel.Width) / 4, lblTitle.Bottom + 20);
            lblLevel.Size = new System.Drawing.Size(80, 20);
            lblLevel.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));
            lblLevel.ForeColor = ColorTranslator.FromHtml("#1c1c1e");

            ComboBox cobLevel = new ComboBox();
            cobLevel.Location = new Point((this.ClientSize.Width - cobLevel.Width) / 2, lblLevel.Bottom + 3);
            cobLevel.Size = new System.Drawing.Size(80, 80);
            cobLevel.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));
            cobLevel.Items.Add("1º Andar");
            cobLevel.Items.Add("2º Andar");
            cobLevel.Items.Add("3º Andar");

            Label lblNumber = new Label();
            lblNumber.Text = "Número";
            lblNumber.Location = new Point((this.ClientSize.Width - lblNumber.Width) / 3, cobLevel.Bottom + 10);
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));

            ComboBox comboboxNumero = new ComboBox();
            comboboxNumero.Location = new Point((this.ClientSize.Width - comboboxNumero.Width) / 2 , cobLevel.Bottom + 10);
            comboboxNumero.Size = new System.Drawing.Size(80, 80);
            comboboxNumero.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));
            comboboxNumero.Items.Add("1");
            comboboxNumero.Items.Add("2");
            comboboxNumero.Items.Add("3");

            Label labelType = new Label();
            labelType.Text = "Tipo";
            labelType.Location = new System.Drawing.Point(400, 120);
            labelType.Size = new System.Drawing.Size(300, 90);
            labelType.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));

            ComboBox comboboxType = new ComboBox();
            comboboxType.Location = new System.Drawing.Point(400, 150);
            comboboxType.Size = new System.Drawing.Size(100, 80);
            comboboxType.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));
            comboboxType.Items.Add("Solteiro");
            comboboxType.Items.Add("Casal");
            comboboxType.Items.Add("Domitório");

            Label labelValor = new Label();
            labelValor.Text = "Valor";
            labelValor.Location = new System.Drawing.Point(30, 200);
            labelValor.Size = new System.Drawing.Size(300, 20);
            labelValor.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));

            TextBox textboxValor = new TextBox();
            textboxValor.Location = new System.Drawing.Point(30, 220);
            textboxValor.Size = new System.Drawing.Size(500, 20);
            textboxValor.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));

            Label labelObservacao = new Label();
            labelObservacao.Text = "Observação";
            labelObservacao.Location = new System.Drawing.Point(30, 280);
            labelObservacao.Size = new System.Drawing.Size(300, 20);
            labelObservacao.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));

            MaskedTextBox textboxObservacao = new MaskedTextBox();
            textboxObservacao.Location = new System.Drawing.Point(30, 300);
            textboxObservacao.Size = new System.Drawing.Size(500, 900);
            textboxObservacao.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));

            Panel panelStore = new Panel();
            panelStore.Size = new System.Drawing.Size(this.Width, 85);
            panelStore.Location = new System.Drawing.Point(0, 480);
            Color colorPanel = System.Drawing.ColorTranslator.FromHtml("#E7E7E7");
            panelStore.BackColor = colorPanel;

            Button buttonStore = new Button();
            buttonStore.Location = new System.Drawing.Point(300, 500);
            buttonStore.Size = new System.Drawing.Size(120, 40);
            buttonStore.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));
            buttonStore.Text = "Cadastrar";
            Color colorButtonStore = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonStore.BackColor = colorButtonStore;
            buttonStore.Click += (sender, args) =>
            {
                MessageBox.Show("Quarto cadastrado com sucesso!");
                this.Close();
                this.Dispose();
            };

            Button buttonCancel = new Button();
            buttonCancel.Location = new System.Drawing.Point(450, 500);
            buttonCancel.Size = new System.Drawing.Size(120, 40);
            buttonCancel.Font = new Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, GraphicsUnit.
            Point, ((byte)(0)));
            buttonCancel.Text = "Cancelar";
            Color colorButtonCancel = System.Drawing.ColorTranslator.FromHtml("#E7E7E7");
            buttonCancel.Click += (sender, args) =>
            {
                this.Close();
                this.Dispose();
            };

            this.Controls.Add(textboxValor);
            this.Controls.Add(labelValor);
            this.Controls.Add(buttonCancel);
            this.Controls.Add(buttonStore);
            this.Controls.Add(textboxObservacao);
            this.Controls.Add(labelObservacao);
            this.Controls.Add(panelStore);
            this.Controls.Add(lblNumber);
            this.Controls.Add(comboboxNumero);
            this.Controls.Add(lblLevel);
            this.Controls.Add(cobLevel);
            this.Controls.Add(comboboxType);
            this.Controls.Add(labelType);
            // this.Controls.Add(label);
            this.ShowDialog();
        }
        
    }
}