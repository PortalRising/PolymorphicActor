using System;
// for ListOf
using System.Collections.Generic;

public class Program
{

  // Actor in the game
  class Actor
  {
    protected string name;      // can be accessed by the subclasses
    private int x;    // x coordinate
    private int y;    // y coordinate

    // Constructor
    public Actor(string n)
    {
      name = n;
      x = y = 0;        // initialise cordinates
    }

    // getter to get the coordinates of the object 
    public (int, int) GetCoordinates()
    {
      return (x, y);
    }

    // Move the actor 

    // draw( )method.
    // Derived classes may provide an implementation
    public virtual void Draw()
    {
      Console.WriteLine("Actor {0}: Base draw() method for an actor", name);
    }

  }

  // Archer class.
  // Attributes: bowLength
  // Method: implement the draw() method to override
  // the implementation the base class
  class Archer : Actor
  {
    private int bowLength;

    // Constructor for Archer.
    // Call the constructor for Actor using the name
    public Archer(string name, int b) : base(name)
    {
      bowLength = b;
    }

    public override void Draw()
    {
      Console.WriteLine("Archer: {0} with bowlength {1}", this.name, bowLength);
    }
  }

  class Swordsman : Actor
  {
    // The length of the actor's sword in millimeters
    protected int swordLength;
    public Swordsman(string name, int swordLength) : base(name)
    {
      this.swordLength = swordLength;
    }

    public override void Draw()
    {
      Console.WriteLine("Swordsman {0} with a sword length of {1}mm", name, swordLength);
    }
  }

  class Knight : Swordsman
  {
    // Name of their horse
    string horseName;


    public Knight(string name, int swordLength, string horseName) : base(name, swordLength)
    {
      this.horseName = horseName;
    }

    public override void Draw()
    {
      Console.WriteLine("Knight {0} has a sword length of {1}mm and a horsey called {2}", name, swordLength, horseName);
    }
  }



  public static void Main()
  {

    // Create a list of Actor object
    List<Actor> actorList =
    [
        // Add instances of Actor objects to the actorList
        new Actor("Ian McEwan"),
        new Archer("Legolas", 120),
        new Swordsman("Phil", 850),
        new Knight("Alexander the Great", 750, "Bucephalus"),
    ];

    // Iterate through the list of actors and call the 
    // call the draw method for each one
    foreach (var a in actorList)
    {
      a.Draw();        // draw the actor


    }
  }
}