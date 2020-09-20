using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class CategoriaController : Controller
    {        
        readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }


        public IActionResult Index()
        {           
            return View(ServicoAplicacaoCategoria.Listagem());
        }

        //[HttpGet]
        //public IActionResult Cadastro(int? id)
        //{
        //    CategoriaViewModel viewModel = new CategoriaViewModel();

        //    if(id != null)
        //    {
        //        var entidade = mContext.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
        //        viewModel.Codigo = entidade.Codigo;
        //        viewModel.Descricao = entidade.Descricao;
        //    }

        //    return View(viewModel);
        //}

        //[HttpPost]
        //public IActionResult Cadastro(CategoriaViewModel entidade)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Categoria objCategoria = new Categoria()
        //        {
        //            Codigo = entidade.Codigo,
        //            Descricao = entidade.Descricao
        //        };

        //        if(entidade.Codigo == null)
        //        {
        //            mContext.Categoria.Add(objCategoria);
        //        }
        //        else
        //        {
        //            mContext.Entry(objCategoria).State = EntityState.Modified;
        //        }

        //        mContext.SaveChanges();
        //    }
        //    else
        //    {
        //        return View(entidade);
        //    }

        //    return RedirectToAction("index");
        //}

        //[HttpGet]
        //public IActionResult Excluir(int id)
        //{
        //    var ent = new Categoria() { Codigo = id };
        //    mContext.Attach(ent);
        //    mContext.Remove(ent);
        //    mContext.SaveChanges();

        //    return RedirectToAction("Index");
        //}


    }
}