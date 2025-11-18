using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvvFintech.Model
{
    public class Transferencia : ITransacao, ITransacaoInterna
    {
        public Transferencia() { }

        private int _id;
        public int Id { get => _id; private set => _id = value; }
        private double _valor;
        public double Valor { get => _valor; private set => _valor = value; }
        private Conta _contaRelacionada;
        public Conta ContaRelacionada { get => _contaRelacionada; private set => _contaRelacionada = value; }
        public int ContaId { get; private set; }
        private Conta _contaDestino;
        public Conta ContaDestino { get => _contaDestino; private set => _contaDestino = value; }
        public int ContaDestinoId { get; private set; }
        private DateTime _dataHora;
        public DateTime DataHora { get => _dataHora; private set => _dataHora = value; }
        public enum MetodoDePagamento
        {
           Pix,
           Credito,
           Debito,
           Boleto
        }
        private MetodoDePagamento _metodo;
        public MetodoDePagamento Metodo { get => _metodo; }

        public bool Autorizar()
        {
            return ContaRelacionada.Transacoes.Contains(this) && ContaDestino.Transacoes.Contains(this);
        }
        public string GerarComprovante()
        {
            return $"Id: {Id}\nValor: {Valor}\nConta Relacionada 1: {ContaRelacionada}\nConta Relacionada 2: {ContaDestino}\nData/Hora: {DataHora}\nMétodo de Pagamento: {Metodo}";
        }
        public Transferencia(double valor, Conta conta1, Conta conta2, MetodoDePagamento metodo)
        {
            _valor = valor;
            _contaRelacionada = conta1;
            _contaDestino = conta2;
            _metodo = metodo;
            _dataHora = DateTime.Now;
            ContaId = ContaRelacionada.Id;
            ContaDestinoId = ContaDestino.Id;
        }
        public bool Cancelar()
        {
            if (ContaRelacionada.Transacoes.Contains(this) && ContaDestino.Transacoes.Contains(this))
            {
                _contaRelacionada.Transacoes.Remove(this);
                _contaDestino.Transacoes.Remove(this);
                _contaRelacionada.SomarSaldo(Valor, this);
                _contaDestino.SubtrairSaldo(Valor, this);
                return true;
            }
            return false;
        }
    }
}
