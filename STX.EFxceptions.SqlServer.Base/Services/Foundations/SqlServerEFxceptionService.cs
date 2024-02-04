// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;

namespace STX.EFxceptions.SqlServer.Base.Services.Foundations
{
    public partial class SqlServerEFxceptionService : ISqlServerEFxceptionService
    {
        private IDbErrorBroker<SqlException> sqlServerErrorBroker;

        public SqlServerEFxceptionService(IDbErrorBroker<SqlException> sqlServerErrorBroker) =>
            this.sqlServerErrorBroker = sqlServerErrorBroker;

        public void ThrowMeaningfulException(DbUpdateException dbUpdateException)
        {
            ValidateInnerException(dbUpdateException);
            throw dbUpdateException;
        }
    }
}
