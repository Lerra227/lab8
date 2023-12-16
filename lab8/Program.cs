

using Lab7;
using System.Xml.Serialization;

Animal animal = new Animal("Island", true, "Ada");
animal.WhatAnimal = eClassificationAnimal.Herbivores;

XmlSerializer XmlSerializer = new XmlSerializer(typeof(Animal));

using (FileStream fs = new FileStream("Animal.xml", FileMode.OpenOrCreate))
{
    XmlSerializer.Serialize(fs, animal);
}
