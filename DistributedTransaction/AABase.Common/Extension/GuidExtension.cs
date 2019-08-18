using System;
using System.Collections.Generic;
using System.Text;

namespace AABase.Common.Extension
{
  public static class GuidExtension
    {
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        public static long ToInt64(this Guid value)
        {
            return BitConverter.ToInt64(value.ToByteArray(), 0);
        }

        public static int ToInt32(this Guid value)
        {
            return BitConverter.ToInt32(value.ToByteArray(), 0);
        }

        public static string ToUniqueCode(this Guid value)
        {
            long num = 1L;
            byte[] array = value.ToByteArray();
            foreach (byte b in array)
            {
                num *= b + 1;
            }
            return $"{num - DateTime.Now.Ticks:x}";
        }
    }
}
