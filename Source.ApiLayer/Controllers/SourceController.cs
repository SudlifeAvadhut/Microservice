using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Source.ApiLayer.BusinessModel;
using Source.ApiLayer.Interface;

namespace Source.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        private ISource _source { get; set; }
        public SourceController(ISource source)
        {
            _source = source;
        }

        [HttpGet("GetAllSource")]
        public IActionResult GetAllSource()
        {
            try
            {
                var allsources = _source.GetAll();

                return Ok(new { Sources = allsources });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertSource")]
        public IActionResult InsertSource(ClsSourceBM Sources)
        {
            try
            {
                _source.Insert(Sources);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("UpdateSource/{SourceId}")]
        public IActionResult UpdateSource(ClsSourceBM Sources, int SourceId)
        {
            try
            {
                _source.Update(Sources, SourceId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteSource/{SourceId}")]
        public IActionResult DeleteSource(int SourceId)
        {
            try
            {
                _source.Delete(SourceId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
