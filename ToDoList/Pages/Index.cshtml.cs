using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoDBContext _context;

        public IndexModel(ToDoDBContext context)
        {
            _context = context;
        }


        public IList<ToDoTable> ToDoTable { get;set; }
        [BindProperty]
        public ToDoTable objToDoTable { get; set; }

        /// <summary>
        /// get todo list
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            ToDoTable = await _context.ToDoLists.ToListAsync();
        }

  
        /// <summary>
        /// Add todo record 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            objToDoTable.Date = DateTime.UtcNow;
            _context.ToDoLists.Add(objToDoTable);
            // Save todo record
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
