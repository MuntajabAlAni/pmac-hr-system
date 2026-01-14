using FirebaseAdmin.Messaging;

namespace Services.Interfaces;

public interface IFirebaseService
{
    Task SendNotificationAsync(Message message);
}