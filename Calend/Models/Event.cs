using System.ComponentModel.DataAnnotations;

namespace Calend.Models
{
    public class Event
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int ResourceId { get; set; }


        public virtual Location Location { get; set; }
        public virtual AppUser User { get; set; }


        public Event(IFormCollection form, Location location, AppUser user)
        {
            User = user;
            Name = form["Event.Name"].ToString();
            Description = form["Event.Description"].ToString();
            Start = DateTime.Parse(form["Event.Start"].ToString());
            End = DateTime.Parse(form["Event.End"].ToString());
            Location = location;

        }

        public void UpdateEvent(IFormCollection form, Location location, AppUser user)
        {
            User = user;
            Name = form["Event.Name"].ToString();
            Description = form["Event.Description"].ToString();
            Start = DateTime.Parse(form["Event.Start"].ToString());
            End = DateTime.Parse(form["Event.End"].ToString());
            Location = location;
        }

        public Event()
        {

        }
    }
}
