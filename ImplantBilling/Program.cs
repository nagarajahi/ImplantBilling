using System;
using System.Collections.Generic;

namespace ImplantBilling
{
   public class Implant
    {
        public int implantquantityUsed { get; set; }
        public string implantfeatureName { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            bool moreItemsToAdd = false;
            int implantquantityUsed = 0;
            string implantfeatureName = "";
            List<Implant> implant = new List<Implant>();
            do
            {
                Implant implantItem = new Implant();
                Console.WriteLine("type DesignImplant if you wish to calculate Design Implant billing else type PrintImplant");
                implantfeatureName = Console.ReadLine();
                implantItem.implantfeatureName = implantfeatureName;
                Console.WriteLine("enter the implant quantity used");
                implantquantityUsed =Convert.ToInt32(Console.ReadLine());
                implantItem.implantquantityUsed = implantquantityUsed;
                Console.WriteLine("type DesignImplant if you wish to calculate Design Implant billing else type PrintImplant");
                implant.Add(implantItem);
                moreItemsToAdd = Convert.ToBoolean(Console.ReadLine());

            }
            while (moreItemsToAdd);
           
            double designImplantTier5Price = 29.99;
            double designImplantTier10Price = 34.99;
            double PrintImplantTier25Price = 49.99;
            double PrintImplantTier30Price = 59.99;
            double billableAmount = 0;

            foreach (var item in implant)
            {
                if (item.implantfeatureName == "DesignImplant" && item.implantquantityUsed > 0)
                {
                    if (item.implantquantityUsed - 5 > 0)
                    {
                        billableAmount = billableAmount+(5 * designImplantTier5Price);
                        billableAmount = billableAmount + (item.implantquantityUsed - 5) * designImplantTier10Price;
                    }
                    else
                    {
                        billableAmount = billableAmount + (implantquantityUsed * designImplantTier5Price);
                    }
                }
                if (item.implantfeatureName == "PrintImplant" && item.implantquantityUsed > 0)
                {
                    if (item.implantquantityUsed - 25 > 0)
                    {
                        billableAmount = billableAmount + (25 * PrintImplantTier25Price);
                        billableAmount = billableAmount + (item.implantquantityUsed - 25) * PrintImplantTier30Price;
                    }
                    else
                    {
                        billableAmount = billableAmount + (item.implantquantityUsed * PrintImplantTier25Price);
                    }
                }
            }
            
            Console.WriteLine("BillableAmount:" + billableAmount);
            Console.ReadLine();
        }
    }
}
