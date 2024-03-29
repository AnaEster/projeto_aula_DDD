﻿using Projeto.Application.Contracts;
using Projeto.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Presentation.Controllers
{
    [RoutePrefix("api/Compromisso")]
    public class CompromissoController : ApiController
    {
        //atributo
        private readonly ICompromissoAppService appService;

        //construtor para injeção de dependência
        public CompromissoController(ICompromissoAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        public HttpResponseMessage Post(CompromissoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    appService.Cadastrar(model);
                    return Request.CreateResponse
                        (HttpStatusCode.OK, "Compromisso cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse
                        (HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(CompromissoEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    appService.Atualizar(model);
                    return Request.CreateResponse
                        (HttpStatusCode.OK, "Compromisso atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse
                        (HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    appService.Excluir(id);
                    return Request.CreateResponse
                        (HttpStatusCode.OK, "Compromisso excluído com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse
                        (HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = appService.ConsultarTodos();
                    return Request.CreateResponse
                        (HttpStatusCode.OK, model);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse
                        (HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = appService.ConsultarPorId(id);
                    return Request.CreateResponse
                        (HttpStatusCode.OK, model);
                }
                catch (Exception e)
                {
                    return Request.CreateResponse
                        (HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}
