using System;
using System.Runtime.InteropServices;
using System.Linq;

namespace PM5
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RowData2
    {
        static public readonly string ID = "0033";
        // Elapsed Time
        public uint elapsedTime;

        // Interval Count
        public byte intervalCount;        // CSAFE_PM_GET_WORKOUTINTERVALCOUNT8
        
        // Average Power
        public ushort avgPower;           // CSAFE_PM_GET_TOTAL_AVG_POWER
        
        // Total Calories
        public ushort totalCalories;      // cals

        // Split/Interval Average Pace
        public ushort splitAvgPace;       // 0.01 sec lsb

        // Split/Interval Average Power
        public ushort splitAvgPower;      // watts

        // Split/Interval Average Calories
        public ushort splitAvgCalories;   // cals/hr

        // Last Split Time
        public uint lastSplitTime;      // 0.1 sec lsb

        // Last Split Distance
        public uint lastSplitDistance;  // in meters

        // Constructor from byte array
        public RowData2(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray));

            if (byteArray.Length != 20)
                throw new ArgumentException($"Byte array length must be 20 bytes.");

            int offset = 0;

            // Elapsed Time (3 bytes)
            elapsedTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);

            // Interval Count (1 byte)
            intervalCount = byteArray[offset++];
            
            // Average Power (2 bytes)
            avgPower = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            // Total Calories (2 bytes)
            totalCalories = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            // Split/Interval Average Pace (2 bytes)
            splitAvgPace = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            // Split/Interval Average Power (2 bytes)
            splitAvgPower = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            // Split/Interval Average Calories (2 bytes)
            splitAvgCalories = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            // Last Split Time (3 bytes)
            lastSplitTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);

            // Last Split Distance (3 bytes)
            lastSplitDistance = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
        }
    
        public override string ToString()
        {
            return $"{HelperFunctions.IntToTimeSpan(elapsedTime)} " +
                $"{intervalCount:X2} " +
                $"{avgPower:X2} " +
                $"{totalCalories:X2} " +
                $"{HelperFunctions.IntToTimeSpan(splitAvgPace)} " +
                $"{splitAvgPower:X2} " +
                $"{splitAvgCalories:X2} " +
                $"{HelperFunctions.IntToTimeSpan(lastSplitTime)} " +
                $"{lastSplitDistance}";
        }
    }
}