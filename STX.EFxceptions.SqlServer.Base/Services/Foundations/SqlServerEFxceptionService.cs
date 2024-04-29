// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Abstractions.Brokers.DbErrorBroker;

namespace STX.EFxceptions.SqlServer.Base.Services.Foundations
{
    public partial class SqlServerEFxceptionService : ISqlServerEFxceptionService
    {
        private IDbErrorBroker<SqlException> sqlServerErrorBroker;

        public SqlServerEFxceptionService(IDbErrorBroker<SqlException> sqlServerErrorBroker) =>
            this.sqlServerErrorBroker = sqlServerErrorBroker;

        public void ThrowMeaningfulException(DbUpdateException dbUpdateException) =>
        TryCatch(() =>
        {
            ValidateInnerException(dbUpdateException);
            SqlException sqlException = GetSqlException(dbUpdateException.InnerException);
            int sqlErrorCode = this.sqlServerErrorBroker.GetErrorCode(sqlException);
            ConvertAndThrowMeaningfulException(sqlErrorCode, sqlException.Message);
            throw dbUpdateException;
        });

        private SqlException GetSqlException(Exception exception) =>
            (SqlException)exception;
    }
}
