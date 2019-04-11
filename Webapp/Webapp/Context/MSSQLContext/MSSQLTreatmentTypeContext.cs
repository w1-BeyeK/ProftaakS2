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

        public TreatmentType GetById(long id)
        {
            string query = $"select * from PTS2_TreatmentType where Id = {id}";

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
        /// <returns>List of treatmenttypes</returns>
        public List<TreatmentType> GetAll()
        {
            // Create result
            List<TreatmentType> result = new List<TreatmentType>();
            // Set query
            string query = "select * from PTS2_TreatmentType where active = 1";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out TreatmentType treatmentType))
                    result.Add(treatmentType);
            }

            return result;
        }

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
                    fields += ",";
                fields += "active = @active";
                parameters.Add(new KeyValuePair<string, object>("active", treatmentType.Active ? "1" : "0"));

                query = query.Replace("@fields", fields);

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Delete(TreatmentType treatmentType)
        {
            try
            {
                string query = "update PTS2_TreatmentType set Active = 0 where Id = @id";

                handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", treatmentType.Id)
                });
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
