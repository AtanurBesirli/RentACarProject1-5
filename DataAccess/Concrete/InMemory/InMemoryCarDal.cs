using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColourId=1,DailyPrice=500,Description="190 Hp",ModelYear=2020},
                new Car{Id=2,BrandId=1,ColourId=2,DailyPrice=700,Description="240 Hp",ModelYear=2019},
                new Car{Id=3,BrandId=2,ColourId=3,DailyPrice=600,Description="130 Hp",ModelYear=2018},
                new Car{Id=4,BrandId=2,ColourId=4,DailyPrice=900,Description="275 Hp",ModelYear=2021},
                new Car{Id=5,BrandId=3,ColourId=5,DailyPrice=200,Description="95 Hp",ModelYear=2015},
                new Car{Id=6,BrandId=4,ColourId=6,DailyPrice=400,Description="115 Hp",ModelYear=2017}

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Remove(Car car)
        {
            Car carToRemove = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToRemove);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColourId = car.ColourId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
