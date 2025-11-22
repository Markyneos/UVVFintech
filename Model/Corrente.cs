using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvvFintech.Model
{
    public class Corrente : Conta
    {
        public Corrente() { }
        public Corrente(string senha, Cliente dono) : base(senha, dono)
        {
        }
        public Corrente(string senha, Cliente dono, double saldoInicial) : base(senha, dono, saldoInicial)
        {
        }

        public override Sacar Saque(double valor)
        {
            if (valor > _saldo)
            {
                return null;
            }
            else
            {
                _saldo -= valor;
                Sacar novoSaque = new(valor, this);
                Transacoes.Add(novoSaque);
                return novoSaque;
            }
        }
        public Transferencia Transferir(double valor, Conta destino, Transferencia.MetodoDePagamento metodo)
        {
            if (valor > _saldo)
            {
                return null;
            }
            else
            {
                _saldo -= valor;
                Transferencia novaTransferencia = new(valor, this, destino, metodo);
                destino.SomarSaldo(valor, novaTransferencia);
                Transacoes.Add(novaTransferencia);
                destino.Transacoes.Add(novaTransferencia);
                return novaTransferencia;
            }
        }
    }
}
