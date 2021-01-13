using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.Extentions
{
    public static class LivrariaExtentions
    {
        public static bool IsNull<T>(this T value) => value == null;

        public static bool IsNotNull<T>(this T value) => !value.IsNull();

        public static bool IsLessThanZero(this int number) => number <= 0;

        public static bool IsNullOrEmpty(this string source) => string.IsNullOrWhiteSpace(source);
    }
}

