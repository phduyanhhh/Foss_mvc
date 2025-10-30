using G7.Foss.Debugging;

namespace G7.Foss;

public class FossConsts
{
    public const string LocalizationSourceName = "Foss";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "3f5e4e19a4214ec4824e26a6e9a98173";
}
