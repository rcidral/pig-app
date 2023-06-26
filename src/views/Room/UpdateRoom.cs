namespace Views{

    public class UpdateRoom : Form{
        public UpdateRoom()
        {
            Form update = new Form();
            update.Text = "Alterar";
            update.Size = new System.Drawing.Size(600, 600);
            update.FormBorderStyle = FormBorderStyle.FixedDialog;
            update.MaximizeBox = false;
            update.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            update.BackColor = color;
            Label label = new Label();
            label.Text = "Alterar Quarto";
            label.Location = new System.Drawing.Point(30, 30);
            label.Size = new System.Drawing.Size(400, 60);
            label.Font = new System.Drawing.Font("Arial", 25, System.Drawing.FontStyle.Bold);

            Label lblLevel = new Label();
            lblLevel.Text = "Andar";
            lblLevel.Location = new System.Drawing.Point(30, 120);
            lblLevel.Size = new System.Drawing.Size(80, 20);
            lblLevel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            ComboBox cobLevel = new ComboBox();
            cobLevel.Location = new System.Drawing.Point(30, 150);
            cobLevel.Size = new System.Drawing.Size(80, 80);
            cobLevel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            cobLevel.Items.Add("1º Andar");
            cobLevel.Items.Add("2º Andar");
            cobLevel.Items.Add("3º Andar");

            Label lblNumber = new Label();
            lblNumber.Text = "Número";
            lblNumber.Location = new System.Drawing.Point(150, 120);
            lblNumber.Size = new System.Drawing.Size(80, 20);
            lblNumber.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            ComboBox comboboxNumero = new ComboBox();
            comboboxNumero.Location = new System.Drawing.Point(150, 150);
            comboboxNumero.Size = new System.Drawing.Size(80, 80);
            comboboxNumero.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            comboboxNumero.Items.Add("1");
            comboboxNumero.Items.Add("2");
            comboboxNumero.Items.Add("3");

            Label labelType = new Label();
            labelType.Text = "Tipo";
            labelType.Location = new System.Drawing.Point(400, 120);
            labelType.Size = new System.Drawing.Size(300, 90);
            labelType.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            ComboBox comboboxType = new ComboBox();
            comboboxType.Location = new System.Drawing.Point(400, 150);
            comboboxType.Size = new System.Drawing.Size(100, 80);
            comboboxType.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            comboboxType.Items.Add("Solteiro");
            comboboxType.Items.Add("Casal");
            comboboxType.Items.Add("Domitório");

            Label labelValor = new Label();
            labelValor.Text = "Valor";
            labelValor.Location = new System.Drawing.Point(30, 200);
            labelValor.Size = new System.Drawing.Size(300, 20);
            labelValor.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            TextBox textboxValor = new TextBox();
            textboxValor.Location = new System.Drawing.Point(30, 220);
            textboxValor.Size = new System.Drawing.Size(500, 20);
            textboxValor.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            Label labelObservacao = new Label();
            labelObservacao.Text = "Observação";
            labelObservacao.Location = new System.Drawing.Point(30, 280);
            labelObservacao.Size = new System.Drawing.Size(300, 20);
            labelObservacao.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            MaskedTextBox textboxObservacao = new MaskedTextBox();
            textboxObservacao.Location = new System.Drawing.Point(30, 300);
            textboxObservacao.Size = new System.Drawing.Size(500, 900);
            textboxObservacao.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);


            Panel panelStore = new Panel();
            panelStore.Size = new System.Drawing.Size(update.Width, 85);
            panelStore.Location = new System.Drawing.Point(0, 480);
            Color colorPanel = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            panelStore.BackColor = colorPanel;

            Button buttonStore = new Button();
            buttonStore.Location = new System.Drawing.Point(300, 500);
            buttonStore.Size = new System.Drawing.Size(120, 40);
            buttonStore.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            buttonStore.Text = "Alterar";
            buttonStore.Click += (sender, args) =>
            {
                var listRoom = new ListarQuartos();
                listRoom.Show();
                update.Close();
                update.Dispose();
            };
            Button buttonCancel = new Button();
            buttonCancel.Location = new System.Drawing.Point(450, 500);
            buttonCancel.Size = new System.Drawing.Size(120, 40);
            buttonCancel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            buttonCancel.Text = "Cancelar";
            Color colorButtonCancel = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonCancel.Click += (sender, args) =>
            {
                update.Close();
            };

            update.Controls.Add(textboxValor);
            update.Controls.Add(labelValor);
            update.Controls.Add(buttonCancel);
            update.Controls.Add(buttonStore);
            update.Controls.Add(textboxObservacao);
            update.Controls.Add(labelObservacao);
            update.Controls.Add(panelStore);
            update.Controls.Add(lblNumber);
            update.Controls.Add(comboboxNumero);
            update.Controls.Add(lblLevel);
            update.Controls.Add(cobLevel);
            update.Controls.Add(comboboxType);
            update.Controls.Add(labelType);
            update.Controls.Add(label);
            update.ShowDialog();
        }

    }
}