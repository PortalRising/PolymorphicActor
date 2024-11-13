using System;
// for ListOf
using System.Collections.Generic;

public class Program {

  // Actor in the game
  class Actor  {
    protected String _name;      // can be accessed by the subclasses
    private int x;    // x cordinate
    private int y;    // y cordinate

    // Constructor
    public Actor (String n) {
      _name = n;
      x = y = 0;        // initialise cordinates
    }

    // getter to get the coordinates of the object 
    public (int, int) getCordinates(){
      return (x, y);
    }
    // draw( )method.
    // Derived classes may provide an implementation
    public virtual void draw() {
      Console.WriteLine ("Actor {0}: Base draw() method for an actor", _name);
    }

  }

  // Archer class.
  // Attributes: bowLength
  // Method: implement the draw() method to override
  // the implementation the base class
  class Archer : Actor {
    private int bowLength;

    // Constructor for Archer.
    // Call the constructor for Actor using the name
    public Archer (String name, int b) : base (name) {
      bowLength= b;
    }
    public override void draw() {
      Console.WriteLine ("Archer: {0} with bowlength {1}", this._name, bowLength);
    }
  }

  
  public static void Main (string[] args) {

    // Create a list of Actor object
    List<Actor> actorList = new List<Actor>();

    // Add instances of Actor objects to the actorList
    actorList.Add (new Actor ("Ian McEwan"));
    actorList.Add (new Archer ("Legolas", 120));

    // Iterate through the list of actors and call the 
    // call the draw method for each one
    foreach (var a in actorList) {
      a.draw();        // draw the actor

      
    }
  }
}