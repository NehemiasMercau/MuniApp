using System.ComponentModel.DataAnnotations;
namespace MuniApp.Models
{
    public class PersonaViewModelCustom
    {
        public int PersonaId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "No ingresar más de 50 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "No ingresar más de 50 caracteres")]
        public string Apellido { get; set; }
        [Range(1, 1000000000, ErrorMessage = "Value must be between 1 to 1000000000")]
        public Nullable<long> DNI { get; set; }
        [Required]
        public Nullable<int> PersonaTipoId { get; set; }
        [Required]
        //[RegularExpression(@"^\b(20|23|24|27|30|33|34)(\D)?[0-9]{8}(\D)?[0-9]", ErrorMessage = "Ingresar un CUIT/CUIL válido.")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{8}-[0-9]$", ErrorMessage = "Ingresar un CUIT/CUIL válido.")]
        public string CUIT { get; set; }
        [StringLength(50, ErrorMessage = "No ingresar más de 50 caracteres")]
        public string RazonSocial { get; set; }
        [RegularExpression(@"^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$", ErrorMessage = "Número de Teléfono inválido")]
        [Display(Name = "Número de teléfono")]
        public Nullable<long> Telefono { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<int> PersonaEstadoId { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> ActualizoDeuda { get; set; }
        public Nullable<System.DateTime> FechaUltimaActualizacion { get; set; }
    }
}