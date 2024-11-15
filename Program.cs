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

    public string GetName()
    {
      return name;
    }

    // A getter to get the coordinates of the object 
    public (int, int) GetCoordinates()
    {
      return (x, y);
    }

    // A setter to set the coordinates of the actor
    public void SetCoordinates(int newX, int newY)
    {
      x = newX;
      y = newY;
    }

    // A setter to set the coordinates of the actor
    public void SetCoordinates((int, int) position)
    {
      SetCoordinates(position.Item1, position.Item2);
    }

    /// <summary>
    /// Display the actor's coordinates to the console
    /// </summary>

    public void DisplayCoordinates()
    {
      Console.WriteLine("{0} is at ({1}, {2})", name, x, y);
    }

    /// <summary>
    /// Move the actor by the provided offset vector 
    /// and then return the new position 
    /// </summary>
    public (int, int) Move((int, int) offsetVector)
    {
      return Move(offsetVector.Item1, offsetVector.Item2);
    }

    /// <summary>
    /// Move the actor by the provided offsets 
    /// and then return the new position
    /// </summary>
    public virtual (int, int) Move(int offsetX, int offsetY)
    {
      // Base actors cannot move so do nothing
      Console.WriteLine("Me no movey");

      // Return the new position, 
      // which for this case is does not change
      return (x, y);
    }

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

    public override (int, int) Move(int offsetX, int offsetY)
    {
      // Get the coordinates of the actor and destructure it
      (int x, int y) = GetCoordinates();

      // Only move in the x axis 
      // as the archer cannot move in the y axis 
      SetCoordinates(x + offsetX, y);

      // Return the Actor's new coordinates
      return GetCoordinates();
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

    public override (int, int) Move(int offsetX, int offsetY)
    {
      // Get the coordinates of the actor and destructure it
      (int x, int y) = GetCoordinates();

      // Only move in the y axis 
      // as the swrodsman cannot move in the x axis 
      SetCoordinates(x, y + offsetY);

      // Return the Actor's new coordinates
      return GetCoordinates();
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

    public override (int, int) Move(int offsetX, int offsetY)
    {
      // Get the coordinates of the actor and destructure it
      (int x, int y) = GetCoordinates();

      // Apply offset to both axes 
      // because the knight can move in on both axes
      SetCoordinates(x + offsetX, y + offsetY);

      // Return the Actor's new coordinates
      return GetCoordinates();
    }

    public override void Draw()
    {
      Console.WriteLine("Knight {0} has a sword length of {1}mm and a horsey called {2}", name, swordLength, horseName);
    }
  }

  // Create a global seeded random for program determinism
  static Random globalRandom = new Random(unchecked((int)0xdeadbeef));

  /// <summary>
  /// Get a random coordinate within the provided range
  /// </summary>
  public static (int, int) GetRandomCoordinate(int min, int max)
  {
    int x = globalRandom.Next(min, max);
    int y = globalRandom.Next(min, max);

    return (x, y);
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
    foreach (Actor actor in actorList)
    {
      // Draw actor to the screen
      actor.Draw();

      // Set and display their initial position
      (int, int) startCoordinates = GetRandomCoordinate(-10, 10);
      actor.SetCoordinates(startCoordinates);
      actor.DisplayCoordinates();

      Console.WriteLine("Moving {0}...", actor.GetName());

      // Create a movement for the actor to consume
      (int, int) moveVector = GetRandomCoordinate(-10, 10);
      actor.Move(moveVector);

      // Output the new position of the actor
      actor.DisplayCoordinates();

      // Add a line break to seperate actors
      Console.WriteLine();
    }
  }
}