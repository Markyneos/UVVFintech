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
    /// Interação lógica para DeletarConta.xam
    /// </summary>
    public partial class DeletarConta : Page
    {
        private Cliente _cliente;
        public DeletarConta(Cliente c)
        {
            InitializeComponent();
            ((MainWindow)Application.Current.MainWindow).Title = "Deletar conta";
            _cliente = c;
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteContas(_cliente));
        }

        private void apagarContaButton_Click(object sender, RoutedEventArgs e)
        {
            string numeroDaConta = numeroContaBox.Text;
            string senhaConta = senhaContaBox.Password;

            if (string.IsNullOrEmpty(numeroDaConta) || string.IsNullOrEmpty(senhaConta))
            {
                MessageBox.Show(
                    "Insira todos os dados corretamente!",
                    "Dados faltando",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else
            {
                Controller.DeletarConta dc = new Controller.DeletarConta(_cliente);
                MessageBoxResult result = MessageBox.Show(
                    "Tem certeza que deseja deletar a conta?",
                    "Confirmação",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (dc.Deletar(numeroDaConta, senhaConta))
                    {
                        MessageBox.Show(
                            "Conta deletada com sucesso!",
                            "Conta deletada",
                            MessageBoxButton.OK,
                            MessageBoxImage.None);
                        ((MainWindow)Application.Current.MainWindow).mainFrame.Navigate(new ClienteContas(_cliente));
                    }
                    else
                    {
                        MessageBox.Show(
                            "Nenhuma conta com essas credenciais foi encontrada. Verifique seus dados e tente novamente.",
                            "Nenhuma conta encontrada",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
                else 
                {
                    return;
                }
            }
        }
    }
}
