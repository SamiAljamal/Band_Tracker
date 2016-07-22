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







    public void Dispose()
    {
      Band.DeleteAll();
      Band.DeleteAll();
    }
  }
}
