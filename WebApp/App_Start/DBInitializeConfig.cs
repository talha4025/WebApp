using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebDemo.ViewModels;

namespace WebApp.App_Start
{
    public class DBInitializeConfig
    {
        private IUserMap userMap;
        public DBInitializeConfig(IUserMap _userMap)
        {
            userMap = _userMap;
        }
        public void DataTest()
        {
            Users();
        }
        private void Users()
        {
            userMap.Create(new UserViewModel() { id = 1, Name = "Talha" });
            userMap.Create(new UserViewModel() { id = 2, Name = "Malik" });
        }
    }
}
