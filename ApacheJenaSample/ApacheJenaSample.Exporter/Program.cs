// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ApacheJenaSample.Csv.Aotp.Parser;
using ApacheJenaSample.Exporter.Dto;
using ApacheJenaSample.Exporter.Extensions;
using TinyCsvParser;
using VDS.RDF;
using VDS.RDF.Nodes;
using VDS.RDF.Parsing;
using VDS.RDF.Storage;

namespace ApacheJenaSample.Exporter
{
    public static class DotNetRdfHelpers
    {
        public static INode AsVariableNode(this INodeFactory nodeFactory, string value)
        {
            return nodeFactory.CreateVariableNode(value);
        }

        public static INode AsUriNode(this INodeFactory nodeFactory, Uri uri)
        {
            return nodeFactory.CreateUriNode(uri);
        }

        public static INode AsLiteralNode(this INodeFactory nodeFactory, string value)
        {
            return nodeFactory.CreateLiteralNode(value);
        }

        public static INode AsLiteralNode(this INodeFactory nodeFactory, string value, string langspec)
        {
            return nodeFactory.CreateLiteralNode(value, langspec);
        }

        public static INode AsBlankNode(this INodeFactory nodeFactory, string nodeId)
        {
            return nodeFactory.CreateBlankNode(nodeId);
        }

        public static INode AsValueNode(this INodeFactory nodeFactory, object value)
        {
            if (value == null)
            {
                return null;
            }

            switch (value)
            {
                case Uri uriValue:
                    return nodeFactory.CreateUriNode(uriValue);

                case bool boolValue:
                    return new BooleanNode(null, boolValue);

                case byte byteValue:
                    return new ByteNode(null, byteValue);

                case DateTime dateTimeValue:
                    return new DateTimeNode(null, dateTimeValue);

                case DateTimeOffset dateTimeOffsetValue:
                    return new DateTimeNode(null, dateTimeOffsetValue);

                case decimal decimalValue:
                    return new DecimalNode(null, decimalValue);

                case double doubleValue:
                    return new DoubleNode(null, doubleValue);

                case float floatValue:
                    return new FloatNode(null, floatValue);

                case long longValue:
                    return new LongNode(null, longValue);

                case int intValue:
                    return new LongNode(null, intValue);

                case string stringValue:
                    return new StringNode(null, stringValue, UriFactory.Create(XmlSpecsHelper.XmlSchemaDataTypeString));

                case char charValue:
                    return new StringNode(null, charValue.ToString(), UriFactory.Create(XmlSpecsHelper.XmlSchemaDataTypeString));

                case TimeSpan timeSpanValue:
                    return new TimeSpanNode(null, timeSpanValue);

                default:
                    throw new InvalidOperationException($"Can't convert type {value.GetType()}");
            }
        }
    }

    public class Program
    {
        /// <summary>
        /// Master Coordination Data.
        /// </summary>
        private static string csvAirportFile = @"D:\flights_data\aotp\master_cord.csv";

        /// <summary>
        /// FAA Aircraft Data.
        /// </summary>
        private static string csvAircraftsFile = @"D:\flights_data\faa\FAA_AircraftRegistration_Database.csv";

        /// <summary>
        /// Carriers.
        /// </summary>
        private static string csvCarriersFile = @"D:\flights_data\aotp\unqiue_carriers.csv";

        /// <summary>
        /// Weather Stations.
        /// </summary>
        private static string csvWeatherStationsFileName = @"D:\flights_data\ncar\stations.txt";

        /// <summary>
        /// Flight Data.
        /// </summary>
        private static string[] csvFlightStatisticsFiles
        {
            get
            {
                return new[] { @"D:\flights_data\aotp\2014\airOT201401.csv" };
                //return Directory.GetFiles(@"D:\flights_data\aotp\2014", "*.csv");
            }
        }

        /// <summary>
        /// Weather Data.
        /// </summary>
        private static string[] csvWeatherDataFiles
        {
            get
            {
                return Directory.GetFiles(@"D:\flights_data\asos\2014", "*.txt");
            }
        }

        private static INodeFactory nodeFactory = new NodeFactory();

