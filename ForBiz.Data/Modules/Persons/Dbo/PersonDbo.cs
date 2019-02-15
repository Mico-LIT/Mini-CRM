using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBiz.Data.Modules.Persons.Dbo
{
    public class PersonDbo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Instagram { get; set; }
        public string Vk { get; set; }
        public string Email { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime? TimeSending { get; set; }
    }
}
