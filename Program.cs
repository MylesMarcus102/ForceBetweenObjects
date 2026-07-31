public class UserObject
{
    public double mass;
    public double x;
    public double y;
    public string Name = "";
    public (double x, double y) Position;

    public (double, double, double) Setup()
    {
            Console.WriteLine($"Please type the mass of the {Name}object in kilograms");
            mass = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Please type the x coordinates in meters of your {Name}object");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Please type the y coordinates in meters of your {Name}object");
            y = Convert.ToDouble(Console.ReadLine());
            Position = (x, y);
            return (mass, x, y);
    }
    
    }
public class ForceCalculator
{
    public void ForceMath()
    {
        double G = 6.6743e-11;
        UserObject Object1 = new UserObject();
        UserObject Object2 = new UserObject();
        Object2.Name = "second ";
        Object1.Setup();
        Object2.Setup();
        while (Object1.Position == Object2.Position)
        {
            Console.WriteLine("Please fix your values, your objects occupy the same space");
            Object1.Setup();
            Object2.Setup();
        }

        double DTStep = 0;
        double DX1;
        double DX2;
        double DY1;
        double DY2;
        double DT = 0.01;
        double VelocityX1 = 0;
        double VelocityX2 = 0;
        double VelocityY1 = 0;
        double VelocityY2 = 0;
        Console.WriteLine("");
        while (Object1.Position != Object2.Position)
        {
            double Distance = Math.Sqrt((Object1.x-Object2.x)*(Object1.x-Object2.x)+(Object1.y-Object2.y)*(Object1.y-Object2.y));
            DY1 = (Object2.y - Object1.y);
            DY2 = (Object1.y - Object2.y);
            DX1 = (Object2.x - Object1.x);
            DX2 = (Object1.x - Object2.x);
            double force = (Object1.mass * Object2.mass*G)/Math.Pow(Distance,2);
            double AccelerationX1 = force/Object1.mass*(DX1/Distance);
            double AccelerationX2 = (force/Object2.mass)*(DX2/Distance);
            double AccelerationY1 = force/Object1.mass*(DY1/Distance);
            double AccelerationY2 = (force/Object2.mass)*(DY2/Distance);
            Console.Write($"\r Object1({Object1.Position.x} meters,{Object1.Position.y} meters) Object2({Object2.Position.x} meters,{Object2.Position.y} meters) Time:{DTStep} seconds. Your objects are pulling each other at {force} newtons.");
            VelocityX1 += AccelerationX1*DT;
            VelocityX2 += AccelerationX2*DT;
            VelocityY1 += AccelerationY1*DT;
            VelocityY2 += AccelerationY2*DT;
            Object1.x += VelocityX1*DT;
            Object1.y += VelocityY1*DT;
            Object2.x += VelocityX2*DT;
            Object2.y += VelocityY2*DT;
            Object1.Position = (Object1.x,Object1.y);
            Object2.Position = (Object2.x,Object2.y);
            DTStep += DT;
            System.Threading.Thread.Sleep(10);
        }
    }
}
    

    public class Program
{
    public static void Main()
    {
        ForceCalculator Force = new ForceCalculator();
        Force.ForceMath();
    }
}