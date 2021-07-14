using DomainModel.Interfaces.Domains;
using DomainModel.Interfaces.Repository;
using DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domains
{
    public class DomainAluno : IDomainAluno
    {
        private readonly IRepositoryAluno _repoAluno;
        public DomainAluno(IRepositoryAluno repoAluno)
        {
            _repoAluno = repoAluno;
        }

        public void AlterarAluno(AlunoDTO aluno)
        {
            _repoAluno.AlterarAluno(aluno);
        }

        public void deleteById(int id)
        {
            _repoAluno.deleteById(id);
        }

        public List<AlunoDTO> GetAll()
        {
            return _repoAluno.GetAll();
        }

        public AlunoDTO GetById(int Id)
        {
            return _repoAluno.GetById(Id);
        }

        public void salvarAluno(AlunoDTO aluno)
        {
            _repoAluno.salvarAluno(aluno);
        }
    }
}
