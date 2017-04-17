using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoExemplo01.Models
{
    public interface IPessoaRepository
    {
        IQueryable<Pessoa> Pessoas { get; }
        Pessoa Create(Pessoa pessoa);
        Pessoa Details(int? id);
        Pessoa Edit(int? id);
        void Edit(Pessoa pessoa);
        Pessoa Delete(int? id);
        void ConfirmDelete(int id);
    }
}
