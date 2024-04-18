// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.SqlClient;
using STX.EFxceptions.Abstractions.Brokers.DbErrorBroker;

namespace STX.EFxceptions.SqlServer.Base.Brokers.DbErrorBroker
{
    public interface ISqlServerErrorBroker : IDbErrorBroker<SqlException>
    { }
}
