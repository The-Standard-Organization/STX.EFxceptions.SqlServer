// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Moq;
using STX.EFxceptions.SqlServer.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.SqlServer.Base.Services.Foundations;

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
    }
}
