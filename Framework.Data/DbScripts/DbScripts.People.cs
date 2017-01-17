namespace Framework.Data
{
    public partial class DbScripts
    {
        public static class People
        {
            public static class Parameters
            {
                public const string Id = "Id";
                public const string FirstName = "FirstName";
                public const string LastName = "LastName";
                public const string Height = "Height";
                public const string Weight = "Weight";
                public const string Age = "Age";
            }

            public static class Sql
            {
                private static string baseQuery = @"SELECT Id, FirstName, LastName, Height, Weight, Age FROM [dbo].[People] ";

                public static readonly string GetAll = string.Format(baseQuery);

                public static readonly string GetById = string.Format(baseQuery + "WHERE Id=@Id", Parameters.Id);

                public static readonly string GetByFirstName = string.Format(baseQuery + "WHERE FirstName=@FirstName", Parameters.FirstName);

                public static readonly string GetByLastName = string.Format(baseQuery + "WHERE LastName=@LastName", Parameters.LastName);

                public static readonly string Insert = string.Format(@"
                    INSERT INTO [dbo].[People](FirstName, LastName, Height, Weight, Age) 
                    VALUES(@FirstName, @LastName, @Height, @Weight, @Age)", 
                    Parameters.FirstName, 
                    Parameters.LastName, 
                    Parameters.Height, 
                    Parameters.Weight, 
                    Parameters.Age);

                public static readonly string Update = string.Format(@"
                    UPDATE [dbo].[People] 
                    SET 
                        FirstName=@FirstName, 
                        LastName=@LastName, 
                        Height=@Height, 
                        Weight=@Weight, 
                        Age=@Age 
                    WHERE Id=@Id", 
                    Parameters.Id, 
                    Parameters.FirstName, 
                    Parameters.LastName, 
                    Parameters.Height, 
                    Parameters.Weight, 
                    Parameters.Age);

                public static readonly string Delete = string.Format(@"
                    DELETE 
                    FROM [dbo].[People] 
                    WHERE Id=@Id", 
                    Parameters.Id);
            }
        }
    }
}
