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

      Post["/venue/add"]=_=>
      {
        Venue newVenue = new Venue(Request.Form["venue"]);
        newVenue.Save();
        List<Venue> allVenues = Venue.GetAll();
        return View["index.cshtml",allVenues];
      };
    }
  }
}
