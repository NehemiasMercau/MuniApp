using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ODAMuniApi.Models
{
    public class ParticularViewModels
    {
        public int PersonaEntidadDeudaDetalleId { get; set; }
        public string Rubro { get; set; }
        public string Periodo { get; set; }
        public decimal Importe { get; set; }
        public decimal Total { get; set; }
        public Nullable<decimal> Recargo { get; set; }
        public System.DateTime? FechaVencimiento { get; set; }
        public bool Pagado { get; set; }
        public bool Anulado { get; set; }
        public string FechaPago { get; set; }
        public int DeudaId { get; set; }
        public string Observ { get; set; }
        public bool Vencido { get; set; }

        public int PagoDetalleId { get; set; }
        public string DatosPersona { get; set; }

    }

    public class DeudasViewModels
    {
        public int DeudaId { get; set; }
        public string Rubro { get; set; }
        public int RubroId { get; set; }
        public string Anio { get; set; }
        public string PersonaTipo { get; set; }
        public string PeriodoTipo { get; set; }
        public decimal Monto { get; set; }
        public decimal Interes { get; set; }
        public Nullable<int> DiaVencimiento { get; set; }
        public string FechaVencimiento { get; set; }

        public string Padron { get; set; }
        public string Observ { get; set; }

    }

    public class DeudaViewModelCustom
    {
        public int DeudaId { get; set; }
        [Required]
        public Nullable<int> RubroId { get; set; }
        [Required]
        public Nullable<int> AnioId { get; set; }
        [Required]
        public Nullable<int> PeriodoTipoId { get; set; }
        [Required]
        public Nullable<int> PersonaTipoId { get; set; }
        [Required]
        //[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})?", ErrorMessage = "Ingresar un monto válido. Hasta 2 decimales.")]
        public Nullable<decimal> Monto { get; set; }

        public Nullable<decimal> Interes { get; set; }
        public Nullable<int> DiaVencimientoReferencia { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public string Observacion { get; set; }
        //[RegularExpression(@"^\b(20|23|24|27|30|33|34)(\D)?[0-9]{8}(\D)?[0-9]", ErrorMessage = "Ingresar un CUIT/CUIL válido.")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{8}-[0-9]$", ErrorMessage = "Ingresar un CUIT/CUIL válido.")]
        public string CUIT { get; set; }

        public List<Periodo> Meses { get; set; }

        public string Padron { get; set; }
    }

    

    

    public class DomicilioViewModelCustom
    {
        public int DomicilioId { get; set; }
        public Nullable<int> PersonaEntidadId { get; set; }
        public Nullable<int> PersonaId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "No ingresar más de 50 caracteres")]
        public string Barrio { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "No ingresar más de 50 caracteres")]
        public string Calle { get; set; }
        public Nullable<int> Altura { get; set; }
        public Nullable<int> Piso { get; set; }
        public Nullable<int> Dpto { get; set; }
        public Nullable<bool> Activo { get; set; }

    }

    public class EntidadViewModel
    {
        public int EntidadId { get; set; }
        [Required]
        public string Nombre { get; set; }

        //[RegularExpression(@"^\b(20|23|24|27|30|33|34)(\D)?[0-9]{8}(\D)?[0-9]", ErrorMessage = "Ingresar un CUIT/CUIL válido.")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{8}-[0-9]$", ErrorMessage = "Ingresar un CUIT/CUIL válido.")]
        public string CUIT { get; set; }
        [Required]
        public Nullable<int> RubroId { get; set; }
        public Nullable<bool> Activo { get; set; }
    }

    public class EntidadPersonaViewModel
    {
        public int EntidadId { get; set; }
        public int PersonaEntidadId { get; set; }
        [Required]
        //[RegularExpression(@"^\b(20|23|24|27|30|33|34)(\D)?[0-9]{8}(\D)?[0-9]", ErrorMessage = "Ingresar un CUIT/CUIL válido.")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{8}-[0-9]$", ErrorMessage = "Ingresar un CUIT/CUIL válido.")]
        public string CUIT { get; set; }

        public IEnumerable<Persona> listPersona { get; set; }
    }

    public class UserViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "CUIL/CUIT")]
        //[RegularExpression(@"\b(20|23|24|27|30|33|34)(\D)?[0-9]{8}(\D)?[0-9]", ErrorMessage = "CUIT/CUIL Inválido")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{8}-[0-9]$", ErrorMessage = "Ingresar un CUIT/CUIL válido.")]
        public string CUIL { get; set; }

        [RegularExpression(@"^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$", ErrorMessage = "Número de Teléfono inválido")]
        [Display(Name = "Número de teléfono")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
        public int PerfilId { get; set; }

        public bool PersonaEstado { get; set; }
    }

    public class EntidadDeleteViewModel
    {
        public Entidad oEntidad { get; set; }
        public List<Deuda> listDeudas { get; set; }
    }

    public class PruebaViewModel
    {
        public string topic { get; set; }
        public string id { get; set; }
    }

    public class PagoGETViewModel
    {
        public string pay { get; set; }
        public string mer { get; set; }
    }


    public class PagosDataModel
    {
        public string[] strDatos { get; set; }
        public PagoDetalle oPagoDetalle { get; set; }
    }

    public class ResumenPagosModel
    {
        public List<ResumenDetalleModel> listResumen { get; set; }

        public List<PersonaDeudaDetalle> listPersonaHabilitacion { get; set; }

        public List<PersonaEnDeuda> listPersonaEnDeuda { get; set; }

        public List<PersonaEnDeuda> listPersonaEnDeudaVencida { get; set; }


        [Required]
        public string fechas { get; set; }

        [Required]
        public string Desde { get; set; }
        [Required]
        public string Hasta { get; set; }

        public int RubroId { get; set; }

        public string RubroNombre { get; set; }

        public PersonaEnDeuda oPersonaEnDeuda { get; set; }
    }

    public class ResumenDetalleModel
    {
        public string campo { get; set; }
        public string valor { get; set; }

        public ResumenDetalleModel(string campo, string valor)
        {
            this.campo = campo;
            this.valor = valor;
        }
    }

    public class HomeViewModel
    {
        public string DeudasAsignadasPorcentaje { get; set; }
        public decimal DeudasAsignadasTotal { get; set; }
        public int Personas { get; set; }
        public int Entidades { get; set; }
        public int EntidadesParticular { get; set; }
        public int Domicilios { get; set; }
        public int Deudas { get; set; }
        public int Arqueos { get; set; }
        public int Cobros { get; set; }
        public int Rubros { get; set; }
        public int Usuarios { get; set; }
    }

    public class PersonaDeudaDetalle
    {
        public Persona oPersona { get; set; }
        public PersonaEntidadDeudaDetalle oPersonaEntidadDeudaDetalle { get; set; }

        public PersonaDeudaDetalle(Persona oPersona, PersonaEntidadDeudaDetalle oPersonaEntidadDeudaDetalle)
        {
            this.oPersona = oPersona;
            this.oPersonaEntidadDeudaDetalle = oPersonaEntidadDeudaDetalle;
        }
    }

    public class PersonaEnDeuda
    {
        public int id { get; set; }
        public string Datos { get; set; }
        public string Periodos { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoIntereses { get; set; }
        public string MontoStr { get; set; }
        public string MontoTotalStr { get; set; }
        public string MontoInteresesStr { get; set; }

        public PersonaEnDeuda(int id, string Datos, string Periodos, decimal Monto, decimal MontoTotal, decimal MontoIntereses)
        {
            this.id = id;
            this.Datos = Datos;
            this.Periodos = Periodos;
            this.Monto = Monto;
            this.MontoTotal = MontoTotal;
            this.MontoIntereses = MontoIntereses;
            this.MontoStr = Monto.ToString().Replace(",", ".");
            this.MontoTotalStr = MontoTotal.ToString().Replace(",", ".");
            this.MontoInteresesStr = MontoIntereses.ToString().Replace(",", ".");
        }

        public PersonaEnDeuda()
        {
            this.id = id;
            this.Datos = Datos;
            this.Periodos = Periodos;
            this.Monto = Monto;
            this.MontoTotal = MontoTotal;
            this.MontoIntereses = MontoIntereses;
            this.MontoStr = Monto.ToString();
            this.MontoTotalStr = MontoTotal.ToString();
            this.MontoInteresesStr = MontoIntereses.ToString();
        }

        
    }

    public class OrderModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}