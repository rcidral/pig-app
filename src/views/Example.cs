namespace Views
{
    public class Example
    {

        public static void create(/* Models.Example example */)
        {
            Form form = new Form();
            form.Width = 500;
            form.Height = 500;
            form.Text = "Example";
            form.Controls.Add(new System.Windows.Forms.Label() { Text = "Example" });
            form.ShowDialog();
        }

    }
}