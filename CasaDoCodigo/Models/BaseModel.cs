﻿using System;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class BaseModel
    {

        [DataMember]
        public int Id { get; set; }



    }
}
