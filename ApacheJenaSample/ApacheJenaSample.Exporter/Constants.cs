using ApacheJenaSample.Exporter.Extensions;
using System;

namespace ApacheJenaSample.Exporter
{
    public static class Constants
    {
        public static readonly Uri NsAviationBaseUri = new Uri("http://www.bytefish.de/aviation/");

        // Ontologies:
        public static readonly Uri NsAviationGeneral = new Uri(NsAviationBaseUri, "General");
        public static readonly Uri NsAviationtAircraft = new Uri(NsAviationBaseUri, "Aircraft");
        public static readonly Uri NsAviationAirport = new Uri(NsAviationBaseUri, "Airport");
        public static readonly Uri NsAviationCarrier = new Uri(NsAviationBaseUri, "Carrier");
        public static readonly Uri NsAviationFlight = new Uri(NsAviationBaseUri, "Flight");
        public static readonly Uri NsAviationWeatherStation = new Uri(NsAviationBaseUri, "WeatherStation");
        public static readonly Uri NsAviationWeather = new Uri(NsAviationBaseUri, "Weather");

        public static class Types
        {
            public const string Flight = "flight";
            public const string Carrier = "carrier";
            public const string Airport = "airport";
            public const string WeatherStation = "weather_station";
            public const string WeatherData = "weather_data";
        }

        public static class Predicates
        {
            public static readonly Uri Type = UriHelper.AppendFragment(NsAviationGeneral, "node_type");

            // Airport Data:
            public static readonly Uri AirportId = UriHelper.AppendFragment(NsAviationAirport, "airport_id");
            public static readonly Uri AirportName = UriHelper.AppendFragment(NsAviationAirport, "name");
            public static readonly Uri AirportIata = UriHelper.AppendFragment(NsAviationAirport, "iata");
            public static readonly Uri AirportCity = UriHelper.AppendFragment(NsAviationAirport, "city");
            public static readonly Uri AirportState = UriHelper.AppendFragment(NsAviationAirport, "state");
            public static readonly Uri AirportCountry = UriHelper.AppendFragment(NsAviationAirport, "country");

            // Carrier Data:
            public static readonly Uri CarrierCode = UriHelper.AppendFragment(NsAviationCarrier, "code");
            public static readonly Uri CarrierDescription = UriHelper.AppendFragment(NsAviationCarrier, "description");

            // Flight Data:
            public static readonly Uri FlightTailNumber = UriHelper.AppendFragment(NsAviationFlight, "tail_number");
            public static readonly Uri FlightNumber = UriHelper.AppendFragment(NsAviationFlight, "flight_number");
            public static readonly Uri FlightDate = UriHelper.AppendFragment(NsAviationFlight, "flight_date");
            public static readonly Uri FlightCarrier = UriHelper.AppendFragment(NsAviationFlight, "carrier");
            public static readonly Uri FlightYear = UriHelper.AppendFragment(NsAviationFlight, "year");
            public static readonly Uri FlightMonth = UriHelper.AppendFragment(NsAviationFlight, "month");
            public static readonly Uri FlightDayOfWeek = UriHelper.AppendFragment(NsAviationFlight, "day_of_week");
            public static readonly Uri FlightDayOfMonth = UriHelper.AppendFragment(NsAviationFlight, "day_of_month");
            public static readonly Uri FlightCancellationCode = UriHelper.AppendFragment(NsAviationFlight, "cancellation_code");
            public static readonly Uri FlightDistance = UriHelper.AppendFragment(NsAviationFlight, "distance");
            public static readonly Uri FlightDepartureDelay = UriHelper.AppendFragment(NsAviationFlight, "departure_delay");
            public static readonly Uri FlightArrivalDelay = UriHelper.AppendFragment(NsAviationFlight, "arrival_delay");
            public static readonly Uri FlightCarrierDelay = UriHelper.AppendFragment(NsAviationFlight, "carrier_delay");
            public static readonly Uri FlightWeatherDelay = UriHelper.AppendFragment(NsAviationFlight, "weather_delay");
            public static readonly Uri FlightNasDelay = UriHelper.AppendFragment(NsAviationFlight, "nas_delay");
            public static readonly Uri FlightSecurityDelay = UriHelper.AppendFragment(NsAviationFlight, "security_delay");
            public static readonly Uri FlightLateAircraftDelay = UriHelper.AppendFragment(NsAviationFlight, "late_aircraft_delay");
            public static readonly Uri FlightScheduledDepartureTime = UriHelper.AppendFragment(NsAviationFlight, "scheduled_departure_time");
            public static readonly Uri FlightActualDepartureTime = UriHelper.AppendFragment(NsAviationFlight, "actual_departure_time");

