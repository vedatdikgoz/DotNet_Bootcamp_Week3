using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeaturesController : ControllerBase
    {
        IProductFeatureService _productFeatureService;

        public ProductFeaturesController(IProductFeatureService productFeatureService)
        {
            _productFeatureService = productFeatureService;
        }

        /// <summary>
        /// List all productFeatures
        /// </summary>       
        /// <return>ProductFeatures List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductFeatureDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productFeatureService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }



        /// <summary>
        /// It brings the details according to its id.
        /// </summary>
        /// /// <param name="id"></param>
        /// <return>ProductFeature List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductFeatureDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("get")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productFeatureService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }


        /// <summary>
        /// Add ProductFeature.
        /// </summary>
        /// <param name="productFeatureAddDto"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add(ProductFeatureAddDto productFeatureAddDto)
        {
            var result = await _productFeatureService.AddAsync(productFeatureAddDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }



        /// <summary>
        /// Update ProductFeature.
        /// </summary>
        /// <param name="productFeatureUpdateDto"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update(ProductFeatureUpdateDto productFeatureUpdateDto)
        {
            var result = await _productFeatureService.UpdateAsync(productFeatureUpdateDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }



        /// <summary>
        /// Delete ProductFeature.
        /// </summary>
        /// <param name="productFeatureId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete(int productFeatureId)
        {
            var result = await _productFeatureService.DeleteAsync(productFeatureId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
    }
}

