// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ApacheJenaSample.Exporter.Extensions;
using System;
using System.Xml;

namespace ApacheJenaSample.Exporter.Dto
{
    public class CarrierDto
    {
        public Uri Uri => UriHelper.Combine(Constants.NsAviationCarrier, XmlConvert.EncodeName($"carrier_{Code}"));

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
