using EmployeeEF.DBContexts;
using EmployeeEF.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeEFNew.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeContext _employeeContext;

        public IndexModel(EmployeeContext employeContext)
        {
            _employeeContext = employeContext;
        }

        public IList<Employee> Employees { get; set; }
        public async Task OnGetAsync()
        {
            Employees = await _employeeContext.Employees.Include(x => x.Address).AsNoTracking().ToListAsync();
        }
    }
}
