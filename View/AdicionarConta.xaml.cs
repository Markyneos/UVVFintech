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
using UvvFintech.Model;
using UvvFintech.Controller;

namespace UvvFintech.View
{
    /// <summary>
    /// Interação lógica para AdicionarConta.xam
    /// </summary>
    public partial class AdicionarConta : Page
    {
        private Cliente _cliente;
        public AdicionarConta(Cliente c)
        {
            InitializeComponent();
            ((MainWindow)Application.Current.MainWindow).Title = "Adicionar conta";
            _cliente = c;
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteContas(_cliente));
        }

        private void adicionarContaButton_Click(object sender, RoutedEventArgs e)
        {
            var selection = tipoDeContaBox.Text;
            if (string.IsNullOrEmpty(selection))
            {
                MessageBox.Show(
                    "Selecione um tipo de conta para prosseguir",
                    "Erro: Tipo de conta",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                CriarConta cc = new CriarConta(_cliente);
                string senha = senhaBox.Password;
                if (selection == "Conta Corrente")
                {
                    Corrente newConta = cc.CriarContaCorrente(senha);
                    MessageBox.Show(
                        $"Conta criada! O número dela é: {newConta.Numero}",
                        "Nova conta criada",
                        MessageBoxButton.OK,
                        MessageBoxImage.None);
                    ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteContas(_cliente));
                }
                else
                {
                    Poupanca newConta = cc.CriarContaPoupanca(senha);
                    MessageBox.Show(
                        $"Conta criada! O número dela é: {newConta.Numero}",
                        "Nova conta criada",
                        MessageBoxButton.OK,
                        MessageBoxImage.None);
                    ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteContas(_cliente));
                }
            }
        }
    }
}
