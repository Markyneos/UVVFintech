using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.Controller
{
    internal class AplicarRendimento : ITransacaoInterna
    {
        private Poupanca _conta;

        public AplicarRendimento(Poupanca p)
        {
            _conta = p;
        }

        public void Aplicar()
        {
            using var context = new AppDbContext();
            context.Attach(_conta);
            var contasPoupanca = context.PoupancaS.ToList();
            if (contasPoupanca.Exists(p => p.Id == _conta.Id)) 
            {
                var matchedConta = context.PoupancaS.Find(_conta.Id);
                matchedConta.SomarSaldo(_conta.Saldo * Poupanca.TaxaDeRendimento, this);
                context.SaveChanges();
            }
        }
    }
}
