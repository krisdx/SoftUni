namespace VehicleParkSystem.Models
{
    using System.Collections.Generic;

    using System.Web.Script.Serialization;

    using VehicleParkSystem.Interfaces;

    public class Command : ICommand
    {
        public Command(string input)
        {
            this.Name = input.Substring(0, input.IndexOf(' '));
            this.Parameters = new JavaScriptSerializer()
                .Deserialize<Dictionary<string, string>>(input.Substring(input.IndexOf(' ') + 1));
        }

        public string Name { get; private set; }

        public IDictionary<string, string> Parameters { get; private set; }
    }
}