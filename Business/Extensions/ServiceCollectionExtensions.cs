using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Context;
using Microsoft.Extensions.DependencyInjection;


namespace Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {


            serviceCollection.AddDbContext<DataContext>();         
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IProductService, ProductManager>();
            serviceCollection.AddScoped<IProductFeatureService, ProductFeatureManager>();
            return serviceCollection;


        }
    }
}
