using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.Controller
{
    internal class AdicionarTransferencia
    {
        private Corrente _conta;

        public AdicionarTransferencia(Corrente c)
        {
            _conta = c;
        }

        public bool Adicionar(double valor, string numeroDoReceptor, Transferencia.MetodoDePagamento metodo)
        {
            using var context = new AppDbContext();
            context.Attach(_conta);
            var contasCorrente = context.CorrenteS.ToList();
            if (contasCorrente.Exists(c => c.Numero == numeroDoReceptor) && valor <= _conta.Saldo)
            {
                var matchedConta = contasCorrente.Find(c => c.Numero == numeroDoReceptor);
                Transferencia t = _conta.Transferir(valor, matchedConta, metodo);
                context.TransferenciaS.Add(t);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
