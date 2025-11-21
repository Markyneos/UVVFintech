using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.Controller
{
    internal class DeletarConta
    {
        private Cliente _cliente;

        public DeletarConta(Cliente c)
        {
            _cliente = c;
        }

        public bool Deletar(string numero, string senha)
        {
            using var context = new AppDbContext();
            context.Attach(_cliente);
            List<Conta> contas = new();
            var contasCorrente = context.CorrenteS.ToList();
            var contasPoupanca = context.PoupancaS.ToList();
            var matchedCorrente = contasCorrente.FindAll(c => c.ClienteId == _cliente.Id) ?? new List<Corrente>();
            var matchedPoupanca = contasPoupanca.FindAll(p => p.ClienteId == _cliente.Id) ?? new List<Poupanca>();
            contas.AddRange(matchedCorrente);
            contas.AddRange(matchedPoupanca);
            try
            {
                var matchedConta = contas.First(c => c.Numero == numero && c.Senha == senha);
                _cliente.Contas.Remove(_cliente.Contas.First(c => c.Numero == numero && c.Senha == senha));
                if (matchedConta is Corrente c)
                {
                    context.CorrenteS.Remove(c);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    Poupanca p = (Poupanca)matchedConta;
                    context.PoupancaS.Remove(p);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
