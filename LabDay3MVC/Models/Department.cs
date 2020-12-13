using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabDay3MVC.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [MaxLength(50)]
        public string name { get; set; }
        public string loc { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
            Projects = new List<Project>();
        }

        public virtual List<Employee> Employees { get; set; }
        public virtual List<Project> Projects { get; set; }

    }
}