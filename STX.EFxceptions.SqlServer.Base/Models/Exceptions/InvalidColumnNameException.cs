﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace STX.EFxceptions.SqlServer.Base.Models.Exceptions
{
    public class InvalidColumnNameException : Exception
    {
        public InvalidColumnNameException(string message) : base(message) { }
    }
}