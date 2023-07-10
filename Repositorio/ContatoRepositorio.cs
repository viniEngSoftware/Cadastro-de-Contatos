using CadastroDeContatos.Data;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositorio;

public class ContatoRepositorio : IContatoRepositorio
{
    private readonly ContatoContext _context;

    public ContatoRepositorio(ContatoContext contatoContext)
    {
        _context = contatoContext;
    }

    public ContatoModel ListarPorId(int id)
    {
        return _context.Contatos.FirstOrDefault(contact => contact.Id == id);
    }

    public List<ContatoModel> Contatos()
    {
        return _context.Contatos.ToList();
    }
    public ContatoModel Adicionar(ContatoModel contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
        return contato;
    }

    public ContatoModel Atualizar(ContatoModel contato)
    {
        ContatoModel contatoDb = ListarPorId(contato.Id);

        if (contatoDb == null) throw new Exception("Não existe um usuario com esse Id");

        contatoDb.Nome = contato.Nome;
        contatoDb.Email = contato.Email;
        contatoDb.Celular = contato.Celular;

        _context.Update(contatoDb);
        _context.SaveChanges();
        return contatoDb;
    }

    public bool Apagar(int id)
    {
        ContatoModel contatoDb = ListarPorId(id);

        if (contatoDb == null) throw new Exception("Não existe um usuario com esse Id");

        _context.Remove(contatoDb);
        _context.SaveChanges();

        return true;
    }
}
