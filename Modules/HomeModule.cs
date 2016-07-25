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
        selectedVenue.AddBand(selectedBand);
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
        selectedBand.AddVenue(selectedVenue);
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

      Delete["band/{bid}/drop/{vid}"]=parameters=>{
        Band selectedBand = Band.Find(parameters.bid);
        Venue selectedVenue = Venue.Find(parameters.vid);
        selectedBand.RemoveVenue(selectedVenue);

        Dictionary<string,object> model = new Dictionary<string, object>();
        List<Venue> venueForBand = selectedBand.GetVenues();
        List<Venue> allvenues = Venue.GetAll();

        model.Add("Bands",selectedBand);
        model.Add("Venue",venueForBand);
        model.Add("allVenues", allvenues);

        return View["band.cshtml", model];
      };


      Delete["/venue/{vid}/drop/{bid}"]=parameters=>{
        Band selectedBand = Band.Find(parameters.bid);
        Venue selectedVenue = Venue.Find(parameters.vid);
        selectedVenue.RemoveBand(selectedBand);

        Dictionary<string,object> model = new Dictionary<string, object>();
        List<Band> bandforVenue = selectedVenue.GetBands();
        List<Band> allBands = Band.GetAll();

        model.Add("Bands",bandforVenue);
        model.Add("Venue",selectedVenue);
        model.Add("allBands", allBands);

        return View["venue.cshtml", model];
      };



      Delete["/venue/delete"]=_=>{
        Venue deleteVenue = Venue.Find(Request.Form["venue_id"]);
        deleteVenue.Delete();
        List<Venue> allvenues = Venue.GetAll();
        return View["index.cshtml", allvenues];
      };

      Get["/update/{id}"]=parameters=>{
        Venue updateVenue = Venue.Find(parameters.id);
        return View["venue_update.cshtml", updateVenue];
      };

      Patch["/update/{id}"]=parameters=>{
        Venue updateVenue = Venue.Find(parameters.id);
        updateVenue.Update(Request.Form["name"]);
        return View["index.cshtml", Venue.GetAll()];
      };



    }
  }
}
