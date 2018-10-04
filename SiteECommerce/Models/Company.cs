using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SiteECommerce.Models
{
    public class Company
    {
        [Key]
        [Display(Name = "Compania")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Compania")]
        [MaxLength(50, ErrorMessage = "O campo Nome recebe no maximo 50 caracteres")]
        public string Name { get; set; }

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
        public string Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        public virtual City Cities { get; set; }
        public virtual Departaments Departament { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}