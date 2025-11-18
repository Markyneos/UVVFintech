using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvvFintech.Model
{
    public class Depositar : ITransacao, ITransacaoInterna
    {
        public Depositar() { }

        private int _id;
        public int Id { get => _id; private set => _id = value; }

        private double _valor;
        public double Valor { get => _valor; private set => _valor = value; }

        private Conta _contaRelacionada;
        public Conta ContaRelacionada { get => _contaRelacionada; private set => _contaRelacionada = value; }
        public int ContaId { get; private set; }

        private DateTime _dataHora;
        public DateTime DataHora { get => _dataHora; private set => _dataHora = value; }

        public Depositar(double valor, Conta conta)
        {
            _valor = valor;
            _contaRelacionada = conta;
            _dataHora = DateTime.Now;
            ContaId = ContaRelacionada.Id;
        }

        public bool Autorizar()
        {
            return ContaRelacionada.Transacoes.Contains(this);
        }

        public string GerarComprovante()
        {
            return $"Id: {Id}\nValor: {Valor}\nConta Relacionada: {ContaRelacionada}\nData/Hora: {DataHora}";
        }
        public bool Cancelar()
        {
            if (_contaRelacionada.Transacoes.Contains(this))
            {
                _contaRelacionada.Transacoes.Remove(this);
                _contaRelacionada.SubtrairSaldo(Valor, this);
                return true;
            }
            return false;
        }
    }
}
