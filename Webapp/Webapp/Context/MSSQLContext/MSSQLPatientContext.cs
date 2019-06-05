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
    public class MSSQLPatientContext : BaseMSSQLContext, IPatientContext
    {
        //TODO : Change Queries!!!!
        public MSSQLPatientContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        /// <summary>
        /// Get a Patient by Id
        /// </summary>
        /// <param name="id"> PatientId </param>
        /// <returns> Patient </returns>
        public Patient GetById(long id)
        {
            string query = "SELECT Id, Name, Username, [Password], Email, RoleName, Active, BirthDate AS Birth, BSN, ContactPersonName, " +
                           "ContactPersonPhone, Gender, HouseNumber, PrivAdress, PrivBirthDate, PrivContactPersonName, PrivContactPersonPhone, PrivMail, PrivGender, PrivPhone, Phone, Zipcode " +
                           "FROM GetPatient " +
                           "WHERE id = @id";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id)
            };


            var dbResult = handler.ExecuteSelect(query, parameters);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out Patient patient))
                return patient;
            else
                return default(Patient);
        }

        /// <summary>
        /// Get all treatment types
        /// </summary>
        /// <returns>List of Treatmenttypes</returns>
        public List<Patient> GetAll()
        {
            // Create result
            List<Patient> result = new List<Patient>();
            // Set query
            string query = "SELECT Id, Name, Username, Email, RoleName, Active, BirthDate AS Birth, BSN, ContactPersonName, " +
                           "ContactPersonPhone, Gender, HouseNumber, PrivAdress, PrivBirthDate, PrivContactPersonName, PrivContactPersonPhone, PrivMail, PrivGender, PrivPhone, Phone, Zipcode " +
                           "FROM GetPatient " +
                           "WHERE Active = @active";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("active", true? "1" : "0")
            };

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Patient patient))
                    result.Add(patient);
            }

            return result;
        }

        /// <summary>
        /// Insert a new Patient and returns its Id (is not a used function because all patient "start" in database)
        /// </summary>
        /// <param name="patient"> Patient </param>
        /// <returns> InsertedId </returns>
        public long Insert(Patient patient)
        {
            return -1;
            //try
            //{
            //    string query = "insert into PTS2_Patient(Active, Birth, BSN, ContactPersonName, ContactPersonPhone, " +
            //        "Email, Gender, HouseNumber, Name, UserName, Phone, PrivAdress, PrivBirthDate, PrivContactPersonName, PrivContactPersonPhone" +
            //        "PrivGender, PrivMail, PrivPhone, Zipcode) OUTPUT INSERTED.Id values(@departmentId, @name, @description, @active)";

            //    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            //    {
            //        new KeyValuePair<string, object>("Active", patient.Active),
            //        new KeyValuePair<string, object>("Birth", patient.Birth),
            //        new KeyValuePair<string, object>("BSN", patient.BSN),
            //        new KeyValuePair<string, object>("ContactPersonName", patient.ContactPersonName),
            //        new KeyValuePair<string, object>("ContactPersonPhone", patient.ContactPersonPhone),
            //        new KeyValuePair<string, object>("Email", patient.Email),
            //        new KeyValuePair<string, object>("Gender", patient.Gender),
            //        new KeyValuePair<string, object>("HouseNumber", patient.HouseNumber),
            //        new KeyValuePair<string, object>("Name", patient.Name),
            //        new KeyValuePair<string, object>("UserName", patient.NormalizedUserName),
            //        new KeyValuePair<string, object>("Phone", patient.Phone),
            //        new KeyValuePair<string, object>("PrivAdress", patient.PrivAdress),
            //        new KeyValuePair<string, object>("PrivBirthDate", patient.PrivBirthDate),
            //        new KeyValuePair<string, object>("PrivContactPersonName", patient.PrivContactPersonName),
            //        new KeyValuePair<string, object>("PrivContactPersonPhone", patient.PrivContactPersonPhone),
            //        new KeyValuePair<string, object>("PrivGender", patient.PrivGender),
            //        new KeyValuePair<string, object>("PrivMail", patient.PrivMail),
            //        new KeyValuePair<string, object>("PrivPhone", patient.PrivPhone),
            //        new KeyValuePair<string, object>("Zipcode", patient.Zipcode)
            //    };

            //    return (long)handler.ExecuteCommand(query, parameters);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }

        /// <summary>
        /// Update a Patient
        /// </summary>
        /// <param name="patient"> Patient </param>
        /// <returns> Bool </returns>
        //TODO : CHECK THIS QUERY!!!
        public bool Update(Patient patient)
        {
            try
            {
                #region UpdateAccount
                string queryAccount = "update PTS2_Account set @fields where Id = @id";

                string fieldsAccount = "";
                List<KeyValuePair<string, object>> parametersAccount = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", patient.Id)
                };

                if (patient.Password != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsAccount))
                        fieldsAccount += ",";
                    fieldsAccount += "[password] = @password";
                    parametersAccount.Add(new KeyValuePair<string, object>("password", patient.Password));
                }
                if (patient.Email != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsAccount))
                        fieldsAccount += ",";
                    fieldsAccount += "[email] = @email";
                    parametersAccount.Add(new KeyValuePair<string, object>("email", patient.Email));
                }

                queryAccount = queryAccount.Replace("@fields", fieldsAccount);

                handler.ExecuteCommand(queryAccount, parametersAccount);
                #endregion

                #region UpdatePatient
                string queryPatient = "update PTS2_Patient set @fields where Id = @id";

                string fieldsPatient = "";
                List<KeyValuePair<string, object>> parametersPatient = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", patient.Id)
                };

                if (patient.ContactPersonName != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsPatient))
                        fieldsPatient += ",";
                    fieldsPatient += "[contactPersonName] = @contactPersonName";
                    parametersPatient.Add(new KeyValuePair<string, object>("contactPersonName", patient.ContactPersonName));
                }
                if (patient.ContactPersonPhone != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsPatient))
                        fieldsPatient += ",";
                    fieldsPatient += "[contactPersonPhone] = @contactPersonPhone";
                    parametersPatient.Add(new KeyValuePair<string, object>("contactPersonPhone", patient.ContactPersonPhone));
                }
                if (patient.HouseNumber > 0)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsPatient))
                        fieldsPatient += ",";
                    fieldsPatient += "[houseNumber] = @houseNumber";
                    parametersPatient.Add(new KeyValuePair<string, object>("houseNumber", patient.HouseNumber));
                }
                if (patient.Zipcode != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsPatient))
                        fieldsPatient += ",";
                    fieldsPatient += "[zipcode] = @zipcode";
                    parametersPatient.Add(new KeyValuePair<string, object>("zipcode", patient.Zipcode));
                }
                if (patient.Phone != null)
                {
                    if (!string.IsNullOrWhiteSpace(fieldsPatient))
                        fieldsPatient += ",";
                    fieldsPatient += "[phone] = @phone";
                    parametersPatient.Add(new KeyValuePair<string, object>("phone", patient.Phone));
                }
                if (!string.IsNullOrWhiteSpace(fieldsPatient))
                {
                    fieldsPatient += ",";
                    fieldsPatient += "[privAdress] = @privAdress";
                    parametersPatient.Add(new KeyValuePair<string, object>("privAdress", patient.PrivAdress));

                    fieldsPatient += ",";
                    fieldsPatient += "[privBirthDate] = @privBirthDate";
                    parametersPatient.Add(new KeyValuePair<string, object>("privBirthDate", patient.PrivBirthDate));

                    fieldsPatient += ",";
                    fieldsPatient += "[privContactPersonName] = @privContactPersonName";
                    parametersPatient.Add(new KeyValuePair<string, object>("privContactPersonName", patient.PrivContactPersonName));

                    fieldsPatient += ",";
                    fieldsPatient += "[privContactPersonPhone] = @privContactPersonPhone";
                    parametersPatient.Add(new KeyValuePair<string, object>("privContactPersonPhone", patient.PrivContactPersonPhone));

                    fieldsPatient += ",";
                    fieldsPatient += "[privGender] = @privGender";
                    parametersPatient.Add(new KeyValuePair<string, object>("privGender", patient.PrivGender));

                    fieldsPatient += ",";
                    fieldsPatient += "[privMail] = @privMail";
                    parametersPatient.Add(new KeyValuePair<string, object>("privMail", patient.PrivMail));

                    fieldsPatient += ",";
                    fieldsPatient += "[privPhone] = @privPhone";
                    parametersPatient.Add(new KeyValuePair<string, object>("privPhone", patient.PrivPhone));
                }

                queryPatient = queryPatient.Replace("@fields", fieldsPatient);

                handler.ExecuteCommand(queryPatient, parametersPatient);
                #endregion
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Deactivates a Patient
        /// </summary>
        /// <param name="patient"> Patient </param>
        /// <returns> Bool </returns>
        public bool Delete(long id, bool active)
        {
            try
            {
                string query = "update PTS2_Patient set Active = @active where Id = @id";

                handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", id),
                    new KeyValuePair<string, object>("active", active? "1" : "0")
                });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Get all Patients from a Doctor
        /// </summary>
        /// <param name="id"> DoctorId </param>
        /// <returns> List of Patients </returns>
        //TODO : WANG WRITES STORED PROCEDURE
        public List<Patient> GetByDoctor(long id)
        {
            // Create result
            List<Patient> result = new List<Patient>();
            // Set query
            string query = "SELECT * FROM [dbo].[GetPatientsWithAccess](@doctorId)";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("doctorId", id)
                };

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Patient patient))
                    result.Add(patient);
            }

            return result;
        }

        /// <summary>
        /// Get a PatientId using a TreatmentId
        /// </summary>
        /// <param name="id"> TreatmentId </param>
        /// <returns> Long </returns>
        public long GetPatientIdByTreatmentId(long id)
        {
            // Set query
            string query = $"SELECT PatientId from PTS2_Treatment WHERE [Id] = @id";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query, id) as DataTable;

            if(long.TryParse(dbResult?.Rows[0][0].ToString(), out long result))
                return result;
            return -1;
        }
    }
}
