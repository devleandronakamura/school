using School.Application.InputModels;
using School.Application.ViewModels;
using School.Domain.Entities;
using School.Domain.Enums;

namespace School.Application.Mappers;

public static class UserMapper
{
    public static User ToUser(AddUserInputModel addUser)
    {
        return new User(fullName: addUser.FullName, email: addUser.Email, password: addUser.Password, access: addUser.Acccess);
    }

    public static UserViewModel ToUserViewModel(User user)
    {
        return new UserViewModel()
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Password = user.Password,
            Access = (int)user.Access,
            Roles = user.Roles,
            IsActive = user.IsActive
        };
    }

    public static IEnumerable<UserViewModel> ToUsersVM(IEnumerable<User> users)
    {
        var usersVM = new List<UserViewModel>();

        foreach (var user in users)
        {
            var userVM = new UserViewModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                Access = (int)user.Access,
                Roles = user.Roles,
                IsActive = user.IsActive
            };

            usersVM.Add(userVM);
        }

        return usersVM;
    }
}