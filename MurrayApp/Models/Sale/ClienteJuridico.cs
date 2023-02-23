using Models.Interfaces;

namespace Models.Sale
{
    public class ClienteJuridico : IIdentity, IActivable
    {

        public int Id { get; set; }

        public bool Estado { get; set; }


    }
}