            // Aircraft Data:
            public static readonly Uri AircraftN_Number = UriHelper.AppendFragment(NsAviationtAircraft, "n_number");
            public static readonly Uri AircraftSerialNumber = UriHelper.AppendFragment(NsAviationtAircraft, "serial_number");
            public static readonly Uri AircraftUniqueId = UriHelper.AppendFragment(NsAviationtAircraft, "unique_id");
            public static readonly Uri AircraftManufacturer = UriHelper.AppendFragment(NsAviationtAircraft, "manufacturer");
            public static readonly Uri AircraftModel = UriHelper.AppendFragment(NsAviationtAircraft, "model");
            public static readonly Uri AircraftSeats = UriHelper.AppendFragment(NsAviationtAircraft, "seats");
            public static readonly Uri AircraftEngineManufacturer = UriHelper.AppendFragment(NsAviationtAircraft, "engine_manufacturer");
            public static readonly Uri AircraftEngineModel = UriHelper.AppendFragment(NsAviationtAircraft, "engine_model");
            public static readonly Uri AircraftEngineHorsepower = UriHelper.AppendFragment(NsAviationtAircraft, "engine_horsepower");
            public static readonly Uri AircraftEngineThrust = UriHelper.AppendFragment(NsAviationtAircraft, "engine_thrust");

            // Weather Station Data:
            public static readonly Uri WeatherStationIcao = UriHelper.AppendFragment(NsAviationWeatherStation, "icao");
            public static readonly Uri WeatherStationName = UriHelper.AppendFragment(NsAviationWeatherStation, "name");
            public static readonly Uri WeatherStationIata = UriHelper.AppendFragment(NsAviationWeatherStation, "iata");
            public static readonly Uri WeatherStationSynop = UriHelper.AppendFragment(NsAviationWeatherStation, "synop");
            public static readonly Uri WeatherStationLat = UriHelper.AppendFragment(NsAviationWeatherStation, "lat");
            public static readonly Uri WeatherStationLon = UriHelper.AppendFragment(NsAviationWeatherStation, "lon");
            public static readonly Uri WeatherStationElevation = UriHelper.AppendFragment(NsAviationWeatherStation, "elevation");

