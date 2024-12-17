using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using FlightDemo.Api.Data;
using FlightDemo.Api.Models;

namespace FlightDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightScheduleController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IDistributedCache _cache;
    private const string CacheKey = "flightSchedules";

    public FlightScheduleController(ApplicationDbContext context, IDistributedCache cache)
    {
        _context = context;
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cachedData = await _cache.GetStringAsync(CacheKey);
        if (cachedData != null)
        {
            return Ok(JsonSerializer.Deserialize<List<FlightSchedule>>(cachedData));
        }

        var flights = await _context.FlightSchedules.ToListAsync();
        var serializedData = JsonSerializer.Serialize(flights);
        
        await _cache.SetStringAsync(CacheKey, serializedData, 
            new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) });
        
        return Ok(flights);
    }
}
