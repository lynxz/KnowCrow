using KnowCrow.GraphQL.Data;

namespace KnowCrow.GraphQL.Types;

public class CompanyType : ObjectType<Company>
{
    protected override void Configure(IObjectTypeDescriptor<Company> descriptor)
    {
        descriptor
            .Field(d => d.CompanyInformationId)
            .ResolveWith<CompanyResolvers>(t => t.GetCompanyInformationAsync(default!, default!, default))
            .Name("companyInformation");
    }

    private class CompanyResolvers
    {
        public Task<Clients.Company?> GetCompanyInformationAsync(
            [Parent] Company company,
            [Service] Clients.CompanyInfoService companyInfo,
            CancellationToken cancellationToken) =>
            company.CompanyInformationId > 0 ?
            companyInfo.CompaniesAsync(company.CompanyInformationId, cancellationToken) :
            Task.FromResult<Clients.Company?>(null);
    }
}
