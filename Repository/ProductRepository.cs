using AutoMapper;
using iii.DbContext;
using iii.Models;
using iii.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace iii.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public ProductRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        IEnumerable<Product> products = await _appDbContext.Products.ToListAsync();
        return _mapper.Map<List<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetProductById(int productId)
    {
        Product productFind =
            await _appDbContext.Products.FindAsync(productId) ?? throw new InvalidOperationException();
        return _mapper.Map<ProductDTO>(productFind);
    }

    public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDto)
    {
        Product product = _mapper.Map<ProductDTO, Product>(productDto);
        if (product.ProductId > 0)
        {
            _appDbContext.Products.Update(product);
        }
        else
        {
            _appDbContext.Products.Add(product);
        }
        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<Product, ProductDTO>(product);
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            Product productFind = await _appDbContext.Products.FindAsync(productId);
            if (productFind == null) return false;
            _appDbContext.Products.Remove(productFind);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}