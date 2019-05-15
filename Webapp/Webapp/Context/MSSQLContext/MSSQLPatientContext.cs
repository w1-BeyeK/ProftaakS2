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
        /// <returns>List of treatmenttypes</returns>
        public List<Patient> GetAll()
        {
            // Create result
            List<Patient> result = new List<Patient>();
            // Set query
            string query = "SELECT Id, Name, Username, Email, RoleName, Active, BirthDate AS Birth, BSN, ContactPersonName, " +
                           "ContactPersonPhone, Gender, HouseNumber, PrivAdres, PrivBirthDate, PrivContactPersonName, PrivContactPersonPhone, PrivMail, PrivGender, PrivPhone, Phone, Zipcode " +
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

        public bool Delete(Patient patient)
        {
            try
            {
                string query = "update PTS2_Patient set Active = @active where Id = @id";

                handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", patient.Id),
                    new KeyValuePair<string, object>("active", patient.Active? "1" : "0")
                });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //TODO : WANG WRITES STORED PROCEDURE
        public List<Patient> GetByDoctor(long id)
        {
            // Create result
            List<Patient> result = new List<Patient>();
            // Set query
            string query = $"SELECT * FROM PTS2_Patient WHERE[Id] IN(SELECT[PatientId] FROM[PTS2_Treatment] WHERE DoctorId = @doctorId) AND Active = @active";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("doctorId", id),
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
    }
}
