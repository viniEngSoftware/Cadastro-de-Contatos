﻿using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositorio;

public interface IContatoRepositorio
{
    ContatoModel ListarPorId(int id);
    List<ContatoModel> Contatos();
    ContatoModel Adicionar(ContatoModel contato);
    ContatoModel Atualizar(ContatoModel contato);
    bool Apagar(int id);
}
