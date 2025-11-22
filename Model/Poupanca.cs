using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvvFintech.Model
{
    public class Poupanca : Conta
    {
        public Poupanca() { }
        protected static double taxaDeRendimento = 0.0055;
        public static double TaxaDeRendimento { get => taxaDeRendimento; private set => taxaDeRendimento = value; }
        protected static double taxaDeSaque = 0.012;
        public static double TaxaDeSaque { get => taxaDeSaque; private set => taxaDeSaque = value; }

        public Poupanca(string senha, Cliente dono) : base(senha, dono) {}
        public Poupanca(string senha, Cliente dono, double saldoInicial) : base(senha, dono, saldoInicial) {}

        public override Sacar Saque(double valor)
        {
            if ((valor * taxaDeSaque) + valor > _saldo)
            {
                return null;
            }
            else
            {
                _saldo -= (valor * taxaDeSaque) + valor;
                Sacar s = new(valor, this);
                Transacoes.Add(s);
                return s;
            }
        }
        public void AplicarRendimento()
        {
            _saldo += _saldo * taxaDeRendimento;
        }
    }
}
