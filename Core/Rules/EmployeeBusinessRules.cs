using Core.Exceptions;

namespace Core.Rules;

public class EmployeeBusinessRules : BaseBusinessRules
{
    public void CheckIfEmployeeExists(bool exists)
    {
        if (!exists)
            throw new BusinessException("Çalışan bulunamadı.");
    }

    public void CheckIfEmailExists(bool exists)
    {
        if (exists)
            throw new BusinessException("Bu email adresi ile kayıtlı bir çalışan zaten var.");
    }
}
