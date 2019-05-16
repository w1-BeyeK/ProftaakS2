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
    public class MSSQLTreatmentContext : BaseMSSQLContext, ITreatmentContext
    {
        public MSSQLTreatmentContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public Treatment GetById(long id)
        {
            string query = "SELECT t.Id, t.[Name], t.PatientId, t.DoctorId, t.BeginDate, t.EndDate, t.TreatmentTypeId, tt.[Name] AS TreatmentTypeName " +
                           "FROM PTS2_Treatment AS t " +
                           "INNER JOIN PTS2_TreatmentType AS tt ON t.TreatmentTypeId = tt.Id " +
                           "WHERE t.Id = @id";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id)
            };

            var dbResult = handler.ExecuteSelect(query, parameters);

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
            string query = "SELECT t.Id, t.Name, t.PatientId, t.DoctorId, t.BeginDate, t.EndDate, t.TreatmentTypeId, tt.[Name] AS TreatmentTypeName " +
                           "FROM PTS2_Treatment AS t " +
                           "INNER JOIN PTS2_TreatmentType AS tt ON t.TreatmentTypeId = tt.Id";

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

        //TODO : CHECK THIS QUERY!!!
        public long Insert(Treatment treatment)
        {
            try
            {
                string query = "insert into PTS2_Treatment(Name, DoctorId, PatientId, BeginDate, EndDate, TreatmentTypeId) OUTPUT INSERTED.ID values (@name, @doctorId, @patientId, @beginDate, @endDate, @treatmentTypeId)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("name", treatment.Name),
                    new KeyValuePair<string, object>("beginDate", treatment.BeginDate.ToString("yyyy-MM-dd")),
                    new KeyValuePair<string, object>("endDate", treatment.EndDate.ToString("yyyy-MM-dd")),
                    new KeyValuePair<string, object>("doctorId", treatment.DoctorId),
                    new KeyValuePair<string, object>("patientId", treatment.Patient.Id),
                    new KeyValuePair<string, object>("treatmentTypeId", treatment.TreatmentType.Id),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
  //          System.Data.SqlClient.SqlException
  //HResult = 0x80131904
  //Message = The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Doctor_Treatment".The conflict occurred in database "dbi409368", table "dbo.PTS2_Doctor", column 'Id'.
  // Source = Core.Net SqlClient Data Provider
  //  StackTrace:
  // at Webapp.Context.MSSQLContext.MSSQLTreatmentContext.Insert(Treatment treatment) in D:\Desktop\Proftaak\PT20\ProftaakS2\Webapp\Webapp\Context\MSSQLContext\MSSQLTreatmentContext.cs:line 81
  // at Webapp.Repository.TreatmentRepository.Insert(Treatment treatment) in D:\Desktop\Proftaak\PT20\ProftaakS2\Webapp\Webapp\Repository\TreatmentRepository.cs:line 30
  // at Webapp.Controllers.TreatmentController.Add(TreatmentDetailViewModel vm) in D:\Desktop\Proftaak\PT20\ProftaakS2\Webapp\Webapp\Controllers\TreatmentController.cs:line 88
  // at Microsoft.Extensions.Internal.ObjectMethodExecutor.Execute(Object target, Object[] parameters)
  // at Microsoft.AspNetCore.Mvc.Internal.ActionMethodExecutor.SyncActionResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
  // at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.< InvokeActionMethodAsync > d__12.MoveNext()

        }

        //TODO : CHECK THIS QUERY!!!
        public bool Update(Treatment treatment)
        {
            try
            {
                string query = "update PTS2_Treatment set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", treatment.Id)
                };

                if (treatment.Name != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[name] = @name";
                    parameters.Add(new KeyValuePair<string, object>("name", treatment.Name));
                }
                if (treatment.BeginDate != DateTime.MinValue)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[beginDate] = @beginDate";
                    parameters.Add(new KeyValuePair<string, object>("beginDate", treatment.BeginDate));
                }
                if (treatment.EndDate != DateTime.MinValue)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[endDate] = @endDate";
                    parameters.Add(new KeyValuePair<string, object>("endDate", treatment.EndDate));
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

        public bool Delete(Treatment treatment)
        {
            //try
            //{
            //    string query = "update PTS2_Treatment set Active = @active where Id = @id";

            //    handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
            //    {
            //        new KeyValuePair<string, object>("id", treatment.Id),
            //        new KeyValuePair<string, object>("active", treatment.Active),

            //    });
            //    return true;
            //}
            //catch (Exception e)
            //{
                return false;
            //}
        }

        public List<Treatment> GetByDoctor(long id)
        {
            try
            {
                // Create result
                List<Treatment> result = new List<Treatment>();
                // Set query
                string query = "SELECT Id, Name, PatientId, DoctorId, BeginDate, EndDate, TreatmentTypeId " +
                               "FROM PTS2_Treatment " +
                               "WHERE DoctorId = @id";
                                // AND t.EndDate >= '@endDate'";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id),
                    //new KeyValuePair<string, object>("endDate", DateTime.Today.AddYears(-1).ToString("yyyy-mm-dd")),
                };

                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

                // Parse all rows
                foreach (DataRow dr in dbResult.Rows)
                {
                    // Parse only if succeeded
                    if (parser.TryParse(dr, out Treatment treatment))
                        result.Add(treatment);
                }

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Treatment> GetByPatient(long id)
        {
            try
            {
                // Create result
                List<Treatment> result = new List<Treatment>();
                // Set query
                string query = "SELECT Id, Name, PatientId, DoctorId, BeginDate, EndDate, TreatmentTypeId " +
                               "FROM PTS2_Treatment " +
                               "WHERE PatientId = @id";

              
                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, id) as DataTable;

                // Parse all rows
                foreach (DataRow dr in dbResult.Rows)
                {
                    // Parse only if succeeded
                    if (parser.TryParse(dr, out Treatment treatment))
                        result.Add(treatment);
                }

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //TODO : CHECK THIS QUERY!!!
        public bool CheckTreatmentRelationship(long doctorId, long patientId)
        {
            try
            {
                // Create result
                List<Treatment> result = new List<Treatment>();

                // Set query
                string query = $"select * from PTS2_Treatment where DoctorId = @doctorId and PatientId = @patientId";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("doctorId", doctorId),
                    new KeyValuePair<string, object>("patientId", patientId),
                    //new KeyValuePair<string, object>("endDate", DateTime.Today.AddYears(-1).ToString("dd-mm-yyyy")),
                };

                // Tell the handler to execute the query
                var dbResult = handler.ExecuteSelect(query, parameters) as DataTable;

                // Parse all rows
                if(dbResult != null)
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
    }
}
