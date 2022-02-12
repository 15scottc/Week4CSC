using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Scott_Week3_Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainAPI : ControllerBase
    {

        [HttpPost(Name = "GetStandardDeviation")]
        public ActionResult<List<string>> IntList(List<int> parent)
        {
            List<string> sList = new List<string>();
            List<int> child = new List<int>();
            List<double> squaredList = new List<double>();
            sList.Sort();

            foreach (int i in parent)
            {
                try
                {
                    double mean = 0;
                    double sum = 0;
                    double count = 0;
                    double result = 0;
                    double standardDeviation;
                    child.Add(i);

                    foreach (int j in child)
                    {
                        count++;
                        sum += j;
                        mean = sum / count;
                        result = (j - mean) * (j - mean);
                        squaredList.Add(result);
                    }
                    standardDeviation = Math.Sqrt(squaredList.Average());
                    if (count == 1)
                    {
                        sList.Add("List too small");
                    }
                    else
                    {
                        sList.Add("Elements: " + count + " Current Standard Deviation " + standardDeviation);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Input must be an integer.");
                }

            }
            return sList;
        }
    }
}