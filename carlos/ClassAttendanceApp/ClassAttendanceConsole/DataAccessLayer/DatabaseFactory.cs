using System;
using DomainLayer.Contracts;

namespace DataAccessLayer
{
    public static class DatabaseFactory
    {
        public static IDatabase Create(string type = "")
        {
            if (string.Equals(type, "file", StringComparison.InvariantCultureIgnoreCase))
            {
                return new JsonFileDatabase();
            }

            if (string.Equals(type, "sqlserver", StringComparison.InvariantCultureIgnoreCase))
            {
                return new SqlServerDatabase();
            }

            if (string.Equals(type, "sqlite", StringComparison.InvariantCultureIgnoreCase))
            {
                return new SqliteDatabase();
            }

            return new InMemoryDatabase();
        }
    }
}