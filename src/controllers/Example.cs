namespace Controllers
{
    public class Example
    {

        public static void create(Models.Example example)
        {
            try {
                Models.Example.create(example);
            } catch (System.Exception e) {
                throw e;
            }
        }

    }
}