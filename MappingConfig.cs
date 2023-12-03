using AutoMapper;
using iii.Models;
using iii.Models.Dto;

namespace iii;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDTO, Product>();
            config.CreateMap<Product, ProductDTO>();
        });

        return mappingConfig;
    }
}