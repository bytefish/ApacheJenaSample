// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ApacheJenaSample.Exporter.Extensions;
using System;
using System.Xml;

namespace ApacheJenaSample.Exporter.Dto
{
    public class AircraftDto
    {
        public Uri Uri => UriHelper.SetFragment(Constants.NsAviationtAircraft, XmlConvert.EncodeName($"aircraft_{N_Number}"));

        public string N_Number { get; set; }

        public string SerialNumber { get; set; }

        public string UniqueId { get; set; }

        public string AircraftManufacturer { get; set; }

        public string AircraftModel { get; set; }

        public string AircraftSeats { get; set; }

        public string EngineManufacturer { get; set; }

        public string EngineModel { get; set; }

        public float? EngineHorsepower { get; set; }

        public float? EngineThrust { get; set; }
    }
}
