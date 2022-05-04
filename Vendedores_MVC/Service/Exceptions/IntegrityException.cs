using System;

namespace Vendedores_MVC.Service.Exceptions
{
    public class IntegrityException :ApplicationException
    {
        public IntegrityException(string mensagem) : base(mensagem){ }
    }
}
