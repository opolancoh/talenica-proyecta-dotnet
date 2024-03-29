using Proyecta.Core.DTOs;
using Proyecta.Core.Results;

namespace Proyecta.Core.Contracts.Services;

public interface IRiskOwnerService: IServiceBase<ApplicationResult, Guid, RiskOwnerCreateOrUpdateDto>
{
    public Task<ApplicationResult> AddRange(IEnumerable<RiskOwnerCreateOrUpdateDto> items);
}