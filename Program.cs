public class UserObject
{
    public double mass;
    public double x;
    public double y;
    public double z;
    public string Name = "";
    public (double x, double y, double z) Position;

    public (double, double, double, double) Setup()
    {
            Console.WriteLine($"Please type the mass of the {Name}object in kilograms");
            mass = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Please type the x coordinates in meters of your {Name}object");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Please type the y coordinates in meters of your {Name}object");
            y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Please type the z coordinates in meters of your {Name}object");
            z = Convert.ToDouble(Console.ReadLine());
            Position = (x, y, z);
            return (mass, x, y, z);
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
        while (Object1.Position.Equals(Object2.Position))
        {
            Console.WriteLine("Please fix your values, your objects occupy the same space");
            Object1.Setup();
            Object2.Setup();
        }

        double Distance = 5;
        double force= 4;
        double DX = 0;
        double DY = 0;
        double DZ = 0;
        double VX = 0;
        double VY = 0;
        double VZ = 0;
        double DX2 = 0;
        double DY2 = 0;
        double DZ2 = 0;
        double VX2 = 0;
        double VY2 = 0;
        double VZ2 = 0;
        double FX = 0;
        double FY = 0;
        double FZ = 0;
        double FX2 = 0;
        double FZ2 = 0;
        double FY2= 0;
        double AX= 0;
        double AY= 0;
        double AZ= 0;
        double AX2 = 0;
        double AY2= 0;
        double AZ2 = 0;
        double VelocityX = 0;
        double VelocityY = 0;
        double VelocityZ = 0;
        double VelocityX2 = 0;
        double VelocityY2 = 0;
        double VelocityZ2 = 0;
        double Time = 0;
        double timestep = 0.01;
        Console.WriteLine("");
        while (Distance > 0.1)
        {
            Distance = Math.Sqrt((Object1.x-Object2.x)*(Object1.x - Object2.x)+(Object1.y - Object2.y)*(Object1.y - Object2.y)+(Object1.z - Object2.z)*(Object1.z - Object2.z));
            if (Distance <= 0.1)
            {
                break;
            }

            if (Distance < 5)
            {
                timestep = 0.0001;
            }
             force = (G*Object1.mass * Object2.mass)/(Distance*Distance);
             DX = Object2.x-Object1.x;
             DY = Object2.y-Object1.y;
             DZ = Object2.z-Object1.z;
             VX = DX / Distance;
             VY = DY / Distance;
             VZ = DZ / Distance;
            DX2 = -DX;
             DY2 = -DY;
             DZ2 = -DZ;
             VX2 = -VX;
             VY2 = -VY;
             VZ2 = -VZ;
             FX = VX * force;
             FY = VY * force;
             FZ = VZ * force;
             FX2 = VX2*force;
             FZ2 = VZ2 * force;
             FY2 = VY2 * force;
             AX = FX / Object1.mass;
             AY = FY / Object1.mass;
             AZ = FZ / Object1.mass;
             AX2 = FX2 / Object2.mass;
             AY2 = FY2 / Object2.mass;
             AZ2 = FZ2 / Object2.mass;
             VelocityX += AX * timestep;
             VelocityY += AY * timestep;
             VelocityZ += AZ * timestep;
            VelocityX2 += AX2 * timestep;
            VelocityY2 += AY2 * timestep;
            VelocityZ2 += AZ2* timestep;
              Object1.x += VelocityX*timestep;
              Object1.y += VelocityY*timestep;
              Object1.z += VelocityZ*timestep;
              Object2.x += VelocityX2*timestep;
              Object2.y += VelocityY2*timestep;
              Object2.z += VelocityZ2*timestep;
              Time += timestep;
            Console.Write($"\r Object1 Position: ({Object1.x} meters,{Object1.y} meters) Object2 Position: ({Object2.x} meters,{Object2.y} meters) Time passed: seconds, force: newtons. ");
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