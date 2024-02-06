// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Runtime.Serialization;
using Microsoft.Data.SqlClient;
using Moq;
using STX.EFxceptions.SqlServer.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.SqlServer.Base.Services.Foundations;
using Tynamix.ObjectFiller;

namespace STX.EFxceptions.SqlServer.Base.Tests.Unit.Services.Foundations
{
    public partial class SqlServerEFxceptionServiceTests
    {
        private readonly Mock<ISqlServerErrorBroker> sqlServerErrorBrokerMock;
        private readonly ISqlServerEFxceptionService sqlServerEFxceptionService;

        public SqlServerEFxceptionServiceTests()
        {
            this.sqlServerErrorBrokerMock = new Mock<ISqlServerErrorBroker>();

            this.sqlServerEFxceptionService = new SqlServerEFxceptionService(
                sqlServerErrorBroker: this.sqlServerErrorBrokerMock.Object);
        }

        private string CreateRandomErrorMessage() => new MnemonicString().GetValue();

        private SqlException CreateSqlException() =>
            FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;
    }
}
