using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
    {
        private readonly IServicoUsuario ServicoUsuario;

        public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario)
        {
            ServicoUsuario = servicoUsuario;
        }

        public Usuario RetornarDadosUsuario(string nome, string senha)
        {
            return ServicoUsuario.Listagem().Where(x => x.Nome.ToUpper() == nome.ToUpper() && x.Senha.ToUpper() == senha.ToUpper()).FirstOrDefault() ;
        }

        public bool ValidarLogin(string nome, string senha)
        {
            return ServicoUsuario.ValidarLogin(nome, senha);
        }
    }
}
