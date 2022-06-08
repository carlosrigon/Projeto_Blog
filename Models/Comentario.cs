using System;

namespace Blog.Models
{
    public class Comentario
    {
        public int Id {get; set;}
        public string Autor {get; set;}
        public string Conteudo {get; set;}
        public DateTime Data {get; set;}
        public int PostId {get; set;}
        public Post Post {get; set;}
    }
}