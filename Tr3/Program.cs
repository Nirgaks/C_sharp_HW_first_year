using System;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
class Program
{
    public static void Main(string[] args)
    {
        DrawingBoard DB = new DrawingBoard(4);
        DB.add(new Circle(2));
        DB.add(new Cube(6));
        DB.add(new Rectangle(4,4));
        DB.add(new Right_angled_Triangle(2, 5));

        DB.show();
        Console.WriteLine($"Max area out of all the shapes is:{DB.MaxArea()}");

        Shape max = DB.MaxVolume();
        if( max ==null)
        {
            Console.WriteLine("there is no Three_Dime_Object");
        }
     else
        {
            Console.WriteLine($"the shape with the biggest volume is:{max.ToString()}");
        }
    }
}
public abstract class  Shape
{
    public abstract double Area();
    public abstract String ToString();
    public abstract bool Equals(object obj);
}
public abstract class TwoDimeshape :Shape
{
    public abstract double Perimeter();
}
public abstract class Threedimeshape :Shape
{
    public abstract double Volume();
}
public class Circle : TwoDimeshape
{
    public double R;
    public Circle(double r)
    {
        R = r;
    }
    public override double Area() { return 3.14 * R * R; }
    public override String ToString() { return $"the radius of the circle is: {R}"; }
    public override bool Equals(object obj)
    {
      if(obj == null) return false;
        if (obj is Circle s)
        {
            return this.R == s.R;
        }
        else
            return false;
     }

    public override double Perimeter()
    {
        return 2 * 3.14 * R;
    }
}
class Right_angled_Triangle : TwoDimeshape
{
    public double Height;
    public double Base;

    public Right_angled_Triangle(double height, double Base)
    {
        Height = height;
        this.Base = Base;
    }
    public override double Area()
    {
        return Base * Height * 0.5;

    }
    public override double Perimeter()
    {
        return (Math.Sqrt(Base * Base + Height * Height)) + Base + Height;
    }
    public override string ToString()
    {
        return $"The data about Right_angled_Triangle is : base = {Base} , " +
            $"Height={Height}, " +
            $"Area is :{Area()} ," +
            $"Perimeter is {Perimeter()} ";
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj is Right_angled_Triangle s)
        { 
            return s.Height == Height && s.Base==Base;
        }
     else
            return false;
    }
     

}
public class Rectangle : TwoDimeshape
{
    public double Width;
    public double Length;

    public Rectangle (double width, double length)
    {
        Width = width;
        Length = length;
    }
    public override double Area()
    {
       return Length*Width;
    }
    public override double Perimeter()
    {
        return (2 * Length) + (2 * Width);
    }
    public override string ToString()
    {
        return $"the data about the Rectangle is : width={Width} , Length={Length}, Area is :{Area()} ,Perimeter is {Perimeter()} ";

    }
    public override bool Equals(object obj)
    {
        if(obj == null) return false;
        if(obj is Rectangle s)
        {
            return Length==s.Length && Width==s.Width;
        }
     else
            return false;
    }

  



}


class Cube : Threedimeshape
{
    public double Side;

    public Cube(double side)
    {
        Side = side;
    }
    public override double Area()
    {
        return 6 * Side * Side;
    }
    public override double Volume()
    {
       return Side * Side*Side;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj is Cube s)
        {
            return Side == s.Side;
        }
        else
            return false;
    }
    public override string ToString()
    {
        return $"the data about the Cube is: side={Side}, Area is :{Area()} ,Volume is {Volume()} ";
    }
}
class Sphere : Threedimeshape
{
    public double Rad;

    public Sphere(double rad)
    {
        Rad = rad;
    }
    public override double Area()
    {
        return 4 * 3.14 * Rad * Rad;
    }
    public override double Volume()
    {
        return (4.0 / 3 / 0) * 3.14 * (Math.Pow(Rad, 3));
    }
    public override bool Equals(object obj)
    {
       if(obj == null) return false;
       if(obj is Sphere s)
        {
            return Rad == s.Rad;
        }
     else
            return false;
    }

    public override string ToString()
    {
        return $"the data about Sphere is:Rad={Rad}, Area is :{Area()} ,Volume is {Volume()} ";
    }
}
class DrawingBoard
{
    Shape[] shapes;
    public int Counter;

    public DrawingBoard(int maxcounter)
    {
        shapes=new Shape[maxcounter];
        Counter = 0;
    }
   public void add(Shape shape)
    {
        if (Counter < shapes.Length)
        {
            shapes[Counter++] = shape;
            Console.WriteLine("the shape was added perfectly");
        }
        else
            Console.WriteLine("the shape failed to upload");
    }

    public void show()
    {
        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine(shapes[i].ToString());
        }
    }

    public double MaxArea()
    {
        if (Counter == 0) return 0;

        double Max = shapes[0].Area();

        for(int i=1;i<shapes.Length;i++)
        {
            if(shapes[i].Area() > Max)
            {
                Max = shapes[i].Area();
            }
    
        }
        return Max;
    }

    public Threedimeshape MaxVolume()
    {
        Threedimeshape? Biggest = null;
        double maxV = 0;

        for(int i = 0;i<shapes.Length;i++)
        {
            if(shapes[i] is Threedimeshape)
            {
                
                Threedimeshape th=(Threedimeshape) shapes[i];
                if(Biggest == null) { return null; }
               double dth = th.Volume();
                if(Biggest == null || dth > maxV)
                {
                    Biggest = th;
                    maxV = dth;
                }
            }
        }
        return Biggest;
        
        
    }

}













