// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using VDS.RDF;

namespace ApacheJenaSample.Web.Utils
{
    public static class RdfUtils
    {
        public static string MakeNodeString(INode node)
        {
            var uriNode = node as IUriNode;

            if (uriNode != null)
            {
                string fragment = uriNode.Uri.Fragment?.Trim('#');

                if(string.IsNullOrWhiteSpace(fragment))
                {
                    return uriNode.Uri.Fragment;
                }

                return fragment;
            }

            var blankNode = node as IBlankNode;

            if (blankNode != null)
            {
                return "_:" + blankNode.InternalID;
            }

            throw new ArgumentException("Node must be a blank node or URI node", nameof(node));
        }
    }
}
