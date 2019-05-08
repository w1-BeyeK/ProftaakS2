using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context.InterfaceContext;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MSSQLContext
{
    public class MSSQLDoctorContext : BaseMSSQLContext, IDoctorContext
    {
        //TODO : Change Queries!!!
        public MSSQLDoctorContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public Doctor GetById(long id)
        {
            string query = "SELECT a.Id, a.Username, a.Name, a.[Password], a.DoctorId, d.Gender, d.Email, d.Phone, d.BirthDate, d.Active " +
                           "FROM PTS2_Account AS a " +
                           "INNER JOIN PTS2_Doctor AS d ON a.DoctorId = d.Id " +
                           "WHERE doctorId = @id";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("id", id)
            };

            var dbResult = handler.ExecuteSelect(query, parameters);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out Doctor doctor))
                return doctor;
            else
                return default(Doctor);
        }

        /// <summary>
        /// Get all doctors
        /// </summary>
        /// <returns>List of doctors</returns>
        public List<Doctor> GetAll()
        {
            // Create result
            List<Doctor> result = new List<Doctor>();
            // Set query
            string query = "SELECT a.Id, a.Username, a.Name, a.[Password], a.DoctorId, d.Gender, d.Email, d.Phone, d.BirthDate, d.Active " +
                           "FROM PTS2_Account AS a " +
                           "INNER JOIN PTS2_Doctor AS d ON a.DoctorId = d.Id " +
                           "WHERE a.DoctorId IS NOT null AND a.PatientId IS NULL AND d.Active = @active";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("active", true? "1" : "0")
            };

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Doctor doctor))
                    result.Add(doctor);
            }

            return result;
        }

        public long Insert(Doctor doctor)
        {
            try
            {
                string query = "exec InsertDoctor " +
                               "@username = @username, " +
                               "@name = @name, " +
                               "@password = @password, " +
                               "@gender = @gender, " +
                               "@email = @email, " +
                               "@privEmail = @privEmail, " +
                               "@phone = @phone, " +
                               "@privPhone = @privPhone, " +
                               "@birthdate = @birthdate, " +
                               "@active = @active";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("username", doctor.UserName),
                    new KeyValuePair<string, object>("name", doctor.Name),
                    new KeyValuePair<string, object>("password", doctor.Password),
                    new KeyValuePair<string, object>("gender", doctor.Gender),
                    new KeyValuePair<string, object>("email", doctor.Email),
                    new KeyValuePair<string, object>("privemail", doctor.PrivMail),
                    new KeyValuePair<string, object>("phone", doctor.PhoneNumber),
                    new KeyValuePair<string, object>("privphone", doctor.PrivPhoneNumber),
                    new KeyValuePair<string, object>("birthdate", doctor.Birth),
                    new KeyValuePair<string, object>("active", doctor.Active? "1" : "0")
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Update(Doctor doctor)
        {
            try
            {
                string query = "update PTS2_Doctor set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", doctor.Id)
                };

                if (doctor.Name != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[name] = @name";
                    parameters.Add(new KeyValuePair<string, object>("name", doctor.Name));
                }
                if (doctor.Email != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[email] = @email";
                    parameters.Add(new KeyValuePair<string, object>("email", doctor.Email));
                }
                if (doctor.Birth != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[birthdate] = @birthdate";
                    parameters.Add(new KeyValuePair<string, object>("birthdate", doctor.Birth));
                }
                if (!string.IsNullOrWhiteSpace(fields))
                {
                    fields += ",";
                    fields += "[gender] = @gender";
                    parameters.Add(new KeyValuePair<string, object>("gender", doctor.Gender));
                }
                if (!string.IsNullOrWhiteSpace(fields))
                {
                    fields += ",";
                    fields += "[phone] = @phone";
                    parameters.Add(new KeyValuePair<string, object>("phone", doctor.PhoneNumber));
                }

                query = query.Replace("@fields", fields);

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Doctor doctor)
        {
            try
            {
                string query = "update PTS2_Doctor " +
                               "set Active = @active " +
                               "where Id = " +
                               "( " +
                               "SELECT a.Id " +
                               "FROM PTS2_Account AS a " +
                               "WHERE a.Id = @id " +
                               ")";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", doctor.Id),
                    new KeyValuePair<string, object>("active", doctor.Active? "1" : "0")
                };

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Doctor> GetByDepartment(long id)
        {
            try
            {
                // Create result
                List<Doctor> result = new List<Doctor>();

                // Set query
                string query = $"select * from PTS2_Doctor where DepartmentId = @id";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id)
                };

                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

                // Parse all rows
                foreach (DataRow dr in dbResult.Rows)
                {
                    // Parse only if succeeded
                    if (parser.TryParse(dr, out Doctor doctor))
                        result.Add(doctor);
                }

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Doctor> GetByInstitution(long id)
        {
            try
            {
                // Create result
                List<Doctor> result = new List<Doctor>();

                // Set query
                string query = $"select * from PTS2_Doctor where InstitutionId = @id";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id)
                };

                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

                // Parse all rows
                foreach (DataRow dr in dbResult.Rows)
                {
                    // Parse only if succeeded
                    if (parser.TryParse(dr, out Doctor doctor))
                        result.Add(doctor);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public bool AddToDepartment(long departmentId, long doctorId)
        {
            try
            {
                string query = "insert into PTS2_Department_Doctor(DepartmentId, DoctorId, Active) values(@departmentId, @doctorId, @active)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("departmentId", departmentId),
                    new KeyValuePair<string, object>("doctorId", doctorId),
                    new KeyValuePair<string, object>("active", "1")
                };

                return (bool)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}
