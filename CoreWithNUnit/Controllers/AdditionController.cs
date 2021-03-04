using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWithNUnit.ViewModels;

namespace CoreWithNUnit.Controllers
{
    public class AdditionController : Controller
    {
       
        //string err = "";
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add(AddViewModel addViewModel)
        {
            if (addViewModel == null)
            {
                addViewModel.Total = "";
                addViewModel.lblmsg = "";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add1(AddViewModel addViewModel)
        {
            AddClass add = new AddClass();
            addViewModel.lblmsg = "";
            addViewModel.Total = "";
            string valMsg = "";
            string valAdd = "";
            bool flag = add.addition(addViewModel.Num1, addViewModel.Num2, out valMsg, out valAdd);
            if (valMsg == "")
            { addViewModel.Total = valAdd; }
            else
            { addViewModel.lblmsg = valMsg; }
            return View("Add", addViewModel);
        }


    }
    public class AddClass
    {
        public string validate(string num1, string num2)
        {
            string err;
            try
            {
                if (num1 == "")
                {
                    err = "PLease enter Num1";
                    return err;
                }
                if (num2 == "")
                {
                    err = "PLease enter Num2";
                    return err;
                }


                decimal num = 0.0M;
                bool numbool = decimal.TryParse(num1, out num);
                if (numbool == false)
                {
                    err = "Num1 is not valid number";
                    return err;
                }
                numbool = decimal.TryParse(num2, out num);
                if (numbool == false)
                {
                    err = "Num2 is not valid number";
                    return err;
                }

                err = "";

            }
            catch
            {
                err = "Technical error.";
            }

            return err;
        }

        public bool addition(string num1, string num2, out string outputText, out string outputAddition)
        {
            bool outputFlag = false;
            string val = "";
            outputText = "";
            outputAddition = "";

            val = validate(num1, num2);
            if (val == "")
            {
                decimal n1, n2, nTotal;
                n1 = Convert.ToDecimal(num1);
                n2 = Convert.ToDecimal(num2);
                nTotal = n1 + n2;
                outputAddition = nTotal.ToString();
                outputFlag = true;

            }
            else
            {
                outputText = val.ToString();
            }

            return outputFlag;
        }

    }

}
