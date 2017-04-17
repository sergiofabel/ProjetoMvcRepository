using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;

namespace ProjetoExemplo01.Models
{
    public class EFPessoaRepository : IPessoaRepository
    {
        PesContext context = new PesContext();

        /// <summary>
        /// Coleção de Pessoas
        /// </summary>
        public IQueryable<Pessoa> Pessoas
        {
            get { return context.Pessoa; }
        }

        /// <summary>
        /// Metodo que cria uma Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public Pessoa Create(Pessoa pessoa)
        {
            if (pessoa.PessoaId == 0)    
            {
                context.Pessoa.Add(pessoa);
            }
            else
            {
                context.Entry(pessoa).State = EntityState.Modified;
            }
            context.SaveChanges();
            return pessoa;
        }

        /// <summary>
        /// Metodo que recebe um id e manda a Pessoa com o 
        /// mesmo id para uma outra View para Editação.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pessoa Edit(int? id)
        {
            
            Pessoa pessoa = context.Pessoa.Find(id);
            return pessoa;
        }

        /// <summary>
        /// Metodo que edita uma pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        public void Edit(Pessoa pessoa)
        {
            context.Entry(pessoa).State = EntityState.Modified;
            context.SaveChanges();

        }

        /// <summary>
        /// Metodo que recebe um id e manda a Pessoa com o 
        /// mesmo id para uma outra View para confirmação se deseja deletar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pessoa Delete(int? id)
        {
            Pessoa pessoa = context.Pessoa.Find(id);       
            return pessoa;
        }

        /// <summary>
        /// Metodo que deleta Pessoa com id indicado
        /// </summary>
        /// <param name="id"></param>
        public void ConfirmDelete(int id)
        {
            Pessoa pessoa = context.Pessoa.Find(id);
            context.Pessoa.Remove(pessoa);
            context.SaveChanges();
        }

        /// <summary>
        /// Metodo que detalha a Pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pessoa Details(int? id)
        {
            Pessoa pessoa = context.Pessoa.Find(id);            
            return pessoa;
        }

    }
}