using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvvFintech.Model
{
    public abstract class Conta
    {
        private Random rand = new();
        protected int _id;
        public int Id { get => _id; }
        protected string _numero;
        public string Numero { get => _numero; }
        protected string _senha;
        public string Senha { get => _senha; set { _senha = value; } }
        protected double _saldo;
        public double Saldo { get => _saldo; }
        public Cliente Dono { get; set; }
        public List<ITransacao> Transacoes = new List<ITransacao>();
        protected double _limiteSaque;
        public double LimiteSaque { get => _limiteSaque; }

        public Conta(string senha, Cliente dono)
        {
            _numero = rand.Next(10000, 100000).ToString();
            _senha = senha;
            _saldo = 0;
            Dono = dono;
        }
        public Conta(string senha, Cliente dono, double saldoInicial)
        {
            _numero = rand.Next(10000, 100000).ToString();
            _senha = senha;
            _saldo = 0;
            Dono = dono;
            _saldo = saldoInicial;
            _limiteSaque = saldoInicial * 0.50;
        }


        public abstract bool Sacar(double valor);
        public void Depositar(double valor)
        {
            _saldo += valor;
            Transacoes.Add(new Depositar(valor, this));
        }
        public bool CancelarTransacao(ITransacao transacao)
        {
            if (transacao is Transferencia transferencia)
            {
                var conta2 = transferencia.ContaRelacionada2;
                if (conta2.Transacoes.Contains(transacao))
                {
                    conta2.Transacoes.Remove(transacao);
                }
            }
            if (Transacoes.Contains(transacao))
            {
                Transacoes.Remove(transacao);
                return true;
            }
            return false;
        }
        public bool AumentarLimite(double valor)
        {
            if (valor > _saldo + _limiteSaque)
            {
                return false;
            }
            else
            {
                _limiteSaque = valor;
                return true;
            }
        }

    }
}
