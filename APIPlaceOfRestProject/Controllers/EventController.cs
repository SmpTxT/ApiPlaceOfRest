using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPlaceOfRestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        APIPlaceOfRestContext _context;

        public EventController(APIPlaceOfRestContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<object> GetEvents()
        {
            var result = from events in _context.Events
                         join themeevents in _context.Themes on events.Theme equals themeevents.Idtheme
                         join picturelick in _context.PictureLinks on events.PictureLink equals picturelick.Idpicture
                         join eventlick in _context.EventLinks on events.EventLink equals eventlick.Idevent
                         join building in _context.Buildings on events.Building equals building.Idbuilding
                         join street in _context.Streets on building.Idstreet equals street.Idstreet
                         join underground in _context.Undergrounds on events.Underground equals underground.Idunderground
                         join coordinateLatitude in _context.Coordinates on building.Idcoordinate equals coordinateLatitude.Idcoordinate
                         join coordinateLongitude in _context.Coordinates on building.Idcoordinate equals coordinateLongitude.Idcoordinate

                         select new { id = events.Idevent, 
                             name = events.Name, 
                             theme = themeevents.Name, 
                             date = events.Date, 
                             discription = events.Discription, 
                             picture = picturelick.Link, 
                             eventev = eventlick.Link, 
                             build = building.NumberBuilding, 
                             structur = building.NumberStructure, 
                             street = street.Name, 
                             metro = underground.Name,
                             coordinatee = coordinateLatitude.Latitude, 
                             coordinateLongitude.Longitude};
            return result;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<object> GetMapMarker()
        {
            var result = from events in _context.Events
                         join building in _context.Buildings on events.Building equals building.Idbuilding
                         join coordinateLatitude in _context.Coordinates on building.Idcoordinate equals coordinateLatitude.Idcoordinate
                         join coordinateLongitude in _context.Coordinates on building.Idcoordinate equals coordinateLongitude.Idcoordinate
                         select new { id = events.Idevent, name = events.Name, coordinatee = coordinateLatitude.Latitude, coordinateLongitude.Longitude };
            return result;
        }

        [HttpGet]
        [Route("[action]/theme/{theme}")]
        public IEnumerable<Object> SearchByEvents(string theme)
        {
            var result = from events in _context.Events
                         join themeevents in _context.Themes on events.Theme equals themeevents.Idtheme
                         join picturelick in _context.PictureLinks on events.PictureLink equals picturelick.Idpicture
                         join eventlick in _context.EventLinks on events.EventLink equals eventlick.Idevent
                         join building in _context.Buildings on events.Building equals building.Idbuilding
                         join street in _context.Streets on building.Idstreet equals street.Idstreet
                         join underground in _context.Undergrounds on events.Underground equals underground.Idunderground
                         join coordinateLatitude in _context.Coordinates on building.Idcoordinate equals coordinateLatitude.Idcoordinate
                         join coordinateLongitude in _context.Coordinates on building.Idcoordinate equals coordinateLongitude.Idcoordinate

                         where themeevents.Name == theme

                         select new
                         {
                             id = events.Idevent,
                             name = events.Name,
                             theme = themeevents.Name,
                             date = events.Date,
                             discription = events.Discription,
                             picture = picturelick.Link,
                             eventev = eventlick.Link,
                             build = building.NumberBuilding,
                             structur = building.NumberStructure,
                             street = street.Name,
                             metro = underground.Name,
                             coordinatee = coordinateLatitude.Latitude,
                             coordinateLongitude.Longitude
                         };
            return result;
        }

        [HttpGet]
        [Route("[action]/id/{id}")]
        public IEnumerable<Object> CatchIDEvent(int id)
        {
            var result = from events in _context.Events
                         join themeevents in _context.Themes on events.Theme equals themeevents.Idtheme
                         join picturelick in _context.PictureLinks on events.PictureLink equals picturelick.Idpicture
                         join eventlick in _context.EventLinks on events.EventLink equals eventlick.Idevent
                         join building in _context.Buildings on events.Building equals building.Idbuilding
                         join street in _context.Streets on building.Idstreet equals street.Idstreet
                         join underground in _context.Undergrounds on events.Underground equals underground.Idunderground
                         join coordinateLatitude in _context.Coordinates on building.Idcoordinate equals coordinateLatitude.Idcoordinate
                         join coordinateLongitude in _context.Coordinates on building.Idcoordinate equals coordinateLongitude.Idcoordinate

                         where events.Idevent == id

                         select new
                         {
                             id = events.Idevent,
                             name = events.Name,
                             theme = themeevents.Name,
                             date = events.Date,
                             discription = events.Discription,
                             picture = picturelick.Link,
                             eventev = eventlick.Link,
                             build = building.NumberBuilding,
                             structur = building.NumberStructure,
                             street = street.Name,
                             metro = underground.Name,
                             coordinatee = coordinateLatitude.Latitude,
                             coordinateLongitude.Longitude
                         };
            return result;
        }
    }
}
