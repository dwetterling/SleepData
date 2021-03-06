using System;
using System.IO;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {
            String file = "data.txt";
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            if (resp == "1")
            {
                // TODO: create data file
                 // create data file

                 // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter("data.txt");
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    
                    // M/d/yyyy,#|#|#|#|#|#|#
                   // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                   //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                    sw.Close();
            }
            else if (resp == "2")
            {
                // TODO: parse data file
                if (File.Exists(file)){
                    StreamReader sr = new StreamReader(file);
                    while(!sr.EndOfStream){
                        string line = sr.ReadLine();
                        //seperate the week, and each days hours
                        string[] seperateStrings = {",","|"};
                        string[] Weeks = line.Split(seperateStrings, System.StringSplitOptions.RemoveEmptyEntries);
                       //Remove date from array
                       var Date = (Weeks[0]);
                       //change date string to DateTime
                       var Week = DateTime.Parse(Date);
                        
                        //output each week, and hours for each night
                        Console.WriteLine("Week of {0:MMM}, {0:dd}, {0:yyyy}", Week);
                        Console.WriteLine("Mo Tu We Th Fr Sa Su");
                        Console.WriteLine("-- -- -- -- -- -- --");
                        Console.WriteLine("{1} {2}  {3}  {4}  {5}  {6} {7}", Weeks);
                        
                    }
                    sr.Close();
                }
                
                
                    }

            }
        }
    }

