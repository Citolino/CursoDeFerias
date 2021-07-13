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
    }
}
