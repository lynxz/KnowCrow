using KnowCrow.CompanyInfo.Data;

namespace KnowCrow.CompanyInfo.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ILogger<CompanyService> logger;
        private readonly IDictionary<int, Company> _companyDictionary;

        public CompanyService(ILogger<CompanyService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _companyDictionary = Generator.CompanyData();
            logger.LogDebug($"{nameof(CompanyService)} created");
        }

        public IEnumerable<Company> GetCompanies()
        {
            logger.LogDebug($"Called {nameof(GetCompanies)}");
            try
            {
                return _companyDictionary.Values.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Call to {nameof(GetCompanies)} failed!");
                throw;
            }
        }

        public Company GetCompany(int id)
        {
            logger.LogDebug($"Called {nameof(GetCompany)}");
            try
            {
                return _companyDictionary[id];
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Call to {nameof(GetCompany)} failed!");
                throw;
            }
        }
    }
}
