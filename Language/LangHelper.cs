using System.Resources;
using System.Reflection;
using System.Globalization;

namespace Space.Language;

public static class LangHelper
{
    private static readonly ResourceManager _rm;

    static LangHelper()
    {
        _rm = new ResourceManager("Space.Language.messages", Assembly.GetExecutingAssembly());
    }

    public static string? GetString(string name)
    {
        return _rm.GetString(name);
    }

    public static void ChangeLanguage(string language)
    {
        var cultureInfo = new CultureInfo(language);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
    }
}

