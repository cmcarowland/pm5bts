using System;
using System.Runtime.InteropServices;
using System.Linq;

namespace PM5
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RowGeneral
    {
        static readonly string ID = "0031";

        public uint elapsedTime; // Elapsed Time Lo (0.01 sec lsb)
        public uint distance; // Distance Lo (0.1 m lsb)
        public WorkoutType workoutType; // Workout Type (enum)
        public IntervalType intervalType; // Interval Type (enum)
        public WorkoutState workoutState; // Workout State (enum)
        public RowingState rowingState; // Rowing State (enum)
        public StrokeState strokeState; // Stroke State (enum)
        public uint totalWorkDistance; // Total Work Distance Lo
        public uint workoutDuration; // Workout Duration Lo (if time, 0.01 sec lsb)
        public WorkoutDurationType workoutDurationType; // Workout Duration Type (enum)
        public byte dragFactor; // Drag Factor
    
        public RowGeneral(byte[] byteArray)
        {
            if (byteArray == null)
                throw new ArgumentNullException(nameof(byteArray));

            if (byteArray.Length != 19)
                throw new ArgumentException($"Byte array length must be 19 bytes.");

            int offset = 0;
            elapsedTime = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            distance = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            workoutType = (WorkoutType)byteArray[offset++];
            intervalType = (IntervalType)byteArray[offset++];
            workoutState = (WorkoutState)byteArray[offset++];
            rowingState = (RowingState)byteArray[offset++];
            strokeState = (StrokeState)byteArray[offset++];
            totalWorkDistance = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            workoutDuration = HelperFunctions.ThreeByteToInt(byteArray, ref offset);
            workoutDurationType = (WorkoutDurationType)byteArray[offset++];
            dragFactor = byteArray[offset];
        }

        public override string ToString()
        {
            return $"ET: {HelperFunctions.IntToTimeSpan(elapsedTime)} Distance: {HelperFunctions.DistToFloat(distance)} WorkoutType: {workoutType}\n" + 
                   $"IntType: {intervalType} WorkoutState: {workoutState} Rowing State: {rowingState}\n" +
                   $"Stroke: {strokeState} TotalWorkDist: {workoutState} Workout Dur: {HelperFunctions.IntToTimeSpan(workoutDuration)}\n" +
                   $"Workout Dur Type: {workoutDurationType} Drag Factor: {dragFactor}";
        }
    }

}