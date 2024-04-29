// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using STX.EFxceptions.Abstractions.Models.Exceptions;
using STX.EFxceptions.SqlServer.Base.Models.Exceptions;
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

            SqlException foreignKeyConstraintConflictException =
                CreateSqlException(
                    message: randomErrorMessage,
                    errorCode: sqlForeignKeyConstraintConflictErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: foreignKeyConstraintConflictException);

            DbUpdateException expectedDbUpdateException = dbUpdateException;

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictException))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

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
            this.sqlServerErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(foreignKeyConstraintConflictException),
                    Times.Once());

            this.sqlServerErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowInvalidColumnNameSqlException()
        {
            // given
            int sqlInvalidColumnNameErrorCode = 207;
            string randomErrorMessage = CreateRandomErrorMessage();

            SqlException invalidColumnNameExceptionThrown =
                CreateSqlException(
                    message: randomErrorMessage,
                    errorCode: sqlInvalidColumnNameErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: invalidColumnNameExceptionThrown);

            var invalidColumnNameSqlException =
                new InvalidColumnNameSqlException(
                    message: invalidColumnNameExceptionThrown.Message);

            var expectedInvalidColumnNameException =
                new InvalidColumnNameException(
                    message: invalidColumnNameSqlException.Message,
                    innerException: invalidColumnNameSqlException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidColumnNameExceptionThrown))
                    .Returns(sqlInvalidColumnNameErrorCode);

            // when 
            InvalidColumnNameException actualInvalidColumnNameException =
                Assert.Throws<InvalidColumnNameException>(() =>
                    this.sqlServerEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualInvalidColumnNameException.Should()
                .BeEquivalentTo(
                 expectation: expectedInvalidColumnNameException,
                 config: options => options
                     .Excluding(ex => ex.TargetSite)
                     .Excluding(ex => ex.StackTrace)
                     .Excluding(ex => ex.Source)
                     .Excluding(ex => ex.InnerException.TargetSite)
                     .Excluding(ex => ex.InnerException.StackTrace)
                     .Excluding(ex => ex.InnerException.Source));

            this.sqlServerErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(invalidColumnNameExceptionThrown),
                    Times.Once());

            this.sqlServerErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowInvalidObjectNameSqlException()
        {
            // given
            int sqlInvalidObjectNameErrorCode = 208;
            string randomErrorMessage = CreateRandomErrorMessage();

            SqlException invalidObjectNameExceptionThrown =
                CreateSqlException(
                    message: randomErrorMessage,
                    errorCode: sqlInvalidObjectNameErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: invalidObjectNameExceptionThrown);

            var invalidObjectNameSqlException =
                new InvalidObjectNameSqlException(
                    message: invalidObjectNameExceptionThrown.Message);

            var expectedInvalidObjectNameException =
                new InvalidObjectNameException(
                    message: invalidObjectNameSqlException.Message,
                    innerException: invalidObjectNameSqlException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidObjectNameExceptionThrown))
                    .Returns(sqlInvalidObjectNameErrorCode);

            // when
            InvalidObjectNameException actualInvalidObjectNameException =
                Assert.Throws<InvalidObjectNameException>(() =>
                    this.sqlServerEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualInvalidObjectNameException.Should()
                .BeEquivalentTo(
                expectation: expectedInvalidObjectNameException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));
            this.sqlServerErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(invalidObjectNameExceptionThrown),
                    Times.Once());

            this.sqlServerErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowForeignKeyConstraintConflictSqlException()
        {
            // given
            int sqlForeignKeyConstraintConflictErrorCode = 547;
            string randomErrorMessage = CreateRandomErrorMessage();

            SqlException foreignKeyConstraintConflictExceptionThrown =
                CreateSqlException(
                    message: randomErrorMessage,
                    errorCode: sqlForeignKeyConstraintConflictErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: foreignKeyConstraintConflictExceptionThrown);

            var foreignKeyConstraintConflictSqlException =
                new ForeignKeyConstraintConflictSqlException(
                    message: foreignKeyConstraintConflictExceptionThrown.Message);

            var expectedForeignKeyConstraintConflictException =
                new ForeignKeyConstraintConflictException(
                    message: foreignKeyConstraintConflictSqlException.Message,
                    innerException: foreignKeyConstraintConflictSqlException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(foreignKeyConstraintConflictExceptionThrown))
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when
            ForeignKeyConstraintConflictException actualForeignKeyConstraintConflictException =
                Assert.Throws<ForeignKeyConstraintConflictException>(() =>
                    this.sqlServerEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualForeignKeyConstraintConflictException.Should()
                .BeEquivalentTo(
                expectation: expectedForeignKeyConstraintConflictException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.sqlServerErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(foreignKeyConstraintConflictExceptionThrown),
                    Times.Once());

            this.sqlServerErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowDuplicateKeyWithUniqueIndexSqlException()
        {
            // given
            int sqlDuplicateKeyWithUniqueIndexErrorCode = 2601;
            string randomErrorMessage = CreateRandomErrorMessage();

            SqlException duplicateKeyWithUniqueIndexExceptionThrown =
                CreateSqlException(
                    message: randomErrorMessage,
                    errorCode: sqlDuplicateKeyWithUniqueIndexErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: duplicateKeyWithUniqueIndexExceptionThrown);

            var duplicateKeyWithUniqueIndexSqlException =
                new DuplicateKeyWithUniqueIndexSqlException(
                    message: duplicateKeyWithUniqueIndexExceptionThrown.Message);

            var expectedDuplicateKeyWithUniqueIndexException =
                new DuplicateKeyWithUniqueIndexException(
                    message: duplicateKeyWithUniqueIndexSqlException.Message,
                    innerException: duplicateKeyWithUniqueIndexSqlException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(duplicateKeyWithUniqueIndexExceptionThrown))
                    .Returns(sqlDuplicateKeyWithUniqueIndexErrorCode);

            // when
            DuplicateKeyWithUniqueIndexException actualDuplicateKeyWithUniqueIndexException =
                Assert.Throws<DuplicateKeyWithUniqueIndexException>(() =>
                    this.sqlServerEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));

            // then
            actualDuplicateKeyWithUniqueIndexException.Should()
                .BeEquivalentTo(
                expectation: expectedDuplicateKeyWithUniqueIndexException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.sqlServerErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(duplicateKeyWithUniqueIndexExceptionThrown),
                    Times.Once());

            this.sqlServerErrorBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowDuplicateKeySqlException()
        {
            // given
            int sqlDuplicateKeyErrorCode = 2627;
            string randomErrorMessage = CreateRandomErrorMessage();

            SqlException duplicateKeyExceptionThrown =
                CreateSqlException(
                    message: randomErrorMessage,
                    errorCode: sqlDuplicateKeyErrorCode);

            string randomDbUpdateExceptionMessage = CreateRandomErrorMessage();

            var dbUpdateException = new DbUpdateException(
                message: randomDbUpdateExceptionMessage,
                innerException: duplicateKeyExceptionThrown);

            var duplicateKeySqlException =
                new DuplicateKeySqlException(
                    message: duplicateKeyExceptionThrown.Message);

            var expectedDuplicateKeyException =
                new DuplicateKeyException(
                    message: duplicateKeySqlException.Message,
                    innerException: duplicateKeySqlException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(duplicateKeyExceptionThrown))
                    .Returns(sqlDuplicateKeyErrorCode);

            // when
            DuplicateKeyException actualDuplicateKeyException =
                Assert.Throws<DuplicateKeyException>(() =>
                    this.sqlServerEFxceptionService
                        .ThrowMeaningfulException(dbUpdateException));
            // then
            actualDuplicateKeyException.Should()
                .BeEquivalentTo(
                expectedDuplicateKeyException,
                config: options => options
                    .Excluding(ex => ex.TargetSite)
                    .Excluding(ex => ex.StackTrace)
                    .Excluding(ex => ex.Source)
                    .Excluding(ex => ex.InnerException.TargetSite)
                    .Excluding(ex => ex.InnerException.StackTrace)
                    .Excluding(ex => ex.InnerException.Source));

            this.sqlServerErrorBrokerMock.Verify(broker => broker
                .GetErrorCode(duplicateKeyExceptionThrown),
                    Times.Once());

            this.sqlServerErrorBrokerMock.VerifyNoOtherCalls();
        }
    }
}
