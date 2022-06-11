using System.Collections.Generic;
using System.Linq;

namespace Blog.Models
{
    public class PostService
    {
         public int CreatePost(Post novoPost)
          {
              using (var context = new BlogContext())
              {
                  context.Add(novoPost);
                  context.SaveChanges();
                  return novoPost.Id;
              }
          }

         public ICollection<Post> GetPosts()
        {
        using (var context = new BlogContext())
            {
                ICollection<Post> resultado = 
                context.Posts.ToList();
    
                return resultado;
            }
        }

        public ICollection<Post> GetPosts(string termo, string ordem)
            {
                using (var context = new BlogContext())
                    {
                        IQueryable<Post> consulta = 
                        context.Posts.Where(p => p.Titulo.Contains(termo, StringComparison.OrdinalIgnoreCase));
            
                        if(ordem == "t")
                        consulta = consulta.OrderBy(p => p.Titulo);
                        else
                        consulta = consulta.OrderBy(p => p.Data);
    
                        return consulta.ToList();
                    }
            }

        public Post GetPostDetail(int id)
            {
                using (var context = new BlogContext())
                {
                    Post registro = context.Posts.Where(p => p.Id == id).SingleOrDefault();
                    return registro;
                }
            }
        
         public void UpdatePost(Post post)
            {
                using (var context = new BlogContext())
                {
                    Post registro = context.Posts.Find(post.Id);
                    if(registro != null)
                        {
                            registro.Texto = post.Texto;
                            registro.Titulo = post.Titulo;
                            registro.Data = post.Data;

                            context.SaveChanges();
                        }
                }
            }
        
        public void DeletePost(int id)
            {
                using (var context = new BlogContext())
                {   
                    Post registro = context.Posts.Find(id);
                    context.Posts.Remove(registro);
                    context.SaveChanges();
                }
            }
    }
}