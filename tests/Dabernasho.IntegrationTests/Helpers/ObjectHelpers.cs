namespace Dabernasho.IntegrationTests.Helpers;

public class ObjectHelpers
{
    public static string ToQueryString(object obj)
    {
        return string.Join("&", obj.GetType()
            .GetProperties()
            .Where(p => p.GetValue(obj, null) != null)
            .Select(p => $"{Uri.EscapeDataString(p.Name)}={Uri.EscapeDataString(p.GetValue(obj).ToString())}"));
    }
}