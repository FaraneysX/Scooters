using System.Linq.Expressions;

using BL.Scooters;

using DataAccess.Entities;
using DataAccess.Repository;

using Moq;

namespace BL.UnitTests.Scooters;

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
        var scooters = scootersProvider.Get();

        scootersRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<ScooterEntity, bool>>>()), Times.Exactly(1));
    }
}
