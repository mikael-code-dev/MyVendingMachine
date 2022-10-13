using MyVendingMachine;

VendingMachine vending = new();
App app = new();
app.Run(vending);

Console.Clear();
Console.WriteLine("As soon as you get some more money, come back and spend it in this Vending Machine");