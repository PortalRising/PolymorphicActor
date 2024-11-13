Polymorphic Actors

Modify the sample code to perform the following tasks:

Task 1

Add getters and setters for the private attributes x and y in the Actor class
Test your code in the main program by calling getX() and getY(), to get and set the value of the (x,y) coordinates of an Archer

Task 2
Create 2 new classes: Knight and Swordsman

Knight which inherits from Actor
Swordsman which inherits from Actor
Add attributes to the Knight and Swordsman which pertain only to those classes, e.g., horseman for Knight
Implement constructors for Knight and Swordsman
Implement a draw() method for the the Knight and Swordsman classes
Create instances of Knights and Swordsman and add the instances to the actorList
Test your code

Task 3

Create a virtual method in the Actor class: move()
The method in the base class just prints out “Me no movey”
Create a virtual move() method in the Archer class, which updates the x coordinate of the Archer (moves left and right)
Create a virtual move() method in the Swordsman class, which updates the y coordinate of the Swordsman (moves up and down)
Create a virtual move() method in the Knight class, which updates the x and y coordinate of the Knight  (moves diagonally)
Test your code

Optional Task 4

Investigate tuples in C#
Uncomment the getCoordinates() method in the Actor class.
NB: it did compile on netfiddle but works on repl.it and jdoodle c#
Use the getCordinates() methods to get (x,y) coordinates 
Add a setCordinates() method to update coordinates.
Use a C# random library to move the the Actors in a random direction in their plane, e.g., Archers move randomly left/right
Investigate default parameters for contrstructors







