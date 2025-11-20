using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UvvFintech.Model
{
    public class Cliente
    {
        public Cliente() { }

        private int _id;
        public int Id { get => _id; private set => _id = value; }
        private string _nome;
        public string Nome { get => _nome; private set => _nome = value; }
        private string _senha;
        public string Senha { get => _senha; private set => _senha = value; }
        private string _cpf;
        public string Cpf { get => _cpf; private set => _cpf = value; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        private string? _rua;
        private int? _numero;
        private string? _bairro;
        private string? _cidade;
        public string? Rua { get => _rua; private set => _rua = value; }
        public int? Numero { get => _numero; private set => _numero = value; }
        public string? Bairro { get => _bairro; private set => _bairro = value; }
        public string? Cidade { get => _cidade; private set => _cidade = value; }
        public enum TiposDeConta
        {
            Corrente,
            Poupanca
        }
        public List<Conta> Contas = new();

        public Cliente(string nome, string senha, string cpf, string telefone, string email)
        {
            _nome = nome;
            _senha = senha;
            _cpf = cpf;
            Telefone = telefone;
            Email = email;
        }
        public Cliente(string nome,
            string senha, 
            string cpf, 
            string telefone, 
            string email, 
            string rua, 
            int numero, 
            string bairro, 
            string cidade)
        {
            _nome = nome;
            _senha = senha;
            _cpf = cpf;
            Telefone = telefone;
            Email = email;
            _rua = rua;
            _numero = numero;
            _bairro = bairro;
            _cidade = cidade;
        }

        public void AdicionarConta(TiposDeConta tipo, string senha, double saldoInicial=0)
        {
            if (saldoInicial == 0)
            {
                if (tipo is TiposDeConta.Corrente)
                {
                    Contas.Add(new Corrente(senha, this));
                }
                else
                {
                    Contas.Add(new Poupanca(senha, this));
                }
            }
            else
            {
                if (tipo is TiposDeConta.Corrente)
                {
                    Contas.Add(new Corrente(senha, this, saldoInicial));
                }
                else
                {
                    Contas.Add(new Poupanca(senha, this, saldoInicial));
                }
            }
        }
        public bool RemoverConta(int idConta)
        {
            var conta = Contas.Find(c => c.Id == idConta);
            if (conta != null)
            {
                Contas.Remove(conta);
                return true;
            }
            return false;
        }

        }
    }
