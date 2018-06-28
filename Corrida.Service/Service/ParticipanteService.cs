using Corrida.Domain.Contracts.Repositories;
using Corrida.Domain.Contracts.Services;
using Corrida.Domain.Entity;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace Corrida.Service.Service
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IParticipanteRepository _repository;
        private bool _disposed = false;
        readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        public ParticipanteService(IParticipanteRepository repository)
        {
            _repository = repository;
        }

        public void Insert(Participante pObjeto)
        {
            _repository.Insert(pObjeto);
        }

        public Participante GetCpf(string pCpf)
        {
          return  _repository.GetCpf(pCpf);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _handle.Dispose();

            _disposed = true;
        }
       
    }
}
