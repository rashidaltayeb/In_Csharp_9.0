var per = new person()
{
  NameWithInit = "rashid",NameWithSet = "rashid"
  /* 
   * the init keyword is useful if we want those property be settable
   * the property well be readonly once the construction has completed 
   */
};
    /*
     * if you try to change the value like this --> person.NameWithInit = "John"; in your project it will show error.
     to see the error uncomment this line
     */ 
    //System.Console.WriteLine(per.NameWithInit = "john");

//but here will print the result without any error
System.Console.WriteLine(per.NameWithInit );
//Declaration the class person
class  person
{
  public string NameWithInit { get; init; } // using init keyword 
  public string NameWithSet { get;  set; } // using set Keyword
}
/*
 * In last with set keyword you can change the property normally
 * Console.WriteLine(per.NameWithSet = "ahmed");
*/