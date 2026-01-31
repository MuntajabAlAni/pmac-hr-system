using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;

namespace Application.Services;

public class FirebaseService : IFirebaseService
{
    private readonly FirebaseMessaging _messaging;

    public FirebaseService(IConfiguration configuration)
    {
        var app = FirebaseApp.DefaultInstance == null
            ? FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("serviceAccountKey.json")
                    .CreateScoped("https://www.googleapis.com/auth/firebase.messaging")
            })
            : FirebaseApp.DefaultInstance;

        _messaging = FirebaseMessaging.GetMessaging(app);
    }

    public async Task SendNotificationAsync(Message message)
    {
        try
        {
            await _messaging.SendAsync(message);
        }
        catch
        {
            // ignored
        }
    }
}
