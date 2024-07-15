using System;
using System.Runtime.InteropServices;

namespace PM5
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AdditionalRow
    {
        static public readonly string ID = "0032";
        // Elapsed Time
        public uint elapsedTime;         // Elapsed Time Lo (0.01 sec lsb)
    
        // Speed
        public ushort speed;               // Speed Lo (0.001m/s lsb), CSAFE_GETSPEED_CMD6

        // Stroke Rate
        public byte strokeRate;            // Stroke Rate (strokes/min), CSAFE_PM_GET_STROKERATE

        // Heart Rate
        public byte heartRate;             // Heartrate (bpm, 255=invalid), CSAFE_PM_GET_AVG_HEARTRATE

        // Current Pace
        public ushort currentPace;         // Current Pace Lo (0.01 sec lsb), CSAFE_PM_GET_STROKE_500MPACE

        // Average Pace
        public ushort avgPace;             // Average Pace Lo (0.01 sec lsb), CSAFE_PM_GET_TOTAL_AVG_500MPACE

        // Rest Distance
        public ushort restDistance;        // Rest Distance Lo, CSAFE_PM_GET_RESTDISTANCE

        // Rest Time
        public uint restTime;            // Rest Time Lo (0.01 sec lsb), CSAFE_PM_GET_RESTTIME
        
        // Erg Machine Type
        public ErgMachineType ergMachineType;        // Erg Machine Type 7

        public override string ToString()
        {
            return $"{HelperFunctions.IntToTimeSpan(elapsedTime)} " +
                $"{HelperFunctions.ShortToMetersPerSecond(speed)} " +
                $"{strokeRate}/M " +
                $"{heartRate:X1} " +
                $"{currentPace} " +
                $"{avgPace:X2} " +
                $"{restDistance:X2} " +
                $"{restTime:X4} " +
                $"{ergMachineType}";
        }

        // Constructor from byte array
        public AdditionalRow(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray));

            // if (byteArray.Length != 17)
            //     throw new ArgumentException($"Byte array length must be 17 bytes. {byteArray.Length}");

            int offset = 0;

            // Elapsed Time (3 bytes)
            elapsedTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);

            // Speed (2 bytes)
            speed = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
            
            // Stroke Rate (1 bytes)
            strokeRate = byteArray[offset++];

            // Heart Rate (1 bytes)
            heartRate = byteArray[offset++];

            // Current Pace (2 bytes)
            currentPace = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
            
            // Average Pace (2 bytes)
            avgPace = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
            
            // Rest Distance (2 bytes)
            restDistance = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
            
            // Rest Time (3 bytes)
            restTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            
            // Erg Machine Type (1 byte)
            ergMachineType = 0;//(ErgMachineType)byteArray[offset];
        }
    }
}