using System.Globalization;
using System.Net.Http.Json;

namespace UserAPI;

public class UserService
{
    private readonly HttpClient client;
    private const string url = "https://jsonplaceholder.typicode.com/users";

    public UserService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await client.GetFromJsonAsync<List<User>>(url);
        return users ?? new List<User>();
    }

    public async Task<User> GetUserById(int id)
    {
        var users = await GetAllUsers();
        return users.Where(user => user.Id == id).FirstOrDefault();
    }

    public async Task<List<User>> GetUserByCity(string city)
    {
        var users = await GetAllUsers();
        return users
            .Where(u => u.Address.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<List<User>> GetUserBySuite(string suite)
    {
        var users = await GetAllUsers();
        return users
            .Where(u => u.Address.Suite.Equals(suite, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<List<User>> GetUserByCompany(string name)
    {
        var users = await GetAllUsers();
        return users.Where(u=> u.company.name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<List<User>> GetUserEmailByDomain(string domain)
    {
        var users = await GetAllUsers();
        return users.Where(u => u.Email.Contains(domain,StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public async Task<List<User>> GetUserInGeoRange(double minRange)
    {
        var users = await GetAllUsers();
        return users.Where(u =>
        {
            double lat= double.Parse(u.Address.Geo.lat, CultureInfo.InvariantCulture);
            double lng= double.Parse(u.Address.Geo.lng, CultureInfo.InvariantCulture);

            return lat > minRange && lng > minRange;
        }).ToList();
    }
    
    public async Task<Dictionary<string, int>> GetCityDistribution()
    {
        var users = await GetAllUsers();
        
        return users
            .GroupBy(u=>u.Address.City)
            .ToDictionary(g => g.Key, g => g.Count());
        
    }

    public async Task<List<string>> GetNameAlphabetically()
    {
        var users = await GetAllUsers();

        return users.OrderBy(u=> u.Name).Select(u => u.Name).ToList();
    }
    
    public async Task SaveSummaryToFile(string fileName)
    {
        var users = await GetAllUsers();
        var summary = users.Select(u => u.Name + u.Email + u.Address.City);
        await File.WriteAllLinesAsync(fileName,summary);
    }
}