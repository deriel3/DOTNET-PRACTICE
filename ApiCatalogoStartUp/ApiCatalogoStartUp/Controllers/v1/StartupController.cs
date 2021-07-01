using ApiCatalogoStartUp.Exceptions;
using ApiCatalogoStartUp.InputModel;
using ApiCatalogoStartUp.Services;
using ApiCatalogoStartUp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoStartUp.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StartupController : ControllerBase
    {
        private readonly IStartupService _startupService;
        public StartupController(IStartupService startupService)
        {
            _startupService = startupService;
        }
        /// <summary>
        /// Buscar todos los start up por paginacion
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StartupViewModel>>> Obtener([FromQuery, Range(1,int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int cantidad = 5)
        {
            throw new Exception();
            var result = await _startupService.obtener(pagina, cantidad);
            if (result.Count == 0)
                return NoContent();
            return Ok(result);
        }
        [HttpGet("{idStartup:guid}")]
        public async Task<ActionResult<List<StartupViewModel>>> Obtener([FromRoute]Guid idStartup)
        {
            var result = await _startupService.obtener(idStartup);
            if (result == null)
                return NoContent();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<StartupViewModel>> IngresarStartup([FromBody]StartupInputModel startupInputModel)
        {
            try
            {
                var result = await _startupService.insertar(startupInputModel);
                return Ok(result);
            }
            catch(StartupYaRegistradoException ex)
            {
                return UnprocessableEntity("Startup ya registrada");
            }
        }
        [HttpPut("{idStartup:guid}")]
        public async Task<ActionResult> ActualizarStartup([FromRoute]Guid idStartup,[FromBody] StartupInputModel startupInputModel)
        {
            try
            {
                await _startupService.actualizar(idStartup, startupInputModel);
                return Ok();
            }
            catch(StartupNoRegistradoException ex)
            {
                return NotFound("No existe este startup");
            }
        }
        [HttpPatch("{idStartup:guid}/precio/{precio:double}")]
        public async Task<ActionResult> ActualizarStartup([FromRoute] Guid idStartup, [FromRoute] double precio)
        {
            try
            {
                await _startupService.actualizar(idStartup, precio);
                return Ok();
            }
            catch(StartupNoRegistradoException ex)
            {
                return NotFound("No existe la Startup");
            }
        }
        [HttpDelete("{idStartup:guid}")]
        public async Task<ActionResult> BorrarStartup([FromRoute] Guid idStartup)
        {
            try
            {
                await _startupService.remover(idStartup);
                return Ok();
            }
            catch(StartupNoRegistradoException ex)
            {
                return NotFound("Startup no registrada");
            }
        }
    }
}
