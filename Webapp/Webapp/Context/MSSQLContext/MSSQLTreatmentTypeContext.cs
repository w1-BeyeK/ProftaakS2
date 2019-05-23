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
    public class MSSQLTreatmentTypeContext : BaseMSSQLContext, ITreatmentTypeContext
    {
        public MSSQLTreatmentTypeContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        /// <summary>
        /// Get a TreatmentType by Id
        /// </summary>
        /// <param name="id"> TreatmentTypeId </param>
        /// <returns> TreatmentType </returns>
        public TreatmentType GetById(long id)
        {
            string query = "select * from PTS2_TreatmentType where Id = @id";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id),
                    new KeyValuePair<string, object>("active", true? "1" : "0")
            };

            var dbResult = handler.ExecuteSelect(query, id);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out TreatmentType treatment))
                return treatment;
            else
                return default(TreatmentType);
        }

        /// <summary>
        /// Get all treatment types
        /// </summary>
        /// <returns> List of treatmenttypes </returns>
        public List<TreatmentType> GetAll()
        {
            // Create result
            List<TreatmentType> result = new List<TreatmentType>();
            // Set query
            string query = "select * from PTS2_TreatmentType where active = @active";

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
                if (parser.TryParse(dr, out TreatmentType treatmentType))
                    result.Add(treatmentType);
            }

            return result;
        }

        /// <summary>
        /// Insert a Treatments and returns its Id
        /// </summary>
        /// <param name="treatmentType"> TreatmentType </param>
        /// <returns> InsertedId </returns>
        public long Insert(TreatmentType treatmentType)
        {
            try
            {
                string query = "insert into PTS2_TreatmentType(DepartmentId, Name, Description, Active) OUTPUT INSERTED.Id values(@departmentId, @name, @description, @active)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("name", treatmentType.Name),
                    new KeyValuePair<string, object>("departmentId", treatmentType.DepartmentId),
                    new KeyValuePair<string, object>("description", treatmentType.Description),
                    new KeyValuePair<string, object>("active", "1"),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Update a TreatmentType
        /// </summary>
        /// <param name="treatmentType"> TreatmentType </param>
        /// <returns> Bool </returns>
        public bool Update(TreatmentType treatmentType)
        {
            try
            {
                string query = "update PTS2_TreatmentType set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", treatmentType.Id)
                };

                if (treatmentType.Name != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[name] = @name";
                    parameters.Add(new KeyValuePair<string, object>("name", treatmentType.Name));
                }
                if (treatmentType.Description != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "description = @description";
                    parameters.Add(new KeyValuePair<string, object>("description", treatmentType.Description));
                }
                if (treatmentType.DepartmentId > 0)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "DepartmentId = @departmentId";
                    parameters.Add(new KeyValuePair<string, object>("departmentId", treatmentType.DepartmentId));
                }
                if (!string.IsNullOrWhiteSpace(fields))
                {
                    fields += ",";
                    fields += "active = @active";
                    parameters.Add(new KeyValuePair<string, object>("active", treatmentType.Active ? "1" : "0"));
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

        /// <summary>
        /// Deactivate a TreatmentType
        /// </summary>
        /// <param name="treatmentType"> TreatmentType </param>
        /// <returns> Bool </returns>
        public bool Delete(TreatmentType treatmentType)
        {
            try
            {
                string query = "update PTS2_TreatmentType set Active = @active where Id = @id";

                handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", treatmentType.Id),
                    new KeyValuePair<string, object>("active", treatmentType.Active)
                });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Get a TreatmentType by TreatmentId
        /// </summary>
        /// <param name="id" > TreatmentId </param>
        /// <returns> TreatmentType </returns>
        public TreatmentType GetByTreatmentId(long id)
        {
            try
            {
                // Create result
                TreatmentType result = new TreatmentType();
                // Set query
                string query = "SELECT * FROM PTS2_TreatmentType WHERE [Id] = @id";


                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, id) as DataTable;

                // Parse all rows
                foreach (DataRow dr in dbResult.Rows)
                {
                    // Parse only if succeeded
                    if (parser.TryParse(dr, out TreatmentType treatmentType))
                        result = treatmentType;
                }

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TreatmentType> GetTreatmentTypesByDoctorId(long id)
        {
            try
            {
                // Create result
                List<TreatmentType> result = new List<TreatmentType>();
                // Set query
                string query = "select t.Id, t.DepartmentId, t.Name, t.Description, t.Active from PTS2_TreatmentType t right join PTS2_Department_Doctor dd ON t.DepartmentId = dd.DepartmentId right join PTS2_doctor d ON dd.doctorId = d.Id where dd.DepartmentId IN (select departmentId from PTS2_Department_Doctor dd WHERE dd.doctorId = @id) and d.Id = @id";

                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, id) as DataTable;

                // Parse all rows
                foreach (DataRow dr in dbResult.Rows)
                {
                    // Parse only if succeeded
                    if (parser.TryParse(dr, out TreatmentType treatmentType))
                        result.Add(treatmentType);
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
