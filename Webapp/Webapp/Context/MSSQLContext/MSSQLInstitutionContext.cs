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
    public class MSSQLInstitutionContext : BaseMSSQLContext, IInstitutionContext
    {
        public MSSQLInstitutionContext(IParser parser, IHandler handler) : base(parser, handler)
        { }

        public bool Delete(Institution obj)
        {
            try
            {
                string query = "update PTS2_Institution set Active = @active where Id = @id";

                handler.ExecuteCommand(query, new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", obj.Id),
                    new KeyValuePair<string, object>("active", obj.Active? "1" : "0")
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Institution> GetAll()
        {
            // Create result
            List<Institution> result = new List<Institution>();
            // Set query
            string query = "select * from PTS2_Institution where active = @active order by [name]";

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
                if (parser.TryParse(dr, out Institution institution))
                    result.Add(institution);
            }

            return result;
        }

        public Institution GetById(long id)
        {
            string query = $"select * from PTS2_Institution where active = @active and Id = @id";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("id", id),
                    new KeyValuePair<string, object>("active", true? "1" : "0")
            };

            var dbResult = handler.ExecuteSelect(query, parameters);

            var res = (dbResult as DataTable).Rows[0];
            if (res != null && parser.TryParse(res, out Institution institution))
                return institution;
            else
                return default(Institution);
        }

        public long Insert(Institution obj)
        {
            try
            {
                string query = "insert into PTS2_Institution(Name, Country, Zipcode, Housenumber, Phone, AdminId) OUTPUT INSERTED.Id values(@name, @country, @zipcode, @housenumber, @phone, @adminid)";

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("name", obj.Name),
                    new KeyValuePair<string, object>("country", obj.Country),
                    new KeyValuePair<string, object>("zipcode", obj.Zipcode),
                    new KeyValuePair<string, object>("housenumber", obj.HouseNumber),
                    new KeyValuePair<string, object>("phone", obj.Phone),
                    new KeyValuePair<string, object>("adminid", obj.Administrator.Id),
                };

                return (long)handler.ExecuteCommand(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Institution obj)
        {
            try
            {
                string query = "update PTS2_Institution set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>()
                {
                    new KeyValuePair<string, object>("id", obj.Id)
                };

                if (obj.Name != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[name] = @name";
                    parameters.Add(new KeyValuePair<string, object>("name", obj.Name));
                }
                if (obj.Country != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "country = @country";
                    parameters.Add(new KeyValuePair<string, object>("country", obj.Country));
                }
                if (obj.Zipcode != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "zipcode = @zipcode";
                    parameters.Add(new KeyValuePair<string, object>("zipcode", obj.Zipcode));
                }
                if (!string.IsNullOrWhiteSpace(fields))
                    fields += ",";
                fields += "phonenumber = @phonenumber";
                parameters.Add(new KeyValuePair<string, object>("phonenumber", obj.Phone));

                query = query.Replace("@fields", fields);

                handler.ExecuteCommand(query, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
