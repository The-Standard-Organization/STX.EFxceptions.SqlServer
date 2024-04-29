// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Abstractions.Models.Exceptions;
using STX.EFxceptions.SqlServer.Base.Models.Exceptions;

namespace STX.EFxceptions.SqlServer.Base.Services.Foundations
{
    public partial class SqlServerEFxceptionService
    {

        public delegate void ReturningExceptionFunction();

        public void TryCatch(ReturningExceptionFunction returningExceptionFunction)
        {
            try
            {
                returningExceptionFunction();
            }
            catch (InvalidColumnNameSqlException invalidColumnNameSqlException)
            {
                throw new InvalidColumnNameException(
                    message: invalidColumnNameSqlException.Message,
                    innerException: invalidColumnNameSqlException);
            }
            catch (InvalidObjectNameSqlException invalidObjectNameSqlException)
            {
                throw new InvalidObjectNameException(
                    message: invalidObjectNameSqlException.Message,
                    innerException: invalidObjectNameSqlException);
            }
            catch (ForeignKeyConstraintConflictSqlException foreignKeyConstraintConflictSqlException)
            {
                throw new ForeignKeyConstraintConflictException(
                    message: foreignKeyConstraintConflictSqlException.Message,
                    innerException: foreignKeyConstraintConflictSqlException);
            }
            catch (DuplicateKeyWithUniqueIndexSqlException duplicateKeyWithUniqueIndexSqlException)
            {
                throw new DuplicateKeyWithUniqueIndexException(
                    message: duplicateKeyWithUniqueIndexSqlException.Message,
                    innerException: duplicateKeyWithUniqueIndexSqlException);
            }
            catch (DuplicateKeySqlException duplicateKeySqlException)
            {
                throw new DuplicateKeyException(
                    message: duplicateKeySqlException.Message,
                    innerException: duplicateKeySqlException);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        private void ConvertAndThrowMeaningfulException(int sqlErrorCode, string message)
        {
            switch (sqlErrorCode)
            {
                case 207:
                    throw new InvalidColumnNameSqlException(message);
                case 208:
                    throw new InvalidObjectNameSqlException(message);
                case 547:
                    throw new ForeignKeyConstraintConflictSqlException(message);
                case 2601:
                    throw new DuplicateKeyWithUniqueIndexSqlException(message);
                case 2627:
                    throw new DuplicateKeySqlException(message);
            }
        }
    }
}
