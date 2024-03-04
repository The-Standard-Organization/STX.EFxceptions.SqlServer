// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace STX.EFxceptions.SqlServer.Base.Models.Exceptions
{
    public class ForeignKeyConstraintConflictSqlException : Exception
    {
        public ForeignKeyConstraintConflictSqlException(string message) : base(message) { } 
    }
}
