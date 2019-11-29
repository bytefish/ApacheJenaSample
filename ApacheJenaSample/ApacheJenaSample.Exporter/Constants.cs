// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ApacheJenaSample.Exporter.Extensions;
using System;

namespace ApacheJenaSample.Exporter
{
    public static class Constants
    {
        public static readonly Uri NsAviationBaseUri = new Uri("http://www.bytefish.de/aviation/");

        // Ontologies:
        public static readonly Uri NsAviationGeneral = new Uri(NsAviationBaseUri, "General#");
        public static readonly Uri NsAviationtAircraft = new Uri(NsAviationBaseUri, "Aircraft#");
        public static readonly Uri NsAviationAirport = new Uri(NsAviationBaseUri, "Airport#");
        public static readonly Uri NsAviationCarrier = new Uri(NsAviationBaseUri, "Carrier#");
        public static readonly Uri NsAviationFlight = new Uri(NsAviationBaseUri, "Flight#");
        public static readonly Uri NsAviationWeatherStation = new Uri(NsAviationBaseUri, "WeatherStation#");
        public static readonly Uri NsAviationWeather = new Uri(NsAviationBaseUri, "Weather#");

        public static class Types
        {
            public const string Aircraft = "aircraft";
            public const string Flight = "flight";
            public const string Carrier = "carrier";
            public const string Airport = "airport";
            public const string WeatherStation = "weather_station";
            public const string WeatherData = "weather_data";
        }

        public static class Predicates
        {
            public static readonly Uri Type = UriHelper.SetFragment(NsAviationGeneral, "node_type");

            // Airport Data:
            public static readonly Uri AirportId = UriHelper.SetFragment(NsAviationAirport, "airport_id");
            public static readonly Uri AirportName = UriHelper.SetFragment(NsAviationAirport, "name");
            public static readonly Uri AirportIata = UriHelper.SetFragment(NsAviationAirport, "iata");
            public static readonly Uri AirportCity = UriHelper.SetFragment(NsAviationAirport, "city");
            public static readonly Uri AirportState = UriHelper.SetFragment(NsAviationAirport, "state");
            public static readonly Uri AirportCountry = UriHelper.SetFragment(NsAviationAirport, "country");

            // Carrier Data:
            public static readonly Uri CarrierCode = UriHelper.SetFragment(NsAviationCarrier, "code");
            public static readonly Uri CarrierDescription = UriHelper.SetFragment(NsAviationCarrier, "description");

            // Flight Data:
            public static readonly Uri FlightTailNumber = UriHelper.SetFragment(NsAviationFlight, "tail_number");
            public static readonly Uri FlightNumber = UriHelper.SetFragment(NsAviationFlight, "flight_number");
            public static readonly Uri FlightDate = UriHelper.SetFragment(NsAviationFlight, "flight_date");
            public static readonly Uri FlightCarrier = UriHelper.SetFragment(NsAviationFlight, "carrier");
            public static readonly Uri FlightYear = UriHelper.SetFragment(NsAviationFlight, "year");
            public static readonly Uri FlightMonth = UriHelper.SetFragment(NsAviationFlight, "month");
            public static readonly Uri FlightDayOfWeek = UriHelper.SetFragment(NsAviationFlight, "day_of_week");
            public static readonly Uri FlightDayOfMonth = UriHelper.SetFragment(NsAviationFlight, "day_of_month");
            public static readonly Uri FlightCancellationCode = UriHelper.SetFragment(NsAviationFlight, "cancellation_code");
            public static readonly Uri FlightDistance = UriHelper.SetFragment(NsAviationFlight, "distance");
            public static readonly Uri FlightDepartureDelay = UriHelper.SetFragment(NsAviationFlight, "departure_delay");
            public static readonly Uri FlightArrivalDelay = UriHelper.SetFragment(NsAviationFlight, "arrival_delay");
            public static readonly Uri FlightCarrierDelay = UriHelper.SetFragment(NsAviationFlight, "carrier_delay");
            public static readonly Uri FlightWeatherDelay = UriHelper.SetFragment(NsAviationFlight, "weather_delay");
            public static readonly Uri FlightNasDelay = UriHelper.SetFragment(NsAviationFlight, "nas_delay");
            public static readonly Uri FlightSecurityDelay = UriHelper.SetFragment(NsAviationFlight, "security_delay");
            public static readonly Uri FlightLateAircraftDelay = UriHelper.SetFragment(NsAviationFlight, "late_aircraft_delay");
            public static readonly Uri FlightScheduledDepartureTime = UriHelper.SetFragment(NsAviationFlight, "scheduled_departure_time");
            public static readonly Uri FlightActualDepartureTime = UriHelper.SetFragment(NsAviationFlight, "actual_departure_time");

