using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PM5
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WorkoutSummary2
    {
        static public readonly string ID = "003A";
        public ushort date;
        public ushort time;
        public byte splitType;
        public ushort splitSize;
        public byte splitCount;
        public ushort totalCalories;
        public ushort watts;
        public uint restDistance;
        public ushort restTime;
        public ushort avgCalories; // cal/hr

        public WorkoutSummary2(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray));

            if (byteArray.Length != 19)
                throw new ArgumentException("Byte array length must be 19 bytes.");

            int offset = 0;
            date = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
            
            time = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
            
            splitType = byteArray[offset++];

            splitSize = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            splitCount = byteArray[offset++];

            totalCalories = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            watts = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            restDistance = HelperFunctions.ThreeByteToInt(byteArray, ref offset);

            restTime = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            avgCalories = BitConverter.ToUInt16(byteArray, offset);
        }
    }
}