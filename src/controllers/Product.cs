using Models;

namespace Controllers{
    public class Product{
       public static void Store(Models.Product product) {
            try {
                List<Models.Product> existingProducts = Controllers.Product.index();

                foreach (Models.Product existingProduct in existingProducts) {
                    if (existingProduct.Name == product.Name) {
                        throw new System.Exception("Product already exists");
                    }
                }
                Models.Product.Store(product);
            } catch (System.Exception e) {
                throw e;
            }
        }
        public static List<Models.Product> index(){
            try {
                return Models.Product.index();
            }catch (System.Exception e){
                throw e;
            }
        }
        public static List<Models.Product> show(int id){
            try{
                return Models.Product.show(id);
            }catch (System.Exception e){
                throw e;
            }
        }
        public static void update(int id, Models.Product product){
            try{
                Models.Product.Update(id, product);
            }catch (System.Exception e){
                throw e;
            }
        }
        public static void destroy(int id, Models.Product product){
            try{
                Models.Product.destroy(id);
            }catch (System.Exception e){
                throw e;
            } 
        }
    }
}