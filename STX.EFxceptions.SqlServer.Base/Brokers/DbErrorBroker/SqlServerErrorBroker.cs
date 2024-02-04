// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.SqlClient;

namespace STX.EFxceptions.SqlServer.Base.Brokers.DbErrorBroker
{
    public class SqlServerErrorBroker : ISqlServerErrorBroker
    {
        public int GetErrorCode(SqlException sqlException) =>
            sqlException.ErrorCode;
    }
}
