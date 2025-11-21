using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Model;
using UvvFintech.Data;

namespace UvvFintech.Controller
{
    internal class SelectContasFromCliente
    {
        private Cliente _cliente;
        public SelectContasFromCliente(Cliente c)
        {
            _cliente = c;
        }

        public List<Conta> GetContas()
        {
            using var context = new AppDbContext();
            context.Attach(_cliente);
            List<Conta> contas = new List<Conta>();
            var contasCorrente = context.CorrenteS.ToList();
            var contasPoupanca = context.PoupancaS.ToList();
            var matchedCorrente = contasCorrente.FindAll(c => c.ClienteId == _cliente.Id) ?? new List<Corrente>();
            var matchedPoupanca = contasPoupanca.FindAll(p => p.ClienteId == _cliente.Id) ?? new List<Poupanca>();
            contas.AddRange(matchedCorrente);
            contas.AddRange(matchedPoupanca);
            var contasOrdenadas = contas.OrderBy(c => c.Id).ToList();
            if (!_cliente.Contas.Any())
            {
                _cliente.Contas.AddRange(contasOrdenadas);
            }
            return contasOrdenadas;
        }
    }
}
