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
            int novoId = service.CreatePost(novoPost);
            if(novoId != 0)
            {
                ViewData["Mensagem"] = "Cadastro realizado com sucesso";
            }
            else
            {
                ViewData["Mensagem"] = "Falha no cadastro";
            }

            return View();
          }        
    }
}