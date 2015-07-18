using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LitJson;


public class Person
{
    // C# 3.0 auto-implemented properties
    public string   Name     { get; set; }
    public int      Age      { get; set; }
    public DateTime Birthday { get; set; }
}

public class JsonSample
{

    public static void Main()
    {
        PersonToJson();
        JsonToPerson();

        JsonWriter writer = new JsonWriter();

        writer.WriteObjectStart();

        writer.WritePropertyName("A");
        writer.WriteArrayStart();
        writer.Write(1);
        writer.Write(2);
        writer.Write(3);
        writer.WriteArrayEnd();

        writer.WritePropertyName("B");
        writer.WriteArrayStart();
        writer.Write(1);
        writer.Write(2);
        writer.Write(3);
        writer.WriteArrayEnd();

        writer.WriteObjectEnd();

        writer.PrettyPrint = true;
        string sss = writer.ToString();
        Console.WriteLine(sss);

        writer.PrettyPrint = false;
        sss = writer.ToString();
        Console.WriteLine(sss);
    }

    public static void JsonWrite()
    {
        StringBuilder sb = new StringBuilder();
        JsonWriter writer = new JsonWriter(sb);

        writer.WriteArrayStart();
        writer.Write(1);
        writer.Write(2);
        writer.Write(3);

        writer.WriteObjectStart();
        writer.WritePropertyName("color");
        writer.Write("blue");
        writer.WriteObjectEnd();

        writer.WriteArrayEnd();

        Console.WriteLine(sb.ToString());
    }

    public static void PersonToJson()
    {
        Person bill = new Person();

        bill.Name = "William Shakespeare";
        bill.Age  = 51;
        bill.Birthday = new DateTime(1564, 4, 26);

        string json_bill = JsonMapper.ToJson(bill);

        Console.WriteLine(json_bill);
    }

    public static void JsonToPerson()
    {
        string json = @"
            {
                ""Name""     : ""Thomas More"",
                ""Age""      : 57,
                ""Birthday"" : ""02/07/1478 00:00:00""
            }";

        try
        {
            Person thomas = JsonMapper.ToObject<Person>(json);
            Console.WriteLine("Thomas' age: {0}", thomas.Age);
        }
        catch (JsonException e)
        {
            Console.WriteLine(e.ToString());
            
        }
        

        
    }
}

//namespace EkLitjson
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            PersonToJson();
//            JsonToPerson();


//        }
//    }
//}
