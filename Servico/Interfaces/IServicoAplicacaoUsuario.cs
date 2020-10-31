﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoUsuario
    {
        bool ValidarLogin(string nome, string senha);

        Usuario RetornarDadosUsuario(string nome, string senha);
    }
}
