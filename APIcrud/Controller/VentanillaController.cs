using APIcrud.Entidad;
using APIcrud.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIcrud.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentanillaController : ControllerBase
    {
        [HttpGet]
        public ActionResult ListaVenta()
        {
            Nventanilla lventa = new Nventanilla();
            return Ok(lventa.listaVentanilla());
        }
        [HttpPost]
        public ActionResult Post([FromBody] Ventanilla request)
        {
            Nventanilla lventa = new Nventanilla();
            return Ok(lventa.AddVentanilla(request));
            
        }

    }
}
