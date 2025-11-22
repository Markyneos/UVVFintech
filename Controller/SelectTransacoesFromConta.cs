using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.Controller
{
    internal class SelectTransacoesFromConta
    {
        private Conta _conta;

        public SelectTransacoesFromConta(Conta c)
        {
            _conta = c;
        }

        public List<ITransacao> GetTransacoes()
        {
            using var context = new AppDbContext();
            context.Attach(_conta);
            List<ITransacao> transacoes = new List<ITransacao>();
            var saques = context.SacarS.ToList();
            var depositos = context.DepositarS.ToList();
            if (_conta is Corrente)
            {
                var transferencias = context.TransferenciaS.ToList();
                transacoes.AddRange(transferencias);
            }
            transacoes.AddRange(saques);
            transacoes.AddRange(depositos);
            var transacoesDaConta = transacoes.FindAll(t => t.ContaId == _conta.Id).OrderBy(t => t.Id).ToList();
            return transacoesDaConta;
        }
    }
}
