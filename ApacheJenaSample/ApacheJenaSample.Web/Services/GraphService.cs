// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ApacheJenaSample.Web.Model;
using VDS.RDF.Query;
using VDS.RDF;
using System.Collections.Generic;
using ApacheJenaSample.Web.Utils;
using System;

namespace ApacheJenaSample.Web.Services
{
    public class GraphService : IGraphService
    {
        public VisDataSet Query(Uri endpointUri, string sparqlQuery)
        {
            var endpoint = new SparqlRemoteEndpoint(endpointUri);

            var result = endpoint.QueryWithResultGraph(sparqlQuery);

            return Convert(result);
        }


        private static VisDataSet Convert(IGraph graph)
        {
            var nodeMapper = new SimpleNodeMapper();
            var edges = new List<VisEdge>();

            var triples = graph.Triples;

            foreach (var triple in triples)
            {
                VisNode fromNode = Convert(nodeMapper, triple.Subject);
                VisNode toNode = Convert(nodeMapper, triple.Object);

                // As Edge Label we simply use the URI Name:
                var edge = new VisEdge
                {
                    From = fromNode.Id,
                    To = toNode.Id,
                    Label = RdfUtils.MakeNodeString(triple.Predicate)
                };

                edges.Add(edge);
            }

            return new VisDataSet
            {
                Nodes = nodeMapper.GetNodes(),
                Edges = edges
            };
        }


        private static VisNode Convert(SimpleNodeMapper mapper, INode node)
        {
            switch (node)
            {
                case BlankNode blankNode:
                    return mapper.MapSubjectNode(blankNode);
                case UriNode uriNode:
                    return mapper.MapSubjectNode(uriNode);
                case ILiteralNode literalNode:
                    return mapper.MapLiteralNode(literalNode);
                default:
                    throw new InvalidOperationException($"Can't convert type {node.GetType()}");
            }
        }
    }
}
