using iii.Models;
using iii.Models.Dto;
using iii.Repository;
using Microsoft.AspNetCore.Mvc;

namespace iii.Controllers;

[Route("api/products")]
public class ProductAPIController : ControllerBase
{
    private IProductRepository _productRepository;

    public ProductAPIController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ResponseDTO> GetAllProducts()
    {
        ResponseDTO _responseDto = new ResponseDTO();
        try
        {
            IEnumerable<ProductDTO> productDtos = await _productRepository.GetProducts();
            _responseDto.Result = productDtos;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ResponseDTO> GetProductById(int id)
    {
        ResponseDTO _responseDto = new ResponseDTO();
        try
        {
            ProductDTO productDto = await _productRepository.GetProductById(id);
            _responseDto.Result = productDto;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }
    
    [HttpPost]
    public async Task<ResponseDTO> CreateProduct([FromBody] ProductDTO productDto)
    {
        ResponseDTO _responseDto = new ResponseDTO();
        try
        {
            ProductDTO model = await _productRepository.CreateUpdateProduct(productDto);
            _responseDto.Result = model;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }
    
    
    [HttpPut]
    public async Task<ResponseDTO> UpdateProduct([FromBody] ProductDTO productDto)
    {
        ResponseDTO _responseDto = new ResponseDTO();
        try
        {
            ProductDTO model = await _productRepository.CreateUpdateProduct(productDto);
            _responseDto.Result = model;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ResponseDTO> DeleteProductById(int id)
    {
        ResponseDTO _responseDto = new ResponseDTO();
        try
        {
            bool result = await _productRepository.DeleteProduct(id);
            _responseDto.Result = result;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }
}