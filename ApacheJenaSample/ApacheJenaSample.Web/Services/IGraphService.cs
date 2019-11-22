// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ApacheJenaSample.Web.Model;
using System;

namespace ApacheJenaSample.Web.Services
{
    public interface IGraphService
    {
        VisDataSet Query(Uri endpointUri, string sparqlQuery);
    }
}
