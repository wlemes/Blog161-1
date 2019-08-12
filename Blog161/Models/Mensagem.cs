using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog161.Models
{
    public class Mensagem
    {
        public int MensagemId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMensagem { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
        //SelectList
    }
}
