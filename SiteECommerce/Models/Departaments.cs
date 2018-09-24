using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteECommerce.Models
{
    public class Departaments
    {
        [Key]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório!!")]
        [Display(Name ="Departamento")]
        [MaxLength(50, ErrorMessage = "O campo Nome recebe no maximo 50 caracteres")]
        [Index("Departament_Name_Index", IsUnique = true)]
        public string Name { get; set; }       
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}