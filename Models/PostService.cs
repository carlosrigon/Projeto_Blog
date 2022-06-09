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
    }
}