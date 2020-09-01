// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arm.Expression.Parser
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Performs the specified action on each element of source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The delegate to perform on each element of source.</param>
        public static TSource[] ForEach<TSource>(this TSource[] source, Action<TSource> action)
        {
            foreach (var item in source)
            {
                action(item);
            }

            return source;
        }

        /// <summary>
        /// Performs the specified action on each element of source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The delegate to perform on each element of source.</param>
        public static IList<TSource> ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            var sourceAsList = source.ToList();

            sourceAsList.ForEach(action);

            return sourceAsList;
        }

        /// <summary>
        /// Performs the specified action on each element of source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The delegate to perform on each element of source.</param>
        public static TSource[] ForEach<TSource>(this TSource[] source, Action<TSource, int> action)
        {
            for (var i = 0; i < source.Length; i++)
            {
                action(source[i], i);
            }

            return source;
        }

        /// <summary>
        /// Performs the specified action on each element of source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The delegate to perform on each element of source.</param>
        public static List<TSource> ForEach<TSource>(this List<TSource> source, Action<TSource, int> action)
        {
            for (var i = 0; i < source.Count; i++)
            {
                action(source[i], i);
            }

            return source;
        }
    }
}