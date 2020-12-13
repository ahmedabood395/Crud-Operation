using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabDay3MVC.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        public DateTime hiredate { get; set; }
        public string address { get; set; }
        public int? salary { get; set; }

        [ForeignKey("department")]
        public int? dept_id { get; set; }

        public virtual Department department { get; set; }


    }
}