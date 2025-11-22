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
    /// Interação lógica para Depositar.xam
    /// </summary>
    public partial class Depositar : Page
    {
        private Conta _conta;
        public Depositar(Conta c)
        {
            ((MainWindow)Application.Current.MainWindow).Title = "Depositar";
            InitializeComponent();
            _conta = c;
        }

        private void prosseguirButton_Click(object sender, RoutedEventArgs e)
        {
            string valor = valorBox.Text;
            if (string.IsNullOrEmpty(valor) || valor == "R$ 0,00")
            {
                MessageBox.Show(
                    "Insira um valor para prosseguir!",
                    "Nenhum valor inserido",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                double valorDouble = decimal.ToDouble(valorBox.Number);
                AdicionarDeposito ad = new(_conta);
                var novoDeposito = ad.Adicionar(valorDouble);
                MessageBox.Show(
                    $"Depósito de R${valorDouble} realizado com sucesso!",
                    "Depósito concluído",
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
    }
}
