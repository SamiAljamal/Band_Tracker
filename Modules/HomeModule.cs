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
        model.Add("Venue", selectedVenue);
        model.Add("Bands", bandsInVenue);

        return View["venue.cshtml", model];
      };



    }
  }
}
