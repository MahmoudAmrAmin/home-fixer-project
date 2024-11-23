using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Specialization : BaseEntity
    {
        [Key]
        public int SpecializationId {  get; set; }

        public string SpecializationName { get; set; }

    }
}
