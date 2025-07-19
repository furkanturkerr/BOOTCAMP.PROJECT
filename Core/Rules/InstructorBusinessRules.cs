using Core.Exceptions;

namespace Core.Rules;

public class InstructorBusinessRules : BaseBusinessRules
{
    public void CheckIfInstructorExists(bool exists)
    {
        if (!exists)
            throw new BusinessException("Eğitmen bulunamadı.");
    }

    public void CheckIfEmailExists(bool exists)
    {
        if (exists)
            throw new BusinessException("Bu email adresi ile kayıtlı bir eğitmen zaten var.");
    }

    public void CheckIfCompanyNameEmpty(string companyName)
    {
        if (string.IsNullOrWhiteSpace(companyName))
            throw new BusinessException("Şirket adı boş bırakılamaz.");
    }
}
