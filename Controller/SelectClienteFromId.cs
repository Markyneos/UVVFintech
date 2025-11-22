using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UvvFintech.Data;
using UvvFintech.Model;

namespace UvvFintech.Controller
{
    internal class SelectClienteFromId
    {
        private int _clientId;
        public SelectClienteFromId(int id)
        {
            _clientId = id;
        }

        public Cliente GetCliente()
        {
            using var context = new AppDbContext();
            try
            {
                var matchingCliente = context.ClienteS.First(c => c.Id == _clientId);
                return matchingCliente;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
