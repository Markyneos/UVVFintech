using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.Controller
{
    internal class CriarConta
    {
        private Cliente _cliente;

        public CriarConta(Cliente cliente)
        {
            _cliente = cliente;
        }

        public Corrente CriarContaCorrente(string senha)
        {
            using var context = new AppDbContext();
            Corrente c = _cliente.AdicionarContaCorrente(senha);
            context.Attach(_cliente);
            context.CorrenteS.Add(c);
            context.SaveChanges();
            return c;
        }
        public Poupanca CriarContaPoupanca(string senha)
        {
            using var context = new AppDbContext();
            Poupanca p = _cliente.AdicionarContaPoupanca(senha);
            context.Attach(_cliente);
            context.PoupancaS.Add(p);
            context.SaveChanges();
            return p;
        }
    }
}
