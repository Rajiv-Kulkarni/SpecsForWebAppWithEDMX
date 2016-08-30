using MySql.Data.MySqlClient;
using System.Data.Entity.Core.EntityClient;
using System.Web;

namespace CT3Application.Web.Infrastructure
{
    public static class CommonHelper
    {
        // readonly variable

        public static string ApplicationEnvironment
        {
            get
            {
                return HttpContext.Current.Application["ApplicationEnvironment"].ToString();
            }
        }

        public static string GetConnectionString(bool isUsedForRunningSpecs)
        {
            var environment = "dev";
            if (HttpContext.Current != null)
            {
                environment = ApplicationEnvironment;
            }
            var myServer = string.Empty;
            var myDatabase = string.Empty;
            var myUserID = string.Empty;
            var myPassword = string.Empty;
            // Initialize the connection string builder for the
            // underlying provider.
            if (environment == Properties.Settings.Default.DEVApplicationEnvironment)
            {
                myServer = isUsedForRunningSpecs ? Properties.Settings.Default.SPECSServer : Properties.Settings.Default.DEVServer;
                myDatabase = isUsedForRunningSpecs ? Properties.Settings.Default.SPECSDatabase : Properties.Settings.Default.DEVDatabase;//"staffing_center"
                myUserID = Properties.Settings.Default.DEVDBUserId;
                myPassword = Properties.Settings.Default.DEVDBPassword;
            }
            //else if (environment == Properties.Settings.Default.QAApplicationEnvironment)
            //{
            //    myDatabase = Properties.Settings.Default.QADatabase;
            //}
            //else if (environment == Properties.Settings.Default.DEMOApplicationEnvironment)
            //{
            //    myDatabase = Properties.Settings.Default.DEMODatabase;
            //}

            var MysqlBuilder =
                new MySqlConnectionStringBuilder
                {
                    // Set the properties for the data source.
                    Server = myServer,
                    Database = myDatabase,
                    PersistSecurityInfo = true,
                    //IntegratedSecurity = false,
                    //MultipleActiveResultSets = true,
                    UserID = myUserID,
                    Password = myPassword
                };

            // Build the SqlConnection connection string.
            string providerConnectionString = MysqlBuilder.ToString();
            //return providerConnectionString;

            var entityBuilder = new EntityConnectionStringBuilder
            {
                //Set the provider name.
                Provider = "MySql.Data.MySqlClient",
                // Set the provider-specific connection string.
                ProviderConnectionString = providerConnectionString,
                // Set the Metadata location.
                Metadata = @"res://*/Data.CT3Application.Web.csdl|
                res://*/Data.CT3Application.Web.ssdl|
                res://*/Data.CT3Application.Web.msl"
            };

            var entityConnection = entityBuilder.ToString();
            return entityConnection;
        }


        public static string GetCommonDbConnectionString(bool isUsedForRunningSpecs)
        {
            var environment = "dev";
            if (HttpContext.Current != null)
            {
                environment = ApplicationEnvironment;
            }
            var myServer = string.Empty;
            var myDatabase = string.Empty;
            var myUserID = string.Empty;
            var myPassword = string.Empty;
            // Initialize the connection string builder for the
            // underlying provider.
            if (environment == Properties.Settings.Default.DEVApplicationEnvironment)
            {
                myServer = isUsedForRunningSpecs ? Properties.Settings.Default.SPECSServer : Properties.Settings.Default.CommonDEVServer;
                myDatabase = Properties.Settings.Default.CommonDEVDatabase;//"staffing_center";
                myUserID = Properties.Settings.Default.CommonDEVDBUserId;
                myPassword = Properties.Settings.Default.CommonDEVDBPassword;
            }
            //else if (environment == Properties.Settings.Default.QAApplicationEnvironment)
            //{
            //    myDatabase = Properties.Settings.Default.QADatabase;
            //}
            //else if (environment == Properties.Settings.Default.DEMOApplicationEnvironment)
            //{
            //    myDatabase = Properties.Settings.Default.DEMODatabase;
            //}

            var MysqlBuilder =
                new MySqlConnectionStringBuilder
                {
                    // Set the properties for the data source.
                    Server = myServer,
                    Database = myDatabase,
                    PersistSecurityInfo = true,
                    //IntegratedSecurity = false,
                    //MultipleActiveResultSets = true,
                    UserID = myUserID,
                    Password = myPassword
                };

            // Build the SqlConnection connection string.
            string providerConnectionString = MysqlBuilder.ToString();
            return providerConnectionString;
        }

        public static string HeaderEnvironmentString
        {
            get
            {
                var headerEnvironmentString = "(Dev)";
                var environment = HttpContext.Current.Application["ApplicationEnvironment"].ToString();
                //switch (ApplicationEnvironment)
                switch (environment)
                {
                    case "dev":
                        headerEnvironmentString = "(Dev)";
                        break;
                    case "qa":
                        headerEnvironmentString = "(QA)";
                        break;
                    case "demo":
                        headerEnvironmentString = "(Demo)";
                        break;
                    case "prod":
                        headerEnvironmentString = "";
                        break;
                    default:
                        headerEnvironmentString = "(Dev)";
                        break;
                }
                return headerEnvironmentString;
            }
        }

        public static string FailureJson(string message, int errorCode)
        {
            string failureJsonString = string.Format("{{ \"outcome\" : \"failed\", \"message\" : \"{0}\", \"errorcode\" : \"{1}\" }}", message, errorCode);
            return failureJsonString;
        }

        public static string SuccessJson(string message)
        {
            string successJsonString = string.Format("{{ \"outcome\" : \"success\", \"message\" : \"{0}\" }}", message);
            return successJsonString;
        }

    }
}