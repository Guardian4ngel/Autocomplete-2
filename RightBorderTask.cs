﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы. 
        /// То есть индекс минимального элемента, который НЕ НАЧИНАЕТСЯ с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            // IReadOnlyList похож на List, но у него нет методов модификации списка.
            // Этот код решает задачу, но слишком неэффективно. Замените его на бинарный поиск!
            while (left < right && right!=0)
            {
               var middle = left + (right - left) / 2;
                if(phrases[middle].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    if (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) >= 0
                        && !phrases[middle].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                        right = middle;
                    else
                        left = middle + 1;
                }
                else  if (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) >= 0)
                    left = middle + 1; 
                else
                    right = middle;
            }
            return right;           

        }
    }
}