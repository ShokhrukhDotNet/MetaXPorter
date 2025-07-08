//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MetaXPorter.Api.Models.Foundations.Pets;

namespace MetaXPorter.Api.Models.Foundations.Persons
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        [JsonIgnore]
        public List<Pet> Pets { get; set; }
    }
}
