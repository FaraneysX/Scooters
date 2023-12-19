using System.Linq.Expressions;

using Moq;

using ScooterRental.BL.Scooters;
using ScooterRental.BL.Scooters.Entities;
using ScooterRental.DataAccess.Entities;
using ScooterRental.DataAccess.Repository;

namespace ScooterRental.UnitTests.BL.Scooters;

[TestFixture]
public class ScooterProviderTests
{
    [Test]
    public void TestGetAllScooters()
    {
        Expression? expression = null;
        Mock<IRepository<ScooterEntity>> scootersRepository = new();

        scootersRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<ScooterEntity, bool>>>()))
            .Callback((Expression<Func<ScooterEntity, bool>> x) => { expression = x; });

        var scootersProvider = new ScooterProvider(scootersRepository.Object, MapperHelper.Mapper);
        var scooterFilter = new ScootersModelFilter()
        {
            MinPrice = 10
        };

        var scooters = scootersProvider.Get(scooterFilter);

        scootersRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<ScooterEntity, bool>>>()), Times.Exactly(1));
    }
}
