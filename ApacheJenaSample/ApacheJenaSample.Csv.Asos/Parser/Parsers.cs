// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ApacheJenaSample.Csv.Asos.Mapper;
using ApacheJenaSample.Csv.Asos.Model;
using TinyCsvParser;

namespace ApacheJenaSample.Csv.Asos.Parser
{
    public static class Parsers
    {
        public static CsvParser<AsosMeasurement> AsosDatasetParser
        {
            get
            {
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');

                return new CsvParser<AsosMeasurement>(csvParserOptions, new AsosMeasurementMapper());
            }
        }

    }
}