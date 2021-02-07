﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetAll();
        Car GetCarById(int id);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        List<Car> GetCarsByDailyPrice(decimal min, decimal max);
        List<Car> GetCarsByModelYear(string modelYear);


    }
}
