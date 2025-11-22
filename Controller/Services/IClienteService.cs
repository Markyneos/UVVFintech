using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Model;

namespace UvvFintech.Controller.Services
{
    public interface IClienteService
    {
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        void CriarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
        void RemoverCliente(int id);
    }
}
