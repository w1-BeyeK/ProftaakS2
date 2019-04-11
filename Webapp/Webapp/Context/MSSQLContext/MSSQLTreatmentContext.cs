using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Context.MSSQLContext
{
    public class MSSQLTreatmentContext : BaseMSSQLContext, ITreatmentContext
    {
        //TODO : Change queries!!!
        public MSSQLTreatmentContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public Treatment GetById(long id)
        {
            string query = $"select * from PTS2_TreatmentType where Id = {id}";

            var dbResult = handler.ExecuteSelect(query, id);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out Treatment treatment))
                return treatment;
            else
                return default(Treatment);
        }

        /// <summary>
        /// Get all treatment types
        /// </summary>
        /// <returns>List of treatmenttypes</returns>
        public List<Treatment> GetAll()
        {
            // Create result
            List<Treatment> result = new List<Treatment>();
            // Set query
            string query = "select * from PTS2_TreatmentType where active = 1";

            // Tell the handler to execute the query
            var dbResult = handler.ExecuteSelect(query) as DataTable;

            // Parse all rows
            foreach (DataRow dr in dbResult.Rows)
            {
                // Parse only if succeeded
                if (parser.TryParse(dr, out Treatment treatment))
                    result.Add(treatment);
            }

            return result;
        }

        public long Insert(Treatment treatment)
        {
            try
            {
                string query = "insert into PTS2_TreatmentType(DepartmentId, Name, Description, Active) OUTPUT INSERTED.Id values(@departmentId, @name, @description, @active)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    //new KeyValuePair<string, object>("name", treatment.Name),
                    //new KeyValuePair<string, object>("departmentId", treatment.DepartmentId),
                    //new KeyValuePair<string, object>("description", treatment.Description),
                    //new KeyValuePair<string, object>("active", "1"),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Treatment treatment)
        {
            //try
            //{
            //    string query = "update PTS2_TreatmentType set @fields where Id = @id";

            //    string fields = "";
            //    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
            //    {
            //        new KeyValuePair<string, object>("id", treatment.Id)
            //    };

            //    if (treatment.Name != null)
            //    {
            //        if (!string.IsNullOrWhiteSpace(fields))
            //            fields += ",";
            //        fields += "[name] = @name";
            //        parameters.Add(new KeyValuePair<string, object>("name", treatment.Name));
            //    }
            //    if (!string.IsNullOrWhiteSpace(fields))
            //        fields += ",";
            //    fields += "active = @active";
            //    parameters.Add(new KeyValuePair<string, object>("active", treatment.Active ? "1" : "0"));

            //    query = query.Replace("@fields", fields);

            //    handler.ExecuteCommand(query, parameters);
            //    return true;
            //}
            //catch(Exception e)
            //{
                return false;
            //}
        }

        public bool Delete(Treatment treatment)
        {
            try
            {
                string query = "update PTS2_TreatmentType set Active = 0 where Id = @id";

                handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", treatment.Id)
                });
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<Treatment> GetByDoctor(long id)
        {
            throw new NotImplementedException();
        }

        public List<Treatment> GetByPatient(long id)
        {
            throw new NotImplementedException();
        }
    }
}
