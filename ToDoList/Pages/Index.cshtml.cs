
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
        /// Get todo list
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
            
            _context.ToDoLists.Add(objToDoTable);
            // Save todo record
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Delete ToDo record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
  
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            objToDoTable = await _context.ToDoLists.FindAsync(id);

            if (objToDoTable != null)
            {
                _context.ToDoLists.Remove(objToDoTable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }


        /// <summary>
        /// Edit ToDo record 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(objToDoTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoTableExists(objToDoTable.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// check record is exists or not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ToDoTableExists(int id)
        {
            return _context.ToDoLists.Any(e => e.Id == id);
        }

        /// <summary>
        /// Get ToDo record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JsonResult> OnGetEditAsync(int? id)
        {

            if (id == null)
            {
                return new JsonResult(objToDoTable);
            }
             objToDoTable = await _context.ToDoLists.FirstOrDefaultAsync(m => m.Id == id);

            if (ToDoTable == null)
            {
                    return new JsonResult(objToDoTable);
            }
            return new JsonResult(objToDoTable);

        }

    }
}
