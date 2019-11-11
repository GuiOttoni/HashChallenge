using Sone;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceOneLib.Impl
{
    public static class DiscountRules
    {
        /// <summary>
        ///As regras de descontos da aplicação são:
        ///Se for aniversário do usuário, o produto terá 5 % de desconto
        ///Se for black friday (nesse exemplo ela pode ser fixada dia 25 / 11) o produto terá 10 % de desconto
        ///O desconto não pode passar de 10 %
        /// </summary>
        /// <param name="product"></param>
        /// <param name="user"></param>
        public static void ApplyDiscountRules(Product product, User user)
        {
            product.Discount = new Discount();

            if (VerifyBirthday(user.BirthDate.ToDateTime().ToLocalTime()))
            {
                product.Discount.Pct = 0.05F;
                ApplyDiscount(product);
            }

            if(VerifyBlackFriday())
            {
                product.Discount.Pct = 0.10F;
                ApplyDiscount(product);
            }
                
                
        }

        private static bool VerifyBirthday(DateTime birthDate)
        {
            if (DateTime.Now.Day == birthDate.Day && DateTime.Now.Month == birthDate.Month)
                return true;
            return false;
        }

        private static bool VerifyBlackFriday()
        {
            if (DateTime.Now.Day == 25 && DateTime.Now.Month == 11)
                return true;
            return false;
        }

        private static void ApplyDiscount(Product product)
        {
            product.Discount.ValueInCents = (int)(product.PriceInCents * product.Discount.Pct);
        }


    }
}
