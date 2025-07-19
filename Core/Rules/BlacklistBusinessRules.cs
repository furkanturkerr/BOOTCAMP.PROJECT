using Core.Exceptions;

namespace Core.Rules;

public class BlacklistBusinessRules : BaseBusinessRules
{
    public void CheckIfActiveBlacklistExists(bool exists)
    {
        if (exists)
            throw new BusinessException("Aynı aday için birden fazla aktif kara liste kaydı olamaz.");
    }

    public void CheckIfReasonEmpty(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new BusinessException("Sebep (reason) boş bırakılamaz.");
    }
}
