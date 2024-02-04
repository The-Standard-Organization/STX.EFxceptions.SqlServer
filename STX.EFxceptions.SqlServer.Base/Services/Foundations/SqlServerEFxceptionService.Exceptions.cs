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
            }
        }
    }
}
