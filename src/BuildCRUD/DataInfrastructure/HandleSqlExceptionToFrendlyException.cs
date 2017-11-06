using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data.Entity.Validation;

namespace DataInfrastructure.Infrastructure
{
    static public class HandleSqlExceptionToFrendlyException
    {
	    static public Exception EntityExceptionAsFriendlyException(this Exception ex)
	    {
            if (ex.GetType().Name != "SqlException" && ex.InnerException != null)
                return EntityExceptionAsFriendlyException(ex.InnerException);

            if (ex.GetType().Name == "SqlException")
                return ((SqlException)(ex)).AsSQLFormated();
		
		    return ex;
	    }
      
        static public Exception DBValidationEntityExceptionAsFriendlyException(this DbEntityValidationException dbEx)
	    {
            string message = "";
            foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        message += string.Format("Property: {0} Error: {1} {2}", validationError.PropertyName, validationError.ErrorMessage,'\n');
                    }
                }
            return new Exception(message, dbEx);
        }
    }


    static public class SQLMessageFormat
    {
      
        static public Dictionary<string, string> dictionary = new Dictionary<string, string>();

        static SQLMessageFormat()
        {
            
        }

        static public Exception AsSQLFormated(this SqlException sqlexc)
        {
            string str = sqlexc.Message;
            var reg = new Regex("\".*?\"");
            var matches = reg.Matches(str);

            if (matches.Count == 0)
            {
                reg = new Regex("\'.*?\'");
                matches = reg.Matches(str);
            }

            switch (sqlexc.Number)
            {
                case 547:
                    return new Exception(string.Format("Invalid {0} value.", dictionary.GetValueOrDefault(matches[0].Value, matches[0].Value)), sqlexc);
                case 2627:
                    return new Exception(string.Format("Invalid {0} value. Already exist in the database.", matches[0]), sqlexc);
                default:
                    return new Exception(sqlexc.Message);
            }
             
        }
    }

    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict,
           TKey key, TValue defaultIfNotFound = default(TValue))
        {
            TValue value;
            // value will be the result or the default for TValue
            if (!dict.TryGetValue(key, out value))
            {
                value = defaultIfNotFound;
            }
            return value;
        }
    }

}






