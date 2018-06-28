using Corrida.Domain.Entity;
using System;

namespace Corrida.Domain.Contracts.Services
{
    public interface IParticipanteService : IDisposable
    {
        void Insert(Participante pObjeto);
        Participante GetCpf(string pCpf);
    }
}
