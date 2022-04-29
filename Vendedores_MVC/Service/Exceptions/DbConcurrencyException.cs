using System;

namespace Vendedores_MVC.Service.Exceptions
{
    public class DbConcurrencyException : ApplicationException 
    {
        public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}
