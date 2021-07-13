using DomainModel.Interfaces.Repository;
using DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Repository.Repositories
{
    public class RepositoryAluno : IRepositoryAluno
    {
        private readonly Context.Context _context;
        public RepositoryAluno(Context.Context context)
        {
            _context = context;

        }

        public void deleteById(int id)
        {
            using (var scope = new TransactionScope())
            {

                var aluno = _context.Aluno.Find(id);
                _context.Aluno.Remove(aluno);
                _context.SaveChanges();
                scope.Complete();
            }
            
        }

        public List<AlunoDTO> GetAll()
        {
            using (var scope = new TransactionScope())
            {
                var alunos = _context.Aluno.ToList();
                // _context.Update(teste);
                return alunos;
            }
        }
    }
}
