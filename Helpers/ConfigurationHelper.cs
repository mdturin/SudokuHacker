namespace SudokuHacker.Helpers;

public static class ConfigurationHelper
{
    private static IConfiguration? _config;
    private static readonly Dictionary<string, Dictionary<string, string?>> _sections
        = new();

    public static void Initialize(IConfiguration config)
    {
        _config = config;
        GetAllConfigurationSections();
    }

    private static void GetAllConfigurationSections()
    {
        foreach (var section in _config!.GetChildren())
        {
            var sectionName = section.Key;
            var sectionValues = section.GetChildren()
                .ToDictionary(child => child.Key, child => child.Value);
            _sections.Add(sectionName, sectionValues);
        }
    }

    public static string? GetValue(string section, string key)
    {
        if (!_sections.ContainsKey(section))
            return null;
        if (!_sections[section].ContainsKey(key))
            return null;
        return _sections[section][key];
    }

    public static string? GetString(string key) => _config![key];

    public static int? GetInt(string key)
    {
        var value = GetString(key);
        if (value == null) return null;
        return int.Parse(value);
    }
}
