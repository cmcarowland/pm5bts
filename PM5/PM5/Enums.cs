namespace PM5
{
    public enum IntervalType : byte 
    {
		TIME, /**< Time interval type (0). */
		DIST, /**< Distance interval type (1). */
		REST, /**< Rest interval type (2). */
		TIMERESTUNDEFINED, /**< Time undefined rest interval type (3). */
		DISTANCERESTUNDEFINED, /**< Distance undefined rest interval type (4). */
		RESTUNDEFINED, /**< Undefined rest interval type (5). */
		CALORIE, /**< Calorie interval type (6). */
		CALORIERESTUNDEFINED , /**< Calorie undefined rest interval type (7). */
		WATTMINUTE, /**< Watt-minute interval type (8). */
		WATTMINUTERESTUNDEFINED, /**< Watt-minute undefined rest interval type (9). */
		NONE = 255 /**< No interval type (255 ). */
    }

    public enum WorkoutDurationType : byte 
    {
		DURATION_IDENTIFIER_TIME = 0,
		DURATION_IDENTIFIER_CALORIES = 0x40,
		DURATION_IDENTIFIER_DISTANCE = 0x80,
		DURATION_IDENTIFIER_WATTMIN = 0xC0 
    }

    public enum WorkoutType : byte 
    {
		JUSTROW_NOSPLITS, /**< JustRow, no splits (0). */
		JUSTROW_SPLITS, /**< JustRow, splits (1). */
		FIXEDDIST_NOSPLITS, /**< Fixed distance, no splits (2). */
		FIXEDDIST_SPLITS, /**< Fixed distance, splits (3). */
		FIXEDTIME_NOSPLITS, /**< Fixed time, no splits (4). */
		FIXEDTIME_SPLITS, /**< Fixed time, splits (5). */
		FIXEDTIME_INTERVAL, /**< Fixed time interval (6). */
		FIXEDDIST_INTERVAL, /**< Fixed distance interval (7). */
		VARIABLE_INTERVAL, /**< Variable interval (8). */
		VARIABLE_UNDEFINEDREST_INTERVAL, /**< Variable interval, undefined rest (9). */
		FIXEDCALORIE_SPLITS, /**< Fixed calorie, splits (10). */
		FIXEDWATTMINUTE_SPLITS, /**< Fixed watt-minute, splits (11). */
		FIXEDCALS_INTERVAL, /**< Fixed calorie interval (12). */
		NUM /**< Number of workout types (13). */
    }

    public enum WorkoutState : byte
    {
		WAITTOBEGIN = 0,
		WORKOUTROW = 1,
		COUNTDOWNPAUSE = 2,
		INTERVALREST = 3,
		INTERVALWORKTIME = 4,
		INTERVALWORKDISTANCE = 5,
		INTERVALRESTENDTOWORKTIME = 6,
		INTERVALRESTENDTOWORKDISTANCE = 7,
		INTERVALWORKTIMETOREST = 8,
		INTERVALWORKDISTANCETOREST = 9,
		WORKOUTEND = 10,
		TERMINATE = 11,
		WORKOUTLOGGED = 12,
		REARM = 13
    }

    public enum RowingState : byte
    {
		INACTIVE = 0,
		ACTIVE = 1
    }

    public enum StrokeState : byte
    {
		WAITING_FOR_WHEEL_TO_REACH_MIN_SPEED_STATE = 0,
		WAITING_FOR_WHEEL_TO_ACCELERATE_STATE = 1,
		DRIVING_STATE = 2,
		DWELLING_AFTER_DRIVE_STATE = 3,
		RECOVERY_STATE = 4
    }


}