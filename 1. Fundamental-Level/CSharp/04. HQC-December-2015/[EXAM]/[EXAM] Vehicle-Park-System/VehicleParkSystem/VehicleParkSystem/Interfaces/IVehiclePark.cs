namespace VehicleParkSystem.Interfaces
{
    using System;

    using VehicleParkSystem.Models.Vehicles;

    /// <summary>
    /// Provides basic operations required to run the vehicle park.
    /// </summary>
    public interface IVehiclePark
    {
        /// <summary>
        /// Adds a car in the vehicle park.
        /// </summary>
        /// <param name="car">The car to add in the park</param>
        /// <param name="sector">The sector where the car should be parked</param>
        /// <param name="placeNumber">The place in the sector where the car should be parked</param>
        /// <param name="startTime">The time when the car is parked</param>
        /// <returns>Returns a success message that the car is added to the park. Returns error message if the sector or the place number are invalid, if the place is occupied by another vehicle and if the park already contains a vehicle with the same license plate.</returns>
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Adds a truck in the vehicle park.
        /// </summary>
        /// <param name="truck">The truck to add in the park</param>
        /// <param name="sector">The sector where the truck should be parked</param>
        /// <param name="placeNumber">The place in the sector where the truck should be parked</param>
        /// <param name="startTime">The time when the truck is parked</param>
        /// <returns>Returns a success message that the truck is added to the park. Returns error message if the sector or the place number are invalid, if the place is occupied by another vehicle and if the park already contains a vehicle with the same license plate.</returns>
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Adds a motorbike in the vehicle park.
        /// </summary>
        /// <param name="motorbike">The motorbike to add in the park</param>
        /// <param name="sector">The sector where the motorbike should be parked</param>
        /// <param name="placeNumber">The place in the sector where the motorbike should be parked</param>
        /// <param name="startTime">The time when the motorbike is parked</param>
        /// <returns>Returns a success message that the motorbike is added to the park. Returns error message if the sector or the place number are invalid, if the place is occupied by another vehicle and if the park already contains a vehicle with the same license plate.</returns>
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Removes the vehicle from the vehicle park.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle</param>
        /// <param name="endOfParking">The time of leaving the park. Used to calculate the price of the ticket</param>
        /// <param name="amountPaid">The amount of money the owner pays for the parking</param>
        /// <returns>Returns a ticket, that shows the place of parking, regular rate, over time rate, total price, paid amount and change. Returns an error message if there is not vehicle with such license plate.</returns>
        string ExitVehicle(string licensePlate, DateTime endOfParking, decimal amountPaid);

        /// <summary>
        /// Gives a report for each sector how many vehicles are currently parked, the capacity of the sector, and the percentage of fullness of the sector. 
        /// </summary>
        /// <returns>Returns a report for each sector in the park.</returns>
        string GetStatus();

        /// <summary>
        /// Finds the vehicle with the specified license plate.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle</param>
        /// <returns>Returns the vehicle with the given license plate. Returns an error message if the no such vehicle exists.</returns>
        string FindVehicle(string licensePlate);

        /// <summary>
        /// Find all vehicles for the specified owner.
        /// </summary>
        /// <param name="owner">The name of the owner</param>
        /// <returns>Returns the vehicles by the given owner. Returns a error message if there are no vehicles to the owner or the owner does not exist.</returns>
        string FindVehiclesByOwner(string owner);
    }
}