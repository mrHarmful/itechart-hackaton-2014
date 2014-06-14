using System;
using System.Data.SqlClient;
using System.Web;
using Seed.Dacs.MsSql.Components.Formatters;
using Seed.Configuration;
using Seed.Logging;

namespace Seed.Dacs.MsSql.Components.MsSqlCommands
{
    internal class BaseCommand
    {
        #region Protected fields

        protected readonly string ConnectionString;

        protected readonly int CommandTimeout;

        #endregion

        #region Protected properties

        protected string StoredProcedureName { get; set; }

        protected string ErrorMessage { get; set; }

        protected string ErrorTraceMessage { get; set; }

        protected string BeginSqlRequestMessage { get; set; }

        protected string EndSqlRequestMessage { get; set; }

        protected string BeginSqlCmdBodyMessage { get; set; }

        protected string EndSqlCmdBodyMessage { get; set; }

        protected Guid? RequestKey { get; set; }

        protected DateTime BeginSqlRequest { get; set; }

        protected DateTime EndSqlRequest { get; set; }

        protected DateTime BeginSqlCmdBody { get; set; }

        protected DateTime EndSqlCmdBody { get; set; }

        #endregion

        #region Constructors

        public BaseCommand()
            : this(ConfigurationManager.Instance.SeedConnectionString) {}

        public BaseCommand(string connectionString)
        {
            ConnectionString = connectionString;
            CommandTimeout = ConfigurationManager.Instance.SqlCommandTimeoutSeconds;

            if (ConfigurationManager.Instance.IsEnableTraceLogging)
            {
                if (HttpContext.Current != null)
                {
                    RequestKey =
                        HttpContext.Current.Items.Contains(ConfigurationManager.Instance.RequestKeyContextItemName)
                            ? (Guid?) HttpContext.Current.Items[ConfigurationManager.Instance.RequestKeyContextItemName]
                            : null;
                }

                if (!RequestKey.HasValue)
                {
                    RequestKey = Guid.NewGuid();
                }
            }

            ErrorMessage = "Error during '{0}' sql request execution.";
            ErrorTraceMessage =
                "TRACE LOG - REQUEST KEY: {0}. PHASE: SQL REQUEST ERROR. DURATION: {1}.\r\n\tError during '{2}' sql request execution at {3}.";
            BeginSqlRequestMessage =
                "TRACE LOG - REQUEST KEY: {0}. PHASE: BEGIN SQL REQUEST.\r\n\t'{1}' sql request started at {2}.";
            EndSqlRequestMessage =
                "TRACE LOG - REQUEST KEY: {0}. PHASE: END SQL REQUEST. DURATION: {1} sec. IS FROM CACHE: Not cacheable data."
                + "\r\n\t'{2}' sql request finished at {3}.";
            BeginSqlCmdBodyMessage =
                "TRACE LOG - REQUEST KEY: {0}. PHASE: BEGIN SQL CMD BODY.\r\n\t'{1}' sql command started at {2}.";
            EndSqlCmdBodyMessage =
                "TRACE LOG - REQUEST KEY: {0}. PHASE: END SQL CMD BODY. DURATION: {1} sec."
                + "\r\n\t'{2}' sql command finished at {3}.";
        }

        #endregion

        #region Public methods

        public virtual void Execute()
        {
            try
            {
                BeginSqlRequestTrace();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandTimeout = CommandTimeout;
                        connection.Open();
                        BeginSqlCmdBodyTrace();
                        CommandBody(cmd);
                        EndSqlCmdBodyTrace();
                        connection.Close();
                    }
                }

                EndSqlRequestTrace();
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }
        }

        public virtual void CommandBody(SqlCommand cmd) {}

        #endregion

        #region Protected methods

        protected virtual void BeginSqlRequestTrace()
        {
            if (ConfigurationManager.Instance.IsEnableTraceLogging)
            {
                BeginSqlRequest = DateTime.Now;

                Logger.InfoFormat(BeginSqlRequestMessage,
                                  RequestKey,
                                  StoredProcedureName,
                                  BeginSqlRequest.ToLongTimeString());
            }
        }

        protected virtual void EndSqlRequestTrace()
        {
            if (ConfigurationManager.Instance.IsEnableTraceLogging)
            {
                EndSqlRequest = DateTime.Now;

                Logger.InfoFormat(EndSqlRequestMessage,
                                  RequestKey,
                                  (EndSqlRequest - BeginSqlRequest).TotalSeconds,
                                  StoredProcedureName,
                                  EndSqlRequest.ToLongTimeString());
            }
        }

        protected virtual void BeginSqlCmdBodyTrace()
        {
            if (ConfigurationManager.Instance.IsEnableTraceLogging)
            {
                BeginSqlCmdBody = DateTime.Now;

                Logger.InfoFormat(BeginSqlCmdBodyMessage,
                                  RequestKey,
                                  StoredProcedureName,
                                  BeginSqlCmdBody.ToLongTimeString());
            }
        }

        protected virtual void EndSqlCmdBodyTrace()
        {
            if (ConfigurationManager.Instance.IsEnableTraceLogging)
            {
                EndSqlCmdBody = DateTime.Now;

                Logger.InfoFormat(EndSqlCmdBodyMessage,
                                  RequestKey,
                                  (EndSqlCmdBody - BeginSqlCmdBody).TotalSeconds,
                                  StoredProcedureName,
                                  EndSqlCmdBody.ToLongTimeString());
            }
        }

        protected virtual void LogError(Exception e)
        {
            if (ConfigurationManager.Instance.IsEnableTraceLogging)
            {
                EndSqlCmdBody = DateTime.Now;

                Logger.ErrorFormat(ErrorTraceMessage,
                                   e,
                                   RequestKey,
                                   (EndSqlCmdBody - BeginSqlCmdBody).TotalSeconds,
                                   StoredProcedureName,
                                   EndSqlCmdBody.ToLongTimeString());
            }
            else
            {
                Logger.ErrorFormat(ErrorMessage, e, StoredProcedureName);
            }
        }

        #endregion
    }

    internal class BaseCommand<TResult> : BaseCommand
    {
        #region Public properties

        public TResult CommandResult { get; set; }

        #endregion

        #region Constructors

        public BaseCommand()
        {
            CommandResult = default (TResult);
        }

        public BaseCommand(string connectionString)
            : base(connectionString)
        {
            CommandResult = default(TResult);
        }

        #endregion

        #region Public methods

        public override void Execute()
        {
            try
            {
                BeginSqlRequestTrace();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandTimeout = CommandTimeout;
                        connection.Open();
                        BeginSqlCmdBodyTrace();
                        CommandBody(cmd);
                        EndSqlCmdBodyTrace();
                        connection.Close();
                        CommandResult = GetCommandResult(cmd);
                    }

                    // todo: uncomment after ApplyFormatting implementation
                    //CommandResult = CommandResult.ApplyFormatting();
                }

                EndSqlRequestTrace();
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }
        }

        #endregion

        #region Protected methods

        protected virtual TResult GetCommandResult(SqlCommand command)
        {
            return default(TResult);
        }

        #endregion
    }
}