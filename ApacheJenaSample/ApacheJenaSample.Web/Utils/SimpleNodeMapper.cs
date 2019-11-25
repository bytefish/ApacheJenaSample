// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using ApacheJenaSample.Web.Model;
using VDS.RDF;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;
using System;

namespace ApacheJenaSample.Web.Utils
{
    public class VisNodeMapper
    {
        private ConcurrentDictionary<string, VisNode> nodes;

        private long nextNodeId;

        public VisNodeMapper()
        {
            this.nodes = new ConcurrentDictionary<string, VisNode>();
            this.nextNodeId = 0;
        }

        public VisNode MapNode(INode node)
        {
            switch (node)
            {
                case BlankNode blankNode:
                    return MapSubjectNode(blankNode);
                case UriNode uriNode:
                    return MapSubjectNode(uriNode);
                case ILiteralNode literalNode:
                    return MapLiteralNode(literalNode);
                default:
                    throw new InvalidOperationException($"Can't convert type {node.GetType()}");
            }
        }

        private VisNode MapSubjectNode(INode node)
        {   
            var nodeString = RdfUtils.MakeNodeString(node);

            Interlocked.Increment(ref nextNodeId);

            return nodes.GetOrAdd(nodeString, (key) =>
            {
                return new VisNode()
                {
                    Id = nextNodeId,
                    Label = key
                };
            });
        }

        private VisNode MapLiteralNode(INode node)
        {
            var literalNode = node as BaseLiteralNode;

            if(literalNode == null)
            {
                throw new Exception($"{node} is not a Literal Node");
            }

            Interlocked.Increment(ref nextNodeId);

            return nodes.GetOrAdd($"Literal_{nextNodeId}", (key) =>
            {
                return new VisNode()
                {
                    Id = nextNodeId,
                    Label = literalNode.Value
                };
            });
        }

        public List<VisNode> GetNodes()
        {
            return nodes
                .Select(x => x.Value)
                .ToList();
        }
    }
}
