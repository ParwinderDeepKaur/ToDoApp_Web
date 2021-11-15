using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    public class ToDoTable
    {
        /// <summary>
        /// Id (primary key)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// ToDo Status
        /// </summary>
        [Required]
        public bool Status { get; set; }

        /// <summary>
        /// Date time
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }
}
