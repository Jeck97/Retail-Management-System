using System;
using System.Data;
using System.Data.SqlClient;

namespace Retail_Management_System
{
    public class Connection
    {
        //copy and paste the connection string from the properties of Data.mdf
        //private static String ConString = @"paste here";
        private static String ConString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\source\repos\Retail Management System\Data.mdf;Integrated Security = True; Connect Timeout = 30";

        public static String SelectLastStoreID()
        {
            return ExecuteScalar("select top 1 [StoreID] from [STORE] order by [StoreID] desc");
        }

        public static String CountAllStore()
        {
            return ExecuteScalar("select count(*) from [STORE]");
        }

        public static String CheckStoreNameAndPassword(String StoreName, String StorePassword)
        {
            return ExecuteScalar("select count(*) from [STORE] where [StoreName] = '" + StoreName + "' and [StorePassword] = '" + StorePassword + "'");
        }

        public static String CheckExistOfStoreName(String StoreName)
        {
            return ExecuteScalar("select count(*) from [STORE] where [StoreName] = '" + StoreName + "'");
        }

        public static String CheckAdminPassword(String AdminPassword)
        {
            return ExecuteScalar("select count(*) from [STORE] where [StorePassword] = '" + AdminPassword + "' and [StoreType] = 'A'");
        }

        public static String CountSearchMember(String Member)
        {
            return ExecuteScalar("select count(*) from [MEMBER] where [MemberID] like '%" + Member + "%' or [MemberName] like '%" + Member + "%'");
        }

        public static String CheckCashierLogin(String Cashier, String Password)
        {
            return ExecuteScalar("select count(*) from [EMPLOYEE] where [EmployeeID] = '" + Cashier + "' and [EmployeePassword] = '" + Password + "' and [EmployeePosition] = 'C' and [StoreID] = '" + Store.ID + "'");
        }

        public static String CheckAdminLogin(String Store, String Password)
        {
            return ExecuteScalar("select count(*) from [STORE] where ([StoreID] = '" + Store + "' or [StoreName] = '" + Store + "') and [StorePassword] = '" + Password + "' and [StoreType] = 'A'");
        }

        public static String GetStorePassword()
        {
            return ExecuteScalar("select [StorePassword] from [STORE] where [StoreID] = '" + Store.ID + "'");
        }

        public static String CheckExistOfCashier(String Cashier)
        {
            return ExecuteScalar("select count(*) from [EMPLOYEE] where ([EmployeeID] = '" + Cashier + "' or [EmployeeName] = '" + Cashier + "') and [EmployeePosition] = 'C' and [StoreID] = '" + Store.ID + "'");
        }

        public static String CheckExistOfEmployee(String Employee)
        {
            return ExecuteScalar("select count(*) from [EMPLOYEE] where ([EmployeeID] = '" + Employee + "' or [EmployeeName] = '" + Employee + "') and [StoreID] = '" + Store.ID + "'");
        }

        public static String SelectEmployeePosition(String Employee)
        {
            return ExecuteScalar("select [EmployeePosition] from [EMPLOYEE] where ([EmployeeID] = '" + Employee + "' or [EmployeeName] = '" + Employee + "') and [StoreID] = '" + Store.ID + "'");
        }

        public static String CheckExistOfMemberID(String MemberID)
        {
            return ExecuteScalar("select count(*) from [MEMBER] where [MemberID] = '" + MemberID + "'");
        }

        public static String CheckExistOfMemberName(String MemberName)
        {
            return ExecuteScalar("select count(*) from [MEMBER] where [MemberName] = '" + MemberName + "'");
        }

        public static String CheckExistOfMemberPhoneNumber(String MemberPhoneNumber)
        {
            return ExecuteScalar("select count(*) from[MEMBER] where[MemberPhoneNumber] = '" + MemberPhoneNumber + "'");
        }

        public static String GetItemSoldQuantity(String ItemID)
        {
            return ExecuteScalar("select coalesce(sum([SoldQuantity]), 0) from [SALE_STOCK] where [ItemID] = '" + ItemID + "' and [StoreID] = '" + Store.ID + "'");
        }

        public static String CountSale()
        {
            return ExecuteScalar("select count(*) from [SALE] where [EmployeeID] in (select [EmployeeID] from [EMPLOYEE] where [StoreID] = '" + Store.ID + "')");
        }

