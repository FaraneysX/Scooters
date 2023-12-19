using System.Linq.Expressions;

using Moq;

using ScooterRental.BL.Rents;
using ScooterRental.BL.Rents.Entities;
using ScooterRental.DataAccess.Entities;
using ScooterRental.DataAccess.Repository;

namespace ScooterRental.UnitTests.BL.Rents;

[TestFixture]
public class RentProviderTests
{
    [Test]
    public void TestGetAllUsers()
    {
        Expression? expression = null;
        Mock<IRepository<RentEntity>> rentsRepository = new();

        rentsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<RentEntity, bool>>>()))
            .Callback((Expression<Func<RentEntity, bool>> x) => { expression = x; });

        var rentsProvider = new RentProvider(rentsRepository.Object, MapperHelper.Mapper);
        var rentFilter = new RentsModelFilter()
        {
            MinTotalPrice = 100
        };

        var users = rentsProvider.Get(rentFilter);

        rentsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<RentEntity, bool>>>()), Times.Exactly(1));
    }
}
