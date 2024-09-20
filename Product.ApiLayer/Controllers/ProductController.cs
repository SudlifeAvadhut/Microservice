using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.ApiLayer.BusinessModel;
using Product.ApiLayer.Interface;

namespace Product.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct _product { get; set; }
        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProduct()
        {
            try
            {
                 var allproducts = _product.GetAll();

                return Ok(new { Products = allproducts } );
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertProducts")]
        public IActionResult InsertProduct(ClsProductBM Products)
        {
            try
            {
                _product.Insert(Products);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("UpdateProducts/{ProductId}")]
        public IActionResult UpdateProducts(ClsProductBM Products,int ProductId)
        {
            try
            {
                _product.Update(Products,ProductId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteProduct/{ProductId}")]
        public IActionResult DeleteProduct(int ProductId)
        {
            try
            {
                _product.Delete(ProductId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
