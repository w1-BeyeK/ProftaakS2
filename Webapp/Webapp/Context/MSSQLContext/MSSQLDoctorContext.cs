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

        /// <summary>
        /// Get a Doctor by Id
        /// </summary>
        /// <param name="id"> DoctorId </param>
        /// <returns> Doctor </returns>
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
        /// <returns> List of Doctors </returns>
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

        /// <summary>
        /// Inserts a new doctor and returns its Id
        /// </summary>
        /// <param name="doctor"> Doctor </param>
        /// <returns> Inserted Long </returns>
        public long Insert(Doctor doctor)
        {
            try
            {
                string query = "exec InsertDoctor " +
                               "@Username = @username, " +
                               "@Name = @name, " +
                               "@Password = @password, " +
                               "@Gender = @gender, " +
                               "@Email = @email, " +
                               "@PrivMail = @privMail, " +
                               "@Phone = @phone, " +
                               "@PrivPhone = @privPhone, " +
                               "@Birthdate = @birthdate, " +
                               "@Active = 1";

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
                    new KeyValuePair<string, object>("birthdate", doctor.Birth.ToString("dd-MM-yyyy")),
                    new KeyValuePair<string, object>("active", doctor.Active? "1" : "0")
                };

                if (long.TryParse(handler.ExecuteCommand(query, parameters).ToString(), out long id))
                {
                    return id;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Update a Doctor
        /// </summary>
        /// <param name="doctor"> Doctor </param>
        /// <returns> Bool </returns>
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
                if (doctor.Birth != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsDoctor))
                        fieldsDoctor += ",";
                    fieldsDoctor += "[birthdate] = @birthdate";
                    parametersDoctor.Add(new KeyValuePair<string, object>("birthdate", doctor.Birth.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                }

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

        /// <summary>
        /// Deactivates a Doctor
        /// </summary>
        /// <param name="doctor"> Doctor </param>
        /// <returns> Bool </returns>
        public bool Delete(long id, bool active)
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
                    new KeyValuePair<string, object>("id", id),
                    new KeyValuePair<string, object>("active", active? "1" : "0")
                };

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Get a list of Doctors from a Department
        /// </summary>
        /// <param name="id"> DepartmentId </param>
        /// <returns> List of Doctors </returns>
        //TODO : CHECK THIS QUERY!!!
        public List<Doctor> GetByDoctorWithDepartment(long id)
        {
            try
            {
                // Create result
                List<Doctor> result = new List<Doctor>();

                // Set query
                string query = $"select distinct d.Id, a.Name, d.Gender, d.Phone, d.BirthDate, d.PrivMail, d.PrivPhone from PTS2_Doctor d right join PTS2_Department_Doctor dd ON d.Id = dd.doctorId right join PTS2_Account a ON d.Id = a.Id where dd.DepartmentId IN (select departmentId from PTS2_Department_Doctor dd WHERE dd.doctorId = @id) and d.Id != @id";

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

        /// <summary>
        /// Get a list of Doctors from an Institution
        /// </summary>
        /// <param name="id"> InstitutionId </param>
        /// <returns> List of Doctors </returns>
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

        /// <summary>
        /// Add a Doctor to a Department
        /// </summary>
        /// <param name="departmentId"> DepartmentId </param>
        /// <param name="doctorId"> DoctorId </param>
        /// <returns> Bool </returns>
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

        public bool CheckDoctorRelationship(long userId, long doctorId)
        {
            try
            {
                // Create result
                List<Treatment> result = new List<Treatment>();

                // Set query
                string query = $"select distinct d.Id from PTS2_Doctor d inner join PTS2_Department_Doctor dd ON d.Id = dd.doctorId where dd.DepartmentId IN (select departmentId from PTS2_Department_Doctor dd WHERE dd.doctorId = @userId) and d.Id = @doctorId";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("userId", userId),
                    new KeyValuePair<string, object>("doctorId", doctorId)
                };

                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

                // Parse all rows
                if (dbResult != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Doctor> GetByPatientWithTreatment(long id)
        {
            try
            {
                // Create result
                List<Doctor> result = new List<Doctor>();
                // Set query
                string query = "select distinct d.Id, a.Name, d.Gender, d.Phone, d.BirthDate, d.PrivMail, d.PrivPhone from PTS2_Doctor d inner join PTS2_Treatment t ON t.doctorId = d.Id inner join PTS2_Account a ON d.Id = a.Id where t.Id IN (select Id from PTS2_Treatment t WHERE t.patientId = @id) and d.Active = @active";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id),
                    new KeyValuePair<string, object>("active", "1")
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
                throw e;
            }
        }
    }
}
