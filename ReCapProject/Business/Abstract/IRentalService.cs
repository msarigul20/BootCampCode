﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetRentalById(int id);
        IResult CompleteRentalById(int id);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult RentalCarControl(int CarId);
        IResult CheckAvailableDate(Rental rental);
    }
}
