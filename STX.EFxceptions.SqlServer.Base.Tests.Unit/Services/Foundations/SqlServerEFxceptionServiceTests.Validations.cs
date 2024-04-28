// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using FluentAssertions;
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
            DbUpdateException expectedDbUpdateException = dbUpdateException;

            // when 
            DbUpdateException actualDbUpdateException =
                Assert.Throws<DbUpdateException>(() =>
                    this.sqlServerEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));
            // then
            actualDbUpdateException.Should()
                .BeEquivalentTo(
                expectation: expectedDbUpdateException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.sqlServerErrorBrokerMock.Verify(broker =>
                broker.GetErrorCode(It.IsAny<SqlException>()),
                    Times.Never);

            this.sqlServerErrorBrokerMock.VerifyNoOtherCalls();
        }
    }
}
