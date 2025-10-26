using LFC.BuildingBlocks.Core.ValueObjects;

namespace LFC.BuildingBlocks.Core.Services
{
    public static class DocumentValidationService
    {
        public static bool ValidateCpf(string cpf) => Cpf.IsValid(cpf);
        public static bool ValidateCnpj(string cnpj) => Cnpj.IsValid(cnpj);
    }
}
