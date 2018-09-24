using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SiteECommerce.Models
{
    public class User
    {
        [Key]
        [Display(Name = "Compania")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "E-Mail")]
        [MaxLength(250, ErrorMessage = "O campo E-Mail recebe no maximo 250 caracteres")]
        [Index("User_UserName_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "O campo Nome recebe no maximo 50 caracteres")]
        public string FirtName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Sobrenome")]
        [MaxLength(50, ErrorMessage = "O campo Sobrenome recebe no maximo 50 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Telefone")]
        [MaxLength(50, ErrorMessage = "O campo Telefone recebe no maximo 50 caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Endereço")]
        [MaxLength(100, ErrorMessage = "O campo Endereço recebe no maximo 100 caracteres")]
        public string Address { get; set; }

        [Display(Name = "Imagen")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [NotMapped]
        [Display(Name = "Imagen")]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Compania")]
        public int CompanyId { get; set; }

        [Display(Name = "Usuário")]
        public string FullName { get { return string.Format("{0} {1}", FirtName, LastName); } }
        public virtual City Cities { get; set; }
        public virtual Company Company { get; set; }
        public virtual Departaments Departament { get; set; }
    }
}