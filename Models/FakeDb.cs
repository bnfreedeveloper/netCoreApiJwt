using System.Collections.Generic;
using System.Threading.Tasks;

namespace netCoreApiJWT.Models
{


    public class FakeDb
    {

        public static Task<List<User>> data = Task.FromResult(new List<User> {
        new User{
            UserName ="jean valjeant", EmailAdress = "jean@gmail.com",
            Password = "jean", Name="jean",Surname="humaniste",Role="administrator"
        },
        new User{
            UserName ="peter dinkel", EmailAdress = "pter@gmail.com",
            Password = "tyrion", Name="peter",Surname="humaniste",Role="Seller"
        },
        });
    }
}