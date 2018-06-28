using Corrida.Api.Structures;
using Corrida.Domain.Contracts.Services;
using Corrida.Domain.Entity;
using Corrida.Shared.Validation;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Corrida.Api.Controllers
{
    public class ParticipanteController : ApiController
    {
        private readonly IParticipanteService _participanteService;

        public ParticipanteController(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }
        
        [HttpGet]
        [Route("Teste")]
        public async Task<HttpResponseMessage> Teste()
        {
            HttpResponseMessage response;
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Api de Corrida esta ok");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return await tsc.Task;
        }

        [HttpGet]
        [Route("ObterParticipante")]
        public async Task<HttpResponseMessage> Post(string cpf)
        {
            HttpResponseMessage response;
            try
            {                
                AssertionConcern.AssertArgumentNotEmpty(cpf, "O Cpf não pode ser nulo.");
                var result = _participanteService.GetCpf(cpf);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return await tsc.Task;
        }

        [HttpPost]
        [Route("Cadastar")]
        public Task<HttpResponseMessage> Post(ParticipanteModel model)
        {
            HttpResponseMessage response;
            try
            {                
                AssertionConcern.AssertArgumentNotEmpty(model.Cpf, "O Cpf não pode ser nulo.");
                AssertionConcern.AssertArgumentNotEmpty(model.Email, "O Email não pode ser nulo");               
                AssertionConcern.AssertArgumentNotEmpty(model.Nome, "O Nome não pode ser nulo.");
                var obj = MontarObjeto(model);
                _participanteService.Insert(obj);
                response = Request.CreateResponse(HttpStatusCode.OK, "Cadastro efetuado com sucesso!");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        private static Participante MontarObjeto(ParticipanteModel participanteModel)
        {
            var obj = new Participante(participanteModel.Nome,
                participanteModel.BaseOperacional,
                participanteModel.Matricula,
                participanteModel.TamanhoCamiseta,
                participanteModel.Cpf,
                Convert.ToDateTime(participanteModel.DataNascimento),
                participanteModel.Sexo,
                participanteModel.Telefone,
                participanteModel.Email,
                participanteModel.RespostaP1,
                participanteModel.RespostaP2,
                participanteModel.RespostaP3);
            return obj;
        }

        protected override void Dispose(bool disposing)
        {
            _participanteService.Dispose();
        }

    }
}