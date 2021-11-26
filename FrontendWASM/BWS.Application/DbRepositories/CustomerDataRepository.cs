

namespace BWS.Application.DbRepositories;

public class CustomerDataRepository : ICustomerDataRepository
{
    private readonly DBInitializer _dBInitializer;

    public CustomerDataRepository(DBInitializer dBInitializer)
    {
        _dBInitializer = dBInitializer;
    }


    public async Task<Customer> GetCustomer(int id)
    {
        var context =await _dBInitializer.GetPreparedDbContextAsync();
        return await context.Customers.AsNoTracking().Where(t => t.Id == id).FirstOrDefaultAsync();
             
    }

    public async Task BulkSaveAsync(List<Customer> customers)
    {
        using var dbContext = await _dBInitializer.GetPreparedDbContextAsync();
        dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        using var dbConnection = dbContext.Database.GetDbConnection();
        dbConnection.Open();

        using var transaction = dbConnection.BeginTransaction();

        var dbCommand = dbConnection.CreateCommand();
        var id = AddDbParameter(dbCommand, "$Id");
        var firstName = AddDbParameter(dbCommand, "$FirstName");
        var lastName = AddDbParameter(dbCommand, "$LastName");
        //var title = AddDbParameter(dbCommand, "$Title");
        var gender = AddDbParameter(dbCommand, "$Gender");
        //var email = AddDbParameter(dbCommand, "$Email");
        var mobileNumber = AddDbParameter(dbCommand, "$MobileNumber");
        //var address1 = AddDbParameter(dbCommand, "$Address1");
        //var address2 = AddDbParameter(dbCommand, "$Address2");
        var zipCode = AddDbParameter(dbCommand, "$ZipCode");
        var city = AddDbParameter(dbCommand, "$City");
        //var stateProvince = AddDbParameter(dbCommand, "$StateProvince");
        //var country = AddDbParameter(dbCommand, "$Country");

        //dbCommand.CommandText =
        //    $"INSERT OR REPLACE INTO Customers (Id, FirstName, LastName, Title, Gender, Email,MobileNumber,Address1,Address2,ZipCode,City,StateProvince,Country)" +
        //    $"VALUES ({id.ParameterName}, {firstName.ParameterName}, {lastName.ParameterName}, {title.ParameterName}, {gender.ParameterName},{email.ParameterName}" +
        //    $",{mobileNumber.ParameterName},{address1.ParameterName},{address2.ParameterName},{zipCode.ParameterName},{city.ParameterName},{stateProvince.ParameterName},{country.ParameterName})";

        dbCommand.CommandText =
                $"INSERT OR REPLACE INTO Customers (Id, FirstName, LastName, Gender, MobileNumber,ZipCode,City)" +
                $"VALUES ({id.ParameterName}, {firstName.ParameterName}, {lastName.ParameterName},  {gender.ParameterName}" +
                $",{mobileNumber.ParameterName},{zipCode.ParameterName},{city.ParameterName})";


        foreach (var customer in customers)
        {
            id.Value = customer.Id;
            firstName.Value = customer.FirstName!=null ? customer.FirstName:string.Empty;
            lastName.Value = customer.LastName != null ? customer.LastName : string.Empty;
            //title.Value = customer.Title != null ? customer.Title : string.Empty;
            gender.Value = customer.Gender != null ? customer.Gender : string.Empty;
            //email.Value = customer.Email != null ? customer.Email : string.Empty;
            mobileNumber.Value = customer.MobileNumber != null ? customer.MobileNumber : string.Empty;
            //address1.Value = customer.Address1 != null ? customer.Address1 : string.Empty;
            //address2.Value = customer.Address2 != null ? customer.Address2 : string.Empty;
            zipCode.Value = customer.ZipCode != null ? customer.ZipCode : string.Empty;
            city.Value = customer.City != null ? customer.City : string.Empty;
           //stateProvince.Value = customer.StateProvince != null ? customer.StateProvince : string.Empty;
            //country.Value = customer.Country != null ? customer.Country : string.Empty;
            try
            {
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        transaction.Commit();

    }

    static DbParameter AddDbParameter(DbCommand command, string name)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        command.Parameters.Add(parameter);
        return parameter;
    }

    public async Task<IQueryable<Customer>> GetCustomerQueryble()
    {
        using var context = await _dBInitializer.GetPreparedDbContextAsync();
        return  context.Customers.AsQueryable();
    }
}

