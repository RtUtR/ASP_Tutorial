using ASp_Tutorial.Controllers.Second_Day.Mapper;
using ASp_Tutorial.Controllers.Second_Day.Models.Dtos;
using ASp_Tutorial.Controllers.Second_Day.Models.entities;
using ASp_Tutorial.Controllers.Third_Day.Interfaces;
using System.Linq.Expressions;

namespace ASp_Tutorial.Controllers.Third_Day
{
    public class ProductService_v1 : IProductService
    {
        private static List<Product> _product = new List<Product>()
        {
            new() { Id = 1, Name = "Laptop", Price = 1500, Category = "Electronics" },
            new() { Id = 2, Name = "Phone", Price = 800, Category = "Electronics" },
            new() { Id = 3, Name = "Book", Price = 20, Category = "Books" }
        };
        private static int index = 4;
        public ProductResponseDto Create(CreateProductDto _create)
        {
            Product Res=_create.ToEntity();
            Res.Id = index;
            _product.Add(Res);
            index++;
            return Res.ToResponse();
        }

        public bool Delete(int id)
        {
            Product? i = _product.FirstOrDefault(x => x.Id == id);
            if (i == null) return false;
            _product.Remove(i);
            return true;
        }

        public IEnumerable<ProductResponseDto> GetAll()
        {
            var i = _product.Select(x => x.ToResponse()).ToList();
            return i;
        }

        public ProductResponseDto? GetById(int id)
        {
            Product? w = _product.FirstOrDefault(x=>x.Id == id);
            if (w is null) return null;
            return w.ToResponse();
        }

        public bool Update(int id , UpdateProductDto x)
        {
            Product? _pew = _product.FirstOrDefault(w => w.Id == id);
            if( _pew is null ) return false;
            _pew.Name = x.Name;
            _pew.Price = x.Price;
            _pew.Category = x.Category;
            return true;
        }
    }
}
