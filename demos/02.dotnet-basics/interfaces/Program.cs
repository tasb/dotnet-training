using Interfaces.Greatings;

IHello helloWorld = new HelloWorldGreater();
IHello customHello = new CustomGreater("Everybody!!!");

Coords c = new Coords(1, 2);
Coords d = new Coords(3, 4);
Console.WriteLine(c);
Console.WriteLine(d);
Coords e = c with { X = 5 };
Console.WriteLine(e);
Console.WriteLine(c + d);


Console.WriteLine(helloWorld.SayHello());
Console.WriteLine(customHello.SayHello());
