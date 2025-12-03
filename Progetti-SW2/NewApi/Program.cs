﻿using System;
using Microsoft.EntityFrameworkCore;
using var db = new ApplicationDbContext();

db.Dvd.Add(new Dvd());
db.Dvd.Add(new Dvd("titolo1" , "genere1"));

//salvare i cambiamenti

db.SaveChanges();