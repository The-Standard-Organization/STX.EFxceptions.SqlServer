// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.SqlServer.Base.Models.Exceptions
{
    public class InvalidColumnNameSqlException : DbUpdateException
    {
        public InvalidColumnNameSqlException(string message) : base(message) { }
    }
}
