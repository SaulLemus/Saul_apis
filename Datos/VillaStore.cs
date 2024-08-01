using MAgicVilla_API.Modelos.Dto;

namespace MAgicVilla_API.Datos
{ 
    public static class VillaStore
    {
        public static List<VillaDto> villalist = new List<VillaDto>
        {
            new VillaDto{Id=1, Nombre="Vista a la piscina"},
            new VillaDto{Id=2, Nombre="Vista a la playa"},
            new VillaDto{Id=3, Nombre="Con estudio privado "}
        };
    }
}

