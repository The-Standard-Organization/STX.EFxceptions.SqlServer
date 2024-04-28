// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using System.Runtime.Serialization;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Moq;
using STX.EFxceptions.SqlServer.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.SqlServer.Base.Services.Foundations;
using Tynamix.ObjectFiller;

namespace STX.EFxceptions.SqlServer.Base.Tests.Unit.Services.Foundations
{
    public partial class SqlServerEFxceptionServiceTests
    {
        private readonly Mock<ISqlServerErrorBroker> sqlServerErrorBrokerMock;
        private readonly ISqlServerEFxceptionService sqlServerEFxceptionService;

        public SqlServerEFxceptionServiceTests()
        {
            this.sqlServerErrorBrokerMock = new Mock<ISqlServerErrorBroker>();

            this.sqlServerEFxceptionService = new SqlServerEFxceptionService(
                sqlServerErrorBroker: this.sqlServerErrorBrokerMock.Object);
        }

        private string CreateRandomErrorMessage() => new MnemonicString().GetValue();

        private SqlException CreateSqlException(string message, int errorCode)
        {
            SqlException sqlException = 
                (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));

            FieldInfo messageField = typeof(SqlException).GetField(
                name: "_message",
                bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic);

            if (messageField != null)
                messageField.SetValue(sqlException, message);

            FieldInfo errorCodeField = typeof(SqlException).GetField(
                name: "_errorCode",
                bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic);

            if (errorCodeField != null)
                errorCodeField.SetValue(sqlException, errorCode);

            return sqlException;
        }
    }
}
