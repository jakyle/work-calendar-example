// See https://aka.ms/new-console-template for more information
using GridExample;

Console.WriteLine("Hello, World!");


var grid = new Grid(10, 10);

var pointIdx = grid.TryGetXyIdx(5, 5);

var point = grid.TryGetPoint(pointIdx.Value);

var badIdx = grid.TryGetXyIdx(5, 11);

var badPoint = grid.TryGetPoint(100);

var workCalendar = new WorkCalendar();
var id = workCalendar.AddTask("Jake", "Clean Toilet", new DateTime(2021, 12, 3), "Clean the shitter");

workCalendar.StartTask(id);
workCalendar.CompleteTask(id);

var task = workCalendar.TryGetTask(id);

if (workCalendar.IsTaskCompletedOnTime(id))
{
    Console.WriteLine($"Hey good job {task.EmployeeName}, you get a raise!");
}
else
{
    Console.WriteLine($"Hey {task.EmployeeName}, fuck you dude.");
}

Console.ReadLine();