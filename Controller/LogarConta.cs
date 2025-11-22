using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.Controller
{
    internal class LogarConta
    {
        private Cliente _cliente;

        public LogarConta(Cliente c)
        {
            _cliente = c;
        }

        public bool ValidarLogin(string numero, string senha)
        {
            using var context = new AppDbContext();
            context.Attach(_cliente);
            List<Conta> contas = new();
            var contasCorrente = context.CorrenteS.ToList();
            var contasPoupanca = context.PoupancaS.ToList();
            contas.AddRange(contasPoupanca);
            contas.AddRange(contasCorrente);
            try
            {
                var matchedConta = contas.First(c => c.Numero == numero && c.Senha == senha && c.ClienteId == _cliente.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Conta GetConta(string numero, string senha)
        {
            using var context = new AppDbContext();
            context.Attach(_cliente);
            List<Conta> contas = new();
            var contasCorrente = context.CorrenteS.ToList();
            var contasPoupanca = context.PoupancaS.ToList();
            contas.AddRange(contasPoupanca);
            contas.AddRange(contasCorrente);
            var matchedConta = contas.First(c => c.Numero == numero && c.Senha == senha && c.ClienteId == _cliente.Id);
            return matchedConta;
        }
    }
}
