using iii.Models.Dto;

namespace iii.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(int productId);
    Task<ProductDTO> CreateUpdateProduct(ProductDTO productDto);
    Task<bool> DeleteProduct(int productId);
}