namespace CocktailyWPF.Extensions;

public static class SessionStorage
{
    private static readonly Dictionary<string, object> _data = new();

    public static void Set(string key, object value) => _data[key] = value;

    public static T Get<T>(string key) => _data.TryGetValue(key, out var value) ? (T)value : default;

    public static bool Has(string key) => _data.ContainsKey(key);
}
