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
        model.Add("allBands", allBands);

        return View["venue.cshtml", model];
      };

      Post["/venue/{id}"]=parameters=>{

        Band selectedBand = Band.Find(Request.Form["band_id"]);
        Venue selectedVenue = Venue.Find(parameters.id);
        selectedBand.AddVenue(selectedVenue);
        Dictionary<string,object> model = new Dictionary<string,object>();
        List<Band> venueBands = selectedVenue.GetBands();
        List<Band> allBands = Band.GetAll();

        model.Add("Venue", selectedVenue);
        model.Add("Bands",venueBands);
        model.Add("allBands", allBands);

        return View["venue.cshtml", model];
      };

      Get["/bands/{id}"]=parameters=>{
        Dictionary<string,object> model = new Dictionary<string,object>();
        Band selectedBand = Band.Find(parameters.id);
        List<Venue> venueInBands = selectedBand.GetVenues();
        List<Venue> allVenues =  Venue.GetAll();
        model.Add("Venue", venueInBands);
        model.Add("Bands", selectedBand);
        model.Add("allVenues", allVenues);

        return View["band.cshtml", model];
      };

      Post["/band/{id}"]=parameters=>{
        Venue selectedVenue = Venue.Find(Request.Form["venue_id"]);

        Band selectedBand = Band.Find(parameters.id);
        selectedVenue.AddBand(selectedBand);

        Dictionary<string,object> model = new Dictionary<string,object>();
        List<Venue> bandsVenue = selectedBand.GetVenues();
        List<Venue> allVenues = Venue.GetAll();

        model.Add("Venue", bandsVenue);
        model.Add("Bands", selectedBand);
        model.Add("allVenues", allVenues);
        return View["band.cshtml", model];
      };

      Get["/venue/remove/{id}"]=parameters=>{
        Venue removeVenue = Venue.Find(parameters.id);
        return View["venue_remove.cshtml", removeVenue];
      };

      Delete["/venue/remove/{id}"]=paramters=>{
        Dictionary<string,object> model = new Dictionary<string,object>();
        Venue removeVenue = Venue.Find(Request.Form["venue_id"]);
        Band selectedBand = Band.Find(paramters.id);
        selectedBand.RemoveVenue(removeVenue);

        List<Venue> bandsVenue = selectedBand.GetVenues();
        List<Venue> allVenues = Venue.GetAll();

        model.Add("allVenues", allVenues);
        model.Add("Venue", bandsVenue);
        model.Add("Bands", selectedBand);

        return View["band.cshtml", model];
      };

      Get["/band/remove/{id}"]=parameters=>{
        Band removeBand = Band.Find(parameters.id);
        return View["band_remove.cshtml", removeBand];
      };

      Delete["/band/remove/{id}"]=parameters=>{
        Dictionary<string,object> model = new Dictionary<string,object>();
        Band removeBand = Band.Find(Request.Form["band_id"]);
        Venue selectedVenue = Venue.Find(parameters.id);
        selectedVenue.RemoveBand(removeBand);

        List<Band> venueBands = selectedVenue.GetBands();
        List<Band> allBands = Band.GetAll();

        model.Add("Venue", selectedVenue);
        model.Add("Bands",venueBands);
        model.Add("allBands", allBands);

        return View["venue.cshtml", model];
      };

      Delete["/venue/delete"]=_=>{
        Venue deleteVenue = Venue.Find(Request.Form["venue_id"]);
        deleteVenue.Delete();
        List<Venue> allvenues = Venue.GetAll();
        return View["index.cshtml", allvenues];
      };


















    }
  }
}
