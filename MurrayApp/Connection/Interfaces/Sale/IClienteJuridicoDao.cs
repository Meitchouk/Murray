using System.Collections.Generic;
using Models.Sale;
using Connection.Base;

namespace Connection.Interfaces.Sale
{
    public interface IClienteJuridicoDao : IDao<ClienteJuridico>
    {

        IEnumerable<ClienteJuridico> Read(bool estado, int Id);

        ClienteJuridico Get(int Id);
    }
}
