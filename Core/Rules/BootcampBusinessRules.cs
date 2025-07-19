using Core.Exceptions;

namespace Core.Rules;

public class BootcampBusinessRules : BaseBusinessRules
{
    public void CheckIfDateValid(DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
            throw new BusinessException("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");
    }

    public void CheckIfBootcampNameExists(bool exists)
    {
        if (exists)
            throw new BusinessException("Aynı isimde bir bootcamp daha önce açılmışsa tekrar açılamaz.");
    }

    public void CheckIfInstructorExists(bool exists)
    {
        if (!exists)
            throw new BusinessException("Eğitmen sistemde kayıtlı olmalıdır.");
    }

    public void CheckIfBootcampClosed(bool isClosed)
    {
        if (isClosed)
            throw new BusinessException("Başvuru durumu 'CLOSED' olan bootcamp'e başvuru alınamaz.");
    }
}
