using System.ComponentModel.DataAnnotations.Schema;

public class Customer
{
    public Customer(int? id, string firstName, string lastName, DateTime bDay)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BDay = bDay;
    }
    public Customer(){}

    public int? Id{get;set;}
    public string FirstName{get;set;}
    public string LastName{get;set;}
    public DateTime BDay{get;set;}

    public double Rating{get;set;}

    public List<ProfilePicture> ProfilePictures{get;set;}=new List<ProfilePicture>();


    public override string ToString()
    {
        return $"{FirstName} {LastName} {BDay}";
    }
}