        public static String GetMemberPoint(String MemberID)
        {
            return ExecuteScalar("select [MemberPoint] from [MEMBER] where [MemberID] = '" + MemberID + "'");
        }

        public static String CheckExistOfStock(String ItemID)
        {
            return ExecuteScalar("select count(*) from [STOCK] where [ItemID] = '" + ItemID + "' and [StoreID] = '" + Store.ID + "'");
        }

        public static String GetFirstSaleDate()
        {
            return ExecuteScalar("select top 1 format([SaleDate], 'MM/dd/yyyy HH:mm:ss') from [SALE] order by [SaleDate] asc");
        }

        public static String CountEmployee()
        {
            return ExecuteScalar("select count(*) from [EMPLOYEE] where [StoreID] = '" + Store.ID + "'");
        }

        public static String CheckExistOfItemName(String name)
        {
            return ExecuteScalar("select count(*) from [ITEM] where [ItemName] = '" + name + "'");
        }

        public static void InsertNewStore(String StoreID, String StoreName, String StorePassword, char StoreType)
        {
            ExecuteNonQuery("insert into [STORE] values('" + StoreID + "', '" + StoreName + "', '" + StoreType + "', '" + StorePassword + "', default)");
        }

        public static void InsertMemberData(String MemberID, String MemberName, String MemberPhoneNumber)
        {
            ExecuteNonQuery("insert into [MEMBER] values('" + MemberID + "', '" + MemberName + "', '" + MemberPhoneNumber + "', default, '" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "')");
        }

        public static void InsertSale(String SaleID, String CashierID)
        {
            ExecuteNonQuery("insert into [SALE]([SaleID], [SaleDate], [EmployeeID]) values('" + SaleID + "','" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "', '" + CashierID + "')");
        }

        public static void InsertSale(String SaleID, int EarnedPoint, String MemberID, String CashierID)
        {
            ExecuteNonQuery("insert into [SALE] values('" + SaleID + "','" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "', '" + EarnedPoint + "','" + MemberID + "', '" + CashierID + "')");
        }

        public static void InsertItemsSold(String SaleID, String ItemID, int SoldQty, double SoldPrice)
        {
            ExecuteNonQuery("insert into [SALE_STOCK] values('" + SaleID + "','" + ItemID + "', '" + Store.ID + "', '" + SoldQty + "', '" + SoldPrice + "')");
        }

        public static void UpdateMemberPoint(String MemberID, int UpdatedPoint)
        {
            ExecuteNonQuery("update [MEMBER] set [MemberPoint] = '" + UpdatedPoint + "' where [MemberID] = '" + MemberID + "'");
        }

        public static void UpdateStockQuantity(String ItemID, int Qty)
        {
            ExecuteNonQuery("update [STOCK] set [StockQuantity] = '" + Qty + "' where [ItemID] = '" + ItemID + "' and [StoreID] = '" + Store.ID + "'");
        }

        public static void UpdateStockDetails(String ItemID, double StockPrice, int StockQty, double StockDesc, bool Availability)
        {
            ExecuteNonQuery("update [STOCK] set [StockPrice] = '" + StockPrice + "', [StockQuantity] = '" + StockQty + "', [StockDiscount] = '" + StockDesc + "', [StockAvailability] = '" + Availability + "' where [ItemID] = '" + ItemID + "' and [StoreID] = '" + Store.ID + "'");
        }

        public static void InsertNewStock(String ItemID, double StockPrice, int StockQty)
        {
            ExecuteNonQuery("insert into [STOCK] values('" + Store.ID + "','" + ItemID + "', '" + StockPrice + "', '" + StockQty + "', default, default)");
        }

        public static void DeleteStock(String ItemID)
        {
            ExecuteNonQuery("update [STOCK] set [StockAvailability] = 'false' where [ItemID] = '" + ItemID + "' and [StoreID]='" + Store.ID + "'");
        }

        public static void UpdateEmployee(String column, String value, String ID)
        {
            ExecuteNonQuery("update [EMPLOYEE] set [Employee" + column + "] = '" + value + "' where [EmployeeID] = '" + ID + "'");
        }

