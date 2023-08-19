using ControleContatos.Models;
using System.Collections.Generic;

namespace ControleContatos.Repository
{
    public interface IContatoRepository
    {
        void Add(ContatoModel contato);

        void Update(ContatoModel contato);

        bool SaveChanges();

        List<ContatoModel> GetAllContatos();

        ContatoModel GetContato(int id);
    }
}
