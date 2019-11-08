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
            public const string Flight = "flight";
            public const string Carrier = "carrier";
            public const string Airport = "airport";
            public const string WeatherStation = "weather_station";
            public const string WeatherData = "weather_data";
        }

        public static class Predicates
        {
            public static readonly Uri Type = new Uri(NsAviationGeneral, "node_type");

            // Airport Data:
            public static readonly Uri AirportId = new Uri(NsAviationAirport, "airport_id");
            public static readonly Uri AirportName = new Uri(NsAviationAirport, "name");
            public static readonly Uri AirportIata = new Uri(NsAviationAirport, "iata");
            public static readonly Uri AirportCity = new Uri(NsAviationAirport, "city");
            public static readonly Uri AirportState = new Uri(NsAviationAirport, "state");
            public static readonly Uri AirportCountry = new Uri(NsAviationAirport, "country");

            // Carrier Data:
            public static readonly Uri CarrierCode = new Uri(NsAviationCarrier, "code");
            public static readonly Uri CarrierDescription = new Uri(NsAviationCarrier, "description");

            // Flight Data:
            public static readonly Uri FlightTailNumber = new Uri(NsAviationFlight, "tail_number");
            public static readonly Uri FlightNumber = new Uri(NsAviationFlight, "flight_number");
            public static readonly Uri FlightDate = new Uri(NsAviationFlight, "flight_date");
            public static readonly Uri FlightCarrier = new Uri(NsAviationFlight, "carrier");
            public static readonly Uri FlightYear = new Uri(NsAviationFlight, "year");
            public static readonly Uri FlightMonth = new Uri(NsAviationFlight, "month");
            public static readonly Uri FlightDayOfWeek = new Uri(NsAviationFlight, "day_of_week");
            public static readonly Uri FlightDayOfMonth = new Uri(NsAviationFlight, "day_of_month");
            public static readonly Uri FlightCancellationCode = new Uri(NsAviationFlight, "cancellation_code");
            public static readonly Uri FlightDistance = new Uri(NsAviationFlight, "distance");
            public static readonly Uri FlightDepartureDelay = new Uri(NsAviationFlight, "departure_delay");
            public static readonly Uri FlightArrivalDelay = new Uri(NsAviationFlight, "arrival_delay");
            public static readonly Uri FlightCarrierDelay = new Uri(NsAviationFlight, "carrier_delay");
            public static readonly Uri FlightWeatherDelay = new Uri(NsAviationFlight, "weather_delay");
            public static readonly Uri FlightNasDelay = new Uri(NsAviationFlight, "nas_delay");
            public static readonly Uri FlightSecurityDelay = new Uri(NsAviationFlight, "security_delay");
            public static readonly Uri FlightLateAircraftDelay = new Uri(NsAviationFlight, "late_aircraft_delay");
            public static readonly Uri FlightScheduledDepartureTime = new Uri(NsAviationFlight, "scheduled_departure_time");
            public static readonly Uri FlightActualDepartureTime = new Uri(NsAviationFlight, "actual_departure_time");

            // Aircraft Data:
            public static readonly Uri AircraftN_Number = new Uri(NsAviationtAircraft, "n_number");
            public static readonly Uri AircraftSerialNumber = new Uri(NsAviationtAircraft, "serial_number");
            public static readonly Uri AircraftUniqueId = new Uri(NsAviationtAircraft, "unique_id");
            public static readonly Uri AircraftManufacturer = new Uri(NsAviationtAircraft, "manufacturer");
            public static readonly Uri AircraftModel = new Uri(NsAviationtAircraft, "model");
            public static readonly Uri AircraftSeats = new Uri(NsAviationtAircraft, "seats");
            public static readonly Uri AircraftEngineManufacturer = new Uri(NsAviationtAircraft, "engine_manufacturer");
            public static readonly Uri AircraftEngineModel = new Uri(NsAviationtAircraft, "engine_model");
            public static readonly Uri AircraftEngineHorsepower = new Uri(NsAviationtAircraft, "engine_horsepower");
            public static readonly Uri AircraftEngineThrust = new Uri(NsAviationtAircraft, "engine_thrust");

            // Weather Station Data:
            public static readonly Uri WeatherStationIcao = new Uri(NsAviationWeatherStation, "icao");
            public static readonly Uri WeatherStationName = new Uri(NsAviationWeatherStation, "name");
            public static readonly Uri WeatherStationIata = new Uri(NsAviationWeatherStation, "iata");
            public static readonly Uri WeatherStationSynop = new Uri(NsAviationWeatherStation, "synop");
            public static readonly Uri WeatherStationLat = new Uri(NsAviationWeatherStation, "lat");
            public static readonly Uri WeatherStationLon = new Uri(NsAviationWeatherStation, "lon");
            public static readonly Uri WeatherStationElevation = new Uri(NsAviationWeatherStation, "elevation");

            // Weather Data:
            public static readonly Uri WeatherDataStation = new Uri(NsAviationWeather, "station");
            public static readonly Uri WeatherDataLongitude = new Uri(NsAviationWeather, "lon");
            public static readonly Uri WeatherDataLatitude = new Uri(NsAviationWeather, "lat");
            public static readonly Uri WeatherDataTimestamp = new Uri(NsAviationWeather, "timestamp");
            public static readonly Uri WeatherDataTmpf = new Uri(NsAviationWeather, "tmpf");
            public static readonly Uri WeatherDataTmpc = new Uri(NsAviationWeather, "tmpc");
            public static readonly Uri WeatherDataDwpf = new Uri(NsAviationWeather, "dwpf");
            public static readonly Uri WeatherDataDwpc = new Uri(NsAviationWeather, "dwpc");
            public static readonly Uri WeatherDataRelh = new Uri(NsAviationWeather, "relh");
            public static readonly Uri WeatherDataDrct = new Uri(NsAviationWeather, "drct");
            public static readonly Uri WeatherDataSknt = new Uri(NsAviationWeather, "sknt");
            public static readonly Uri WeatherDataP01i = new Uri(NsAviationWeather, "p01i");
            public static readonly Uri WeatherDataAlti = new Uri(NsAviationWeather, "alti");
            public static readonly Uri WeatherDataMslp = new Uri(NsAviationWeather, "mslp");
            public static readonly Uri WeatherDataVsbyMi = new Uri(NsAviationWeather, "vsby_mi");
            public static readonly Uri WeatherDataVsbyKm = new Uri(NsAviationWeather, "vsby_km");
            public static readonly Uri WeatherDataGust = new Uri(NsAviationWeather, "gust");
            public static readonly Uri WeatherDataSkyc1 = new Uri(NsAviationWeather, "skyc1");
            public static readonly Uri WeatherDataSkyc2 = new Uri(NsAviationWeather, "skyc2");
            public static readonly Uri WeatherDataSkyc3 = new Uri(NsAviationWeather, "skyc3");
            public static readonly Uri WeatherDataSkyc4 = new Uri(NsAviationWeather, "skyc4");
            public static readonly Uri WeatherDataSkyl1 = new Uri(NsAviationWeather, "skyl1");
            public static readonly Uri WeatherDataSkyl2 = new Uri(NsAviationWeather, "skyl2");
            public static readonly Uri WeatherDataSkyl3 = new Uri(NsAviationWeather, "skyl3");
            public static readonly Uri WeatherDataSkyl4 = new Uri(NsAviationWeather, "skyl4");
            public static readonly Uri WeatherDataWxcodes = new Uri(NsAviationWeather, "wxcodes");
            public static readonly Uri WeatherDataFeelf = new Uri(NsAviationWeather, "feelf");
            public static readonly Uri WeatherDataFeelc = new Uri(NsAviationWeather, "feelc");
            public static readonly Uri WeatherDataIceAccretion1hr = new Uri(NsAviationWeather, "ice_accretion_1hr");
            public static readonly Uri WeatherDataIceAccretion3hr = new Uri(NsAviationWeather, "ice_accretion_3hr");
            public static readonly Uri WeatherDataIceAccretion6hr = new Uri(NsAviationWeather, "ice_accretion_6hr");
            public static readonly Uri WeatherDataPeakWindGust = new Uri(NsAviationWeather, "peak_wind_gust");
            public static readonly Uri WeatherDataPeakWindDrct = new Uri(NsAviationWeather, "peak_wind_drct");
            public static readonly Uri WeatherDataPeakWindTime_hh = new Uri(NsAviationWeather, "peak_wind_time_hh");
            public static readonly Uri WeatherDataPeakWindTime_MM = new Uri(NsAviationWeather, "peak_wind_time_MM");
            public static readonly Uri WeatherDataMetar = new Uri(NsAviationWeather, "metar");

            // Relationships:
            public static readonly Uri HasAircraft = new Uri(NsAviationGeneral, "has_aircraft");
            public static readonly Uri HasOriginAirport = new Uri(NsAviationGeneral, "has_origin_airport");
            public static readonly Uri HasDestinationAirport = new Uri(NsAviationGeneral, "has_destination_airport");
            public static readonly Uri HasCarrier = new Uri(NsAviationGeneral, "has_carrier");
            public static readonly Uri HasWeatherStation = new Uri(NsAviationGeneral, "has_weather_station");
        }
    }
}