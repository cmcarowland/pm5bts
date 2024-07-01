using System;
using System.Runtime.InteropServices;
using System.Linq;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct RowData2
{
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
        var et = byteArray.Take(3).ToList();
        et.Add(0);
        elapsedTime = BitConverter.ToUInt32(et.ToArray(), 0);
        offset += 3;

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
        et = byteArray.Skip(offset).Take(3).ToList();
        et.Add(0);
        lastSplitTime = BitConverter.ToUInt32(et.ToArray(), 0);
        offset += 3;

        // Last Split Distance (3 bytes)
        et = byteArray.Skip(offset).Take(3).ToList();
        et.Add(0);
        lastSplitDistance = BitConverter.ToUInt32(et.ToArray(), 0);
    }
  
    public override string ToString()
    {
        return $"{elapsedTime:X2} " +
               $"{intervalCount:X2} " +
               $"{avgPower:X2} " +
               $"{totalCalories:X2} " +
               $"{splitAvgPace:X2} " +
               $"{splitAvgPower:X2} " +
               $"{splitAvgCalories:X2} " +
               $"{lastSplitTime:X2} " +
               $"{lastSplitDistance:X2}";
    }
}
