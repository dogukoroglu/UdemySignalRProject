using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
			return Ok(values);
		}

		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
			{
				ProductDescription = y.ProductDescription,
				ProductImageUrl = y.ProductImageUrl,
				ProductPrice = y.ProductPrice,
				ProductID = y.ProductID,
				ProductName = y.ProductName,
				ProductStatus = y.ProductStatus,
				CategoryName = y.Category.CategoryName
			});
			return Ok(values.ToList());
		}

		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			_productService.TAdd(new Product()
			{
				ProductDescription = createProductDto.ProductDescription,
				ProductName = createProductDto.ProductName,
				ProductImageUrl = createProductDto.ProductImageUrl,
				ProductPrice = createProductDto.ProductPrice,
				ProductStatus = true
			});
			return Ok("Ürün Başarılı Bir Şekilde Eklendi!");
		}

		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			var value = _productService.TGetByID(id);
			_productService.TDelete(value);
			return Ok("Ürün Başarılı Bir Şekilde Silindi!");
		}

		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			_productService.TUpdate(new Product()
			{
				ProductID = updateProductDto.ProductID,
				ProductDescription = updateProductDto.ProductDescription,
				ProductName = updateProductDto.ProductName,
				ProductImageUrl = updateProductDto.ProductImageUrl,
				ProductPrice = updateProductDto.ProductPrice,
				ProductStatus = updateProductDto.ProductStatus
			});
			return Ok("Ürün Başarılı Bir Şekilde Güncellendi!");
		}

		[HttpGet("GetProduct")]
		public IActionResult GetProduct(int id)
		{
			var value = _productService.TGetByID(id);
			return Ok(value);
		}
	}
}
