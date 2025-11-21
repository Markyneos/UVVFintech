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

        public Corrente CriarContaCorrente(string senha, int donoId)
        {
            using var context = new AppDbContext();
            Corrente c = new Corrente(senha, dono);
            context.CorrenteS.Add(c);
            context.SaveChanges();
            return c;
        }
        public Poupanca CriarContaPoupanca(string senha, Cliente dono)
        {
            using var context = new AppDbContext();
            Poupanca c = new Poupanca(senha, dono);
            context.PoupancaS.Add(c);
            context.SaveChanges();
            return c;
        }
    }
}
