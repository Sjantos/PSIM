﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StudBaza.Core
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Returns the set of items, made distinct by the selected value.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="selector">A function that selects a value to determine unique results.</param>
        /// <returns>IEnumerable&lt;TSource&gt;.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            HashSet<TResult> set = new HashSet<TResult>();

            foreach (var item in source)
            {
                var selectedValue = selector(item);

                if (set.Add(selectedValue))
                    yield return item;
            }
        }
    }
}
