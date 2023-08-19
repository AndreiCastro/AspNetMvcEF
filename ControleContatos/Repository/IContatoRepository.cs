using ControleContatos.Models;
using System.Collections.Generic;

namespace ControleContatos.Repository
{
    public interface IContatoRepository
    {
        void Add(ContatoModel contato);

        bool SaveChanges();

        List<ContatoModel> GetAllContatos();
    }
}
