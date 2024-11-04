using System.Collections.Generic;
using Oracle.DataAccess.Client;
namespace DUC.CMS.CustomerService.DAL.Repository
{
  public  class FinanceId
    {
      private string _connectionString = DUC.Utilities.CryptoEngine.CryptoEngine.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString, true);
      public List<CTFinanceId> GetNonRegisteredERPAccounts()
      {
          try
          {
              using (var entity = new Entities(DUC.Utilities.CryptoEngine.CryptoEngine.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString, true)))
              {
                 
                  var searchResult = entity.GetNonRegisteredERPAccounts().ToList();
                
                  return searchResult;
              }
          }
          catch (OracleException)
          {
              throw;
          }
      }
      public List<CTFinanceId> GetRegisteredERPAccounts()
      {
          try
          {
              using (var entity = new Entities(DUC.Utilities.CryptoEngine.CryptoEngine.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString, true)))
              {

                  var searchResult = entity.GetRegistredERPAccounts().ToList();

                  return searchResult;
              }
          }
          catch (OracleException)
          {
              throw;
          }
      }
      public List<CTFinanceId> GetAllSIteIDForERPAccount(int? financialID)
      {
          try
          {
              using (var entity = new Entities(DUC.Utilities.CryptoEngine.CryptoEngine.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString, true)))
              {

                  var searchResult = entity.GetAllSiteIDForERPAccount(financialID).ToList();

                  return searchResult;
              }
          }
          catch (OracleException)
          {
              throw;
          }
      }
      public List<CTFinanceId> GetNonRegisteredSIteIDForERPAccount(int financialID)
      {
          try
          {
              using (var entity = new Entities(DUC.Utilities.CryptoEngine.CryptoEngine.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString, true)))
              {

                    var searchResult1 = entity.GetNonRegisteredSitedIDERPAccounts(financialID);
                        var searchResult= searchResult1.ToList();

                  return searchResult;
              }
          }
          catch (OracleException)
          {
              throw;
          }
      }
      public List<CTFinanceId> GetRegisteredSIteIDForERPAccount(int financialID)
      {
          try
          {
              using (var entity = new Entities(DUC.Utilities.CryptoEngine.CryptoEngine.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString, true)))
              {

                  var searchResult = entity.GetRegistredSitedIDERPAccounts(financialID).ToList();

                  return searchResult;
              }
          }
          catch (OracleException)
          {
              throw;
          }
      }

        public List<CTFinanceId> GetNonRegisteredIndAccounts()
        {
            try
            {
                using (var entity = new Entities(DUC.Utilities.CryptoEngine.CryptoEngine.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["Entities"].ConnectionString, true)))
                {

                    var searchResult = entity.GetNonRegisteredIndAccounts().ToList();

                    return searchResult;
                }
            }
            catch (OracleException)
            {
                throw;
            }
        }

    }
}
