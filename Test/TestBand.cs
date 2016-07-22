using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Band.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfBandsAreSame()
    {
      Band firstBand = new Band("Fred");
      Band secondBand = new Band("Fred");

      Assert.Equal(firstBand, secondBand);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Band testBand = new Band("Fred");

      //Act
      testBand.Save();
      List<Band> result = Band.GetAll();
      List<Band> testBands = new List<Band>{testBand};

      //Assert
      Assert.Equal(testBands, result);
    }

    [Fact]
    public void Test_Find_FindsBandInDatabase()
    {
      Band testBand = new Band("Joe");
      testBand.Save();
      Band foundBand = Band.Find(testBand.GetId());
      Assert.Equal(testBand, foundBand);
    }

    [Fact]
    public void Test_Update_UpdatesBandInDatabase()
    {
      Band testBand = new Band("The Ballroom");
      testBand.Save();
      string newBand ="The Stage";

      testBand.Update(newBand);
      System.Console.WriteLine(testBand.GetName());
      System.Console.WriteLine(newBand);

      Assert.Equal(newBand, testBand.GetName());
    }

  [Fact]
  public void Test_Delete_DeleteBandfromDB()
  {
    Band testBand = new Band("Rockers");
    Band testBand2 = new Band("The Stage");
    testBand.Save();
    testBand2.Save();

    List<Band> allbands = new List<Band>{testBand,testBand2};
    allbands.Remove(testBand);
    testBand.Delete();

    Assert.Equal(allbands, Band.GetAll());
  }

  [Fact]
  public void Test_GetVenues_FindVenuesFromDb_noVenuesinDb()
  {

    Band testBand = new Band("Rockers");
      testBand.Save();

    List<Venue> result = testBand.GetVenues();


    Assert.Equal(0,result.Count);
  }


  [Fact]
  public void Test_AddVenue_AddsVenuetoBands()
  {
    Venue testVenue = new Venue("The Ballroom");
    testVenue.Save();

    Band testBand = new Band("The rockers");
    testBand.Save();

    testVenue.AddBand(testBand);
    List<Venue> testList = new List<Venue>{testVenue};
    List<Venue> result = testBand.GetVenues();

    Assert.Equal(testList, result);
  }

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
