using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWendel.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
    }
}
