# BandTracker

#### By Sami Al-Jamal

## Description

Band Tracker is an application using HTTP CRUD method to update and delete elements within a many-to-many database.

## Database setup
To setup Database in SQLCMD:
  * open up the terminal
  * run the following command:
    * sqlcmd -S "(localdb)\mssqllocaldb"
    * CREATE DATABASE band_tracker;
    * Go
    * USE band_tacker;
    * Go
    * CREATE TABLE bands (name VARCHAR(255), id INT IDENTITY(1,1));
    * Go
    * CREATE TABLE venues (name VARCHAR(255), id INT IDENTITY(1,1));
    * Go
    * CREATE TABLE bands_venues (id INT IDENTITY(1,1), venues_id INT, bands_id INT);
    * Go

## Installation and how to run page.
 To run the nancy app type in the following commands:
  * type in the command dnu restore.
  * type in the command dnx Kestrel.
  * open up a web browser, and type  http://localhost:5004 in the url form.

## Running the Test classes
  To run tests on your methods:
    * Open the command prompt and type in dnx test.


## Support and contact details
For any concerns, please contact me at sami.m.aljamal@gmail.com
## Technologies Used
Technologies used in this program include:
  * Html
  * C#
  * Nancy Framwork.
  * bootstrap
  * Microsfort SQL Server Management Studio (SSMS)
  * Razor Engine view.

### License
This is licensed under the MIT license.

Copyright (c) 2016 **Sami Al-Jamal**
