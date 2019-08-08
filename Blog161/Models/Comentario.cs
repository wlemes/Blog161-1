using System;
using System.Collections.Generic;
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
    }
}
