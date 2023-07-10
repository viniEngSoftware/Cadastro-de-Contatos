using CadastroDeContatos.Models;
using CadastroDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.Contatos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id) 
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["mensagemSucesso"] = "Contato Apagado com Sucesso!";
                }
                else
                {
                    TempData["mensagemErro"] = "Não foi possivel apagar";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["mensagemErro"] = $"Não foi possivel apagar, Erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["mensagemSucesso"] = "Contato cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }   
            catch (Exception erro)
            {
                TempData["mensagemErro"] = $"Não foi possivel fazer o cadastro, Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["mensagemSucesso"] = "Contato Alterado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["mensagemErro"] = $"Não foi possivel fazer a alteração, Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
