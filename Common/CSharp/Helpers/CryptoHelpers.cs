namespace Common.Helpers;
public static class CryptoHelpers
{
    public static byte[] HashWithSHA256(string str)
    {
        byte[] strBytes = System.Text.Encoding.UTF8.GetBytes(str);
        return System.Security.Cryptography.SHA256.HashData(strBytes);
    }
}