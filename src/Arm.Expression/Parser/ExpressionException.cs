// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;

namespace Arm.Expression.Parser
{
    /// <summary>
    /// The expression exception.
    /// </summary>
    public class ExpressionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="additionalInfo">The additional information for the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ExpressionException(string message, TemplateErrorAdditionalInfo additionalInfo = null, Exception innerException = null)
            : base(message, innerException)
        {
            this.TemplateErrorAdditionalInfo = additionalInfo ?? new TemplateErrorAdditionalInfo();
        }

        /// <summary>
        /// Gets the additional info for template error.
        /// </summary>
        public TemplateErrorAdditionalInfo TemplateErrorAdditionalInfo { get; }
    }
}