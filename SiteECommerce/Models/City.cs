using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiteECommerce.Models
{
    public class City
    {
        [Key]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]
        [Display(Name = "Cidade")]
        public string Name { get; set; }

        [Display(Name ="Departamentos")]
        [Range(1, double.MaxValue, ErrorMessage ="Selecione um departamento")]
        public int DepartamentsId { get; set; }
        public virtual Departaments Departament { get; set; }
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}