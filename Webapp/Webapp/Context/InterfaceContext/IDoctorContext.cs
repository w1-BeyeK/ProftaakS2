using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.InterfaceContext
{
    public interface IDoctorContext : IUniversalGenerics<Doctor>
    {
        List<Doctor> GetByDoctorWithDepartment(long id);
        List<Doctor> GetByInstitution(long id);
        bool AddToDepartment(long departmentId, long doctorId);
        bool CheckDoctorRelationship(long userId, long doctorId);
    }
}
