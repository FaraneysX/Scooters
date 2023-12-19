using System.Linq.Expressions;

using Moq;

using ScooterRental.BL.Users;
using ScooterRental.BL.Users.Entities;
using ScooterRental.DataAccess.Entities;
using ScooterRental.DataAccess.Repository;

namespace ScooterRental.UnitTests.BL.Users;

[TestFixture]
public class ScooterProviderTests
{
    [Test]
    public void TestGetAllUsers()
    {
        Expression? expression = null;
        Mock<IRepository<UserEntity>> usersRepository = new();

        usersRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()))
            .Callback((Expression<Func<UserEntity, bool>> x) => { expression = x; });

        var usersProvider = new UserProvider(usersRepository.Object, MapperHelper.Mapper);
        var userFilter = new UsersModelFilter()
        {
            Name = "name"
        };

        var users = usersProvider.Get(userFilter);

        usersRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()), Times.Exactly(1));
    }
}
