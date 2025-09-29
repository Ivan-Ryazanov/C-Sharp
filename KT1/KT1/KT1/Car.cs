namespace KT1
{
    class Driver
    {
        public double AverageSpeed;
        public double Coordinates;
        public double Condition;

        private readonly double _CityAstart = 1010;
        private readonly double _CityAend = 1020;

        private readonly double _CityBstart = 3565;
        private readonly double _CityBend = 3580;

        private readonly double _CityCstart = -2530;
        private readonly double _CityCend = -2500;


        public Driver(double averageSpeed, double initialCoordinates)
        {
            AverageSpeed = averageSpeed;
            Coordinates = initialCoordinates;
            Condition = 100;
        }

        public double Drive(double time)
        {
            if (Condition <= 0)
            {
                Console.WriteLine("Ошибка: Техническое состояние машины 0%");
                return 0;
            }

            double distance = AverageSpeed * time;
            Coordinates += distance; // + дистанция 

            double deterioration = Math.Floor(distance / 100);
            Condition -= deterioration * 0.01;


            if (Condition < 0) Condition = 0;

            return distance;
        }

        public double DriveBack(double time)
        {
            if (Condition <= 0)
            {
                Console.WriteLine("Ошибка: Техническое состояние машины 0%");
                return 0;
            }

            double distance = AverageSpeed * time;
            Coordinates -= distance; // - дистанция 

            double deterioration = Math.Floor(distance / 100);
            Condition -= deterioration * 0.01;

            if (Condition < 0) Condition = 0;

            return distance;
        }

        public void PrintLocation()
        {
            if (Coordinates >= _CityAstart && Coordinates <= _CityAend)
                Console.WriteLine("Машина в городе A");
            else if (Coordinates >= _CityBstart && Coordinates <= _CityBend)
                Console.WriteLine("Машина в городе B");
            else if (Coordinates >= _CityCstart && Coordinates <= _CityCend)
                Console.WriteLine("Машина в городе C");
            else
                Console.WriteLine("Машина на трассе");
        }

        public void PrintCarTechnicalState()
        {
            Console.WriteLine($"Техническое состояние машины: {Condition:F2}%");
        }
    }
}