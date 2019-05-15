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
            string query = "SELECT Id, Username, Name, [Password], Gender, Email, RoleName, Phone, PrivPhone, PrivMail, BirthDate as Birth, Active " +
                           "FROM GetDoctor " +
                           "WHERE Id = @id";

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
            string query = "SELECT Id, Username, Name, [Password], Gender, Email, RoleName, Phone, PrivPhone, PrivMail, BirthDate AS Birth, Active " +
                           "FROM GetDoctor " +
                           "WHERE Active = @active";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("active", true? 1 : 0)
            };

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query, 1) as DataTable;

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
                               "@privMail = @privMail, " +
                               "@phone = @phone, " +
                               "@privPhone = @privPhone, " +
                               "@birthdate = @birthdate, " +
                               "@active = @active";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("username", doctor.UserName),
                    new KeyValuePair<string, object>("name", doctor.Name),
                    new KeyValuePair<string, object>("password", "AQAAAAEAACcQAAAAEDUhPAiD1wmdSduXLptdEQURGL9oocNf9T9nKEk4wdBZ9V/foWU1Saa4kd47qZBI6Q=="),
                    new KeyValuePair<string, object>("gender", (int)doctor.Gender),
                    new KeyValuePair<string, object>("email", doctor.Email),
                    new KeyValuePair<string, object>("privmail", doctor.PrivMail),
                    new KeyValuePair<string, object>("phone", doctor.Phone),
                    new KeyValuePair<string, object>("privphone", doctor.PrivPhone),
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

        //TODO : CHECK THIS QUERY!!!
        public bool Update(Doctor doctor)
        {
            try
            {
                #region Account
                string queryAccount = "update PTS2_Account set @fields where Id = @id";

                string fieldsAccount = "";
                List<KeyValuePair<string, object>> parametersAccount = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", doctor.Id)
                };

                if (doctor.UserName != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsAccount))
                        fieldsAccount += ",";
                    fieldsAccount += "[username] = @username";
                    parametersAccount.Add(new KeyValuePair<string, object>("username", doctor.UserName));
                }
                if (doctor.Password != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsAccount))
                        fieldsAccount += ",";
                    fieldsAccount += "[password] = @password";
                    parametersAccount.Add(new KeyValuePair<string, object>("password", doctor.Password));
                }
                if (doctor.Email != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsAccount))
                        fieldsAccount += ",";
                    fieldsAccount += "[email] = @email";
                    parametersAccount.Add(new KeyValuePair<string, object>("email", doctor.Email));
                }

                queryAccount = queryAccount.Replace("@fields", fieldsAccount);

                handler.ExecuteCommand(queryAccount, parametersAccount);
                #endregion

                #region Doctor
                string queryDoctor = "update PTS2_Doctor set @fields where Id = @id";

                string fieldsDoctor = "";
                List<KeyValuePair<string, object>> parametersDoctor = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", doctor.Id)
                };

                //TODO : ??? Doesnt do anything
                //if (doctor.Birth != null)
                //{
                //    if (!string.IsNullOrWhiteSpace(fieldsDoctor))
                //        fieldsDoctor += ",";
                //    fieldsDoctor += "[birthdate] = @birthdate";
                //    parametersDoctor.Add(new KeyValuePair<string, object>("birthdate", doctor.Birth));
                //}

                if (Convert.ToInt16(doctor.Gender) >= 0)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsDoctor))
                    { fieldsDoctor += ","; }
                    fieldsDoctor += "[gender] = @gender";
                    parametersDoctor.Add(new KeyValuePair<string, object>("gender", Convert.ToInt16(doctor.Gender)));
                }
                if (doctor.Phone != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsDoctor))
                        fieldsDoctor += ",";
                    fieldsDoctor += "[phone] = @phone";
                    parametersDoctor.Add(new KeyValuePair<string, object>("phone", doctor.Phone));
                }
                if (!string.IsNullOrWhiteSpace(fieldsDoctor))
                {
                    fieldsDoctor += ",";
                }
                fieldsDoctor += "[privPhone] = @privPhone";
                parametersDoctor.Add(new KeyValuePair<string, object>("privPhone", doctor.PrivPhone));

                if (!string.IsNullOrWhiteSpace(fieldsDoctor))
                {
                    fieldsDoctor += ",";
                }
                fieldsDoctor += "[privMail] = @privMail";
                parametersDoctor.Add(new KeyValuePair<string, object>("privMail", doctor.PrivMail));

                queryDoctor = queryDoctor.Replace("@fields", fieldsDoctor);

                handler.ExecuteCommand(queryDoctor, parametersDoctor);
                #endregion
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

        //TODO : CHECK THIS QUERY!!!
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

        //TODO : CHECK THIS QUERY!!!
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

        //TODO : CHECK THIS QUERY!!!
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
