using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Converter
{
    public static List<Color> TextToColor(string text)
    {
        var bytes = Encoding.ASCII.GetBytes(text);
        var hexString = ByteArrayToHex(bytes);
        var colors = new List<Color>();
        for (var i = 0; i < hexString.Length; i += 6)
            colors.Add(HexToColor(hexString.Substring(i, Math.Min(6, hexString.Length - i))));
        return colors;
    }

    public static string ColorToText(string colors) => Encoding.ASCII.GetString(HexToByteArray(colors.Replace(",", "").Replace("#", "")));

    private static string ByteArrayToHex(IReadOnlyCollection<byte> ba)
    {
        StringBuilder hex = new StringBuilder(ba.Count * 2);
        foreach (var b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }

    private static byte[] HexToByteArray(string hex)
    {
        var numberChars = hex.Length;
        var bytes = new byte[numberChars / 2];
        for (var i = 0; i < numberChars; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        return bytes;
    }

    private static Color HexToColor(string hex)
    {
        while (hex.Length < 6) hex += 0;
        return ColorUtility.TryParseHtmlString($"#{hex}", out var color) ? color : Color.clear;
    }
}