using System;
using System.Windows.Forms;


namespace Views
{

    public class Room
    {
        public static void CadastrarQuartos()
        {
            Form menu = new Form();
            menu.Text = "Cadastro";
            menu.Size = new System.Drawing.Size(600, 600);
            menu.FormBorderStyle = FormBorderStyle.FixedDialog;
            menu.MaximizeBox = false;
            menu.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            menu.BackColor = color;
            Label label = new Label();
            label.Text = "Cadastrar Quarto";
            label.Location = new System.Drawing.Point(30, 30);
            label.Size = new System.Drawing.Size(400, 60);
            label.Font = new System.Drawing.Font("Arial", 25, System.Drawing.FontStyle.Bold);

            Label labelAndar = new Label();
            labelAndar.Text = "Andar";
            labelAndar.Location = new System.Drawing.Point(30, 120);
            labelAndar.Size = new System.Drawing.Size(80, 20);
            labelAndar.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            ComboBox comboboxAndar = new ComboBox();
            comboboxAndar.Location = new System.Drawing.Point(30, 150);
            comboboxAndar.Size = new System.Drawing.Size(80, 80);
            comboboxAndar.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            comboboxAndar.Items.Add("1º Andar");
            comboboxAndar.Items.Add("2º Andar");
            comboboxAndar.Items.Add("3º Andar");

            Label labelNumero = new Label();
            labelNumero.Text = "Número";
            labelNumero.Location = new System.Drawing.Point(150, 120);
            labelNumero.Size = new System.Drawing.Size(80, 20);
            labelNumero.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

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
            panelStore.Size = new System.Drawing.Size(menu.Width, 85);
            panelStore.Location = new System.Drawing.Point(0, 480);
            Color colorPanel = System.Drawing.ColorTranslator.FromHtml("#E7E7E7");
            panelStore.BackColor = colorPanel;

            Button buttonStore = new Button();
            buttonStore.Location = new System.Drawing.Point(300, 500);
            buttonStore.Size = new System.Drawing.Size(120, 40);
            buttonStore.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            buttonStore.Text = "Cadastrar";
            Color colorButtonStore = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonStore.BackColor = colorButtonStore;
            buttonStore.Click += (sender, args) =>
            {
                MessageBox.Show("Quarto cadastrado com sucesso!");
                menu.Close();
                menu.Dispose();
                ListarQuartos();

            };

            Button buttonCancel = new Button();
            buttonCancel.Location = new System.Drawing.Point(450, 500);
            buttonCancel.Size = new System.Drawing.Size(120, 40);
            buttonCancel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            buttonCancel.Text = "Cancelar";
            Color colorButtonCancel = System.Drawing.ColorTranslator.FromHtml("#E7E7E7");
            buttonCancel.Click += (sender, args) =>
            {
                menu.Close();
                menu.Dispose();
                ListarQuartos();
            };

            menu.Controls.Add(textboxValor);
            menu.Controls.Add(labelValor);
            menu.Controls.Add(buttonCancel);
            menu.Controls.Add(buttonStore);
            menu.Controls.Add(textboxObservacao);
            menu.Controls.Add(labelObservacao);
            menu.Controls.Add(panelStore);
            menu.Controls.Add(labelNumero);
            menu.Controls.Add(comboboxNumero);
            menu.Controls.Add(labelAndar);
            menu.Controls.Add(comboboxAndar);
            menu.Controls.Add(comboboxType);
            menu.Controls.Add(labelType);
            menu.Controls.Add(label);
            menu.ShowDialog();
        }
        public static void ListarQuartos()
        {
            Form list = new Form();
            list.Text = "Lista";
            list.Size = new System.Drawing.Size(600, 600);
            list.StartPosition = FormStartPosition.CenterScreen;
            list.FormBorderStyle = FormBorderStyle.FixedDialog;
            list.MaximizeBox = false;
            list.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            list.BackColor = color;

            Label Room = new Label();
            Room.Text = "Quartos";
            Room.Location = new System.Drawing.Point(30, 30);
            Room.Size = new System.Drawing.Size(400, 60);
            Room.Font = new System.Drawing.Font("Arial", 25, System.Drawing.FontStyle.Bold);

            ListView listview = new ListView();
            listview.Location = new System.Drawing.Point(30, 90);
            listview.Size = new System.Drawing.Size(500, 350);
            listview.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            listview.View = View.Details;
            listview.Columns.Add("Id", -2, HorizontalAlignment.Left);
            listview.Columns.Add("Andar", -2, HorizontalAlignment.Left);
            listview.Columns.Add("Número", -2, HorizontalAlignment.Left);
            listview.Columns.Add("Tipo", -2, HorizontalAlignment.Left);
            listview.Columns.Add("Observação", -2, HorizontalAlignment.Left);

            Panel panelList = new Panel();
            panelList.Size = new System.Drawing.Size(list.Width, 85);
            panelList.Location = new System.Drawing.Point(0, 480);
            Color color2 = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            panelList.BackColor = color2;

            Button buttonAdd = new Button();
            buttonAdd.Text = "Cadastrar";
            buttonAdd.Location = new System.Drawing.Point(150, 500);
            buttonAdd.Size = new System.Drawing.Size(95, 40);
            buttonAdd.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonAdd = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonAdd.BackColor = colorButtonAdd;
            buttonAdd.Click += (sender, args) =>
            {
                list.Close();
                list.Dispose();
                CadastrarQuartos();
            };

            Button buttonEdit = new Button();
            buttonEdit.Text = "Editar";
            buttonEdit.Location = new System.Drawing.Point(250, 500);
            buttonEdit.Size = new System.Drawing.Size(95, 40);
            buttonEdit.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonEdit = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonEdit.BackColor = colorButtonEdit;
            buttonEdit.Click += (sender, args) =>
            {
                list.Close();
                list.Dispose();
                updateRoom();
            };

            Button buttonDelete = new Button();
            buttonDelete.Text = "Excluir";
            buttonDelete.Location = new System.Drawing.Point(350, 500);
            buttonDelete.Size = new System.Drawing.Size(95, 40);
            buttonDelete.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonDelete = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonDelete.BackColor = colorButtonDelete;
            buttonDelete.Click += (sender, args) =>
            {
                list.Close();
                list.Dispose();
                deleteRoom();
            };

            Button buttonReturn = new Button();
            buttonReturn.Text = "Voltar";
            buttonReturn.Location = new System.Drawing.Point(450, 500);
            buttonReturn.Size = new System.Drawing.Size(95, 40);
            buttonReturn.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonReturn = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonReturn.BackColor = colorButtonReturn;
            buttonReturn.Click += (sender, args) =>
            {
                list.Close();
                list.Dispose();

            };

            list.Controls.Add(buttonReturn);
            list.Controls.Add(buttonDelete);
            list.Controls.Add(buttonEdit);
            list.Controls.Add(buttonAdd);
            list.Controls.Add(panelList);
            list.Controls.Add(Room);
            list.Controls.Add(listview);
            list.ShowDialog();
        }
        public static void updateRoom()
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