        public static void Main(string[] args)
        {
            // Use Apache Jena Fuseki Connector:
            using (var connector = new FusekiConnector("http://localhost:3030/aviation/data"))
            {

                // Write Aircrafts:
                var aircrafts = GetAircraftData(csvAircraftsFile).ToList();
                var carriers = GetCarrierData(csvCarriersFile).ToList();
                var airports = GetAirportData(csvAirportFile).ToList();
                var stations = GetWeatherStationData(csvWeatherStationsFileName).ToList();

                WriteAircrafts(connector, aircrafts);
                WriteAirports(connector, airports);
                WriteCarriers(connector, carriers);
                WriteFlights(connector, aircrafts, airports, carriers);
                WriteWeatherStations(connector, stations, airports);
                WriteWeatherDatas(connector, stations);
            }
        }

        private static void WriteAircrafts(IStorageProvider connector, IEnumerable<AircraftDto> aircrafts)
        {
            foreach (var batch in aircrafts
                .SelectMany(x => ConvertAircraft(x))
                .Batch(1000))
            {
                AddTriples(connector, batch);
            }
        }

        private static List<Triple> ConvertAircraft(AircraftDto aircraft)
        {
            return new TripleBuilder(nodeFactory.AsUriNode(aircraft.Uri))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.Type), nodeFactory.AsValueNode(Constants.Types.Airport))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftEngineHorsepower), nodeFactory.AsValueNode(aircraft.EngineHorsepower))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftEngineManufacturer), nodeFactory.AsValueNode(aircraft.EngineManufacturer))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftEngineModel), nodeFactory.AsValueNode(aircraft.EngineModel))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftEngineThrust), nodeFactory.AsValueNode(aircraft.EngineThrust))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftManufacturer), nodeFactory.AsValueNode(aircraft.AircraftManufacturer))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftModel), nodeFactory.AsValueNode(aircraft.AircraftModel))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftN_Number), nodeFactory.AsValueNode(aircraft.N_Number))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftSeats), nodeFactory.AsValueNode(aircraft.AircraftSeats))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftSerialNumber), nodeFactory.AsValueNode(aircraft.SerialNumber))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AircraftUniqueId), nodeFactory.AsValueNode(aircraft.UniqueId))
                    .Build();
        }

        private static void WriteAirports(IStorageProvider connector, IEnumerable<AirportDto> airports)
        {
            foreach (var batch in airports
                .SelectMany(x => ConvertAirport(x))
                .Batch(1000))
            {
                AddTriples(connector, batch);
            }
        }

        private static List<Triple> ConvertAirport(AirportDto airport)
        {
            return new TripleBuilder(nodeFactory.AsUriNode(airport.Uri))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.Type), nodeFactory.AsValueNode(Constants.Types.Airport))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AirportId), nodeFactory.AsValueNode(airport.AirportId))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AirportIata), nodeFactory.AsValueNode(airport.IATA))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AirportName), nodeFactory.AsValueNode(airport.Name))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AirportCity), nodeFactory.AsValueNode(airport.City))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AirportState), nodeFactory.AsValueNode(airport.State))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.AirportCountry), nodeFactory.AsValueNode(airport.Country))
                    .Build();
        }

        private static void WriteCarriers(IStorageProvider connector, IEnumerable<CarrierDto> carriers)
        {
            foreach (var batch in carriers
                .SelectMany(x => ConvertCarrier(x))
                .Batch(1000))
            {
                AddTriples(connector, batch);
            }
        }

        private static List<Triple> ConvertCarrier(CarrierDto carrier)
        {
            return new TripleBuilder(nodeFactory.AsUriNode(carrier.Uri))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.Type), nodeFactory.AsValueNode(Constants.Types.Carrier))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.CarrierCode), nodeFactory.AsValueNode(carrier.Code))
                    .Add(nodeFactory.AsUriNode(Constants.Predicates.CarrierDescription), nodeFactory.AsValueNode(carrier.Description))
                    .Build();
        }

        private static void WriteFlights(IStorageProvider connector, List<AircraftDto> aircrafts, List<AirportDto> airports, List<CarrierDto> carriers)
        {
            // Build Lookup Tables. We group by a criteria, to prevent duplicates 
            // from being used as dictionary keys.
            var aircraftNodes = aircrafts
                .GroupBy(x => x.N_Number).Select(x => x.First())
                .ToDictionary(x => x.N_Number, x => x);

            var airportNodes = airports
                .GroupBy(x => x.AirportId).Select(x => x.First())
                .ToDictionary(x => x.AirportId, x => x);

            var carrierNodes = carriers
                .GroupBy(x => x.Code).Select(x => x.First())
                .ToDictionary(x => x.Code, x => x);

            foreach (var csvFlightStatisticsFile in csvFlightStatisticsFiles)
            {
                var flights = GetFlightData(csvFlightStatisticsFile);

                foreach (var batch in flights
                    .SelectMany(x => ConvertFlight(x, aircraftNodes, airportNodes, carrierNodes))
                    .Batch(5000))
                {
                    AddTriples(connector, batch);
                }
            }
        }

        private static List<Triple> ConvertFlight(FlightDto flight, Dictionary<string, AircraftDto> aircrafts, Dictionary<string, AirportDto> airports, Dictionary<string, CarrierDto> carriers)
        {
            var triples = new TripleBuilder(nodeFactory.AsUriNode(flight.Uri));

            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.Type), nodeFactory.AsValueNode(Constants.Types.Flight));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightNumber), nodeFactory.AsValueNode(flight.FlightNumber));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightTailNumber), nodeFactory.AsValueNode(flight.TailNumber));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightDate), nodeFactory.AsValueNode(flight.FlightDate));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightDayOfWeek), nodeFactory.AsValueNode(flight.DayOfWeek));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightDayOfMonth), nodeFactory.AsValueNode(flight.DayOfMonth));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightMonth), nodeFactory.AsValueNode(flight.Month));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightYear), nodeFactory.AsValueNode(flight.Year));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightDistance), nodeFactory.AsValueNode(flight.Distance));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightArrivalDelay), nodeFactory.AsValueNode(flight.ArrivalDelay));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightCarrierDelay), nodeFactory.AsValueNode(flight.CarrierDelay));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightDepartureDelay), nodeFactory.AsValueNode(flight.DepartureDelay));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightLateAircraftDelay), nodeFactory.AsValueNode(flight.LateAircraftDelay));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightNasDelay), nodeFactory.AsValueNode(flight.NasDelay));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightSecurityDelay), nodeFactory.AsValueNode(flight.SecurityDelay));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightWeatherDelay), nodeFactory.AsValueNode(flight.WeatherDelay));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightScheduledDepartureTime), nodeFactory.AsValueNode(flight.ScheduledDepartureTime));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.FlightActualDepartureTime), nodeFactory.AsValueNode(flight.ActualDepartureTime));

            // Add Relations:
            if (aircrafts.TryGetValue(flight.TailNumber, out AircraftDto aircraft))
            {
                triples.Add(nodeFactory.AsUriNode(Constants.Predicates.HasAircraft), nodeFactory.AsUriNode(aircraft.Uri));
            }

            if (airports.TryGetValue(flight.OriginAirport, out AirportDto originAirport))
            {
                triples.Add(nodeFactory.AsUriNode(Constants.Predicates.HasOriginAirport), nodeFactory.AsUriNode(originAirport.Uri));
            }

            if (airports.TryGetValue(flight.DestinationAirport, out AirportDto destinationAirport))
            {
                triples.Add(nodeFactory.AsUriNode(Constants.Predicates.HasDestinationAirport), nodeFactory.AsUriNode(destinationAirport.Uri));
            }

            if (carriers.TryGetValue(flight.Carrier, out CarrierDto carrier))
            {
                triples.Add(nodeFactory.AsUriNode(Constants.Predicates.HasCarrier), nodeFactory.AsUriNode(carrier.Uri));
            }

            return triples.Build();
        }

        private static void WriteWeatherStations(IStorageProvider connector, IEnumerable<WeatherStationDto> stations, IEnumerable<AirportDto> airports)
        {
            var airportNodes = airports
                .GroupBy(x => x.AirportId).Select(x => x.First())
                .ToDictionary(x => x.AirportId, x => x);

            foreach (var batch in stations
                .SelectMany(x => ConvertWeatherStation(x, airportNodes))
                .Batch(1000))
            {
                AddTriples(connector, batch);
            }
        }

        private static List<Triple> ConvertWeatherStation(WeatherStationDto station, Dictionary<string, AirportDto> airports)
        {
            var triples = new TripleBuilder(nodeFactory.AsUriNode(station.Uri));

            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.Type), nodeFactory.AsValueNode(Constants.Types.WeatherStation));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.WeatherStationIata), nodeFactory.AsValueNode(station.IATA));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.WeatherStationName), nodeFactory.AsValueNode(station.Station));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.WeatherStationIcao), nodeFactory.AsValueNode(station.ICAO));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.WeatherStationLat), nodeFactory.AsValueNode(station.Latitude));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.WeatherStationLon), nodeFactory.AsValueNode(station.Longitude));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.WeatherStationSynop), nodeFactory.AsValueNode(station.SYNOP));
            triples.Add(nodeFactory.AsUriNode(Constants.Predicates.WeatherStationElevation), nodeFactory.AsValueNode(station.Elevation));

            if (airports.TryGetValue(station.IATA, out AirportDto airport))
            {
                triples.Add(nodeFactory.AsUriNode(Constants.Predicates.HasWeatherStation), nodeFactory.AsUriNode(airport.Uri));
            }

            return triples.Build();
        }

        private static void WriteWeatherDatas(IStorageProvider connector, IEnumerable<WeatherStationDto> stations)
        {
            var stationNodes = stations
                .GroupBy(x => x.IATA).Select(x => x.First())
                .ToDictionary(x => x.IATA, x => x);

            foreach (var csvWeatherDataFile in csvWeatherDataFiles)
            {
                var weatherDataList = GetWeatherData(csvWeatherDataFile).AsEnumerable();

                foreach(var batch in weatherDataList
                    .SelectMany(x => ConvertWeatherData(x, stationNodes))
                    .Batch(1000))
                {
                    AddTriples(connector, batch);
                }
            }
        }

        private static List<Triple> ConvertWeatherData(WeatherDataDto weather, Dictionary<string, WeatherStationDto> stations)
        {
            var triples = new TripleBuilder(nodeFactory.AsUriNode(weather.Uri));

            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.Type), nodeFactory.AsValueNode(Constants.Types.WeatherData));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataStation), nodeFactory.AsValueNode(weather.station));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataAlti), nodeFactory.AsValueNode(weather.alti));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataDrct), nodeFactory.AsValueNode(weather.drct));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataDwpc), nodeFactory.AsValueNode(weather.dwpc));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataDwpf), nodeFactory.AsValueNode(weather.dwpf));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataFeelc), nodeFactory.AsValueNode(weather.feelc));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataFeelf), nodeFactory.AsValueNode(weather.feelf));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataGust), nodeFactory.AsValueNode(weather.gust));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataIceAccretion1hr), nodeFactory.AsValueNode(weather.ice_accretion_1hr));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataIceAccretion3hr), nodeFactory.AsValueNode(weather.ice_accretion_3hr));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataIceAccretion6hr), nodeFactory.AsValueNode(weather.ice_accretion_6hr));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataLatitude), nodeFactory.AsValueNode(weather.lat));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataLongitude), nodeFactory.AsValueNode(weather.lon));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataMetar), nodeFactory.AsValueNode(weather.metar));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataMslp), nodeFactory.AsValueNode(weather.mslp));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataP01i), nodeFactory.AsValueNode(weather.p01i));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataPeakWindDrct), nodeFactory.AsValueNode(weather.peak_wind_drct));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataPeakWindGust), nodeFactory.AsValueNode(weather.peak_wind_gust));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataPeakWindTime_hh), nodeFactory.AsValueNode(weather.peak_wind_time_hh));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataPeakWindTime_MM), nodeFactory.AsValueNode(weather.peak_wind_time_MM));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataRelh), nodeFactory.AsValueNode(weather.relh));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataSknt), nodeFactory.AsValueNode(weather.sknt));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataSkyc1), nodeFactory.AsValueNode(weather.skyc1));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataSkyc2), nodeFactory.AsValueNode(weather.skyc2));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataSkyc3), nodeFactory.AsValueNode(weather.skyc3));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataSkyc4), nodeFactory.AsValueNode(weather.skyc4));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataSkyl1), nodeFactory.AsValueNode(weather.skyl1));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataSkyl2), nodeFactory.AsValueNode(weather.skyl2));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataSkyl3), nodeFactory.AsValueNode(weather.skyl3));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataSkyl4), nodeFactory.AsValueNode(weather.skyl4));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataTimestamp), nodeFactory.AsValueNode(weather.valid));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataTmpc), nodeFactory.AsValueNode(weather.tmpc));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataTmpf), nodeFactory.AsValueNode(weather.tmpf));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataVsbyKm), nodeFactory.AsValueNode(weather.vsby_km));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataVsbyMi), nodeFactory.AsValueNode(weather.vsby_mi));
            triples.Add(nodeFactory.CreateUriNode(Constants.Predicates.WeatherDataWxcodes), nodeFactory.AsValueNode(weather.wxcodes));

            if (stations.TryGetValue(weather.station, out WeatherStationDto station))
            {
                triples.Add(nodeFactory.AsUriNode(Constants.Predicates.HasWeatherStation), nodeFactory.AsUriNode(station.Uri));
            }

            return triples.Build();
        }

        #region CSV Parsing 

        private static ParallelQuery<CarrierDto> GetCarrierData(string filename)
        {
            return Parsers.CarrierParser
                // Parse as ASCII file:
                .ReadFromFile(filename, Encoding.ASCII)
                // Only use valid lines:
                .Where(x => x.IsValid)
                // Get the Result:
                .Select(x => x.Result)
                // Get Carrier:
                .Select(x => new CarrierDto
                {
                    Code = x.Code,
                    Description = x.Description
                });
        }

        private static ParallelQuery<AircraftDto> GetAircraftData(string filename)
        {
            return Csv.Faa.Parser.Parsers.FaaAircraftParser
                // Parse as ASCII file:
                .ReadFromFile(filename, Encoding.ASCII)
                // Only use valid lines:
                .Where(x => x.IsValid)
                // Get the Result:
                .Select(x => x.Result)
                // Get Carrier:
                .Select(x => new AircraftDto
                {
                    AircraftManufacturer = x.AircraftManufacturer,
                    AircraftModel = x.AircraftModel,
                    AircraftSeats = x.AircraftSeats,
                    EngineHorsepower = x.EngineHorsepower,
                    EngineManufacturer = x.EngineManufacturer,
                    EngineModel = x.EngineModel,
                    EngineThrust = x.EngineThrust,
                    N_Number = x.N_Number,
                    SerialNumber = x.SerialNumber,
                    UniqueId = x.UniqueId
                });
        }

        private static ParallelQuery<AirportDto> GetAirportData(string filename)
        {
            return Parsers.AirportParser
                // Read from the Master Coordinate CSV File:
                .ReadFromFile(filename, Encoding.ASCII)
                // Only take valid entities:
                .Where(x => x.IsValid)
                // Get the parsed result:
                .Select(x => x.Result)
                // Only select the latest available data:
                .Where(x => x.AirportIsLatest)
                // Build the intermediate Airport Information:
                .Select(x => new AirportDto
                {
                    AirportId = x.AirportId,
                    IATA = x.AirportIata,
                    Name = x.AirportName,
                    City = x.AirportCityName,
                    Country = x.AirportCountryName,
                    State = x.AirportStateName,
                });
        }

        private static ParallelQuery<FlightDto> GetFlightData(string filename)
        {
            return Parsers.FlightStatisticsParser
                // Read from the Master Coordinate CSV File:
                .ReadFromFile(filename, Encoding.ASCII)
                // Only take valid entities:
                .Where(x => x.IsValid)
                // Get the parsed result:
                .Select(x => x.Result)
                // Return the Graph Model:
                .Select(x => new FlightDto
                {
                    FlightNumber = x.FlightNumber,
                    Year = x.Year,
                    Month = x.Month,
                    DayOfMonth = x.DayOfMonth,
                    DayOfWeek = x.DayOfWeek,
                    Carrier = x.UniqueCarrier,
                    OriginAirport = x.OriginAirport,
                    DestinationAirport = x.DestinationAirport,
                    TailNumber = x.TailNumber,
                    ArrivalDelay = x.ArrivalDelay,
                    CancellationCode = x.CancellationCode,
                    DepartureDelay = x.DepartureDelay,
                    CarrierDelay = x.CarrierDelay,
                    Distance = x.Distance,
                    LateAircraftDelay = x.LateAircraftDelay,
                    NasDelay = x.NasDelay,
                    SecurityDelay = x.SecurityDelay,
                    WeatherDelay = x.WeatherDelay,
                    FlightDate = x.FlightDate,
                    ActualDepartureTime = x.ActualDepartureTime,
                    ScheduledDepartureTime = x.ScheduledDepartureTime
                });
        }

        private static ParallelQuery<WeatherStationDto> GetWeatherStationData(string filename)
        {
            return Csv.Ncar.Parser.Parsers.MetarStationParser
                // Read from the Master Coordinate CSV File:
                .ReadFromFile(filename, Encoding.ASCII)
                // Only take valid entities:
                .Where(x => x.IsValid)
                // Get the parsed result:
                .Select(x => x.Result)
                // Return the Graph Model:
                .Select(x => new WeatherStationDto
                {
                    Station = x.Station,
                    Elevation = x.Elevation,
                    IATA = x.IATA,
                    ICAO = x.ICAO,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    SYNOP = x.SYNOP
                });
        }

        private static ParallelQuery<WeatherDataDto> GetWeatherData(string filename)
        {
            return Csv.Asos.Parser.Parsers.AsosDatasetParser
                // Read from the Master Coordinate CSV File:
                .ReadFromFile(filename, Encoding.ASCII)
                // Only take valid entities:
                .Where(x => x.IsValid)
                // Get the parsed result:
                .Select(x => x.Result)
                // Return the Graph Model:
                .Select(x => new WeatherDataDto
                {
                    alti = x.alti,
                    drct = x.drct,
                    dwpf = x.dwpf,
                    dwpc = ConvertFahrenheitToCelsius(x.dwpf),
                    feelf = x.feel,
                    feelc = ConvertFahrenheitToCelsius(x.feel),
                    gust = x.gust,
                    ice_accretion_1hr = x.ice_accretion_1hr,
                    ice_accretion_3hr = x.ice_accretion_3hr,
                    ice_accretion_6hr = x.ice_accretion_6hr,
                    lat = x.lat,
                    lon = x.lon,
                    metar = x.metar,
                    mslp = x.mslp,
                    p01i = x.p01i,
                    peak_wind_drct = x.peak_wind_drct,
                    peak_wind_gust = x.peak_wind_gust,
                    peak_wind_time_hh = x.peak_wind_time.HasValue ? x.peak_wind_time.Value.Hours : default(int?),
                    peak_wind_time_MM = x.peak_wind_time.HasValue ? x.peak_wind_time.Value.Minutes : default(int?),
                    relh = x.relh,
                    sknt = x.sknt,
                    skyc1 = x.skyc1,
                    skyc2 = x.skyc2,
                    skyc3 = x.skyc3,
                    skyc4 = x.skyc4,
                    skyl1 = x.skyl1,
                    skyl2 = x.skyl2,
                    skyl3 = x.skyl3,
                    skyl4 = x.skyl4,
                    station = x.station,
                    tmpf = x.tmpf,
                    tmpc = ConvertFahrenheitToCelsius(x.tmpf),
                    valid = x.valid,
                    vsby_mi = x.vsby,
                    vsby_km = ConvertMilesToKilometers(x.vsby),
                    wxcodes = x.wxcodes,
                });
        }

        #endregion

        #region Unit Converters

        public static float? ConvertFahrenheitToCelsius(float? fahrenheit)
        {
            if (!fahrenheit.HasValue)
            {
                return default(float?);
            }

            return (fahrenheit.Value - 32.0f) * 5.0f / 9.0f;
        }

        public static float ConvertFahrenheitToCelsius(float fahrenheit)
        {
            return (fahrenheit - 32.0f) * 5.0f / 9.0f;
        }

        public static float? ConvertMilesToKilometers(float? miles)
        {
            if (!miles.HasValue)
            {
                return default(float?);
            }

            return miles.Value * 1.609344f;
        }

        public static float ConvertMilesToKilometers(float miles)
        {
            return miles * 1.609344f;
        }

        #endregion

        #region Utilities

        public class TripleBuilder
        {
            private readonly INode subj;
            private readonly List<Triple> triples;

            public TripleBuilder(INode subj)
            {
                this.subj = subj;
                this.triples = new List<Triple>();
            }

            public TripleBuilder Add(INode pred, INode obj)
            {
                if(obj == null)
                {
                    return this;
                }

                triples.Add(new Triple(subj, pred, obj));

                return this;
            }

            public List<Triple> Build()
            {
                return triples;
            }
        }

        private static void AddTriples(IStorageProvider connector, IEnumerable<Triple> triples)
        {
            connector.UpdateGraph("/aviation", triples, new Triple[] { });
        }

        #endregion

    }
}