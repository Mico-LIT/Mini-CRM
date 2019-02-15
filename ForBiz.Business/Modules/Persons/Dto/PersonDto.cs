using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBiz.Business.Modules.Persons.Dto
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri Instagram { get; set; }
        public Uri Vk { get; set; }
        public string Email { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime? TimeSending { get; set; }
    }
}
