// See https://aka.ms/new-console-template for more information
using Calculator;

FluentCalculator calculator = new FluentCalculator();
var result = calculator.Value("one").Operation("plus")
    .Value("two").Operation("minus").Value("four").Operation("times").Value("nine")
    .Operation("dividedBy").Value("three").Result();
Console.WriteLine(result);

