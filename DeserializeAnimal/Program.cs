
using Lab7;
using System.Xml.Serialization;

XmlSerializer deserializer = new XmlSerializer(typeof(Animal));
string path = @"C:\\Users\\amana\\source\\repos\\lab8\\lab8\\bin\\Debug\\net6.0\\Animal.xml";

using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate)) 
{
    Animal animal = (Animal)deserializer.Deserialize(fs);

    Console.WriteLine("Deserialization had done");
    Console.WriteLine($"Animal:\nCountry: {animal.Country}\nName: {animal.Name}" +
        $"\nHide from other animals: {animal.HideFromOtherAnimals}\nWhat animal? {animal.WhatAnimal}");

}