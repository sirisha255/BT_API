namespace BT_API.Models
{
    public interface IProductContext
    {
        ProductResponse GetAll();
        ProductResponse GetById(int id);
        ProductResponse Add(Product item);
        ProductResponse Delete(int id);
        ProductResponse Update(Product item);
    }
}
