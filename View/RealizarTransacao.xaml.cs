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
    /// Interação lógica para RealizarTransacao.xam
    /// </summary>
    public partial class RealizarTransacao : Page
    {
        private Cliente _cliente;
        public RealizarTransacao(Cliente c)
        {
            InitializeComponent();
            _cliente = c;
            ((MainWindow)Application.Current.MainWindow).Title = "Realizar Transação";
        }

        private void prosseguirButton_Click(object sender, RoutedEventArgs e)
        {
            string numeroDaConta = numeroContaBox.Text;
            var senhaConta = senhaContaBox.Password;
            if (string.IsNullOrEmpty(numeroDaConta) || string.IsNullOrEmpty(senhaConta))
            {
                MessageBox.Show(
                    "Insira todos os dados corretamente!",
                    "Inconsistência de dados",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                LogarConta lc = new(_cliente);
                if (lc.ValidarLogin(numeroDaConta, senhaConta))
                {
                    var contaLogin = lc.GetConta(numeroDaConta, senhaConta);
                    if (contaLogin is Corrente c)
                    {
                        ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new TransacoesCorrente(c));
                    }
                    else
                    {
                        Poupanca p = (Poupanca)contaLogin;
                        ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new TransacoesPoupanca(p));
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Não foi encontrada nenhuma conta com esses dados. Por favor, verifique-os e tente novamente",
                        "Conta não encontrada",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteContas(_cliente));
        }
    }
}
