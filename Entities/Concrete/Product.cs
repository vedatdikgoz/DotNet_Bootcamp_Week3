using Core.Entities;


namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }

    }
}
