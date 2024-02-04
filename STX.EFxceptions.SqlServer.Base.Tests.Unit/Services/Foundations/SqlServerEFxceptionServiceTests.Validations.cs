// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace STX.EFxceptions.SqlServer.Base.Tests.Unit.Services.Foundations
{
    public partial class SqlServerEFxceptionServiceTests
    {
        [Fact]
        public void ShouldThrowDbUpdateExceptionIfSqlExceptionIsNull()
        {
            // given
            var dbUpdateException = new DbUpdateException(null, default(Exception));

            // when
            Assert.Throws<DbUpdateException>(() =>
                this.sqlServerEFxceptionService.ThrowMeaningfulException(dbUpdateException));

            // then
            this.sqlServerErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(It.IsAny<SqlException>()), Times.Never);
        }
    }
}
