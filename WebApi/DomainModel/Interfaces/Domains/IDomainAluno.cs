using DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Domains
{
    public interface IDomainAluno
    {

        List<AlunoDTO> GetAll();

        void deleteById(int id);

        void salvarAluno(AlunoDTO aluno);

        AlunoDTO GetById(int Id);

        void AlterarAluno(AlunoDTO aluno);
    }
}
