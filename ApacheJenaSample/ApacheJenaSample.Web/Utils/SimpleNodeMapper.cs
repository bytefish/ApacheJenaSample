// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using ApacheJenaSample.Web.Model;
using VDS.RDF;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;

namespace ApacheJenaSample.Web.Utils
{
    public class SimpleNodeMapper
    {
        private ConcurrentDictionary<string, VisNode> nodes;

        private long nextNodeId;

        public SimpleNodeMapper()
        {
            this.nodes = new ConcurrentDictionary<string, VisNode>();
            this.nextNodeId = 0;
        }

        public VisNode MapNode(INode node)
        {
            var nodeString = RdfUtils.MakeNodeString(node);

            return nodes.GetOrAdd(nodeString, (key) =>
            {
                Interlocked.Increment(ref nextNodeId);

                return new VisNode()
                {
                    Id = nextNodeId,
                    Label = key
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
