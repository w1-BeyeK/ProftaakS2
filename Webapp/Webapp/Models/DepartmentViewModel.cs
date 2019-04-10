using System.Collections.Generic;

namespace Webapp.Models
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
            Departments = new List<DepartmentDetailViewModel>();
        }

        public List<DepartmentDetailViewModel> Departments { get; set; }
    }
}
