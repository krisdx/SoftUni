namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;
    using CompanyHierarchy.Models;

    public interface IDeveloper
    {
         ISet<Project> Projects { get; set; }

         void AddProjects(ISet<Project> projects);
    }
}
