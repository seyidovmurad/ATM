using System;
namespace ATM
{
    static public class RandomGenerator
    {

        static public string GetRandNumOfString(int size)
        {
            string nums = "0123456789";
            string randNum = "";
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                randNum += nums[random.Next(0, 10)];
            }
            return randNum;
        }

    }
}