            // Aircraft Data:
            public static readonly Uri AircraftN_Number = UriHelper.SetFragment(NsAviationtAircraft, "n_number");
            public static readonly Uri AircraftSerialNumber = UriHelper.SetFragment(NsAviationtAircraft, "serial_number");
            public static readonly Uri AircraftUniqueId = UriHelper.SetFragment(NsAviationtAircraft, "unique_id");
            public static readonly Uri AircraftManufacturer = UriHelper.SetFragment(NsAviationtAircraft, "manufacturer");
            public static readonly Uri AircraftModel = UriHelper.SetFragment(NsAviationtAircraft, "model");
            public static readonly Uri AircraftSeats = UriHelper.SetFragment(NsAviationtAircraft, "seats");
            public static readonly Uri AircraftEngineManufacturer = UriHelper.SetFragment(NsAviationtAircraft, "engine_manufacturer");
            public static readonly Uri AircraftEngineModel = UriHelper.SetFragment(NsAviationtAircraft, "engine_model");
            public static readonly Uri AircraftEngineHorsepower = UriHelper.SetFragment(NsAviationtAircraft, "engine_horsepower");
            public static readonly Uri AircraftEngineThrust = UriHelper.SetFragment(NsAviationtAircraft, "engine_thrust");

            // Weather Station Data:
            public static readonly Uri WeatherStationIcao = UriHelper.SetFragment(NsAviationWeatherStation, "icao");
            public static readonly Uri WeatherStationName = UriHelper.SetFragment(NsAviationWeatherStation, "name");
            public static readonly Uri WeatherStationIata = UriHelper.SetFragment(NsAviationWeatherStation, "iata");
            public static readonly Uri WeatherStationSynop = UriHelper.SetFragment(NsAviationWeatherStation, "synop");
            public static readonly Uri WeatherStationLat = UriHelper.SetFragment(NsAviationWeatherStation, "lat");
            public static readonly Uri WeatherStationLon = UriHelper.SetFragment(NsAviationWeatherStation, "lon");
            public static readonly Uri WeatherStationElevation = UriHelper.SetFragment(NsAviationWeatherStation, "elevation");

