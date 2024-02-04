// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using STX.EFxceptions.SqlServer.Base.Models.Exceptions;

namespace STX.EFxceptions.SqlServer.Base.Services.Foundations
{
    public partial class SqlServerEFxceptionService
    {
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
