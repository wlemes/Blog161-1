using Blog161.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog161.ViewModel
{
    public class ViewMensagensEComentarios
    {
        public IEnumerable<Mensagem> Mensagens { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
    }
}
