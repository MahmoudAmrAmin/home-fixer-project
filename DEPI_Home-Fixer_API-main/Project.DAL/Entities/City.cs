using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class City :BaseEntity
    {
        [Key]
        public int CityId { get; set; } 
        public string Name { get; set; }
    }
}
