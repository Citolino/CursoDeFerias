using DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Repository
{
    public interface IRepositoryAluno
    {
        List<AlunoDTO> GetAll();
        void deleteById(int id);
    }
}