        public static void AddEmployee(String ID, String name)
        {
            ExecuteNonQuery("insert into [EMPLOYEE] values('" + ID + "', '" + name + "', default, default, default, default, '" + Store.ID + "')");
        }

        public static void DeleteEmployee(String ID)
        {
            ExecuteNonQuery("delete from [EMPLOYEE] where [EmployeeID] = '" + ID + "' and [StoreID] = '" + Store.ID + "'");
        }

        public static void UpdateItem(String column, String value, String ID)
        {
            ExecuteNonQuery("update [ITEM] set [Item" + column + "] = '" + value + "' where [ItemID] = '" + ID + "'");
        }

        public static void AddItem(String ID, String name, String type, String cost)
        {
            ExecuteNonQuery("insert into [ITEM] values('" + ID + "', '" + name + "', '" + type + "', '" + cost + "')");
        }

        public static void DeleteItem(String ID)
        {
            ExecuteNonQuery("delete from [ITEM] where [ItemID] = '" + ID + "'");
        }


        public static DataTable GetStoreInfo(String attribute, String StoreName)
        {
            return GetDataTable("select [" + attribute + "] from [STORE] where [StoreName] = '" + StoreName + "'");
        }

        public static DataTable SelectAllStoreName()
        {
            return GetDataTable("select [StoreName] from [STORE]");
        }

        public static DataTable SelectItemIDByType(String ItemType)
        {
            return GetDataTable("select [ITEM].[ItemID] from [STOCK] join [ITEM] on [STOCK].[ItemID] = [ITEM].[ItemID] where [ITEM].[ItemType] = '" + ItemType + "' and [STOCK].[StockAvailability] = 'true' and [STOCK].[StoreID] = '" + Store.ID + "'");
        }

        public static DataTable SelectSearchMember(String Member)
        {
            return GetDataTable("select * from [MEMBER] where [MemberID] like '%" + Member + "%' or [MemberName] like '%" + Member + "%'");
        }

        public static DataTable SelectAllCashier()
        {
            return GetDataTable("select [EmployeeID] from [EMPLOYEE] where [EmployeePosition] = 'C' and [EmployeeAvailability] = 1 and [StoreID] = '" + Store.ID + "'");
        }

        public static DataTable GetRegisteredCashier(String Employee)
        {
            return GetDataTable("select [EmployeeID], [EmployeeName] from [EMPLOYEE] where ([EmployeeID] = '" + Employee + "' or [EmployeeName] = '" + Employee + "') and [StoreID] = '" + Store.ID + "'");
        }

        public static DataTable SelectAllEmployeeID()
        {
            return GetDataTable("select [EmployeeID] from [EMPLOYEE] where [EmployeeAvailability] = true and [StoreID] = '" + Store.ID + "'");
        }

        public static DataTable SelectAllItemTypeInStock()
        {
            return GetDataTable("select [ITEM].[ItemType] from [STOCK] join [ITEM] on [STOCK].[ItemID] = [ITEM].[ItemID] where [STOCK].[StockAvailability] = 'true' and [STOCK].[StoreID] = '" + Store.ID + "' group by [ITEM].[ItemType]");
        }

        public static DataTable GetItemDetail(String ItemID)
        {
            return GetDataTable("select [ITEM].[ItemName], [ITEM].[ItemType], [ITEM].[ItemCost], [STOCK].[StockPrice], [Stock].[StockQuantity], [STOCK].[StockDiscount] from [STOCK] join [ITEM] on [STOCK].[ItemID] = [ITEM].[ItemID] where [ITEM].[ItemID] = '" + ItemID + "' and [STOCK].[StockAvailability] = 'true' and [STOCK].[StoreID] = '" + Store.ID + "'");
        }

        public static DataTable ItemTable()
        {
            return GetDataTable("select	[ITEM].[ItemID], [ITEM].[ItemName], [ITEM].[ItemType], [ITEM].[ItemCost], [STOCK].[StockPrice], [Stock].[StockQuantity], [STOCK].[StockDiscount], coalesce(sum([SALE_STOCK].[SoldQuantity]), 0) as sold from [STOCK] join [ITEM] on [STOCK].[ItemID] = [ITEM].[ItemID] left join [SALE_STOCK] on [STOCK].[ItemID] = [SALE_STOCK].[ItemID] and [STOCK].[StoreID] = [SALE_STOCK].[StoreID] where [STOCK].[StockAvailability] = 'true' and [STOCK].[StoreID] = '" + Store.ID + "' group by [ITEM].[ItemID], [ITEM].[ItemName], [ITEM].[ItemType], [ITEM].[ItemCost], [STOCK].[StockPrice], [Stock].[StockQuantity], [STOCK].[StockDiscount]");
        }

