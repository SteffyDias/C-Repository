using System;             //System namespace is used to organise the many classes in a namespace
using System.IO;
using System.Text;
using System.Collections.ObjectModel;

namespace InheritanceAssignment         //to organise and provide a level of separation to code
{
  /*  Shape is a Base class also called Parent Class
  *   that has generic attributes and functionalities
  *   of its derived or child class.
  */
  abstract class Shape{               
    
    public abstract string getName();

    public abstract double getArea();


    /*
    *   Increase the size of the Shape by the specified percent
    */
    public double increaseSize(double incPercent){

      double area = getArea();
        try{
            
            area = (area + ((incPercent * area)/100));

        }catch(Exception e){
            
            Console.WriteLine(e.Message); 
        }
        return area;
      

    }

  }

  class Square : Shape{     //Square is derived from the Base class Shape
  
  	  int side;
      public Square(int side=1){    //parameterised constructor
       
         this.side = side;

      }

      public override double getArea(){     //overriden function of Base class

          return this.side * this.side;
      }

      public override string getName(){   //overriden function of Base class
          
          return "Square";

      }
      
  }

  class Circle : Shape{
   
    int radius;
    public Circle(int radius = 1){    //parameterised Constructor

      this.radius = radius;

    }

    public override double getArea(){       //overriden function of Base class

        return 3.14 * this.radius * this.radius;

    }

    public override string getName(){       //overriden function of Base class

        return "Circle";
    }
    
  }

  class Program{

      static void Main(string[] args){

          double incPercent;
          double newArea;

          Console.WriteLine("PART 1 OF EXECUTION");
          Console.WriteLine();
          Console.WriteLine("Area of shapes with default values and percentage increase value given by user");

          Shape[] shapes = {new Square(), new Circle()};    // Creating an Array for derived class objects

          foreach (Shape shape in shapes){

              Console.WriteLine();
              Console.WriteLine("Name of Shape: "+shape.getName());
              Console.WriteLine("Area of "+shape.getName()+"is: "+shape.getArea());
              Console.Write("Enter percentage by which Area should increase: ");
              incPercent = Convert.ToInt32(Console.ReadLine());
              newArea = shape.increaseSize(incPercent);
              Console.WriteLine("Area of "+shape.getName()+" after increasing by "+incPercent+"% is: "+newArea);
              Console.WriteLine();

          }
          Console.WriteLine();
          Console.WriteLine("PART 2 OF EXECUTION");
          Console.WriteLine();
          Console.WriteLine("Creating a colllection of the Shapes");
          Console.WriteLine("Increasing the size of the Shape by 10%");

          /*
          *   creating a collection of the Base Class and
          *   objects of the Derived Class
          */
          var collection = new ObservableCollection<Shape> {new Square(3), new Circle(2)};

          foreach (var shape in collection)
          {
            Console.WriteLine();
            Console.WriteLine("Name of the Shape is: "+shape.getName());
            Console.WriteLine("Area of "+shape.getName()+" is: "+shape.getArea());
            newArea = shape.increaseSize(10);
            Console.WriteLine("Area of "+shape.getName()+" after increasing by 10% is: "+newArea);
            Console.WriteLine();
          }

          Console.WriteLine("***************");
        
          Console.ReadLine();
         

      }
      
      
        

  }

}