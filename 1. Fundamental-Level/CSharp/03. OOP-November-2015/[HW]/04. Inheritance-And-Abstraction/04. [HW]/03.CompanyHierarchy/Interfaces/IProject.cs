namespace CompanyHierarchy.Interfaces
{
    using System;
    using CompanyHierarchy.Models;

    public interface IProject
    {
        string Name { get; set; }

        string Details { get; set; }

        DateTime StartDate { get; set; }

        ProjectState State { get; set; }

        void CloseProject();
    }
}