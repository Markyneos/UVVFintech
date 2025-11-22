using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.Controller
{
    public class AdicionarSaque
    {
        private Conta _conta;

        public AdicionarSaque(Conta c)
        {
            _conta = c;
        }

        public bool ValidarSaque(double valor)
        {
            if (_conta is Corrente c)
            {
                return c.Saldo > valor;
            }
            else
            {
                Poupanca p = (Poupanca)_conta;
                return p.Saldo > (valor * Poupanca.TaxaDeSaque) + valor;
            }
        }
        public Sacar Adicionar(double valor)
        {
            using var context = new AppDbContext();
            context.Attach(_conta);
            Sacar s = _conta.Saque(valor);
            context.SacarS.Add(s);
            context.SaveChanges();
            return s;
        }
    }
}
