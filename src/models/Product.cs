using Database;

namespace Models{
    public class Product{
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        

        public Product(int id, string name, double value){
            this.Id = id;
            this.Name = name;
            this.Value = value;
        }
        public static void Store(Product product){
            try{
            using (Context context = new Context()){
                context.Products.Add(product);
                context.SaveChanges();
            }
            }catch(System.Exception e){
                throw e;
            }
        }
        public static List<Product> index(){
            try{
               using (Context context = new Context()){
                    return context.Products.ToList();
               } 
            }catch(System.Exception e){
                throw e;
            }
        }
        public static List<Product> show(int id){
            try{
                using(Context context = new Context()){
                    return context.Products.Where(Product => Product.Id == id).ToList();
                }
            }catch(System.Exception e){
                throw e;
            }
        }
        public static void Update(int id, Product products){
            try{
            using(Context context = new Context()){
                Product oldProduct = context.Products.Find(id);  
                oldProduct.Value = product.Value; 
                oldProduct.Name = product.Name;
                context.SaveChanges();
            }
            }catch(System.Exception e){
                throw e;
            }
        }
        public static void destroy(int id){
            try{
               using (Context context = new Context()){
                    Product product = context.Products.Find(id);
                    context.Products.Remove(product);
                    context.SaveChanges();
               }
            }
            catch (System.Exception e)
            { 
                throw e;
            }
        }
    }

}