            // Weather Data:
            public static readonly Uri WeatherDataStation = UriHelper.AppendFragment(NsAviationWeather, "station");
            public static readonly Uri WeatherDataLongitude = UriHelper.AppendFragment(NsAviationWeather, "lon");
            public static readonly Uri WeatherDataLatitude = UriHelper.AppendFragment(NsAviationWeather, "lat");
            public static readonly Uri WeatherDataTimestamp = UriHelper.AppendFragment(NsAviationWeather, "timestamp");
            public static readonly Uri WeatherDataTmpf = UriHelper.AppendFragment(NsAviationWeather, "tmpf");
            public static readonly Uri WeatherDataTmpc = UriHelper.AppendFragment(NsAviationWeather, "tmpc");
            public static readonly Uri WeatherDataDwpf = UriHelper.AppendFragment(NsAviationWeather, "dwpf");
            public static readonly Uri WeatherDataDwpc = UriHelper.AppendFragment(NsAviationWeather, "dwpc");
            public static readonly Uri WeatherDataRelh = UriHelper.AppendFragment(NsAviationWeather, "relh");
            public static readonly Uri WeatherDataDrct = UriHelper.AppendFragment(NsAviationWeather, "drct");
            public static readonly Uri WeatherDataSknt = UriHelper.AppendFragment(NsAviationWeather, "sknt");
            public static readonly Uri WeatherDataP01i = UriHelper.AppendFragment(NsAviationWeather, "p01i");
            public static readonly Uri WeatherDataAlti = UriHelper.AppendFragment(NsAviationWeather, "alti");
            public static readonly Uri WeatherDataMslp = UriHelper.AppendFragment(NsAviationWeather, "mslp");
            public static readonly Uri WeatherDataVsbyMi = UriHelper.AppendFragment(NsAviationWeather, "vsby_mi");
            public static readonly Uri WeatherDataVsbyKm = UriHelper.AppendFragment(NsAviationWeather, "vsby_km");
            public static readonly Uri WeatherDataGust = UriHelper.AppendFragment(NsAviationWeather, "gust");
            public static readonly Uri WeatherDataSkyc1 = UriHelper.AppendFragment(NsAviationWeather, "skyc1");
            public static readonly Uri WeatherDataSkyc2 = UriHelper.AppendFragment(NsAviationWeather, "skyc2");
            public static readonly Uri WeatherDataSkyc3 = UriHelper.AppendFragment(NsAviationWeather, "skyc3");
            public static readonly Uri WeatherDataSkyc4 = UriHelper.AppendFragment(NsAviationWeather, "skyc4");
            public static readonly Uri WeatherDataSkyl1 = UriHelper.AppendFragment(NsAviationWeather, "skyl1");
            public static readonly Uri WeatherDataSkyl2 = UriHelper.AppendFragment(NsAviationWeather, "skyl2");
            public static readonly Uri WeatherDataSkyl3 = UriHelper.AppendFragment(NsAviationWeather, "skyl3");
            public static readonly Uri WeatherDataSkyl4 = UriHelper.AppendFragment(NsAviationWeather, "skyl4");
            public static readonly Uri WeatherDataWxcodes = UriHelper.AppendFragment(NsAviationWeather, "wxcodes");
            public static readonly Uri WeatherDataFeelf = UriHelper.AppendFragment(NsAviationWeather, "feelf");
            public static readonly Uri WeatherDataFeelc = UriHelper.AppendFragment(NsAviationWeather, "feelc");
            public static readonly Uri WeatherDataIceAccretion1hr = UriHelper.AppendFragment(NsAviationWeather, "ice_accretion_1hr");
            public static readonly Uri WeatherDataIceAccretion3hr = UriHelper.AppendFragment(NsAviationWeather, "ice_accretion_3hr");
            public static readonly Uri WeatherDataIceAccretion6hr = UriHelper.AppendFragment(NsAviationWeather, "ice_accretion_6hr");
            public static readonly Uri WeatherDataPeakWindGust = UriHelper.AppendFragment(NsAviationWeather, "peak_wind_gust");
            public static readonly Uri WeatherDataPeakWindDrct = UriHelper.AppendFragment(NsAviationWeather, "peak_wind_drct");
            public static readonly Uri WeatherDataPeakWindTime_hh = UriHelper.AppendFragment(NsAviationWeather, "peak_wind_time_hh");
            public static readonly Uri WeatherDataPeakWindTime_MM = UriHelper.AppendFragment(NsAviationWeather, "peak_wind_time_MM");
            public static readonly Uri WeatherDataMetar = UriHelper.AppendFragment(NsAviationWeather, "metar");

            // Relationships:
            public static readonly Uri HasAircraft = UriHelper.AppendFragment(NsAviationGeneral, "has_aircraft");
            public static readonly Uri HasOriginAirport = UriHelper.AppendFragment(NsAviationGeneral, "has_origin_airport");
            public static readonly Uri HasDestinationAirport = UriHelper.AppendFragment(NsAviationGeneral, "has_destination_airport");
            public static readonly Uri HasCarrier = UriHelper.AppendFragment(NsAviationGeneral, "has_carrier");
            public static readonly Uri HasWeatherStation = UriHelper.AppendFragment(NsAviationGeneral, "has_weather_station");
        }
    }
}