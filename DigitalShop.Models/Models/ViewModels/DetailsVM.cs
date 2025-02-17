namespace DigitalShop.Models.ViewModels;

public class DetailsVM
{
    public Product Product { get; set; }
    public bool ExistsInCart { get; set; }

    public DetailsVM()
    {
        Product = new Product();
    }
}
