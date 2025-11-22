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
    /// Interação lógica para TransacoesCorrente.xam
    /// </summary>
    public partial class TransacoesCorrente : Page
    {
        private Corrente _conta;
        public TransacoesCorrente(Corrente c)
        {
            InitializeComponent();
            ((MainWindow)Application.Current.MainWindow).Title = "Transações Conta Corrente";
            _conta = c;
            SelectTransacoesFromConta sTFC = new(_conta);
            var transacoes = sTFC.GetTransacoes();
            var transacoesTratadas = transacoes
                .Select(transacao => new
                {
                    transacao.Id,
                    Tipo = transacao.GetType().Name,
                    transacao.Valor,
                    transacao.DataHora,
                    transacao.ContaId,
                    Destinatario = transacao is Model.Transferencia transf ? transf.ContaDestinoId.ToString() : "",
                    Metodo = transacao is Model.Transferencia t ? t.Metodo.ToString() : ""
                }).ToList();
            dataGridTransacoes.ItemsSource = transacoesTratadas;
        }

        private void depositarButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new View.Depositar(_conta));
        }

        private void transferenciaButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new Transferencia(_conta));
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
    }
}
