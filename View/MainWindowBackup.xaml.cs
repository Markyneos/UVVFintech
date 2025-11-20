using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UvvFintech.Data;
using System.Linq;

namespace UvvFintech
{
    /// <summary>
    /// Interaction logic for MainWindowBackup.xaml
    /// </summary>
    public partial class MainWindowBackup : Window
    {
        public MainWindowBackup()
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