using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvvFintech.Model
{
    public abstract class Conta
    {
        public Conta() {}

        private Random rand = new();
        protected int _id;
        public int Id { get => _id; private set => _id = value; }
        protected string _numero;
        public string Numero { get => _numero; private set => _numero = value; }
        protected string _senha;
        public string Senha { get => _senha; set => _senha = value; }
        protected double _saldo;
        public double Saldo { get => _saldo; private set => _saldo = value; }
        public Cliente Dono { get; private set; }
        public int ClienteId { get; private set; }
        public List<ITransacao> Transacoes = new List<ITransacao>();
        protected double _limiteSaque;
        public double LimiteSaque { get => _limiteSaque; private set => _limiteSaque = value; }

        public Conta(string senha, Cliente dono)
        {
            _numero = rand.Next(10000, 100000).ToString();
            _senha = senha;
            _saldo = 0;
            Dono = dono;
            ClienteId = Dono.Id;
        }
        public Conta(string senha, Cliente dono, double saldoInicial)
        {
            _numero = rand.Next(10000, 100000).ToString();
            _senha = senha;
            _saldo = 0;
            Dono = dono;
            _saldo = saldoInicial;
            _limiteSaque = saldoInicial * 0.50;
            ClienteId = Dono.Id;
        }


        public abstract bool Sacar(double valor);
        public void Depositar(double valor)
        {
            _saldo += valor;
            Transacoes.Add(new Depositar(valor, this));
        }
         public bool CancelarTransacao(ITransacao transacao)
        {
            return transacao.Cancelar();
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
        internal void SomarSaldo(double valor, ITransacaoInterna origem)
        {
            _saldo += valor;
        }
        internal void SubtrairSaldo(double valor, ITransacaoInterna origem)
        {
            _saldo -= valor;
        }

    }
}
