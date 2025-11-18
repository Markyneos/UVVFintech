using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvvFintech.Model
{
    public interface ITransacao
    {
        int Id { get; }
        double Valor { get; }
        Conta ContaRelacionada { get; }
        int ContaId { get; }
        DateTime DataHora { get; }

        public bool Autorizar();
        public string GerarComprovante();
        public bool Cancelar();
    }
}
