using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Post
    {
        public int Id {get; set;}
        public string Titulo { get; set;}
        public string Texto { get; set;}
        public DateTime Data {get; set;}
        public ICollection<Comentario> Comentarios {get; set;}
    }
}