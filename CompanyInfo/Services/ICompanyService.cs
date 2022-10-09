using KnowCrow.CompanyInfo.Data;

namespace KnowCrow.CompanyInfo.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompanies();
        Company GetCompany(int id);
    }
}