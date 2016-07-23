using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] =_=>{
        List<Venue> allVenues = Venue.GetAll();

        return View["index.cshtml",allVenues];
      };

      Get["/bands"]=_=>{
        List<Band> allBands = Band.GetAll();
        return View["bands.cshtml", allBands];
      };


      Post["/bands/add"]=_=>
      {
        Band newBand = new Band(Request.Form["bands"]);
        newBand.Save();
        List<Band> allBands = Band.GetAll();
        return View["bands.cshtml",allBands];
      };


      Post["/venue/add"]=_=>
      {
        Venue newVenue = new Venue(Request.Form["venue"]);
        newVenue.Save();
        List<Venue> allVenues = Venue.GetAll();
        return View["index.cshtml",allVenues];
      };

      Get["/venues/{id}"]=parameters=>{
        Dictionary<string,object> model = new Dictionary<string,object>();
        Venue selectedVenue = Venue.Find(parameters.id);
        List<Band> bandsInVenue = selectedVenue.GetBands();
        List<Band> allBands =  Band.GetAll();
        model.Add("Venue", selectedVenue);
        model.Add("Bands", bandsInVenue);
        model.Add("AllBands", allBands);

        return View["venue.cshtml", model];
      };

      Get["/bands/{id}"]=parameters=>{
        Dictionary<string,object> model = new Dictionary<string,object>();
        Band selectedBand = Band.Find(parameters.id);
        List<Venue> venueInBands = selectedBand.GetVenues();
        List<Venue> allVenues =  Venue.GetAll();
        model.Add("Venue", venueInBands);
        model.Add("Band", selectedBand);
        model.Add("AllVenues", allVenues);

        return View["band.cshtml", model];
      };



    }
  }
}
