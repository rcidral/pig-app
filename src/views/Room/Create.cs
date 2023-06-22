using Models;
using Controllers;

namespace Views
{
    public class RoomCreate : Form
    {
       public Label lblAndar;
       public Label lblNumero;
       public Label lblTipo;
       public Label lblObservacao;
       public TextBox txtAndar;
       public TextBox txtNumero;
       public TextBox txtTipo;
       public TextBox txtObservacao;
       public Button btCrt;

       public void btCrt_Click(object sender, EventArgs e)
       {
           if (
            txtAndar.Text == ""
            )
           {
               MessageBox.Show("Informe o campo de dados");
               return;
           }
       }
    }
}