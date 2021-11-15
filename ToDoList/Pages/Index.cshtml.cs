using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ToDoDBContext _dBContext;

        public IndexModel(ILogger<IndexModel> logger, 
            ToDoDBContext dBContext)
        {
            _logger = logger;
            this._dBContext = dBContext;
        }

        /// <summary>
        /// Get List Of Todo record
        /// </summary>
        public void OnGet()
        {

           // Test DB table 
           //Insert demo record 
            _dBContext.Add(new ToDoTable
            {
                Description = "Testing.",
                Status = false,
                Date = new DateTime()
            });

            _dBContext.SaveChanges();

        }
    }
}
