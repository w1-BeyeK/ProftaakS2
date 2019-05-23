using System.Collections.Generic;

namespace Webapp.Models
{
    public class DepartmentViewModel
    {
        public List<DepartmentDetailViewModel> Departments { get; set; } = new List<DepartmentDetailViewModel>();
    }
}
