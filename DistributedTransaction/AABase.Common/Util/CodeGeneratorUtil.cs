using AABase.Common.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AABase.Common.Util
{
   public static class CodeGeneratorUtil
    {
        private static readonly Random random;

        static CodeGeneratorUtil()
        {
            random = new Random();
        }

        public static long GetRandomNumber(int size)
        {
            return GetRandomNumber(size, false);
        }

        public static long GetRandomNumber(int size, bool minIsSize)
        {
            if (size <= 0)
            {
                return 0L;
            }
            int maxNumber = MaxValueBySize(size);
            return GetRandomNumber(minIsSize ? MinValueBySize(size) : 0, maxNumber);
        }

        public static long GetRandomNumber(int minNumber, int MaxNumber)
        {
            return random.Next(minNumber, MaxNumber);
        }

        public static int MaxValueBySize(int size)
        {
            if (size <= 0)
            {
                return 0;
            }
            return Convert.ToInt32(new string('9', size));
        }

        public static int MinValueBySize(int size)
        {
            if (size <= 0)
            {
                return 0;
            }
            if (size == 1)
            {
                return 0;
            }
            string str = new string('0', size - 1);
            return Convert.ToInt32("1" + str);
        }

        public static string GetUniqueNumberByDate()
        {
            long randomNumber = GetRandomNumber(100, 999);
            long randomNumber2 = GetRandomNumber(100, 999);
            return DateTime.Now.ToString("yyyyMMddHHmmss") + randomNumber + randomNumber2;
        }

        public static Guid GetGuidCode()
        {
            return Guid.NewGuid();
        }

        public static long GetInt64UniqueCode()
        {
            return Guid.NewGuid().ToInt64();
        }

        public static int GetInt32UniqueCode()
        {
       
            int num =Guid.NewGuid().ToInt32();
            return Math.Abs(Guid.NewGuid().ToInt32() + num);
        }
    }
}
