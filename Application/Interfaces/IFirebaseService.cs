using FirebaseAdmin.Messaging;

namespace Application.Interfaces;

public interface IFirebaseService
{
    Task SendNotificationAsync(Message message);
}