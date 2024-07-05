using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PM5
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WorkoutSummary
    {
        static public readonly string ID = "0039";
        public ushort date;
        public ushort time;
        public uint elapsedTime;
        public uint distance;
        public byte avgStrokeRate;
        public byte endingHeartRate;
        public byte avgHeartRate;
        public byte minHeartRate;
        public byte maxHeartRate;
        public byte dragFactorAvg;
        public byte workoutType;
        public byte recoveryHeartRate;
        public ushort avgPace;

        public WorkoutSummary(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray));

            if (byteArray.Length != 20)
                throw new ArgumentException("Byte array length must be 20 bytes.");

            int offset = 0;
            date = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
            
            time = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
            
            elapsedTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            distance = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            avgStrokeRate = byteArray[offset++];
            endingHeartRate = byteArray[offset++];
            avgHeartRate = byteArray[offset++];
            minHeartRate = byteArray[offset++];
            maxHeartRate = byteArray[offset++];
            dragFactorAvg = byteArray[offset++];
            workoutType = byteArray[offset++];
            recoveryHeartRate = byteArray[offset++];
            avgPace = BitConverter.ToUInt16(byteArray, offset);
        }
    }
}