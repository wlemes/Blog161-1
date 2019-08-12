using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog161.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario { get; set; }
        public string Autor { get; set; }

        public int MensagemId { get; set; }
        [DisplayName("Mensagem")]
        [ForeignKey("MensagemId")]
        public Mensagem Mensagem { get; set; }
    }
}
