using System;
using System.Runtime.InteropServices;

namespace PM5
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SplitData
    {
        static public readonly string ID = "0037";
        
        public uint elapsedTime; //Lo (0.01 sec lsb);
        public uint distance;//(0.1 m lsb);
        
        public uint splitIntervalTime; //(0.1 sec lsb);
        public uint splitIntervalDistance; //Lo ( 1m lsb);
        public ushort intervalRestTime; // Lo (1 sec lsb);
        public ushort intervalRestDistance; //(1m lsb);
        public IntervalType splitIntervalType;
        public byte splitIntervalNumber;

        public SplitData(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray));

            if (byteArray.Length != 18)
                throw new ArgumentException($"Byte array length must be 18 bytes.");

            int offset = 0;
            elapsedTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            distance = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            splitIntervalTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            splitIntervalDistance = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            intervalRestTime = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            intervalRestDistance = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            splitIntervalType = (IntervalType)byteArray[offset++];
            splitIntervalNumber = byteArray[offset++];
        }

        public override string ToString()
            {
                return $"ET : {HelperFunctions.IntToTimeSpan(elapsedTime)} " +
                    $"Distance : {distance}\n" +
                    $"Split Time : {HelperFunctions.IntToTimeSpan(splitIntervalTime)} " +
                    $"Split Dist : {splitIntervalDistance}\n" +
                    $"Interval Rest: {HelperFunctions.IntToTimeSpan(intervalRestTime)} " +
                    $"Interval Dist: {intervalRestDistance}\n" +
                    $"Type : {splitIntervalType} " +
                    $"Split Num: {splitIntervalNumber}";
            }
    }
}