            // Weather Data:
            public static readonly Uri WeatherDataStation = UriHelper.SetFragment(NsAviationWeather, "station");
            public static readonly Uri WeatherDataLongitude = UriHelper.SetFragment(NsAviationWeather, "lon");
            public static readonly Uri WeatherDataLatitude = UriHelper.SetFragment(NsAviationWeather, "lat");
            public static readonly Uri WeatherDataTimestamp = UriHelper.SetFragment(NsAviationWeather, "timestamp");
            public static readonly Uri WeatherDataTmpf = UriHelper.SetFragment(NsAviationWeather, "tmpf");
            public static readonly Uri WeatherDataTmpc = UriHelper.SetFragment(NsAviationWeather, "tmpc");
            public static readonly Uri WeatherDataDwpf = UriHelper.SetFragment(NsAviationWeather, "dwpf");
            public static readonly Uri WeatherDataDwpc = UriHelper.SetFragment(NsAviationWeather, "dwpc");
            public static readonly Uri WeatherDataRelh = UriHelper.SetFragment(NsAviationWeather, "relh");
            public static readonly Uri WeatherDataDrct = UriHelper.SetFragment(NsAviationWeather, "drct");
            public static readonly Uri WeatherDataSknt = UriHelper.SetFragment(NsAviationWeather, "sknt");
            public static readonly Uri WeatherDataP01i = UriHelper.SetFragment(NsAviationWeather, "p01i");
            public static readonly Uri WeatherDataAlti = UriHelper.SetFragment(NsAviationWeather, "alti");
            public static readonly Uri WeatherDataMslp = UriHelper.SetFragment(NsAviationWeather, "mslp");
            public static readonly Uri WeatherDataVsbyMi = UriHelper.SetFragment(NsAviationWeather, "vsby_mi");
            public static readonly Uri WeatherDataVsbyKm = UriHelper.SetFragment(NsAviationWeather, "vsby_km");
            public static readonly Uri WeatherDataGust = UriHelper.SetFragment(NsAviationWeather, "gust");
            public static readonly Uri WeatherDataSkyc1 = UriHelper.SetFragment(NsAviationWeather, "skyc1");
            public static readonly Uri WeatherDataSkyc2 = UriHelper.SetFragment(NsAviationWeather, "skyc2");
            public static readonly Uri WeatherDataSkyc3 = UriHelper.SetFragment(NsAviationWeather, "skyc3");
            public static readonly Uri WeatherDataSkyc4 = UriHelper.SetFragment(NsAviationWeather, "skyc4");
            public static readonly Uri WeatherDataSkyl1 = UriHelper.SetFragment(NsAviationWeather, "skyl1");
            public static readonly Uri WeatherDataSkyl2 = UriHelper.SetFragment(NsAviationWeather, "skyl2");
            public static readonly Uri WeatherDataSkyl3 = UriHelper.SetFragment(NsAviationWeather, "skyl3");
            public static readonly Uri WeatherDataSkyl4 = UriHelper.SetFragment(NsAviationWeather, "skyl4");
            public static readonly Uri WeatherDataWxcodes = UriHelper.SetFragment(NsAviationWeather, "wxcodes");
            public static readonly Uri WeatherDataFeelf = UriHelper.SetFragment(NsAviationWeather, "feelf");
            public static readonly Uri WeatherDataFeelc = UriHelper.SetFragment(NsAviationWeather, "feelc");
            public static readonly Uri WeatherDataIceAccretion1hr = UriHelper.SetFragment(NsAviationWeather, "ice_accretion_1hr");
            public static readonly Uri WeatherDataIceAccretion3hr = UriHelper.SetFragment(NsAviationWeather, "ice_accretion_3hr");
            public static readonly Uri WeatherDataIceAccretion6hr = UriHelper.SetFragment(NsAviationWeather, "ice_accretion_6hr");
            public static readonly Uri WeatherDataPeakWindGust = UriHelper.SetFragment(NsAviationWeather, "peak_wind_gust");
            public static readonly Uri WeatherDataPeakWindDrct = UriHelper.SetFragment(NsAviationWeather, "peak_wind_drct");
            public static readonly Uri WeatherDataPeakWindTime_hh = UriHelper.SetFragment(NsAviationWeather, "peak_wind_time_hh");
            public static readonly Uri WeatherDataPeakWindTime_MM = UriHelper.SetFragment(NsAviationWeather, "peak_wind_time_MM");
            public static readonly Uri WeatherDataMetar = UriHelper.SetFragment(NsAviationWeather, "metar");

            // Relationships:
            public static readonly Uri HasAircraft = UriHelper.SetFragment(NsAviationGeneral, "has_aircraft");
            public static readonly Uri HasOriginAirport = UriHelper.SetFragment(NsAviationGeneral, "has_origin_airport");
            public static readonly Uri HasDestinationAirport = UriHelper.SetFragment(NsAviationGeneral, "has_destination_airport");
            public static readonly Uri HasCarrier = UriHelper.SetFragment(NsAviationGeneral, "has_carrier");
            public static readonly Uri HasWeatherStation = UriHelper.SetFragment(NsAviationGeneral, "has_weather_station");
            public static readonly Uri HasStation = UriHelper.SetFragment(NsAviationGeneral, "has_station");
        }
    }
}