// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace ApacheJenaSample.Exporter.Extensions
{
    public static class StringExtensions
    {
        public static string ToSafeString(this Uri u)
        {
            return (u != null ? u.AbsoluteUri : String.Empty);
        }
    }
}
