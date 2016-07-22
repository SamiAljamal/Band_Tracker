using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
  public class Band
  {
    int _id;
    string _name;

    public Band(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public static List<Band> GetAll()
    {
      List<Band> allBands = new List<Band>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int bandId = rdr.GetInt32(1);
        string bandName = rdr.GetString(0);
        Band newBand = new Band(bandName, bandId);
        allBands.Add(newBand);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allBands;
    }

    public override bool Equals(System.Object otherBand)
    {
      if (!(otherBand is Band))
      {
        return false;
      }
      else
      {
        Band newBand = (Band) otherBand;
        bool idEquality = this.GetId() == newBand.GetId();
        bool nameEquality = this.GetName() == newBand.GetName();
        return (idEquality && nameEquality);
      }
    }






    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM bands;", conn);
      cmd.ExecuteNonQuery();
    }

  }
}