        public static DataTable ItemTable(String search)
        {
            return GetDataTable("select	[ITEM].[ItemID], [ITEM].[ItemName], [ITEM].[ItemType], [ITEM].[ItemCost], [STOCK].[StockPrice], [Stock].[StockQuantity], [STOCK].[StockDiscount], coalesce(sum([SALE_STOCK].[SoldQuantity]), 0) as sold from [STOCK] join [ITEM] on [STOCK].[ItemID] = [ITEM].[ItemID] left join [SALE_STOCK] on [STOCK].[ItemID] = [SALE_STOCK].[ItemID] and [STOCK].[StoreID] = [SALE_STOCK].[StoreID] where [STOCK].[StockAvailability] = 'true' and [STOCK].[StoreID] = '" + Store.ID + "' and ([ITEM].[ItemID] like '%" + search + "%' or [ITEM].[ItemName] like '%" + search + "%') group by [ITEM].[ItemID], [ITEM].[ItemName], [ITEM].[ItemType], [ITEM].[ItemCost], [STOCK].[StockPrice], [Stock].[StockQuantity], [STOCK].[StockDiscount]");
        }

        public static DataTable SelectItemNotInStock()
        {
            return GetDataTable("select * from [ITEM] where [ItemID] not in (select [ItemID] from [STOCK] where [StockAvailability] = 'true' and [StoreID] = '" + Store.ID + "')");
        }

        public static DataTable SelectTimeProfit(String DateTimeFormat, String Start, String End, String OrderBy)
        {
            return GetDataTable("select format([SALE].[SaleDate], '" + DateTimeFormat + "') time, sum([SALE_STOCK].[SoldProfit]) profit from [SALE] join [SALE_STOCK] on [SALE].[SaleID] = [SALE_STOCK].[SaleID] where ([SALE].[SaleDate] between '" + Start + "' and '" + End + "') and [SALE_STOCK].[StoreID] = '" + Store.ID + "' group by format([SALE].[SaleDate], '" + DateTimeFormat + "')" + OrderBy);
        }

        public static DataTable SelectSoldItem(String Start, String End)
        {
            return GetDataTable("select [ITEM].[ItemName] item, coalesce([soldTbl].[soldqty], 0) sold from [STOCK] left join (select [SALE_STOCK].[ItemID] ItemID, [SALE_STOCK].[StoreID] StoreID, sum([SALE_STOCK].[SoldQuantity]) soldqty from [SALE_STOCK] join [SALE] on [SALE_STOCK].[SaleID] = [SALE].[SaleID] where [SALE].[SaleDate] between '" + Start + "' and '" + End + "' group by [SALE_STOCK].[ItemID], [SALE_STOCK].[StoreID]) soldTbl on [STOCK].[ItemID] = [soldTbl].[ItemID] and [STOCK].[StoreID] = [soldTbl].[StoreID] join [ITEM] on [STOCK].[ItemID] = [ITEM].[ItemID] where [STOCK].[StoreID] = '" + Store.ID + "'");
        }

        public static DataTable SelectAllEmployee()
        {
            return GetDataTable("select [EmployeeID], [EmployeeName], [EmployeePosition], [EmployeeSalary], [EmployeeAvailability] from [EMPLOYEE] where [StoreID] = '" + Store.ID + "'");
        }

        public static DataTable SelectAllItem()
        {
            return GetDataTable("select * from [ITEM]");
        }


        //Methods for executing sql command
        private static String ExecuteScalar(String SqlQuery)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, con);
                return cmd.ExecuteScalar().ToString();
            }
        }

        private static void ExecuteNonQuery(String SqlQuery)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, con);
                cmd.ExecuteNonQuery();
            }
        }

        private static DataTable GetDataTable(String SqlQuery)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(SqlQuery, con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
        }
    }
}