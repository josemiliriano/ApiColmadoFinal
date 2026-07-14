using Application.Contract;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiColmadoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderAppService _providerService;
        public ProviderController(IProviderAppService providerService)
        {
            _providerService = providerService;
        }
        [Route("api/[controller]/CreateProduct")]
        [HttpPost]
        public IActionResult CreateProduct(ProviderDto dto)
        {
            var NewProvider = _providerService.AddProvider(dto);
            return Ok(NewProvider);
        }
        [Route("api/[controller]/GetAllProvider")]
        [HttpGet]
        public IActionResult GetAllProvider()
        {
            var providers = _providerService.GetAllProvider();
            return Ok(providers);
        }
        [Route("api/[controller]/GetProviderById/{id}")]
        [HttpGet]
        public IActionResult GetProviderById(int id)
        {
            var provider = _providerService.GetProviderById(id);
            return Ok(provider);
        }
        [Route("api/[controller]/GetProviderWithCondition")]
        [HttpGet]
        public IActionResult GetProviderWithCondition()
        {
            var provider = _providerService.GetProviderNotDeleted();
            return Ok(provider);
        }
        [Route("api/[controller]/softDelete")]
        [HttpDelete]
        public IActionResult softDelete(int id)
        {
            var provider = _providerService.SoftDelete(id);
            if (provider == null)
            {
                return NotFound($"El id {id} no existe en la base de datos");
            }
            _providerService.SoftDelete(id);
            return Ok(provider);
        }
        [Route("api/[controller]/DeleteProvider")]
        [HttpDelete]
        public IActionResult DeleteProvider(int id)
        {
            var provider = _providerService.GetProviderById(id);
            if (provider == null)
            {
                return NotFound($"El id {id} no existe en la base de datos");
            }
            _providerService.DeleteProvider(id);
            return Ok("EL proveedor fue borrado definitivamente");
        }
        [Route("api/[controller]/UpdateProvider")]
        [HttpPut]
        public IActionResult UpdateProvider(int id, ProviderDto dto)
        {
            var provider = _providerService.GetProviderById(id);
            if (provider == null)
            {
                return NotFound($"El id {id} no exite en el base de datos");
            }
            _providerService.UpdateProvider(id, dto);
            return Ok(provider);
        }
    }
}
