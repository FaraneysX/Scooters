using ScooterRental.BL.Users.Entities;

namespace ScooterRental.Service.Controllers.Entities.Users;

public class UsersListResponse
{
    public List<UserModel>? Users { get; set; }
}
