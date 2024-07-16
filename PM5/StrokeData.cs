using System;
using System.Runtime.InteropServices;
using UnityEditor;

namespace PM5
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StrokeData
    {
        static public readonly string ID = "0035";

        // Define all data types according to the given ranges and requirements.
        public uint elapsedTime; // Lo (0.01 sec lsb)
        
        public uint distance;

        public ushort driveLength; // (0.01 meters, max = 2.55m)

        public ushort driveTime; // (0.01 sec, max = 2.55 sec)

        public ushort strokeRecoveryTime; // Lo (0.01 sec, max = 655.35 sec)

        public ushort strokeDistance; // Lo (0.01 m, max=655.35m)

        public ushort peakDriveForce; // Lo (0.1 lbs of force, max=6553.5 lbs)

        public ushort averageDriveForce; // Lo (0.1 lbs of force, max=6553.5 lbs)

        public ushort workPerStroke; // Lo (0.1 Joules, max=6553.5 Joules)

        public ushort strokeCount; // Lo

        public StrokeData(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray));

            if (byteArray.Length != 20)
                throw new ArgumentException("Byte array length must be 20 bytes.");

            int offset = 0;
            elapsedTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            distance = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            
            driveLength = byteArray[offset++]; // 0.01 meters max 2.55m
            driveTime = byteArray[offset++]; //0.01 sec max = 2.55 sec

            strokeRecoveryTime = BitConverter.ToUInt16(byteArray, offset); //0.01 sec max = 655.35 m
            offset += 2;

            strokeDistance = BitConverter.ToUInt16(byteArray, offset); // 0.01m max=655.35 m
            offset += 2;

            peakDriveForce = BitConverter.ToUInt16(byteArray, offset); // 0.1 lbs max 6553.5
            offset += 2;

            averageDriveForce = BitConverter.ToUInt16(byteArray, offset); // 0.1 lbs max 6553.5
            offset += 2;

            workPerStroke = BitConverter.ToUInt16(byteArray, offset); // 0.1 joules max = 6553.5
            offset += 2;

            strokeCount = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
        }

        public override string ToString()
        {
            return $"Elapsed Time: {elapsedTime}\n" +
                   $"Distance: {distance}\n" +
                   $"Drive Length: {driveLength}\n" +
                   $"Drive Time: {driveTime}\n" +
                   $"Stroke Recovery Time: {strokeRecoveryTime}\n" +
                   $"Stroke Distance: {strokeDistance}\n" +
                   $"Peak Drive Force: {peakDriveForce}\n" +
                   $"Average Drive Force: {averageDriveForce}\n" +
                   $"Work Per Stroke: {workPerStroke}\n" +
                   $"Stroke Count: {strokeCount}";
        }
    }
}
