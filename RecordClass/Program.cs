/*
 * IN class record you can comparison classes with there properties values in a less code
 */  
var per = new person("rashid","programmer");
var per2 = new person("rashid", "programmer");
System.Console.WriteLine(per==per2); // will be true 
/*
 * any Object form record class can use the same property value by use the 'with' Keyword as this Following example :
 */
var emp = new employee(per.name,per.jobTitle, 10000);
var emp2 = emp with {name = "John"};
System.Console.WriteLine(emp2);
record person (string name, string jobTitle);
/*
 * Records support inheritance. You can declare a new Employee record derived from Person as follows:
 */
record employee(string name, string jobTitle, decimal salary) : person(name, jobTitle); 
  /*
   * you can customize the output display to the Employee result you can change this block as you want
       {
            public override string ToString()
            {
                return $"name = {name},Job = {job}, salary = {salary}";
            }
       }
 */