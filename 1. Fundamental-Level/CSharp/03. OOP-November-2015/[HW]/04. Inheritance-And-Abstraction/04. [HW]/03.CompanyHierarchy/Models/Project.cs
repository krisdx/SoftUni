namespace CompanyHierarchy.Models
{
    using System;
    using CompanyHierarchy.Interfaces;

    public class Project : IProject
    {
        private string name;
        private string details;

        public Project(string name, string details, DateTime startDate)
        {
            this.Name = name;
            this.Details = details;
            this.StartDate = startDate;
            this.State = ProjectState.Open;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Project name cannot be empty.");
                }

                this.name = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Details cannot be empty.");
                }

                this.details = value;
            }
        }

        public DateTime StartDate { get; set; }

        public ProjectState State { get; set; }

        public void CloseProject()
        {
            this.State = ProjectState.Closed;
        }
    }
}