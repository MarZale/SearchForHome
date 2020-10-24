//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;

//namespace HomesForSale
//{
//    public static class Helpers
//    {
//        public static void WaitForElementDisplayed(this IWebElement element, int duration = 30)
//        {
//        //    var stopTime = DateTime.Now.AddSeconds(duration);
//        //    string exceptionError = "";
//        //    while (DateTime.Now < stopTime)
//        //    {
//        //        try
//        //        {                 
//        //            if (func.Invoke())
//        //            {
//        //                return;
//        //            }
//        //        }
//        //        catch (Exception e)
//        //        {
//        //            exceptionError = e.Message;
//        //        }
//        //    }
//        //}

//        public static bool IsElementDisplayed(this Func<IWebElement> element)
//        {
//            try
//            {
//                return element().Displayed;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//    }
//}
