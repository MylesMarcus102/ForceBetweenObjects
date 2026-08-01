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

        double force = 1;
        double DTStep = 0;
        double DY=100;
        double DX=100;
        double DT = 0.01;
        double VelocityX1 = 0;
        double VelocityX2 = 0;
        double VelocityY1 = 0;
        double VelocityY2 = 0;
        double Distance = Math.Sqrt(DY*DY+DX*DX);
        Console.WriteLine("");
        while (Distance > 0.1)
        {
            if (force >= 1e300)
            {
                break;
            }
            DX = (Object2.x - Object1.x);
            DY = (Object2.y - Object1.y);
            Distance = Math.Sqrt(DX*DX + DY*DY);
            if (Distance < 5)
            {
                DT = 0.0001;
            }
            force = (Object1.mass * Object2.mass*G)/Math.Pow(Distance,2);
            double AccelerationX1 = force/Object1.mass*(DX/Distance);
            double AccelerationX2 = (force/Object2.mass)*(-DX/Distance);
            double AccelerationY1 = force/Object1.mass*(DY/Distance);
            double AccelerationY2 = (force/Object2.mass)*(-DY/Distance);
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
            Console.Write($"\r Object1 Position: ({Object1.x} meters,{Object1.y} meters) Object2 Position: ({Object2.x} meters,{Object2.y} meters) Time passed: {DTStep} seconds, force: {force} newtons. ");
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