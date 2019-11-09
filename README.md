# ApacheJenaSample #

This repository is an experiment for working with [Apache Jena]:

> Apache Jena (or Jena in short) is a free and open source Java framework for building 
> semantic web and Linked Data applications. The framework is composed of different APIs 
> interacting together to process RDF data.

The idea is to use a [Triplestore] to infer knowledge about Aviation data, using information from:

* Aircrafts
* Airports
* Carriers
* Flights
* Weather Stations
* ASOS / METAR Weather Data

[Triplestore]: https://en.wikipedia.org/wiki/Triplestore

## Datasets ##

## Airline On Time Performance (AOTP) Data ##

Is my flight delayed? The plan is to analyze the Airline On Time Performance dataset, which contains:

> [...] on-time arrival data for non-stop domestic flights by major air carriers, and provides such additional 
> items as departure and arrival delays, origin and destination airports, flight numbers, scheduled and actual departure 
> and arrival times, cancelled or diverted flights, taxi-out and taxi-in times, air time, and non-stop distance.

The data spans a time range from October 1987 to present, and it contains more than 150 million rows of flight informations. 
It can be obtained as CSV files from the Bureau of Transportation Statistics Database, and requires you to download the data 
month by month. 

More conveniently the [Revolution Analytics dataset repository] contains a ZIP File with the CSV data from 1987 to 2012.

[Revolution Analytics dataset repository]: https://packages.revolutionanalytics.com/datasets/AirOnTime87to12/

## ASOS Weather Data ##

[Iowa State University]: https://www.iastate.edu/

Is a flight delayed, because of strong winds, heavy rain or ice accretion? Many airports in the 
USA have so called Automated Surface Observing System (ASOS) units, that are designed to serve 
aviation and meterological operations. The NOAA website writes on ASOS weather stations:

> Automated Surface Observing System (ASOS) units are automated sensor suites that are designed 
> to serve meteorological and aviation observing needs. There are currently more than 900 ASOS 
> sites in the United States. These systems generally report at hourly intervals, but also report 
> special observations if weather conditions change rapidly and cross aviation operation thresholds.
>
> ASOS serves as a primary climatological observing network in the United States. Not every ASOS is 
> located at an airport; for example, one of these units is located at Central Park in New York City. 
> ASOS data are archived in the Global Surface Hourly database, with data from as early as 1901.

The [Iowa State University] hosts an archive of automated airport weather observations:

> The IEM maintains an ever growing archive of automated airport weather observations from around 
> the world! These observations are typically called 'ASOS' or sometimes 'AWOS' sensors. A more 
> generic term may be METAR data, which is a term that describes the format the data is transmitted 
> as. If you don't get data for a request, please feel free to contact us for help. The IEM also has 
> a one minute interval dataset for Iowa ASOS (2000-) and AWOS (1995-2011) sites. This archive simply 
> provides the as-is collection of historical observations, very little quality control is done. 
> "M" is used to denote missing data.

[Daryl Herzmann](https://github.com/akrherz) of the [Iowa State University] provides a great Python 
script to download the ASOS / AWOS data from the Webservices, which is available at:

* [iem_scraper_example.py](https://github.com/akrherz/iem/blob/master/scripts/asos/iem_scraper_example.py)

## The FAA Aircraft Registry Dataset ##

[Power Query]: https://docs.microsoft.com/en-us/power-query/
[Aircraft Registry Releasable Aircraft Database]: https://www.faa.gov/licenses_certificates/aircraft_certification/aircraft_registry/releasable_aircraft_download/
[Power Query M formula language]: https://docs.microsoft.com/en-us/powerquery-m/power-query-m-reference

Is a flight delayed because of aircraft or engine problems? This is an interesting question, that 
you might want to know about. And there is a database maintained by the FAA, which contains the data 
we need to answer the question:

* [Aircraft Registry Releasable Aircraft Database]

The dataset is described as:

> The archive file contains the:
> 
> * Aircraft Registration Master file
> * Aircraft Dealer Applicant file
> * Aircraft Document Index file
> * Aircraft Reference file by Make/Model/Series Sequence
> * Deregistered Aircraft file
> * Engine Reference file
> * Reserve N-Number file
>
> Files are updated each federal business day. The records in each database file are stored in a comma delimited format (CDF) and can be manipulated by common database management applications, such as MS Access.

I have used some Excel magic to join the several files and build a view on the data, that could be parsed easily:

* [https://github.com/bytefish/ApacheJenaSample/tree/master/Resources/FAA](https://github.com/bytefish/ApacheJenaSample/tree/master/Resources/FAA)

## Apache Jena Fuseki ##

You can start the ``fuseki-server`` for this experiment by running: 

```
fuseki-server --tdb2 --loc=<DATA_DIRECTORY> /aviation
```

Where:

* ``--tdb2`` instructs Apache Jena to use its new TDB2
* ``--loc=<DATA_DIRECTORY>`` is the directory where the data should be written to
* ``/aviation`` is the named Graph we register


[Apache Jena]: https://jena.apache.org
