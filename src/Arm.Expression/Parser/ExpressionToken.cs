// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Diagnostics;

namespace Arm.Expression.Parser
{
    /// <summary>
    /// The expression token.
    /// </summary>
    [DebuggerDisplay("Type = {Type}")]
    public class ExpressionToken
    {
        /// <summary>
        /// The end of data token.
        /// </summary>
        public static readonly ExpressionToken EndOfData = new ExpressionToken
        {
            Type = ExpressionTokenType.EndOfData
        };

        /// <summary>
        /// The begin of data token.
        /// </summary>
        public static readonly ExpressionToken BeginOfData = new ExpressionToken
        {
            Type = ExpressionTokenType.BeginOfData
        };

        /// <summary>
        /// Gets or sets the expression token type.
        /// </summary>
        public ExpressionTokenType Type { get; set; }

        /// <summary>
        /// Gets or sets the expression token value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets the expression string. 
        /// </summary>
        public string ToExpression()
        {
            return this.Type == ExpressionTokenType.Literal
                ? string.Format("'{0}'", this.Value.ToString())
                : this.Value.ToString();
        }
    }
}