            Label labelAndar = new Label();
            labelAndar.Text = "Andar";
            labelAndar.Location = new System.Drawing.Point(30, 120);
            labelAndar.Size = new System.Drawing.Size(80, 20);
            labelAndar.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            ComboBox comboboxAndar = new ComboBox();
            comboboxAndar.Location = new System.Drawing.Point(30, 150);
            comboboxAndar.Size = new System.Drawing.Size(80, 80);
            comboboxAndar.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            comboboxAndar.Items.Add("1º Andar");
            comboboxAndar.Items.Add("2º Andar");
            comboboxAndar.Items.Add("3º Andar");

            Label labelNumero = new Label();
            labelNumero.Text = "Número";
            labelNumero.Location = new System.Drawing.Point(150, 120);
            labelNumero.Size = new System.Drawing.Size(80, 20);
            labelNumero.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

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
                update.Close();
                update.Dispose();
                ListarQuartos();
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
            update.Controls.Add(labelNumero);
            update.Controls.Add(comboboxNumero);
            update.Controls.Add(labelAndar);
            update.Controls.Add(comboboxAndar);
            update.Controls.Add(comboboxType);
            update.Controls.Add(labelType);
            update.Controls.Add(label);
            update.ShowDialog();
        }

        public static void deleteRoom()
        {
            Form delete = new Form();
            delete.Text = "Excluir";
            delete.Size = new System.Drawing.Size(500, 300);
            delete.FormBorderStyle = FormBorderStyle.FixedDialog;
            delete.MaximizeBox = false;
            delete.MinimizeBox = false;
            Color color = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            delete.BackColor = color;

            Label label = new Label();
            label.Text = "Deseja prosseguir?";
            label.Location = new System.Drawing.Point(80, 30);
            label.Size = new System.Drawing.Size(400, 60);
            label.Font = new System.Drawing.Font("Arial", 25, System.Drawing.FontStyle.Bold);

            Button buttonYes = new Button();
            buttonYes.Location = new System.Drawing.Point(105, 150);
            buttonYes.Size = new System.Drawing.Size(120, 40);
            buttonYes.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonYes = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonYes.BackColor = colorButtonYes;
            buttonYes.Text = "Sim";
            buttonYes.Click += (sender, args) =>
            {
                MessageBox.Show("Quarto excluído com sucesso!");
                delete.Close();
                delete.Dispose();
                ListarQuartos();
            };

            Button buttonNo = new Button();
            buttonNo.Location = new System.Drawing.Point(235, 150);
            buttonNo.Size = new System.Drawing.Size(120, 40);
            buttonNo.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            Color colorButtonNo = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            buttonNo.BackColor = colorButtonNo;
            buttonNo.Text = "Não";
            buttonNo.Click += (sender, args) =>
            {
                delete.Close();
            };

            delete.Controls.Add(buttonNo);
            delete.Controls.Add(buttonYes);
            delete.Controls.Add(label);
            delete.ShowDialog();

        }
    }
}