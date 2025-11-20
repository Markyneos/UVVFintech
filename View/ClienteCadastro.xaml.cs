using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UvvFintech.Controller;

namespace UvvFintech.View
{
    /// <summary>
    /// Interação lógica para ClienteCadastro.xam
    /// </summary>
    public partial class ClienteCadastro : Page
    {
        public ClienteCadastro()
        {
            InitializeComponent();
            ((MainWindow)Application.Current.MainWindow).Width = 815;
            ((MainWindow)Application.Current.MainWindow).Height = 500;
            ((MainWindow)Application.Current.MainWindow).Title = "Cadastrar";
        }

        private string GetText()
        {
            return enderecoBox.Text;
        }

        private void cadastrarButton_Click(object sender, RoutedEventArgs e)
        {
            string nome = nomeBox.Text;
            string cpf = cpfBox.Text;
            var senha = senhaBox.Password;
            string telefone = telefoneBox.Text;
            string email = emailBox.Text;
            string rua = enderecoBox.Text.Split(',')[0];
            string numero = enderecoBox.Text.Split(',')[1];
            string bairro = bairroBox.Text;
            string cidade = cidadeBox.Text;

            if (
                string.IsNullOrEmpty(nome) ||
                string.IsNullOrEmpty(cpf) ||
                string.IsNullOrEmpty(senha) ||
                string.IsNullOrEmpty(telefone) ||
                string.IsNullOrEmpty(email) ||
                cpf.Any(char.IsLetter) ||
                cpf.Length != 11)
            {
                MessageBox.Show("Por favor preencha todos os dados necessários corretamente!",
                    "Erro com os dados",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else if (
                !string.IsNullOrEmpty(rua) &&
                !string.IsNullOrEmpty(numero) &&
                !string.IsNullOrEmpty(bairro) &&
                !string.IsNullOrEmpty(cidade))
            {
                var cc = new CadastrarCliente(nome, senha, cpf, telefone, email, rua, int.Parse(numero), bairro, cidade);
                bool valido = cc.InsertCliente();
                if (!valido)
                {
                    MessageBox.Show("Já existe um usuário com esse CPF. Por favor revisar suas credenciais.",
                        "CPF identificado",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(
                        "Cadastro Concluído!",
                        "Cadastro Concluído",
                        MessageBoxButton.OK,
                        MessageBoxImage.None);
                    ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteLogin());
                }
            }
            else
            {
                var cc = new CadastrarCliente(nome, senha, cpf, telefone, email);
                bool valido = cc.InsertCliente();
                if (!valido)
                {
                    MessageBox.Show("Já existe um usuário com esse CPF. Por favor revisar suas credenciais",
                        "CPF identificado",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(
                        "Cadastro Concluído!",
                        "Cadastro Concluído",
                        MessageBoxButton.OK,
                        MessageBoxImage.None);
                    ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteLogin());
                }
            }
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteLogin());
        }
    }
}
