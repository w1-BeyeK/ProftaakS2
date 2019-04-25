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
            string query = $"select * from PTS2_Patient where Id = @id";

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
            string query = "select * from PTS2_Patient where active = @active";

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

        //This May not!!!
        public long Insert(Patient patient)
        {
            return -1;
            //try
            //{
            //    string query = "insert into PTS2_Patient(Active, Birth, BSN, ContactPersonName, ContactPersonPhone, " +
            //        "Email, Gender, HouseNumber, Name, UserName, PhoneNumber, PrivAdress, PrivBirthDate, PrivContactPersonName, PrivContactPersonPhone" +
            //        "PrivGender, PrivMail, PrivPhoneNumber, Zipcode) OUTPUT INSERTED.Id values(@departmentId, @name, @description, @active)";

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
            //        new KeyValuePair<string, object>("PhoneNumber", patient.PhoneNumber),
            //        new KeyValuePair<string, object>("PrivAdress", patient.PrivAdress),
            //        new KeyValuePair<string, object>("PrivBirthDate", patient.PrivBirthDate),
            //        new KeyValuePair<string, object>("PrivContactPersonName", patient.PrivContactPersonName),
            //        new KeyValuePair<string, object>("PrivContactPersonPhone", patient.PrivContactPersonPhone),
            //        new KeyValuePair<string, object>("PrivGender", patient.PrivGender),
            //        new KeyValuePair<string, object>("PrivMail", patient.PrivMail),
            //        new KeyValuePair<string, object>("PrivPhoneNumber", patient.PrivPhoneNumber),
            //        new KeyValuePair<string, object>("Zipcode", patient.Zipcode)
            //    };

            //    return (long)handler.ExecuteCommand(query, parameters);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }

        public bool Update(Patient patient)
        {
            try
            {
                string query = "update PTS2_Patient set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", patient.Id)
                };

                if (patient.ContactPersonName != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[contactPersonName] = @contactPersonName";
                    parameters.Add(new KeyValuePair<string, object>("contactPersonName", patient.ContactPersonName));
                }
                if (patient.ContactPersonPhone != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[contactPersonPhone] = @contactPersonPhone";
                    parameters.Add(new KeyValuePair<string, object>("contactPersonPhone", patient.ContactPersonPhone));
                }
                if (patient.Email != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[email] = @email";
                    parameters.Add(new KeyValuePair<string, object>("email", patient.Email));
                }
                if (patient.HouseNumber > 0)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[houseNumber] = @houseNumber";
                    parameters.Add(new KeyValuePair<string, object>("houseNumber", patient.HouseNumber));
                }
                if (patient.UserName != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[userName] = @userName";
                    parameters.Add(new KeyValuePair<string, object>("userName", patient.UserName));
                }
                if (patient.Password != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[password] = @password";
                    parameters.Add(new KeyValuePair<string, object>("password", patient.Password));
                }
                if (patient.PhoneNumber != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[phoneNumber] = @phoneNumber";
                    parameters.Add(new KeyValuePair<string, object>("phoneNumber", patient.PhoneNumber));
                }
                if (!string.IsNullOrWhiteSpace(fields))
                {
                    fields += ",";
                    fields += "[privAdress] = @privAdress";
                    parameters.Add(new KeyValuePair<string, object>("privAdress", patient.PrivAdress));

                    fields += ",";
                    fields += "[privBirthDate] = @privBirthDate";
                    parameters.Add(new KeyValuePair<string, object>("privBirthDate", patient.PrivBirthDate));

                    fields += ",";
                    fields += "[privContactPersonName] = @privContactPersonName";
                    parameters.Add(new KeyValuePair<string, object>("privContactPersonName", patient.PrivContactPersonName));

                    fields += ",";
                    fields += "[privContactPersonPhone] = @privContactPersonPhone";
                    parameters.Add(new KeyValuePair<string, object>("privContactPersonPhone", patient.PrivContactPersonPhone));

                    fields += ",";
                    fields += "[privGender] = @privGender";
                    parameters.Add(new KeyValuePair<string, object>("privGender", patient.PrivGender));

                    fields += ",";
                    fields += "[privMail] = @privMail";
                    parameters.Add(new KeyValuePair<string, object>("privMail", patient.PrivMail));

                    fields += ",";
                    fields += "[privPhoneNumber] = @privPhoneNumber";
                    parameters.Add(new KeyValuePair<string, object>("privPhoneNumber", patient.PrivPhoneNumber));
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

        //TODO : USE DOCTORID!!!
        public List<Patient> GetByDoctor(long id)
        {
            // Create result
            List<Patient> result = new List<Patient>();
            // Set query
            string query = "select * from PTS2_Patient where active = @active";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
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
