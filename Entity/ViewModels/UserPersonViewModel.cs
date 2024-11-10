using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class UserPersonViewModel
    {
        public User user {  get; set; }= new User();
        public Person person { get; set; } = new Person();

    }
}
