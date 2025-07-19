using Core.Exceptions;
using Entities;

namespace Core.Rules;

public class ApplicationBusinessRules : BaseBusinessRules
{
    public void CheckIfDuplicateApplication(bool exists)
    {
        if (exists)
            throw new BusinessException("Aynı kişi aynı bootcamp'e birden fazla başvuru yapamaz.");
    }

    public void CheckIfBootcampActive(bool isActive)
    {
        if (!isActive)
            throw new BusinessException("Başvuru yapılan bootcamp aktif olmalıdır.");
    }

    public void CheckIfApplicantBlacklisted(bool isBlacklisted)
    {
        if (isBlacklisted)
            throw new BusinessException("Kara listeye alınmış bir aday başvuru yapamaz.");
    }

    public void CheckIfStateTransitionValid(ApplicationState currentState, ApplicationState newState)
    {
        bool isValid = (currentState, newState) switch
        {
            (ApplicationState.PENDING, ApplicationState.APPROVED) => true,
            (ApplicationState.PENDING, ApplicationState.REJECTED) => true,
            (ApplicationState.PENDING, ApplicationState.IN_REVIEW) => true,
            (ApplicationState.IN_REVIEW, ApplicationState.APPROVED) => true,
            (ApplicationState.IN_REVIEW, ApplicationState.REJECTED) => true,
            (ApplicationState.PENDING, ApplicationState.CANCELLED) => true,
            (ApplicationState.IN_REVIEW, ApplicationState.CANCELLED) => true,
            _ => false
        };

        if (!isValid)
            throw new BusinessException("Başvurunun durumu sadece belirli statülere geçirilebilir.");
    }
}
