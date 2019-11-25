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
            endpointUri = new Uri("http://localhost:3030/aviation/query");

            var endpoint = new SparqlRemoteEndpoint(endpointUri);

            var result = endpoint.QueryWithResultGraph(sparqlQuery);

            return Convert(result);
        }
        
        private static VisDataSet Convert(IGraph graph)
        {
            var nodeMapper = new VisNodeMapper();
            var edges = new List<VisEdge>();

            var triples = graph.Triples;

            foreach (var triple in triples)
            {
                VisNode fromNode = nodeMapper.MapNode(triple.Subject);
                VisNode toNode = nodeMapper.MapNode(triple.Object);

                // As Edge Label we simply use the URI Name:
                var edge = new VisEdge
                {
                    From = fromNode.Id,
                    To = toNode.Id,
                    Label = RdfUtils.MakeNodeString(triple.Predicate)
                };

                edges.Add(edge);
            }

            var nodes = nodeMapper.GetNodes();

            return new VisDataSet
            {
                Nodes = nodes,
                Edges = edges
            };
        }
    }
}
