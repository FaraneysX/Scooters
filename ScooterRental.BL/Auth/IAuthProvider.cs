using ScooterRental.BL.Auth.Entities;

namespace ScooterRental.BL.Auth;

public interface IAuthProvider
{
    Task<TokensResponse> AuthorizeUser(string email, string password);
    Task RegisterUser(string name, string surname, string email, string phoneNumber, string password);
}
