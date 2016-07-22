using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest 
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog= band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_Equal_ReturnsTrueifVenuesaretheSame()
    {
      Venue firstVenue = new Venue("The Ballroom");
      Venue secondVenue = new Venue("The Ballroom");

      Assert.Equal(firstVenue, secondVenue);
    }


  }
}