using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in context.Users
                             join cu in context.Customers
                             on u.UserId equals cu.UserId
                             join r in context.Rentals
                             on cu.CustomerId equals r.CustomerId
                             
                             select new RentalDetailDto
                             {
                                 UserId = u.UserId,
                                 FirstName = u.FirstName,
                                 CustomerId = cu.CustomerId,
                                 CompanyName = cu.CompanyName,
                                 Email = u.Email,
                                 LastName=u.LastName,
                                 Password=u.Password
                             };

                return result.ToList();
            }
        }

 
    }
}
