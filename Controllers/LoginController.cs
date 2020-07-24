using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Helpers;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {
        protected ApplicationDbContext mContext;
        protected IHttpContextAccessor httpContextAcessor;

        public LoginController(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            mContext = context;
            httpContextAcessor = httpContext;
        }

        public IActionResult Index(int? id)
        {
            if(id != null)
            { 
                if(id == 0)
                {
                    httpContextAcessor.HttpContext.Session.Clear();
                }
            }
            return View();
        }


        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErroLogin"] = string.Empty;
            if (ModelState.IsValid)
            {
                var Senha = Criptografia.GetMd5Hash(model.Senha);
                var usuario = mContext.Usuario.Where(x => x.Nome == model.Nome && x.Senha == Senha).FirstOrDefault();
                
                if (usuario == null)
                {
                    ViewData["ErroLogin"] = "O Nome ou senha informado não existe no sistema!";
                    return View(model);
                }
                else
                {
                    httpContextAcessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    httpContextAcessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    httpContextAcessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                    httpContextAcessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);

                    //Colocar os dados do usuário na sessão
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                return View(model);
            }

            
        }
    }
}