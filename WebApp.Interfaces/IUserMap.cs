using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Models;
using WebDemo.ViewModels;

namespace WebApp.Interfaces
{
    public interface IUserMap
    {
        UserViewModel Create(UserViewModel viewModel);
        bool Delete(int id);
        List<UserViewModel> DomainToViewModel(List<User> domain);
        UserViewModel DomainToViewModel(User domain);
        List<UserViewModel> GetAll();
        bool Update(UserViewModel viewModel);
        User ViewModelToDomain(UserViewModel officeViewModel);
    }
}
