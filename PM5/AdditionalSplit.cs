using System;
using System.Runtime.InteropServices;

namespace PM5
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AdditionalSplit
    {
        static public readonly string ID = "0038";

        public uint elapsedTime;         // Elapsed Time Lo (0.01 sec lsb)
    
        public byte avgStrokeRate;  

        public byte workHeartrate;    

        public byte restHeartrate;    

        public ushort avgPace;         // 0.1 sec

        public ushort totalCalories;    // Calories
        
        public ushort avgCalories;    // Calories/Hour

        public ushort speed; // 0.001 m/s; max= 65.534 m/s

        public ushort power; // Watts; max = 65.534kW

        public ushort avgDragFactor; 

        public ushort splitNumber; 

        public ErgMachineType ergMachineType; 

        public override readonly string ToString()
        {
            return
               $"Elapsed Time: {HelperFunctions.IntToTimeSpan(elapsedTime)}\n" +
               $"Average Stroke Rate: {avgStrokeRate} strokes/min\n" +
               $"Work Heart Rate: {workHeartrate} bpm\n" +
               $"Rest Heart Rate: {restHeartrate} bpm\n" +
               $"Average Pace: {avgPace}\n" +
               $"Total Calories: {totalCalories} kcal\n" +
               $"Average Calories/Hour: {avgCalories} kcal/hr\n" +
               $"Speed: {HelperFunctions.ShortToMetersPerSecond(speed)}\n" +
               $"Power: {power} W\n" +
               $"Average Drag Factor: {avgDragFactor}\n" +
               $"Split Number: {splitNumber}\n" +
               $"Erg Machine Type: {ergMachineType}";
        }

        // Constructor from byte array
        public AdditionalSplit(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray));

            if (byteArray.Length != 19)
                throw new ArgumentException($"Byte array length must be 19 bytes. {byteArray.Length}");

            int offset = 0;
            elapsedTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);

            avgStrokeRate = byteArray[offset++];
            workHeartrate = byteArray[offset++];
            restHeartrate = byteArray[offset++];

            avgPace = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;
           
            totalCalories = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            avgCalories = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            speed = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            power = BitConverter.ToUInt16(byteArray, offset);
            offset += 2;

            avgDragFactor = byteArray[offset++];
            splitNumber = byteArray[offset++];
            ergMachineType = (ErgMachineType)byteArray[offset];
        }
    }
}