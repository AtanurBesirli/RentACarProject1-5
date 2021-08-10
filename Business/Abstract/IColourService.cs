using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColourService
    {
        IDataResult<List<Colour>> GetAll();
        IDataResult<Colour> GetById(int colourId);
        IResult Add(Colour colour);
        IResult Update(Colour colour);
        IResult Remove(Colour colour);
    }
}
