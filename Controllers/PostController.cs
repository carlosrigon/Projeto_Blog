using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Cadastro()
          {
              return View();
          }

        [HttpPost]
        public IActionResult Cadastro(Post novoPost)
          {
            PostService service = new PostService();
            if(novoPost.Id != 0)
            {
                service.UpdatePost(novoPost);
                ViewData["Mensagem"] = "Cadastro realizado com sucesso";
            }
            else
            {
                int novoId = service.CreatePost(novoPost);
                if (novoId != 0)
                {
                    ViewData["Mensagem"] = "Cadastro realizado com sucesso";
                }
                else
                {
                    ViewData["Mensagem"] = "Falha no cadastro";
                }
            }

            return View();
          }

        public IActionResult Lista()
            {
                PostService service = new PostService();
                return View(service.GetPosts());
            }

        public IActionResult Lista(string q, string ordem)
            {
                PostService service = new PostService();

                if(q == null)
                q = String.Empty;
          
                if(ordem == null)
                ordem = "t";

                return View(service.GetPosts(q, ordem));
            }
        
        public IActionResult Atualiza(int id)
            {
                PostService service = new PostService();
                Post post = service.GetPostDetail(id);

                return View("Cadastro", post);
            }
        
        public IActionResult Exclui(int id)
            {
                PostService service = new PostService();
                Post post = service.GetPostDetail(id);

                return View(post);
            }

        [HttpPost]
        public IActionResult Exclui(int id, string decisao)
            {
                if(decisao == "s")
                {
                    PostService service = new PostService();
                    service.DeletePost(id);
                }

                return RedirectToAction("Lista");
            }
    }
}