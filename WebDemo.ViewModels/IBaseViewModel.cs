using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.ViewModels
{
    public interface IBaseViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
