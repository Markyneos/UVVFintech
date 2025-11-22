using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.Controller
{
    internal class AdicionarDeposito
    {
        private Conta _conta;

        public AdicionarDeposito(Conta c)
        {
            _conta = c;
        }

        public Depositar Adicionar(double valor)
        {
            using var context = new AppDbContext();
            context.Attach(_conta);
            Depositar d = _conta.Deposito(valor);
            context.DepositarS.Add(d);
            context.SaveChanges();
            return d;
        }
    }
}
