using BL.Models;
using System;
using System.Net.Http.Json;
class Program
{
    static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        client.BaseAddress = new Uri("https://localhost:7000/api/People/GetAllPeople");

        await GetAllPeople();

        Console.ReadKey();
    }

    private static async Task GetAllPeople()
    {
        try
        {
            Console.WriteLine("People info");
            Console.WriteLine("-------------------------------");
            var people = await client.GetFromJsonAsync<List<Person>>("GetAllPeople");

            foreach (var person in people)
            {
                Console.WriteLine
                   ($"\n\n" +
                   $"----------------------------------------" +
                   $"\nPerson Id: {person.PersonId}" +
                    $"\nName     : {person.Name}" +
                    $"\nDOB      : {person.DateOfBirth}" +
                    $"\nEmail    : {person.Email}" +
                    $"\nGender   : {(person.Gender == 'M' ? "Male" : "Female")}" +
                    $"\nAddress  : {person.Address}" +
                    $"\n----------------------------------------\n\n");
            }
            
            //if(people is not null)
            //{
            //    foreach (var person in people)
            //    {
            //        Console.WriteLine(person.PersonId);
            //    }
            //}
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}