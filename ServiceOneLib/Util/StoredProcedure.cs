using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceOneLib.Util
{
    public static class StoredProcedure
    {
        public static string GetProduct = "[dbo].[Get_ProductById]";
        public static string GetUser = "[dbo].[Get_UserById]";
    }
}
