using Core.Exceptions;

namespace Core.Rules;

public class ApplicantBusinessRules : BaseBusinessRules
{
    public void CheckIfNationalIdAlreadyApplied(bool exists)
    {
        if (exists)
            throw new BusinessException("Aynı TC kimlik numarası ile birden fazla başvuru yapılamaz.");
    }

    public void CheckIfApplicantBlacklisted(bool isBlacklisted)
    {
        if (isBlacklisted)
            throw new BusinessException("Kara listeye alınan başvuru sahibi yeni başvuru yapamaz.");
    }

    public void CheckIfApplicantExists(bool exists)
    {
        if (!exists)
            throw new BusinessException("Sistemde kayıtlı olmayan bir başvuru sahibi ile işlem yapılamaz.");
    }
}
