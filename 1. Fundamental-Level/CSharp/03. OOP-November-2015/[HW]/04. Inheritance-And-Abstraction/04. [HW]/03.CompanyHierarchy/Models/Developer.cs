namespace CompanyHierarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CompanyHierarchy.Interfaces;

    public class Developer : RegularEmployee, IDeveloper
    {
        public Developer(string id, string firstName, string lastName, Department department, decimal salary, ISet<Project> projects = null)
            : base(id, firstName, lastName, department, salary)
        {
            this.Projects = projects ?? new HashSet<Project>();
        }

        public ISet<Project> Projects { get; set; }

        public void AddProjects(ISet<Project> projects)
        {
            foreach (var project in projects)
            {
                this.Projects.Add(project);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append(base.ToString());
            output.AppendFormat("Open projects: {0}\n",
                this.Projects.Count(project => project.State == ProjectState.Open));
            output.AppendFormat("Closed projects: {0}\n",
                this.Projects.Count(project => project.State == ProjectState.Closed));

            return output.ToString();
        }
    }
}