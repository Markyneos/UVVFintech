using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.View;
using UvvFintech.Model;
using UvvFintech.Data;
using System.Windows;

namespace UvvFintech.Controller
{
    internal class CadastrarCliente
    {
        private Cliente cliente;
        public CadastrarCliente(string nome, string senha, string cpf, string telefone, string email)
        {
            cliente = new Cliente(nome, senha, cpf, telefone, email);
        }
        public CadastrarCliente(
            string nome, 
            string senha, 
            string cpf, 
            string telefone, 
            string email, 
            string rua, 
            int numero, 
            string bairro, 
            string cidade)
        {
            cliente = new Cliente(nome, senha, cpf, telefone, email, rua, numero, bairro, cidade);
        }

        public bool InsertCliente()
        {
            using var context = new AppDbContext();
            var clientes = context.ClienteS.ToList();
            try
            {
                var clienteMatched = clientes.First(c => c.Cpf == cliente.Cpf);
            }
            catch (Exception e)
            {
                context.ClienteS.Add(cliente);
                context.SaveChanges();
                return true;
            }
            MessageBox.Show("Já existe um usuário com esse cpf. Por favor revisar suas credenciais",
                "CPF identificado",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return false;
        }
    }
}
