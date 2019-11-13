using System;
using System.Collections.Generic;
using System.Text;

namespace ApacheJenaSample.Exporter.Extensions
{
    public static class StringExtensions
    {
        public static String ToSafeString(this Uri u)
        {
            return (u != null ? u.AbsoluteUri : String.Empty);
        }
    }
}
