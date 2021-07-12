using DomainModel.Interfaces.Repository;
using DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Repository.Repositories
{
    public class RepositoryTeste : IRepositoryTeste
    {
        private readonly Context.Context _context;

        public RepositoryTeste(Context.Context context)
        {
            _context = context;
        }
        public string GetTeste()
        {
            using (var scope = new TransactionScope())
            {
                var teste = _context.TesteDTO.Where(l => l.id == 1).FirstOrDefault();
                // _context.Update(teste);
                return teste.descricao;
            }
        }
    }
}
