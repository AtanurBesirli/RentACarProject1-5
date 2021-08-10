using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands 
                             on c.BrandId equals b.BrandId
                             join co in context.Colours
                             on c.ColourId equals co.ColourId
                             select new CarDetailDto { Id = c.Id, BrandName = b.BrandName,ColourId=co.ColourId,
                                                       ColourName=co.ColourName,DailyPrice=c.DailyPrice};
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetailDtosWithBrandId(int id)
        {

            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join co in context.Colours
                             on c.ColourId equals co.ColourId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             where b.BrandId == id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColourName = co.ColourName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear
                             };

                return result.ToList();
            }




        }

        public List<CarDetailDto> GetCarDetailDtosWithColorId(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join co in context.Colours
                             on c.ColourId equals co.ColourId
                             where co.ColourId == id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColourName = co.ColourName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear
                             };

                return result.ToList();
            }
        }

    }
}
