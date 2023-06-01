using Database;

namespace Models
{
    public class Example
    {
        private int Id { get; set; }
        private string Nome { get; set; }

        public Example(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public static void create(Example example)
        {
            try {
                using(Context context = new Context())
                {
                    context.Example.Add(example);
                    context.SaveChanges();
                }
            } catch (System.Exception e) {
                throw e;
            }
        }

    }
}