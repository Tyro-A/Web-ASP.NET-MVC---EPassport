using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPassport.Models;
using System.Data.Entity;

namespace EPassport.Controllers
{
    [HandleError]
    public class PassportApplicantController : Controller
    {
        // GET: PassportApplicant
        public ActionResult Index()
        {
              using (ePassportModel dbModel = new ePassportModel())
                {
                    return View(dbModel.PassportApplicants.ToList());
                } 
                
        }

        // GET: PassportApplicant/Details/5
        public ActionResult Details(int id)
        {

            try 
            {
                using (ePassportModel dbModel = new ePassportModel())
                {
                    return View(dbModel.PassportApplicants.Where(x => x.id == id).FirstOrDefault());
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
           
        }


        // GET: PassportApplicant/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }
            
        }

        // POST: PassportApplicant/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,LastName,FirstName,MiddleName," +
            "DateOfBirth,PlaceOfBirth,CivilStatus,CompleteAddress,TelephoneNumber,MobileNumber," +
            "PresentOccupation,WorkAddress,EmailAddress,NameofWifeorHusband, Citizenship," +
            " NameOfFather, FatherCitizenship, NameOfMother,MotherCitizenship," +
            "CitizenshipAcquiredBy,ForeignPassHolder,ForeignPassport," +
            "PhilPassHolder, LatestPhilPassNumber,DateIssuedPhPassNum, MinorTravelingCompanion," +
            "CompanionRelationship,CompanionContactNum ")]PassportApplicant passportApplicant)
        {




            //DateTime dateNow = new DateTime(DateTime.Now.Year);
            //int currDate = Convert.ToInt32(Convert.ToString(dateNow.Year));
            //DateTime bDate = passportApplicant.DateOfBirth;
            //int BDate = Convert.ToInt32(Convert.ToString(bDate.Year));
            //int BdYear = BDate;
            //int age = BdYear - currDate;

            try
            {

                //if(age <= 18)
                //{
                //    if(passportApplicant.CivilStatus == "Married")
                //    {
                //        ModelState.AddModelError("CivilStatus", "You can not be married at that age of " + age);
                //    }
                //    if(passportApplicant.PresentOccupation != null)
                //    {
                //        ModelState.AddModelError("PresentOccupation", "You can not work at that age of " + age);
                //    }
                //    if (passportApplicant.MinorTravelingCompanion == null)
                //    {
                //        ModelState.AddModelError("MinorTravelingCompanion", "Please enter name of companion" );
                //    }
                //    if (passportApplicant.CompanionRelationship== null)
                //    {
                //        ModelState.AddModelError("CompanionRelationship", "Please enter name of relationship");
                //    }
                //    if (passportApplicant.CompanionContactNum == null)
                //    {
                //        ModelState.AddModelError("CompanionContactNum", "Please enter contact number");
                //    }

                //}               


                if (passportApplicant.CivilStatus != null)
                {

                    if ((passportApplicant.CivilStatus == "Married") || (passportApplicant.CivilStatus == "Widow"))
                    {
                        if (passportApplicant.NameofWifeorHusband == null)
                        {
                            ModelState.AddModelError("NameofWifeorHusband", "Enter name of husband and wife");
                            ModelState.AddModelError("Citizenship", "Choose citizenship");
                        }
                        if (passportApplicant.NameofWifeorHusband == null)
                        {
                            ModelState.AddModelError("Citizenship", "Choose citizenship");
                        }
                        
                    }

                    else 
                    {
                        if (passportApplicant.NameofWifeorHusband != null)
                        {
                            ModelState.AddModelError("NameofWifeorHusband", "Do not enter name");
                            ModelState.AddModelError("Citizenship", "Do not choose any");
                        }
                        if (passportApplicant.NameofWifeorHusband != null)
                        {
                            ModelState.AddModelError("Citizenship", "Do not choose any");
                        }
                    }


                }

                if (passportApplicant.ForeignPassHolder != null)
                {
                    if (passportApplicant.ForeignPassHolder == "Yes")
                    {
                        if (passportApplicant.ForeignPassport == null)
                        {
                            ModelState.AddModelError("ForeignPassport", "Choose country");
                            
                        }

                    }
                    else
                    {
                        if (passportApplicant.ForeignPassport != null)
                        {
                            ModelState.AddModelError("ForeignPassport", "Do not choose any");
                        }
                           
                    }

                }
                if (passportApplicant.PhilPassHolder != null)
                {
                    if (passportApplicant.PhilPassHolder == "Yes")
                    {
                        if (passportApplicant.LatestPhilPassNumber == null)
                        {
                            ModelState.AddModelError("LatestPhilPassNumber", "Enter your latest passport number");
                            ModelState.AddModelError("DateIssuedPhPassNum", "Please select date");

                        }

                    }
                    else
                    {
                        if (passportApplicant.LatestPhilPassNumber != null)
                        {
                            ModelState.AddModelError("LatestPhilPassNumber", "Do not enter anything");
                            ModelState.AddModelError("DateIssuedPhPassNum", "Do not select any date");
                        }

                    }

                }



                if (ModelState.IsValid)
                {
                    using (ePassportModel dbModel = new ePassportModel())
                    {

                        dbModel.PassportApplicants.Add(passportApplicant);
                        dbModel.SaveChanges();

                    }

                }

              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            } 

        }

        // GET: PassportApplicant/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {
                using (ePassportModel dbModel = new ePassportModel())
                {
                    return View(dbModel.PassportApplicants.Where(x => x.id == id).FirstOrDefault());
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
            
        }

        // POST: PassportApplicant/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id,LastName,FirstName,MiddleName," +
            "DateOfBirth,PlaceOfBirth,CivilStatus,CompleteAddress,TelephoneNumber,MobileNumber," +
            "PresentOccupation,WorkAddress,EmailAddress,NameofWifeorHusband, Citizenship," +
            " NameOfFather, FatherCitizenship, NameOfMother,MotherCitizenship," +
            "CitizenshipAcquiredBy,ForeignPassHolder,ForeignPassport," +
            "PhilPassHolder, LatestPhilPassNumber,DateIssuedPhPassNum, MinorTravelingCompanion," +
            "CompanionRelationship,CompanionContactNum ")]int id, PassportApplicant passportApplicant)
        {
            try
            {

                if (passportApplicant.CivilStatus != null)
                {

                    if ((passportApplicant.CivilStatus == "Married") || (passportApplicant.CivilStatus == "Widow"))
                    {
                        if (passportApplicant.NameofWifeorHusband == null)
                        {
                            ModelState.AddModelError("NameofWifeorHusband", "Enter name of husband and wife");
                            ModelState.AddModelError("Citizenship", "Choose citizenship");
                        }
                        if (passportApplicant.NameofWifeorHusband == null)
                        {
                            ModelState.AddModelError("Citizenship", "Choose citizenship");
                        }

                    }

                    else
                    {
                        if (passportApplicant.NameofWifeorHusband != null)
                        {
                            ModelState.AddModelError("NameofWifeorHusband", "Do not enter name");
                            ModelState.AddModelError("Citizenship", "Do not choose any");
                        }
                        if (passportApplicant.NameofWifeorHusband != null)
                        {
                            ModelState.AddModelError("Citizenship", "Do not choose any");
                        }
                    }


                }

                if (passportApplicant.ForeignPassHolder != null)
                {
                    if (passportApplicant.ForeignPassHolder == "Yes")
                    {
                        if (passportApplicant.ForeignPassport == null)
                        {
                            ModelState.AddModelError("ForeignPassport", "Choose country");

                        }

                    }
                    else
                    {
                        if (passportApplicant.ForeignPassport != null)
                        {
                            ModelState.AddModelError("ForeignPassport", "Do not choose any");
                        }

                    }

                }
                if (passportApplicant.PhilPassHolder != null)
                {
                    if (passportApplicant.PhilPassHolder == "Yes")
                    {
                        if (passportApplicant.LatestPhilPassNumber == null)
                        {
                            ModelState.AddModelError("LatestPhilPassNumber", "Enter your latest passport number");
                            ModelState.AddModelError("DateIssuedPhPassNum", "Please select date");

                        }

                    }
                    else
                    {
                        if (passportApplicant.LatestPhilPassNumber != null)
                        {
                            ModelState.AddModelError("LatestPhilPassNumber", "Do not enter anything");
                            ModelState.AddModelError("DateIssuedPhPassNum", "Do not select any date");
                        }

                    }

                }
                if (ModelState.IsValid)
                {
                    using (ePassportModel dbModel = new ePassportModel())
                    {
                        dbModel.Entry(passportApplicant).State = EntityState.Modified;
                        dbModel.SaveChanges();
                    }
                    // TODO: Add update logic here
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PassportApplicant/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (ePassportModel dbModel = new ePassportModel())
                {
                    return View(dbModel.PassportApplicants.Where(x => x.id == id).FirstOrDefault());
                }
            }
            catch
            {
                return RedirectToAction("Error");
            }
            
        }

        // POST: PassportApplicant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (ePassportModel dbModel = new ePassportModel())
                {
                    PassportApplicant passportApplicant = dbModel.PassportApplicants.Where(x => x.id == id).FirstOrDefault();
                    dbModel.PassportApplicants.Remove(passportApplicant);
                    dbModel.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
