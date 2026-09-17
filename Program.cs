var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var students = new List<Student>
{
    new Student { Id = 1, Name = "Raju", Age = 22 },
    new Student { Id = 2, Name = "Srinu", Age = 24 }
};

//app.MapGet("/hello", () =>
//{
//    return "Hello Vinesh";
//});

//app.MapGet("/hello/{name}", (string name) =>
//{
//    return "Hello "+name;
//});

//app.MapGet("/add/{a}/{b}", (int a, int b) =>
//{
//    return a + b;
//});

//app.MapGet("/search", (string name) =>
//{
//    return "Your Search name is " + name;
//});

//app.MapGet("/student",(string name,int age)=>{
//    return "Your name is "+name+" and age is "+age;
//});

//app.MapPost("/students", (Student std) =>
//{
//return "Student Created: " + std.Name + " Age is " + std.Age;
//});

//app.MapPut("/students/{id}", (int id, Student std) =>
//{
//    return "Student " + id + " Updated: " + std.Name + ", Age: " + std.Age;
//});

//app.MapDelete("/students/{id}", (int id) =>
//{
//    return "Student " + id + " Deleted";
//});

app.MapGet("/students", () =>
{
    return students;
});

app.MapPost("/students", (Student std) =>
{
    std.Id = students.Count + 1;
    students.Add(std);

    return std;
});

app.MapGet("/students/{id}", (int id) =>
{
    foreach(var student in students)
    {
        if(student.Id==id)
        {
            return Results.Ok(student);
        }
    }

    return Results.NotFound("Student not found");
});



app.Run();

class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? Age { get; set; }
}

//// testing
