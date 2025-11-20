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
using UvvFintech.Data;

namespace UvvFintech.View
{
    /// <summary>
    /// Interação lógica para LoginFrame.xam
    /// </summary>
    public partial class ClienteLogin : Page
    {
        public ClienteLogin()
        {
            InitializeComponent();
        }
        private void logarButton_Click(object sender, RoutedEventArgs e)
        {
            string cpf = cpfTextBox.Text;
            var senha = senhaPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha) || cpf.Any(char.IsLetter) || cpf.Length != 11)
            {
                MessageBox.Show(
                    "Você deve preencher todos os campos corretamente antes de prosseguir!",
                    "Aviso",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            else
            {
                using var context = new AppDbContext();

                var clientes = context.ClienteS.ToList();
                var matchingCliente = clientes.Find(c => c.Cpf == cpf && c.Senha == senha);
                if (matchingCliente is null)
                {
                    MessageBox.Show(
                        "Não foi encontrado nenhuma conta de cliente com essas credenciais.",
                        "Cliente não encontrado",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(
                        "Teste passou!!",
                        "Teste passou",
                        MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                }
            }
        }
    }
}
