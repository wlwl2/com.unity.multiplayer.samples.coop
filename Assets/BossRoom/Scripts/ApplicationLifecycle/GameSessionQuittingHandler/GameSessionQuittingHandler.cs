using System;
using Unity.Multiplayer.Samples.BossRoom.Shared.Infrastructure;
using Unity.Multiplayer.Samples.BossRoom.Shared.Net.UnityServices.Lobbies;
using Unity.Multiplayer.Samples.Utilities;

namespace Unity.Multiplayer.Samples.BossRoom
{
    public class GameSessionQuittingHandler : IDisposable
    {
        readonly LobbyServiceFacade m_LobbyServiceFacade;
        IDisposable m_Subscription;

        [Inject]
        public GameSessionQuittingHandler(LobbyServiceFacade lobbyServiceFacade, ISubscriber<QuitGameSessionMessage> quitGameSessionSubscriber)
        {
            m_LobbyServiceFacade = lobbyServiceFacade;
            m_Subscription = quitGameSessionSubscriber.Subscribe(LeaveSession);
        }

        private void LeaveSession(QuitGameSessionMessage msg)
        {
            m_LobbyServiceFacade.EndTracking();

            if (msg.UserRequested)
            {
                // first disconnect then return to menu
                var gameNetPortal = GameNetPortal.Instance;
                if (gameNetPortal != null)
                {
                    gameNetPortal.RequestDisconnect();
                }
            }
            SceneLoaderWrapper.Instance.LoadScene("MainMenu", useNetworkSceneManager: false);
        }

        public void Dispose()
        {
            m_Subscription?.Dispose();
        }
    }
}
