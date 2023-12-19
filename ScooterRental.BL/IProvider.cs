using ScooterRental.BL.Users.Entities;

namespace ScooterRental.BL;

public interface IProvider<TModel, TModelFilter> where TModelFilter : class
{
    IEnumerable<TModel> Get(TModelFilter? modelFilter = null);
    TModel GetInfo(Guid id);
}
