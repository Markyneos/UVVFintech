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
    /// Interação lógica para Transferencia.xam
    /// </summary>
    public partial class Transferencia : Page
    {
        private Corrente _conta;
        public Transferencia(Corrente c)
        {
            InitializeComponent();
            _conta = c;
            ((MainWindow)Application.Current.MainWindow).Title = "Transferência";
        }

        private void prosseguirButton_Click(object sender, RoutedEventArgs e)
        {
            string valor = valorBox.Text;
            string numeroContaDestino = numeroContaBox.Text;
            Model.Transferencia.MetodoDePagamento metodoDePagamento;

            if (numeroContaDestino == _conta.Numero)
            {
                MessageBox.Show(
                    "Erro: Não pode realizar uma transferência pra mesma conta.",
                    "Transferência entre mesma conta",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(metodosComboBox.Text))
            {
                MessageBox.Show(
                    "Escolha um método de pagamento!",
                    "Escolher método",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            switch (metodosComboBox.Text)
            {
                case "Credito":
                    metodoDePagamento = Model.Transferencia.MetodoDePagamento.Credito;
                    break;
                case "Debito":
                    metodoDePagamento = Model.Transferencia.MetodoDePagamento.Debito;
                    break;
                case "Boleto":
                    metodoDePagamento = Model.Transferencia.MetodoDePagamento.Boleto;
                    break;
                case "Pix":
                    metodoDePagamento = Model.Transferencia.MetodoDePagamento.Pix;
                    break;
                default:
                    metodoDePagamento = Model.Transferencia.MetodoDePagamento.Debito;
                    break;

            }
            
            if (string.IsNullOrEmpty(valor) || string.IsNullOrEmpty(numeroContaDestino) || valor == "R$ 0,00")
            {
                MessageBox.Show(
                    "Insira todos os dados corretamente antes de prosseguir!",
                    "Inconsistência nos dados",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                double valorDouble = decimal.ToDouble(valorBox.Number);
                AdicionarTransferencia at = new(_conta);
                if (at.Adicionar(valorDouble, numeroContaDestino, metodoDePagamento))
                {
                    MessageBox.Show(
                        $"Transação de R${valorDouble} para a conta de número {numeroContaDestino} foi concluída!",
                        "Transferência realizada",
                        MessageBoxButton.OK,
                        MessageBoxImage.None);
                    ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new TransacoesCorrente(_conta));
                }
                else
                {
                    MessageBox.Show("Erro: O número da conta destino não foi encontrado ou o saldo foi insuficiente para realizar a transferência. Lembre-se que a transferência só pode ser realizada entre duas contas corrente.",
                        "Erro na transferência",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new TransacoesCorrente(_conta));
        }
    }
}
