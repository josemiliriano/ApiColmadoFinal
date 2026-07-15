using Application.Contract;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiColmadoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMovementController : ControllerBase
    {
        private readonly IInventoryMovementAppService _services;
        public InventoryMovementController(IInventoryMovementAppService servives)
        {
            _services = servives;
        }
        [Route("api/[controller]/CreateBuy")]
        [HttpPost]
        public IActionResult CreateBuy(InventoryMovementDto dto)
        {
            var NewBuy = _services.AddBuy(dto);
            return Ok(NewBuy);
        }
        [Route("api/[controller]/CreateSale")]
        [HttpPost]
        public IActionResult CreateSale(InventoryMovementDto dto)
        {
            var NewSale = _services.AddSale(dto);
            return Ok(NewSale);
        }
        [Route("api/[controller]/GetAllBuy")]
        [HttpGet]
        public IActionResult GetAllBuy()
        {
            var ListToBuy = _services.GetAllBuy();
            return Ok(ListToBuy);
        }
        [Route("api/[controller]/GetAllSale")]
        [HttpGet]
        public IActionResult GetAllSale()
        {
            var ListToSale = _services.GetAllSale();
            return Ok(ListToSale);
        }
        [Route("api/[controller]/GetAllTransactionComplete")]
        [HttpGet]
        public IActionResult GetAllTransactionComplete()
        {
            var ListTransaction = _services.GetAllTransactionComplete();
            return Ok(ListTransaction);
        }
        [Route("api/[controller]/GetAllTransactionWihtCondition")]
        [HttpGet]
        public IActionResult GetAllTransactionWihtCondition()
        {
            var ListTransaction = _services.GetAllTransactionWihtCondition();
            return Ok(ListTransaction);
        }
        [Route("api/[controller]/GetTransactionById/{id}")]
        [HttpGet]
        public IActionResult GetTransactionById(int id)
        {
            var transaction = _services.GetById(id);
            if (transaction == null)
            {
                return NotFound($"EL id {id} no existe ne la base de datos");
            }
            return Ok(transaction);
        }
        [Route("api/[controller]/SoftDelete")]
        [HttpDelete]
        public IActionResult SoftDelete(int id)
        {
            var transaction = _services.GetById(id);
            if (transaction == null)
            {
                return NotFound($"EL id {id} no existe ne la base de datos");
            }
            _services.SoftDelete(id);
            return Ok(transaction);
        }
        [Route("api/[controller]/DeleteTransaction")]
        [HttpDelete]
        public IActionResult DeleteTransaction(int id)
        {
            var transaction = _services.GetById(id);
            if (transaction == null)
            {
                return NotFound($"EL id {id} no existe ne la base de datos");
            }
            _services.DeleteTrasaction(id);
            return Ok("La transaccion fue borrada definitivamente");
        }
        [Route("api/[controller]/UpdateInventary")]
        [HttpPut]
        public IActionResult UpdateInventary(int id, InventoryMovementDto dto)
        {
            var transaction = _services.GetById(id);
            if (transaction == null)
            {
                return NotFound($"EL id {id} no existe ne la base de datos");
            }
            _services.UpdateInventary(id, dto);
            return Ok(transaction);
        }
    }
}
