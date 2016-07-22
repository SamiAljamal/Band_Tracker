using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest : IDisposable
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

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Venue.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SaveVenuetoDB()
    {
      Venue testVenue = new Venue("The Ballroom");
      testVenue.Save();

      List<Venue> testVenues = new List<Venue>{testVenue};
      List<Venue> resultVenues = Venue.GetAll();

      Assert.Equal(testVenues, resultVenues);
    }

    [Fact]
    public void Test_Save_AssignsIdToVenue()
    {

      Venue testVenue = new Venue("The Ballroom");
      testVenue.Save();
      Venue savedVenue = Venue.GetAll()[0];

      int result = savedVenue.GetId();
      int testId = testVenue.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsVenueInDatabase()
    {
      //Arrange
      Venue testVenue =  new Venue("The Ballroom");
      testVenue.Save();

      //Act
      Venue foundVenue = Venue.Find(testVenue.GetId());

      //Assert
      Assert.Equal(testVenue, foundVenue);
    }

    [Fact]
    public void Test_Update_UpdatesVenueInDatabase()
    {
      Venue testVenue = new Venue("The Ballroom");
      testVenue.Save();
      string newVenue = "The Stage";

      testVenue.Update(newVenue);

      Assert.Equal(newVenue, testVenue.GetName());
    }

    [Fact]
    public void Test_Delete_DeleteVenuefromDB()
    {
      Venue testVenue = new Venue("The Ballroom");
      Venue testVenue2 = new Venue("The Stage");
      testVenue.Save();
      testVenue2.Save();

      List<Venue> allcourses = new List<Venue>{testVenue,testVenue2};
      allcourses.Remove(testVenue);
      testVenue.Delete();

      Assert.Equal(allcourses,Venue.GetAll());
    }

    [Fact]
    public void Test_GetBands_FindBandsFromDb_nobandsinDb()
    {

      Venue testVenue = new Venue("The Ballroom");
      testVenue.Save();

      List<Band> result = testVenue.GetBands();


      Assert.Equal(0,result.Count);


    }

    [Fact]
    public void Test_AddBand_AddsBandstoVenue()
    {
      Venue testVenue = new Venue("The Ballroom");
      testVenue.Save();

      Band testBand = new Band("The rockers");
      testBand.Save();

      testVenue.AddBand(testBand);
      List<Band> testList = new List<Band>{testBand};
      List<Band> result = testVenue.GetBands();

      Assert.Equal(testList, result);
    }


    public void Dispose()
    {
      Venue.DeleteAll();
      Band.DeleteAll();
    }



  }
}
