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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UvvFintech.Controller;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.View
{
    /// <summary>
    /// Interação lógica para ClienteContas.xam
    /// </summary>
    public partial class ClienteContas : Page
    {
        private Cliente _cliente;
        public List<Conta> contas = new List<Conta>();
        public ClienteContas(Cliente c)
        {
            InitializeComponent();
            _cliente = c;
            this.titulo3.Content = $"Bem-vindo, {_cliente.Nome.Split(" ")[0]}";
            SelectContasFromCliente sCFC = new SelectContasFromCliente(_cliente);
            var contas = sCFC.GetContas();
            dataGridContas.ItemsSource = contas;
        }
    }
}
