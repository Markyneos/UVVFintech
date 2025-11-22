using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Model;
using UvvFintech.Data.Repositories;
using UvvFintech.Data.Migrations;

namespace UvvFintech.Controller.Services
{
    internal class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            if (string.IsNullOrWhiteSpace(cliente.Nome)) throw new ArgumentException("Nome inválido");
            if (string.IsNullOrWhiteSpace(cliente.Cpf) || cliente.Cpf.Length != 11) throw new ArgumentException("CPF inválido");
            if (string.IsNullOrWhiteSpace(cliente.Telefone) || cliente.Telefone.Length != 11) throw new ArgumentException("Telefone inválido");

            _repo.Update(cliente);
        }
        public void CriarCliente(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            if (string.IsNullOrWhiteSpace(cliente.Nome)) throw new ArgumentException("Nome inválido");
            if (string.IsNullOrWhiteSpace(cliente.Cpf) || cliente.Cpf.Length != 11) throw new ArgumentException("CPF inválido");
            if (string.IsNullOrWhiteSpace(cliente.Telefone) || cliente.Telefone.Length != 11) throw new ArgumentException("Telefone inválido");

            _repo.Add(cliente);
        }
        public IEnumerable<Cliente> ObterTodos()
        {
            return _repo.GetAll();
        }
        public Cliente ObterPorId(int id)
        {
            return _repo.GetById(id);
        }
        public void RemoverCliente(int id)
        {
            _repo.Delete(id);
        }
    }
}
