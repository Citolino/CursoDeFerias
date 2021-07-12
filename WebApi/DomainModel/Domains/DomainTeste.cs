using DomainModel.Interfaces.Domains;
using DomainModel.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domains
{
    public class DomainTeste : IDomainTeste
    {
        private readonly IRepositoryTeste _repoTeste;

        public DomainTeste(IRepositoryTeste repoTeste)
        {
            _repoTeste = repoTeste;
        }
        public string GetTeste()
        {
            return _repoTeste.GetTeste();
        }
    }
}
