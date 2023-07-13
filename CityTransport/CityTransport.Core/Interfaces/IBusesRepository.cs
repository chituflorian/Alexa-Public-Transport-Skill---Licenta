using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityTransport.Core.Data;

namespace CityTransport.Core.Interfaces
{
    public interface IBusesRepository
    {
        Task<Bus> GetBusByIdAsync(int id);

        Task<IReadOnlyList<Bus>> GetBusesAsync();

        Task<IReadOnlyList<Schedule>> GetBusesWithScheduleAsync();

        /// <summary>
        /// Gets the list of buses that stop at a given bus station.
        /// </summary>
        /// <param name="stationName">The name of the bus station.</param>
        /// <returns>A list of <see cref="Bus"/> objects.</returns>
        Task<IReadOnlyList<Bus>> GetBusesByStationName(string stationName);
        Task<IReadOnlyList<object>> GetBusesByStationNameWithScheduleAsync(string stationName);

        /// <summary>
        /// Gets a list of buses that operate on the specified route, defined by a pair of terminal stations.
        /// The list is ordered by the expected arrival time of the next bus at the specified station.
        /// </summary>
        /// <param name="stationName">The name of the station to check for buses at.</param>
        /// <param name="terminal">The name of the terminal station that defines the route.</param>
        /// <returns>A list of anonymous objects representing buses, including their name and expected arrival time.</returns>
        /// <remarks>
        /// The method returns buses that have a schedule that includes both the specified station and the specified terminal station,
        /// ordered by the expected arrival time of the next bus at the specified station. The expected arrival time is computed based on
        /// the current time and the schedule of the bus. If no buses are found that meet these criteria, an empty list is returned.
        /// </remarks>

        Task<IReadOnlyList<object>> GetBusesOnTheSpecifiedRouteAsync(string stationName, string terminal);

        /// <summary>
        /// Gets a list of buses that operate on the specified route, defined by a pair of terminal stations and a specific bus line.
        /// The list is ordered by the expected arrival time of the next bus at the specified station.
        /// </summary>
        /// <param name="stationName">The name of the station to check for buses at.</param>
        /// <param name="terminal">The name of the terminal station that defines the route.</param>
        /// <param name="line">The name of the bus line to search for.</param>
        /// <returns>A list of anonymous objects representing buses, including their name, expected arrival time, and day of week.</returns>
        /// <remarks>
        /// The method returns buses that have a schedule that includes both the specified station and the specified terminal station,
        /// and belong to the specified bus line, ordered by the expected arrival time of the next bus at the specified station. The expected arrival time
        /// is computed based on the current time and the schedule of the bus. If no buses are found that meet these criteria, an empty list is returned.
        /// </remarks>
        Task<IReadOnlyList<object>> GetBusesOnTheSpecifiedRouteAsync(string stationName, string terminal, string line);

        /// <summary>
        /// Gets the time remaining until the next bus on a specific line arrives at a given station, and continuing to a specified terminal.
        /// </summary>
        /// <param name="stationName">The name of the station to check for bus arrivals at.</param>
        /// <param name="terminal">The name of the terminal station that the bus is expected to reach.</param>
        /// <param name="line">The name of the bus line to search for.</param>
        /// <returns>The time remaining in minutes until the next bus of the specified line arrives at the given station, continuing towards the terminal station.</returns>
        /// <remarks>
        /// This method returns the time remaining until the next bus arrives, considering the current time and the bus schedule. It is calculated based on buses that operate on the route defined by the given pair of stations and the specific bus line.
        /// If there's no bus found that meets these criteria, or the bus has already passed for the day, the method will return null.
        /// </remarks>

        Task<int?> GetNextBusTimeAsync(string stationName, string terminal, string line);

    }
}
