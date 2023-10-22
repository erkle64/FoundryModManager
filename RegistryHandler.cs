using Microsoft.Win32;

namespace Narod
{
    internal static class RegistryHandler
    {
        public static string? safeGetRegistryKey(string keyName, string regPath)
        {
            object? regKeyObj = Registry.GetValue(regPath, keyName, null);
            if (regKeyObj != null)
            {
                return regKeyObj?.ToString() ?? null;
            }
            else
            {
                return null;
            }
        }
    }
}
