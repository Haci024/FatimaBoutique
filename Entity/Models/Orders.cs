using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public AppUser AppUser { get; set; }

        public Guid? AppUserId { get; set; }

        public string  FullName { get; set; }

        public string  PhoneNumber { get; set; }

    

    }


}
