using HackathonEquipe6.Application.Models;

namespace HackathonEquipe6.Application.ICNPJBizPersistance;

public interface ICNPJBizPersistance
{
    Task<CNPJApiViewModel> GetEmpresaByCNPJAsync(string cnpj);
}