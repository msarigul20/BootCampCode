﻿using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {

            //defined managers
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //TestColorCRUDOperations(colorManager,"Eflatun");
            //ClearLastColor(colorManager,2);
            //TestBrandCRUDOperations(brandManager, "Mercedes");
            //ClearLastBrand(brandManager, 2);
            //TestCarCRUDOperations(carManager,8,6,"2018",230,"Added Operation is working!!!");
            //ClearLastCar(carManager, 2);
            //GetCarsDetail(carManager);
            /*
             * rentalManager.Add(new Rental() { CarId =1, CustomerId=1, RentalDate = DateTime.Now});
             * rentalManager.Add(new Rental() { CarId = 2, CustomerId = 1, RentalDate = DateTime.Now });
            */


            // Wrong rental because of rental can not has return date. (It will not add.)
            // var result =rentalManager.Add(new Rental() {CarId= 10, CustomerId = 4 ,RentDate = DateTime.Now, ReturnDate = DateTime.Now });
           
            //Correct rental
            // rentalManager.Add(new Rental() { CarId = 3, CustomerId = 3, RentDate = DateTime.Now,ReturnDate=null});

            var result = rentalManager.CompleteRentalByCarId(10);
            if (result.Success)
            {
                Console.WriteLine(Messages);
                
            }
            else
            {
                Console.WriteLine("Ekleme gerçekleşmedi. sebebi" + result.Message );
            }
            
            
            
        
        }

        private static void PrintUserToTest(UserManager userManager)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("| User Id |  First Name  |  Last Name   |            Email          |        Password      |");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(String.Format("|{0,-8} | {1,-12} | {2,-12} | {3,-25} | {4,-20} |", " " + user.Id, user.FirstName, user.LastName, user.Email, user.Password));
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }

        private static void GetCarsDetail(CarManager carManager)
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| Car Id | Brand Name   | Color Name   | Daily Price |");
            Console.WriteLine("------------------------------------------------------");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(String.Format("|{0,-7} | {1,-12} | {2,-12} | {3,12}|", " " + car.CarId, car.BrandName, car.ColorName, car.DailyPrice + " TL"));
            }
            Console.WriteLine("------------------------------------------------------");
        }

        //Test Color Mehtods
        private static void TestColorCRUDOperations(ColorManager colorManager, string colorNameToAdd)
        {
            //Added new colors to test our CRUD operations as comes parameter, Will Update and Will Delete.
            colorManager.Add(new Color() { ColorName = colorNameToAdd });
            //To test Update and Delete
            colorManager.Add(new Color() { ColorName = "Will Update" });
            colorManager.Add(new Color() { ColorName = "Will Delete" });
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Added new color that entered by you." + " \n"+ 
                              " Color Id: {0} \n ColorName {1}", colorManager.GetColorById(colorManager.GetAll().Data[colorManager.GetAll().Data.Count - 3].ColorId).Data.ColorId,
                                                                 colorManager.GetColorById(colorManager.GetAll().Data[colorManager.GetAll().Data.Count - 3].ColorId).Data.ColorName);
            Console.WriteLine("------------------------------------------------------------------------");
            //Printed all list
            Console.WriteLine(" ********************************* 1.PRİNT ALL (After Adding Colors) *******************************************");
            Console.WriteLine("ColorId\tColorName\t\b\b");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.ColorId}" +
                    $"\t{color.ColorName}" +
                    $"\t\b\b");
            }
            Console.WriteLine("****************************************************************************************************************");
            //Deleted the color that has last index of its table (named Will Delete) by using getColorByID method.
            //I am using count - 1 to access last row index so that I accessed the last color id and could give exact id to GetColorById. 
            //Finally. Delete method takes last color in the list. 
            colorManager.Delete(colorManager.GetColorById(colorManager.GetAll().Data[colorManager.GetAll().Data.Count-1].ColorId).Data);
            Console.WriteLine(" ********************************* 2.PRİNT ALL (After Deleting Related Color) *******************************************");
            Console.WriteLine("ColorId\tColorName\t\b\b");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.ColorId}" +
                    $"\t{color.ColorName}" +
                    $"\t\b\b");
            }
            Console.WriteLine("***********************************************************************************");
            //Updated our color.
            colorManager.Update(new Color() { ColorId = colorManager.GetAll().Data[colorManager.GetAll().Data.Count - 1].ColorId, ColorName = "Color UPDATED!"});
            Console.WriteLine(" ********************************* 3.PRİNT ALL (After Updating Related Color) *******************************************");
            Console.WriteLine("ColorId\tColorName\t\b\b");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.ColorId}" +
                    $"\t{color.ColorName}" +
                    $"\t\b\b");
            }
            Console.WriteLine("***********************************************************************************");
          
           
        }
        private static void ClearLastColor(ColorManager colorManager, int howMantTimes) {
            for (int i = 1; i <= howMantTimes; i++)
            {
                colorManager.Delete(colorManager.GetAll().Data[colorManager.GetAll().Data.Count - 1]);
            }
            
        }
        
        //Test Brand Mehtods
        private static void TestBrandCRUDOperations(BrandManager brandManager, string brandNameToAdd)
        {
            //Added new colors to test our CRUD operations as comes parameter, Will Update and Will Delete.
            brandManager.Add(new Brand() { BrandName = brandNameToAdd });
            //To test Update and Delete
            brandManager.Add(new Brand() { BrandName = "Will Update" });
            brandManager.Add(new Brand() { BrandName = "Will Delete" });
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Added new brand that entered by you." + " \n" +
                              " BrandId: {0} \n BrandName {1}", brandManager.GetBrandById(brandManager.GetAll().Data[brandManager.GetAll().Data.Count - 3].BrandId).Data.BrandId,
                                                                 brandManager.GetBrandById(brandManager.GetAll().Data[brandManager.GetAll().Data.Count - 3].BrandId).Data.BrandName);
            Console.WriteLine("------------------------------------------------------------------------");
            //Printed all list
            Console.WriteLine(" ********************************* 1.PRİNT ALL (After Adding Brands) *******************************************");
            Console.WriteLine("BrandId\tBrandName\t\b\b");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.BrandId}" +
                    $"\t{brand.BrandName}" +
                    $"\t\b\b");
            }
            Console.WriteLine("****************************************************************************************************************");
            //Deleted the color that has last index of its table (named Will Delete) by using getColorByID method.
            //I am using count - 1 to access last row index so that I accessed the last color id and could give exact id to GetColorById. 
            //Finally. Delete method takes last color in the list. 
            brandManager.Delete(brandManager.GetBrandById(brandManager.GetAll().Data[brandManager.GetAll().Data.Count - 1].BrandId).Data);
            Console.WriteLine(" ********************************* 2.PRİNT ALL (After Deleting Related Brand) *******************************************");
            Console.WriteLine("BrandId\tBrandName\t\b\b");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.BrandId}" +
                    $"\t{brand.BrandName}" +
                    $"\t\b\b");
            }
            Console.WriteLine("***********************************************************************************");
            //Updated our color.
            brandManager.Update(new Brand() { BrandId = brandManager.GetAll().Data[brandManager.GetAll().Data.Count - 1].BrandId,  BrandName= "Brand UPDATED!" });
            Console.WriteLine(" ********************************* 3.PRİNT ALL (After Updating Related Brand) *******************************************");
            Console.WriteLine("BrandId\tBrandName\t\b\b");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.BrandId}" +
                    $"\t{brand.BrandName}" +
                    $"\t\b\b");
            }
            Console.WriteLine("***********************************************************************************");


        }
        private static void ClearLastBrand(BrandManager brandManager, int howMantTimes)
        {
            for (int i = 1; i <= howMantTimes; i++)
            {
                brandManager.Delete(brandManager.GetAll().Data[brandManager.GetAll().Data.Count - 1]);
            }

        }

        //Test Car Mehtods
        private static void TestCarCRUDOperations(CarManager carManager, int brandId, int colorId, string modelYear, decimal dailyPrice, string descriptions )
        {
            //Added new colors to test our CRUD operations as comes parameter, Will Update and Will Delete.
            carManager.Add(new Car() { BrandId = brandId, ColorId = colorId, ModelYear = modelYear, DailyPrice = dailyPrice, Descriptions =descriptions });
            //To test Update
            carManager.Add(new Car() { BrandId = 1, ColorId = 2, ModelYear = "1000", DailyPrice = 3, Descriptions = "Will Update" });
            //To test Delete
            carManager.Add(new Car() { BrandId = 1, ColorId = 2, ModelYear = "1000", DailyPrice = 3, Descriptions = "Will Delete" });
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Added new CAR that entered by you." + " \n" +
                              " Car Id: {0} \n BrandId {1} \n ColorId {2} \n ModelYear {3} \n DailyPrice {4} \n Descriptions {5}", 
                              carManager.GetCarById(carManager.GetAll().Data[carManager.GetAll().Data.Count - 3].CarId).Data.CarId,
                              carManager.GetCarById(carManager.GetAll().Data[carManager.GetAll().Data.Count - 3].CarId).Data.BrandId,
                              carManager.GetCarById(carManager.GetAll().Data[carManager.GetAll().Data.Count - 3].CarId).Data.ColorId,
                              carManager.GetCarById(carManager.GetAll().Data[carManager.GetAll().Data.Count - 3].CarId).Data.ModelYear,
                              carManager.GetCarById(carManager.GetAll().Data[carManager.GetAll().Data.Count - 3].CarId).Data.DailyPrice,
                              carManager.GetCarById(carManager.GetAll().Data[carManager.GetAll().Data.Count - 3].CarId).Data.Descriptions
                              );
            Console.WriteLine("------------------------------------------------------------------------");
            //Printed all list
            Console.WriteLine(" ********************************* 1.PRİNT ALL (After Adding Cars) *******************************************");
            Console.WriteLine("CarId\t BrandId\t ColorId\t ModelYear\t DailyPrice\t Descriptions\t\b\b");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.CarId}" +
                    $"\t{car.BrandId}" +
                     $"\t{car.ColorId}" +
                      $"\t{car.ModelYear}" +
                       $"\t{car.DailyPrice}" +
                      $"\t{car.Descriptions}" +
                    $"\t\b\b");
            }
            Console.WriteLine("****************************************************************************************************************");
            //Deleted the color that has last index of its table (named Will Delete) by using getColorByID method.
            //I am using count - 1 to access last row index so that I accessed the last color id and could give exact id to GetColorById. 
            //Finally. Delete method takes last color in the list. 
            carManager.Delete(carManager.GetCarById(carManager.GetAll().Data[carManager.GetAll().Data.Count - 1].CarId).Data);
            Console.WriteLine(" ********************************* 2.PRİNT ALL (After Deleting Related Car) *******************************************");
            Console.WriteLine("CarId\t BrandId\t ColorId\t ModelYear\t DailyPrice\t Descriptions\t\b\b");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.CarId}" +
                    $"\t{car.BrandId}" +
                     $"\t{car.ColorId}" +
                      $"\t{car.ModelYear}" +
                       $"\t{car.DailyPrice}" +
                      $"\t{car.Descriptions}" +
                    $"\t\b\b");
            }
            Console.WriteLine("***********************************************************************************");
            //Updated our color.
            carManager.Update(new Car() { CarId = carManager.GetAll().Data[carManager.GetAll().Data.Count - 1].CarId, 
                BrandId = carManager.GetAll().Data[carManager.GetAll().Data.Count - 1].BrandId, 
                ColorId = carManager.GetAll().Data[carManager.GetAll().Data.Count - 1].ColorId,
                DailyPrice = 435,
                ModelYear = carManager.GetAll().Data[carManager.GetAll().Data.Count - 1].ModelYear,
                Descriptions = "Updated Car Desc."
            });
            Console.WriteLine(" ********************************* 3.PRİNT ALL (After Updating Related Car) *******************************************");
            Console.WriteLine("CarId\t BrandId\t ColorId\t ModelYear\t DailyPrice\t Descriptions\t\b\b");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.CarId}" +
                    $"\t{car.BrandId}" +
                     $"\t{car.ColorId}" +
                      $"\t{car.ModelYear}" +
                       $"\t{car.DailyPrice}" +
                      $"\t{car.Descriptions}" +
                    $"\t\b\b");
            }
            Console.WriteLine("***********************************************************************************");


        }
        private static void ClearLastCar(CarManager carManager, int howMantTimes)
        {
            for (int i = 1; i <= howMantTimes; i++)
            {
                carManager.Delete(carManager.GetAll().Data[carManager.GetAll().Data.Count - 1]);
            }

        }



    }
}
