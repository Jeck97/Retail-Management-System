using System;

namespace Retail_Management_System
{
    public class Store
    {
        public static String Name { get; private set; }
        public static String ID { get; private set; }
        public static char Type { get; private set; }
        public static bool Availability { get; private set; }

        public Store(String SName)
        {
            Name = SName;
            ID = Connection.GetStoreInfo("StoreID", SName).Rows[0][0].ToString();
            Type = char.Parse(Connection.GetStoreInfo("StoreType", SName).Rows[0][0].ToString());
            Availability = (bool)Connection.GetStoreInfo("StoreAvailability", SName).Rows[0][0];
        }
    }
}
