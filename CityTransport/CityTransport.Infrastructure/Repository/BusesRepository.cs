using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CityTransport.Core.Data;
using CityTransport.Core.Interfaces;
using CityTransport.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CityTransport.Infrastructure.Repository
{
    public class BusesRepository : IBusesRepository
    {
        private readonly RatBVTransportContext _context;

        public BusesRepository(RatBVTransportContext context)
        {
            _context = context;
        }

        public async Task<Bus> GetBusByIdAsync(int id)
        {
            return await _context.Buses.FindAsync(id);
        }

        public async Task<IReadOnlyList<Bus>> GetBusesAsync()
        {
            return await _context.Buses.Include(s => s.Schedules).ToListAsync();
        }


        public async Task<IReadOnlyList<Schedule>> GetBusesWithScheduleAsync()
        {
            return await _context.Schedules.Include(s => s.Bus).Include(s => s.Station).ToListAsync();
        }

        /*This code first retrieves the bus station with the given name and then retrieves
         * the schedules for that station by filtering the schedules by the station ID.
         * Then, it selects the distinct buses from those schedules and loads the schedules
         * for each bus by filtering the schedules by the bus ID and the station ID,
         * and ordering them by arrival time and day of week. Finally, it returns the list of buses
         * with their respective schedules for the specified station.
         */
        public async Task<IReadOnlyList<Bus>> GetBusesByStationName(string stationName)
        {
            // Get the bus station with the given name.
            var station = await _context.BusStations.FirstOrDefaultAsync(s => s.StationName.ToLower() == stationName.ToLower());

            if (station == null)
            {
                return null;
            }

            // Get the list of buses with schedules for the specified station.
            var buses = await _context.Schedules
                .Where(s => s.StationId == station.StationId)
                .Select(s => s.Bus)
                .Distinct()
                .ToListAsync();

            // Load the schedules for the buses.
            foreach (var bus in buses)
            {
                bus.Schedules = await _context.Schedules
                    .Include(s => s.Station)
                    .Where(s => s.BusId == bus.BusId && s.StationId == station.StationId)
                    .OrderBy(s => s.ArrivalTime)
                    .ThenBy(s => s.DayOfWeek)
                    .ToListAsync();
            }

            return buses;
        }


        public async Task<IReadOnlyList<object>> GetBusesByStationNameWithScheduleAsync(string stationName)
        {


            // Set the time zone to Bucharest
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Bucharest");
            // Get the current time in Bucharest
            DateTimeOffset now = DateTimeOffset.UtcNow.ToOffset(timeZone.GetUtcOffset(DateTimeOffset.UtcNow));

            var currentTime = now.TimeOfDay;

            var schedules = await _context.Schedules
                .Include(s => s.Bus)
                .Include(s => s.Station)
                .Where(s => s.Station.StationName.ToLower() == stationName.ToLower() && s.ArrivalTimeExplicit > currentTime)
                .OrderBy(s => s.ArrivalTimeExplicit)
                .Select(s => new
                {
                    BusName = s.Bus.BusName,
                    ArrivalTime = s.ArrivalTime,
                    DayOfWeek = s.DayOfWeek
                })
                .ToListAsync();

            return schedules.Cast<object>().ToList();
        }
        /*The function GetBusesOnTheSpecifiedRouteAsync takes in two parameters: stationName and terminal.
        * It sets the time zone to Bucharest and gets the current time in Bucharest.
        * The function then retrieves the schedules of buses arriving at the specified station and headed towards
        * the specified terminal, with arrival times after the current time in Bucharest time zone.
        * The results are sorted by arrival time and returned as a list of objects containing the bus name,
        * arrival time, and day of the week. This function could be useful for a bus tracking system that needs
        * to display the schedules of buses arriving at a particular station and headed towards a specific terminal.
        */
        public async Task<IReadOnlyList<object>> GetBusesOnTheSpecifiedRouteAsync(string stationName, string terminal)
        {
            // Set the time zone to Bucharest
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Bucharest");
            // Get the current time in Bucharest
            DateTimeOffset now = DateTimeOffset.UtcNow.ToOffset(timeZone.GetUtcOffset(DateTimeOffset.UtcNow));

            var currentTime = now.TimeOfDay;

            var schedules = await _context.Schedules
                .Include(s => s.Bus)
                .Include(s => s.Station)
                .Where(s => s.Station.StationName.ToLower() == stationName.ToLower()
                       && s.ArrivalTimeExplicit > currentTime
                       && _context.Schedules.Any(s2 => s2.Bus.BusName == s.Bus.BusName
                                                  && s2.Station.StationName.ToLower() == terminal.ToLower()))
                .OrderBy(s => s.ArrivalTimeExplicit)
                .Select(s => new
                {
                    BusName = s.Bus.BusName,
                    ArrivalTime = s.ArrivalTime,
                    DayOfWeek = s.DayOfWeek
                })
                .ToListAsync();

            return schedules.Cast<object>().ToList();
        }

        public async Task<IReadOnlyList<object>> GetBusesOnTheSpecifiedRouteAsync(string stationName, string terminal, string line)
        {
            // Set the time zone to Bucharest
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Bucharest");
            // Get the current time in Bucharest
            DateTimeOffset now = DateTimeOffset.UtcNow.ToOffset(timeZone.GetUtcOffset(DateTimeOffset.UtcNow));

            var currentTime = now.TimeOfDay;

            var schedules = await _context.Schedules
                .Include(s => s.Bus)
                .Include(s => s.Station)
                .Where(s => s.Station.StationName.ToLower() == stationName.ToLower()
                       && s.ArrivalTimeExplicit > currentTime
                       && s.Bus.BusName.ToLower() == line.ToLower())
                .OrderBy(s => s.ArrivalTimeExplicit)
                .Select(s => new
                {
                    BusName = s.Bus.BusName,
                    ArrivalTime = s.ArrivalTime,
                    DayOfWeek = s.DayOfWeek
                })
                .ToListAsync();

            schedules = schedules
                .Where(s => _context.Schedules.Any(s2 => s2.Bus.BusName == s.BusName
                                                   && s2.Station.StationName.ToLower() == terminal.ToLower()))
                .ToList();


            return schedules.Cast<object>().ToList();
        }

        public async Task<int?> GetNextBusTimeAsync(string stationName, string terminal, string line)

        {
            // Set the time zone to Bucharest
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Bucharest");
            // Get the current time in Bucharest
            DateTimeOffset now = DateTimeOffset.UtcNow.ToOffset(timeZone.GetUtcOffset(DateTimeOffset.UtcNow));

            var currentTime = now.TimeOfDay;

            // Find the next bus on the given line arriving at the specified station
            var nextBus = await _context.Schedules
                .Include(s => s.Bus)
                .Include(s => s.Station)
                .Where(s => s.Station.StationName.ToLower() == stationName.ToLower()
                        && s.Bus.BusName.ToLower() == line.ToLower()
                        && s.ArrivalTimeExplicit > currentTime
                        && _context.Schedules.Any(s2 => s2.Bus.BusName == s.Bus.BusName
                                                   && s2.Station.StationName.ToLower() == terminal.ToLower()))
                .OrderBy(s => s.ArrivalTimeExplicit)
                .FirstOrDefaultAsync();

            if (nextBus == null)
            {
                // No bus found
                return null;
            }

            // Calculate the time remaining until the next bus arrives
            TimeSpan? timeRemaining = nextBus.ArrivalTimeExplicit - currentTime;

            if (timeRemaining.HasValue)
            {
                return (int)timeRemaining.Value.TotalMinutes;
            }
            else
            {
                return null;
            }


            //return (int)timeRemaining.TotalMinutes;
        }
    }
}
