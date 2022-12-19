using Calend.Models;



namespace Calend.Helpers
{
    public class JSONListHelper
    {
        public static string GetEventsListJSONString(List<Models.Event> events)
        {
            var eventList = new List<Event>();
            foreach (var model in events)
            {
                var myevent = new Event()
                {
                    Id = model.Id,
                    Start = model.Start,
                    End = model.End,
                    ResourceId = model.Location.Id,
                    Description = model.Description,
                    Name = model.Name
                };
                eventList.Add(myevent);

            }
            return System.Text.Json.JsonSerializer.Serialize(eventList);

        }

        public static string GetResourceListJSONString(List<Models.Location> locations)
        {
            var resourcelist = new List<Resource>();

            foreach (var loc in locations)
            {
                var resource = new Resource()
                {
                    Id = loc.Id,
                    Name = loc.Name
                };
                resourcelist.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourcelist);
        }

    }
}
