using Connection.Interfaces.Identity;
using NUnit.Framework;
using System.Linq;

namespace Test
{
    public class UserDaoTest
    {
        private IUsuarioDao Dao;

        [SetUp]
        public void Setup()
        {
            Dao = Connection.Factory.Invoke<IUsuarioDao>(
                "Data Source=Meitchouk2;Initial Catalog=Murray;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                new Common.Util.ErrorHandler()
            );
        }

        [Test]
        public void Read()
        {
            var collection = Dao.Read().ToArray();
            Assert.IsTrue(collection.Length > 0);
        }
    }
}