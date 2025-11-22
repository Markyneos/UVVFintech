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
    /// Interação lógica para TransacoesPoupanca.xam
    /// </summary>
    public partial class TransacoesPoupanca : Page
    {
        private Poupanca _conta;
        public TransacoesPoupanca(Poupanca p)
        {
            InitializeComponent();
            ((MainWindow)Application.Current.MainWindow).Title = "Transações Conta Poupança";
            _conta = p;
            SelectTransacoesFromConta sTFC = new(_conta);
            var transacoes = sTFC.GetTransacoes();
            dataGridTransacoes.ItemsSource = transacoes;
        }

        private void depositarButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new View.Depositar(_conta));
        }

        private void sacarButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new Sacar(_conta));
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            SelectClienteFromId sCFI = new(_conta.ClienteId);
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteContas(sCFI.GetCliente()));
        }

        private void aplicarRendimentoButton_Click(object sender, RoutedEventArgs e)
        {
            AplicarRendimento ap = new(_conta);
            ap.Aplicar();
            MessageBox.Show(
                "Rendimento aplicado com sucesso!",
                "Rendimento aplicado",
                MessageBoxButton.OK,
                MessageBoxImage.None);
        }
    }
}
