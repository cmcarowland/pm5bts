using System;
using System.Runtime.InteropServices;

namespace PM5
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AdditionalStroke
    {
        static public readonly string ID = "0036";
        public uint elapsedTime;         // Elapsed Time Lo (0.01 sec lsb)
    
        public ushort strokePower;       // Power in Watts

        public ushort strokeCalories;     // Stroke Calories cal/hr

        public ushort strokeCount;         

        public uint projectedWorkTime;    // Seconds

        public uint projectedWorkDistance; // meters

        public override readonly string ToString()
        {
            return $"ET: {HelperFunctions.IntToTimeSpan(elapsedTime)} " +
                $"Stroke Power (W): {strokePower}\n" +
                $"Stroke Calories : {strokeCalories} " +
                $"Stroke Count : {strokeCount}\n" +
                $"Projected Work Time : {TimeSpan.FromSeconds(projectedWorkTime).ToString(@"hh\:mm\:ss\.f")} " +
                $"Projected Work Distance : {projectedWorkDistance}";
        }

        // Constructor from byte array
        public AdditionalStroke(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray));

            if (byteArray.Length != 15)
                throw new ArgumentException($"Byte array length must be 15 bytes. {byteArray.Length}");

            int offset = 0;
            elapsedTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);

            strokePower = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            strokeCalories = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            strokeCount = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            projectedWorkTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            projectedWorkDistance = HelperFunctions.ThreeByteToInt(byteArray, ref offset);

        }
    }
}