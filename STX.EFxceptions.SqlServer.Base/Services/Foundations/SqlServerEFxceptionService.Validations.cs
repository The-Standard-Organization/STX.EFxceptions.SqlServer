// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace STX.EFxceptions.SqlServer.Base.Services.Foundations
{
    public partial class SqlServerEFxceptionService
    {
        private void ValidateInnerException(DbUpdateException dbUpdateException)
        {
            if (dbUpdateException.InnerException == null)
            {
                throw dbUpdateException;
            }
        }
    }
}
