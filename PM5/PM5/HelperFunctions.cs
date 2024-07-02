using System;

namespace PM5
{
    static class HelperFunctions
    {
        public static string CreateGUID(string command)
        {
            return string.Format("CE06{0}-43E5-11E4-916C-0800200C9A66", command);
        }

        public static uint ThreeByteToInt(byte[] data, ref int offset)
        {
            List<byte> bytes = data.Skip(offset).Take(3).ToList();
            bytes.Add(0);
            offset += 3;
            return BitConverter.ToUInt32(bytes.ToArray(), 0);
        }

        public static string IntToTimeSpan(uint data)
        {
            var ts = TimeSpan.FromSeconds(data * 0.01f);
            if(ts.TotalHours > 1)
                return ts.ToString(@"hh\:mm\:ss\.f");
            
            return ts.ToString(@"mm\:ss\.f");
        }

        public static float ShortToMetersPerSecond(ushort data)
        {
            return data * 0.001f;
        }
    }
}