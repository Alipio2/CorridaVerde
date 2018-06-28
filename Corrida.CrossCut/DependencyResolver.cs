using Corrida.Domain.Contracts.Repositories;
using Corrida.Domain.Contracts.Services;
using Corrida.Infra;
using Corrida.Service.Service;
using Microsoft.Practices.Unity;

namespace Corrida.CrossCut
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<IParticipanteRepository, ParticipanteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IParticipanteService, ParticipanteService>(new HierarchicalLifetimeManager());
        }
    }
}
