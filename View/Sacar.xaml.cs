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
using UvvFintech.Model;

namespace UvvFintech.View
{
    /// <summary>
    /// Interação lógica para Sacar.xam
    /// </summary>
    public partial class Sacar : Page
    {
        private Conta _conta;
        public Sacar(Conta c)
        {
            ((MainWindow)Application.Current.MainWindow).Title = "Sacar";
            InitializeComponent();
            _conta = c;
        }


        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            if (_conta is Corrente c)
            {
                ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new TransacoesCorrente(c));
            }
            else
            {
                Poupanca p = (Poupanca)_conta;
                ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new TransacoesPoupanca(p));
            }
        }

        private void prosseguirButton_Click(object sender, RoutedEventArgs e)
        {
            string valor = valorBox.Text;
            if (string.IsNullOrEmpty(valor) || valor == "R$ 0,00")
            {
                MessageBox.Show(
                    "Insira um valor válido para prosseguir!",
                    "Nenhum valor inserido",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            else
            {
                double valorDouble = decimal.ToDouble(valorBox.Number);
                AdicionarSaque aS = new(_conta);
                if (aS.ValidarSaque(valorDouble))
                {
                    var novoSaque = aS.Adicionar(valorDouble);
                    MessageBox.Show(
                        $"Novo saque de R${valorDouble} realizado com sucesso!",
                        "Saque concluído",
                        MessageBoxButton.OK,
                        MessageBoxImage.None);
                    if (_conta is Corrente c)
                    {
                        ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new TransacoesCorrente(c));
                    }
                    else
                    {
                        Poupanca p = (Poupanca)_conta;
                        ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new TransacoesPoupanca(p));
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Erro: Você só pode sacar uma quantia que você tem disponível no seu saldo.",
                        "Saldo insuficiente",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
            }
       }
    }
}
