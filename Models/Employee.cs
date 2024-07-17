namespace WebApplication1.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }

        public long Salary { get; set; }

        public string Department { get; set; }
    }
}


// <Project Sdk="Microsoft.NET.Sdk.Web">
// by default the nullable value is enables so ytou have to disable it to remove warnings, this is project description that you get when double clicking on the application name in right 
/*  < PropertyGroup >
    < TargetFramework > net8.0 </ TargetFramework >
    < Nullable > enable </ Nullable >
    < ImplicitUsings > enable </ ImplicitUsings >
  </ PropertyGroup >*/
