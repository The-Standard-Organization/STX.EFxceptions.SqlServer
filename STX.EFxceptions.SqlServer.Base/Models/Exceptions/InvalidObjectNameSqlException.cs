// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.SqlServer.Base.Models.Exceptions
{
    public class InvalidObjectNameSqlException : DbUpdateException
    {
        public InvalidObjectNameSqlException(string message) : base(message) { }
    }
}
