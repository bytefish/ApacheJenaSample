// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ApacheJenaSample.Exporter.Extensions;
using System;

namespace ApacheJenaSample.Exporter.Dto
{
    public class WeatherStationDto
    {
        public Uri Uri => UriHelper.SetFragment(Constants.NsAviationWeatherStation, $"weather_station_{IATA}_{ICAO}");

        /// <summary>
        /// 16 character station long name
        /// </summary>
        public string Station { get; set; }

        /// <summary>
        /// 4-character international id
        /// </summary>
        public string ICAO { get; set; }

        /// <summary>
        /// 3-character(FAA) id
        /// </summary>
        public string IATA { get; set; }

        /// <summary>
        /// 5-digit international synoptic number
        /// </summary>
        public string SYNOP { get; set; }

        /// <summary>
        /// Latitude(degrees minutes)
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// Longitude(degree minutes)
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// Station elevation(meters)
        /// </summary>
        public float? Elevation { get; set; }
    }
}
