using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Helpers;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {        
        protected IHttpContextAccessor httpContextAcessor;
        readonly IServicoAplicacaoUsuario ServicoAplicacaoUsuario;

        public LoginController(IServicoAplicacaoUsuario servicoAplicacaoUsuario, IHttpContextAccessor httpContext)
        {
            ServicoAplicacaoUsuario = servicoAplicacaoUsuario;
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
                bool login = ServicoAplicacaoUsuario.ValidarLogin(model.Nome, Senha) ;
                var usuario = ServicoAplicacaoUsuario.RetornarDadosUsuario(model.Nome, Senha);

                if (login)
                {
                    //TODO: VER A PORRA DO NOVO ERRO NO VIDEO 39
                    httpContextAcessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario?.Nome);
                    httpContextAcessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario?.Email);
                    httpContextAcessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario?.Codigo);
                    httpContextAcessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);

                    //Colocar os dados do usuário na sessão
                    return RedirectToAction("Index", "Home");                    
                }
                else
                {
                    ViewData["ErroLogin"] = "O Nome ou senha informado não existe no sistema!";
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }

            
        }
    }
}