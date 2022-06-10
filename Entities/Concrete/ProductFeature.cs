using Core.Entities;



namespace Entities.Concrete
{
    public class ProductFeature:IEntity
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        //one to one ilişkide kimin child olduğunu bildirmek için parent id belirtilir. product:parent, productfeature:child
        public int ProductId { get; set; }       
        public Product Product { get; set; }
    }
}
