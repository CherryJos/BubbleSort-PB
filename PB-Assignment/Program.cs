using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace PB_Assignment
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string APIUrl = "https://jsonplaceholder.typicode.com/users";
        

        static async Task Main(string[] args)
        {
            var userLists = await ProcessRepositories();

            userLists.Select(x => x.username).ToArray();

            string[] myArray;
            string[] myArr;
            myArray = userLists.Select(x => x.name).ToArray();
            myArr = userLists.Select(x => x.name).ToArray();
            Console.WriteLine("***************************");
            Console.WriteLine("Orginial Data");
            foreach (var repo in userLists)
            {
                
                Console.WriteLine(repo.name);

            }
            Console.WriteLine("***************************");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("Bubble Sort -Normal");
            BubbleSort(myArray);
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine("###########################");
            Console.WriteLine("Bubble Sort With Flag");
            BubbleSortWithFlag(myArr);
            Console.WriteLine("###########################");

        }

        private static async Task<List<User>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

         var usersTask = client.GetStreamAsync(APIUrl);
         var userList = await JsonSerializer.DeserializeAsync<List<User>>(await usersTask);
         return userList;
        }

        public static void BubbleSort(String[] arr)
        {
            int length = arr.Length;
            String temp;
            for (int j = 0; j < length - 1; j++)
            { 
                for (int i = j + 1; i < length; i++)
                {
                    if (arr[j].CompareTo(arr[i]) > 0)
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted Array");
            Array.ForEach(arr, Console.WriteLine);
        }
        public static void BubbleSortWithFlag(String[] stgArray)
        {
            bool flag = true;
            for (int i = 1; (i <= (stgArray.Length - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (stgArray.Length - 1); j++)
                {
                    if (stgArray[j].CompareTo(stgArray[j+1]) > 0)
                    {
                        string temp = stgArray[j];
                        stgArray[j] = stgArray[j + 1];
                        stgArray[j + 1] = temp;
                        flag = true;
                    }
                }
                if (flag==false)
                {
                    break;
                }
            }
            Array.ForEach(stgArray, Console.WriteLine);
            Console.WriteLine();
            Console.ReadKey();
        }

    }
    
}
