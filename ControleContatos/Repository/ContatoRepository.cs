﻿using ControleContatos.Data;
using ControleContatos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ControleContatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ContatoContext _context;
        public ContatoRepository(ContatoContext context)
        {
            _context = context;         
        }
        public void Add(ContatoModel contato)
        {
            _context.Add(contato);
        }

        public List<ContatoModel> GetAllContatos()
        {
            return _context.Contatos.AsNoTracking().OrderBy(c => c.Nome).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
