using Corrida.Domain.Entity;

namespace Corrida.Domain.Contracts.Repositories
{
    public interface IParticipanteRepository
    {
        void Insert(Participante pObjeto);
        Participante GetCpf(string pCpf);
    }
}
