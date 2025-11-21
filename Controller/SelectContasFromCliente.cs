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
            List<Conta> contas = new List<Conta>();
            var contasCorrente = context.CorrenteS.ToList();
            var contasPoupanca = context.PoupancaS.ToList();
            contas.AddRange(contasCorrente);
            contas.AddRange(contasPoupanca);
            return contas;
        }
      //  public Conta GetContaFromId(int id)
      //  {
      //      using var context = new AppDbContext();
      //      try
      //      {
      //          var correnteMatched = context.CorrenteS.First(c => c.Id == id);
      //          var poupancaMatched = context.PoupancaS.First(p => p.Id == id);
      //          var contas = new List<Conta>();
      //          contas.AddRange(correnteMatched);
      //          contas.AddRange(poupancaMatched);

      //      }
      //      catch (Exception e)
      //      {
      //      }
      //  }
    }
}
