using Contracts.DataTransferObject;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/estates")]
    public class EstatesController : ControllerBase
    {
        private readonly IEstatesService estatesService;
        private readonly IPdfService pdfService;
        public EstatesController(IEstatesService estatesService, IPdfService pdfService)
        {
            this.estatesService = estatesService;
            this.pdfService = pdfService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Properties has been returned.", typeof(EstatesDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Properties not found, return error message.")]
        public async Task<IActionResult> GetEstates()
        {
            try
            {
                var estates = await estatesService.GetAllActive();
                return Ok(estates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Propertie has been returned.", typeof(EstatesDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Propertie not found, return error message.")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var estate = await estatesService.GetByIdAsync(id);
                return Ok(estate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation("Create propertie.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Propertie has been created.", typeof(CreateEstatesDto))]
        public async Task<IActionResult> CreateEstate([FromBody] CreateEstatesDto dto)
        {
            try
            {
                await estatesService.CreateAsync(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Propertie has been updated.", typeof(EstatesDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Propertie not found, return error message.")]
        public async Task<IActionResult> UpdateEstate([FromRoute] int id, [FromBody] UpdateEstatesDto dto)
        {
            try
            {
                await estatesService.UpdateAsync(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Propertie has been removed.", typeof(EstatesDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Propertie not found, return error message.")]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            try
            {
                await estatesService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Propertie has been bought.", typeof(CreateEstatesDto))]
        public async Task<IActionResult> BuyEstate(int id)
        {
            try
            {
                await estatesService.BuyEstate(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/print")]
        [SwaggerOperation("Download agreement")]
        [SwaggerResponse(StatusCodes.Status200OK, "Agreement has been downloaded")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Agreement not found, return error message.")]
        public IActionResult GenerateInvoice(int id)
        {
            using (var stream = new MemoryStream())
            {
                try
                {
                    var estate = estatesService.GetById(id);
                    pdfService.GeneratePdf(stream, estate);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream.ToArray(), "application/pdf", "Agreement.pdf");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost("image")]
        public IActionResult UploadImage([FromForm] FileModel file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FileName);

                using(Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
