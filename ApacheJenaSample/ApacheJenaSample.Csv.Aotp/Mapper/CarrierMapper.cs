// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ApacheJenaSample.Csv.Aotp.Model;
using TinyCsvParser.Mapping;

namespace ApacheJenaSample.Csv.Aotp.Mapper
{
    public class CarrierMapper : CsvMapping<Carrier>
    {
        public CarrierMapper()
        {
            MapProperty(0, x => x.Code);
            MapProperty(1, x => x.Description);
        }
    }
}
