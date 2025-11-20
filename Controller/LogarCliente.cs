using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Model;
using UvvFintech.Data;

namespace UvvFintech.Controller
{
    internal class LogarCliente
    {
        private string _cpf;
        private string _senha;

        public LogarCliente( string cpf, string senha)
        {
            _cpf = cpf;
            _senha = senha;
        }

        public bool Logar()
        {
                using var context = new AppDbContext();

                var clientes = context.ClienteS.ToList();
                var matchingCliente = clientes.Find(c => c.Cpf == _cpf && c.Senha == _senha);
                if (matchingCliente is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }

