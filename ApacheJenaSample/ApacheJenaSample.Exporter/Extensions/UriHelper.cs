// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace ApacheJenaSample.Exporter.Extensions
{
    public static class UriHelper
    {
        public static Uri Create(Uri baseUri, string path, string fragment)
        {
            var builder = new UriBuilder(baseUri);

            builder.Path = path;
            builder.Fragment = fragment;

            return builder.Uri;
        }


        public static Uri AppendFragment(Uri uri, string fragment)
        {
            var builder = new UriBuilder(uri);

            builder.Fragment = fragment;

            return builder.Uri;
        }

        public static Uri Combine(Uri uri, string path)
        {
            var absoluteUri = uri.AbsoluteUri;
            var left = absoluteUri.TrimEnd('/');
            var right = path.TrimStart('/');

            return new Uri($"{left}/{right}");
        }
    }
}
