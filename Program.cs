public class ForceCalculator
{
    public double G;
    public double mass2;
    public double mass;
    public double x;
    public double y;
    public double z;
    public double x2;
    public double y2;
    public double z2;
    public (double x, double y, double z) Position;
    public void Introduction()
    {
        Console.WriteLine("This will calculate the gravitational force two objects would have on each other");
    }

    public (double,double,double,double, double) Setup()
    {
        while (true)
        {
            Console.WriteLine("Please type the mass of the object in kilograms");
            mass = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please type the x coordinates in meters of your object");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please type the y coordinates in meters of your object");
            y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please type the z coordinates in meters of your object");
            z = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please type the mass of the second object in kilograms");
            mass2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please type the x coordinates in meters of your second object");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please type the y coordinates in meters of your second object");
            y2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please type the z coordinates in meters of your second object");
            z2 = Convert.ToDouble(Console.ReadLine());
            G = 6.6743 * Math.Pow(10, -11);
            Position = (x, y, z);
            if (x2 == x && y2 == y && z2 == z)
            {
                Console.WriteLine("Please retype the coordinates because they occupy the same space");
            }
            else
            {
                break;
            }   
            
        }
        return (G, mass, x, y, z);
    }
    public void Force()
    {
            double Distance = Math.Sqrt((x-x2)*(x-x2)+(y-y2)*(y-y2)+(z-z2)*(z-z2));
            double force = (mass2 * mass*G)/Math.Pow(Distance,2);
            Console.WriteLine($"Your objects are pulling each other at {force} newtons.");
    }
}

public class Program
{
    public static void Main()
    {
        ForceCalculator Force = new ForceCalculator();
        Force.Introduction();
        Force.Setup();
        Force.Force();
    }
}