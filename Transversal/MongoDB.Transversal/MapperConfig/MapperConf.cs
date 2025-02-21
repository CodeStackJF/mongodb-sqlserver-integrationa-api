using AutoMapper;
using MongoDB.Domain;
using MongoDB.Domain.Mongo.Entities;
using MongoDB.Domain.SQL.Entities;
namespace MongoDB.Transversal.MapperConfig;

public class MapperConf : Profile
{
    public MapperConf()
    {
        CreateMap<products, productsCollection>()
            .ForMember(x=>x.id_product, y=>y.MapFrom(z=>z.id_product))
            .ForMember(x=>x.name, y=>y.MapFrom(z=>z.name))
            .ForMember(x=>x.Id, y=>y.Ignore())
            .ForMember(x=>x.suppliers, y=>y.MapFrom(z=>z.product_supplier))
            .ForMember(x=>x.categories, y=>y.MapFrom(z=>z.product_category))
            .ReverseMap();
            
        CreateMap<products_categories, categoriesCollection>()
            .ForMember(x=>x.id_category, y=>y.MapFrom(z=>z.category.id_category))
            .ForMember(x=>x.description, y=>y.MapFrom(z=>z.category.description)).ReverseMap();

        CreateMap<products_suppliers, suppliersCollection>()
            .ForMember(x=>x.id_supplier, y=>y.MapFrom(z=>z.supplier.id_supplier))
            .ForMember(x=>x.name, y=>y.MapFrom(z=>z.supplier.name)).ReverseMap();
    }
}