using System;
using System.Threading.Tasks;
using Unity.Services.Core;

namespace BossRoom.Scripts.Shared.Net.UnityServices.Auth
{
    public interface IAuthenticationServiceFacade
    {
        Task InitializeAndSignInAsync(InitializationOptions initializationOptions);
        Task<bool> EnsurePlayerIsAuthorized();
    }
}
