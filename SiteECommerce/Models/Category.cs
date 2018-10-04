using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SiteECommerce.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [MaxLength(100, ErrorMessage = "O campo Nome recebe no maximo 100 caracteres")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!!")]//Define obrigatoriedade para o campo
        [Display(Name = "Categoria")]
        [Index("Category_Description_CompanyId_Index", 2, IsUnique = true)]//Não permite que repita o nome
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido!!")]
        [Index("Category_Description_CompanyId_Index", 1, IsUnique = true)] //Não permite que repita o nome
        [Display(Name = "Distribuidoras")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione um Distribuidora")]//Obriga que seja selecionado um valor para o campo
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}