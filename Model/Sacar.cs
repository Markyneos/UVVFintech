using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvvFintech.Model
{
    public class Sacar : ITransacao
    {
        private int _id;
        public int Id { get => _id; }

        private double _valor;
        public double Valor { get => _valor; }

        private Conta _contaRelacionada;
        public Conta ContaRelacionada { get => _contaRelacionada; }

        private DateTime _dataHora;
        public DateTime DataHora { get => _dataHora; }


        public Sacar(double valor, Conta conta)
        {
            _valor = valor;
            _contaRelacionada = conta;
            _dataHora = DateTime.Now;

        }

        public bool Autorizar()
        {
            return ContaRelacionada.Transacoes.Contains(this);
        }

        public string GerarComprovante()
        {
            return $"Id: {Id}\nValor: {Valor}\nConta Relacionada: {ContaRelacionada}\nData/Hora: {DataHora}";
        }
    }

    }
