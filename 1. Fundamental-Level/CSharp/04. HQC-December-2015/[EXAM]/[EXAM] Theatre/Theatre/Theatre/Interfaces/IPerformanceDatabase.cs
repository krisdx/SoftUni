namespace Theatre.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds a theatre to the database.
        /// </summary>
        /// <param name="theatreName">The name of the thatre</param>
        /// <exception cref="DuplicateTheatreException">Throws when the theatre name already exists.</exception>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Lists all existing theatres.
        /// </summary>
        /// <returns>Retursn all existing theatres, or an empty collection.</returns>
        IEnumerable<string> ListTheatres();
            
        /// <summary>
        /// Adds a performance to the database.
        /// </summary>
        /// <param name="theatreName">The name of the thatre</param>
        /// <param name="performanceTitle">The name of the performance</param>
        /// <param name="startDateTime">The start date and time of the performance</param>
        /// <param name="duration">The duration of the performance</param>
        /// <param name="price">The price of the performance</param>
        /// <exception cref="TheatreNotFoundException">Throws if the theatre name cannot be found</exception>
        /// <exception cref="TimeDurationOverlapException">Throws if the time of the performance overlap with another performance</exception>
        /// <returns>Returns the performance that has been added to the database.</returns>
        IPerformance AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Lists all existing performances.
        /// </summary>
        /// <returns>Returns all existing performances, or an empty collection.</returns>
        IEnumerable<IPerformance> ListAllPerformances();

        /// <summary>
        /// Finds all performances for the specified theatre.
        /// </summary>
        /// <param name="theatreName">The name of the thatre</param>
        /// <exception cref="TheatreNotFoundException">It is trown then the theatre, does not exist in the database.</exception>
        /// <returns>Returns a list of performances for the specified theatre, as IEnumerable collection.</returns>
        IEnumerable<IPerformance> ListPerformances(string theatreName);
    }
}