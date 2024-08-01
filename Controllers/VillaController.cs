using MAgicVilla_API.Datos;
using MAgicVilla_API.Modelos;
using MAgicVilla_API.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAgicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        // Aqui funciona si regresar un estado de resultado
        //[HttpGet]
        //public IEnumerable<VillaDto> GetVillas()
        //{
        //    // Aqui retorna los valorse fijos de la clase VillaDto
        //    //return new List<VillaDto>
        //    //{
        //    //    new VillaDto{Id=1, Nombre="Vista a la piscina"},
        //    //    new VillaDto{Id=2, Nombre="Vista a la playa"}
        //    //};

        //    // Aqui se consumen los datos ficticios de Datos.VillaStore
        //    return VillaStore.villalist;
        //}

        //[HttpGet("Id")]
        //public VillaDto GetVilla(int id) 
        //{
        //    return VillaStore.villalist.FirstOrDefault(v => v.Id == id);
        //}

        [HttpGet]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {

            return Ok(VillaStore.villalist);
        }
        // Este codigo no hace validacion del resultado solo funciona si la request es correcta
        //[HttpGet("Id")]
        //public ActionResult<VillaDto> GetVilla(int id)
        //{
        //    return Ok(VillaStore.villalist.FirstOrDefault(v => v.Id == id));
        //}

        [HttpGet("Id:int")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<VillaDto> GetVilla(int id)
        {
            if(id==0) 
            {
                return BadRequest();
            }

            var villa = VillaStore.villalist.FirstOrDefault(v => v.Id == id);

            if(villa==null)
            {
                return NotFound();
            }

            return Ok(villa);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto VillaDto)
        {
            if(VillaDto == null) 
            { 
                return BadRequest(VillaDto); 
            }

            if(VillaDto.Id>0)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            VillaDto.Id = VillaStore.villalist.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.villalist.Add(VillaDto);

            return Ok(VillaDto);

        }


    }
}
