using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.Models.EntityBase
{
    public class EntityBase
    {
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Deleted { get; set; }

        public EntityBase()
        {
            Deleted = false;
        }
        public virtual object[] IdentityID(bool dummy = true)
        {
            return new List<object>().ToArray();
        }
    }
}
