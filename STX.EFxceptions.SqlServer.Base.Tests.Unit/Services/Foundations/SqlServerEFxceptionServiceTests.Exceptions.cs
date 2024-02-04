// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace STX.EFxceptions.SqlServer.Base.Tests.Unit.Services.Foundations
{
    public partial class SqlServerEFxceptionServiceTests
    {
        [Fact]
        public void ShouldThrowDbUpdateExceptionIfErrorCodeIsNotRecognized()
        {
            // given
            int sqlForeignKeyConstraintConflictErrorCode = 0000;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqlException foreignKeyConstraintConflictException = CreateSqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: foreignKeyConstraintConflictException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictException))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when . then
            Assert.Throws<DbUpdateException>(() =>
                this.sqlServerEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
    }
}
