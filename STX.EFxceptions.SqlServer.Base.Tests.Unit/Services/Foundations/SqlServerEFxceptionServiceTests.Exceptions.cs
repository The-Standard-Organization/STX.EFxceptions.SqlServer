// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        
        [Fact]
        public void ShouldThrowInvalidColumnNameSqlException()
        {
            // given
            int sqlInvalidColumnNameErrorCode = 207;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqlException invalidColumnNameException = CreateSqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: invalidColumnNameException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidColumnNameException))
                    .Returns(sqlInvalidColumnNameErrorCode);

            // when . then
            Assert.Throws<InvalidColumnNameSqlException>(() =>
                this.sqlServerEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
        
        [Fact]
        public void ShouldThrowInvalidObjectNameSqlException()
        { 
            // given
            int sqlInvalidObjectNameErrorCode = 208;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqlException invalidObjectNameException = CreateSqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: invalidObjectNameException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(invalidObjectNameException))    
                    .Returns(sqlInvalidObjectNameErrorCode);

            // when . then
            Assert.Throws<InvalidObjectNameSqlException>(() =>
                this.sqlServerEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
        
        [Fact]
        public void ShouldThrowForeignKeyConstraintConflictSqlException()
        { 
            // given
            int sqlForeignKeyConstraintConflictErrorCode = 547;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqlException ForeignKeyConstraintConflictException = CreateSqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: ForeignKeyConstraintConflictException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(ForeignKeyConstraintConflictException))    
                    .Returns(sqlForeignKeyConstraintConflictErrorCode);

            // when . then
            Assert.Throws<ForeignKeyConstraintConflictSqlException>(() =>
                this.sqlServerEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
        
        [Fact]
        public void ShouldThrowDuplicateKeyWithUniqueIndexSqlException()
        { 
            // given
            int sqlDuplicateKeyWithUniqueIndexErrorCode = 2601;
            string randomErrorMessage = CreateRandomErrorMessage();
            SqlException duplicateKeyWithUniqueIndexException = CreateSqlException();

            var dbUpdateException = new DbUpdateException(
                message: randomErrorMessage,
                innerException: duplicateKeyWithUniqueIndexException);

            this.sqlServerErrorBrokerMock.Setup(broker =>
                broker.GetErrorCode(duplicateKeyWithUniqueIndexException))    
                    .Returns(sqlDuplicateKeyWithUniqueIndexErrorCode);

            // when . then
            Assert.Throws<DuplicateKeyWithUniqueIndexSqlException>(() =>
                this.sqlServerEFxceptionService.ThrowMeaningfulException(dbUpdateException));
        }
    }
}
