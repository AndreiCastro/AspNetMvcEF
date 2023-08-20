using ControleContatos.Models;
using System.Collections.Generic;

namespace ControleContatos.Repository
{
    public interface IContatoRepository
    {
        void Add(ContatoModel contato);

        void Update(ContatoModel contato);

        bool SaveChanges();

        void Delete(ContatoModel contato);

        List<ContatoModel> GetAllContatos();

        ContatoModel GetContato(int id);
    }
}
