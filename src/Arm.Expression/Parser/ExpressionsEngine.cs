// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using Arm.Expression.Expressions;

namespace Arm.Expression.Parser
{
    public static class ExpressionsEngine
    {
        /// <summary>
        /// Determines whether specified value is language expression.
        /// </summary>
        /// <param name="expression">The language expression.</param>
        public static bool IsLanguageExpression(string expression)
        {
            return ExpressionParser.IsLanguageExpression(expression: expression);
        }

        /// <summary>
        /// Parses the language expression.
        /// </summary>
        /// <param name="expression">The language expression.</param>
        /// <param name="additionalInfo">The additional Info of the expression.</param>
        public static LanguageExpression ParseLanguageExpression(string expression, TemplateErrorAdditionalInfo additionalInfo = null)
        {
            return ExpressionParser.ParseLanguageExpression(expression, additionalInfo);
        }
    }
}