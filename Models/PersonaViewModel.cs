using Microsoft.AspNetCore.Mvc.Rendering;
using MuniApp.Negocio.entidades;

namespace MuniApp.Models
{
    public class PersonaViewModel
    {
        public List<Persona> listPersona { get; set; }
        public int? ddlPersonaId { get; set;}
        public int? ddlPersona { get; set; }
    }
}