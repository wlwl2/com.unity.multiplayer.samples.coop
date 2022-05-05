using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Lobbies.Models;

namespace Unity.Multiplayer.Samples.BossRoom.Shared.Net.UnityServices.Lobbies
{
    public class ZooLobbyServiceFacade : ILobbyServiceFacade
    {
        public Lobby CurrentUnityLobby => null;
        public void SetRemoteLobby(Lobby lobby)
        {

        }

        public void BeginTracking()
        {

        }

        public async Task EndTracking()
        {

        }

        public void UpdateLobby(float unused)
        {

        }

        public async Task<(bool Success, Lobby Lobby)> TryCreateLobbyAsync(string lobbyName, int maxPlayers, bool isPrivate)
        {
            return (false, null);
        }

        public async Task<(bool Success, Lobby Lobby)> TryJoinLobbyAsync(string lobbyId, string lobbyCode)
        {
            return (false, null);
        }

        public async Task<(bool Success, Lobby Lobby)> TryQuickJoinLobbyAsync()
        {
            return (false, null);
        }

        public async Task RetrieveAndPublishLobbyListAsync()
        {

        }

        public async Task LeaveLobbyAsync(string lobbyId)
        {

        }

        public async void RemovePlayerFromLobbyAsync(string uasId, string lobbyId)
        {

        }

        public async void DeleteLobbyAsync(string lobbyId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePlayerDataAsync(Dictionary<string, PlayerDataObject> data)
        {

        }

        public Task UpdatePlayerRelayInfoAsync(string allocationId, string connectionInfo)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLobbyDataAsync(Dictionary<string, DataObject> data)
        {
            throw new NotImplementedException();
        }

        public void DoLobbyHeartbeat(float dt)
        {
            throw new NotImplementedException();
        }
    }

    public interface ILobbyServiceFacade
    {
        Lobby CurrentUnityLobby { get; }
        void SetRemoteLobby(Lobby lobby);
        void BeginTracking();
        Task EndTracking();
        void UpdateLobby(float unused);

        /// <summary>
        /// Attempt to create a new lobby and then join it.
        /// </summary>
        Task<(bool Success, Lobby Lobby)> TryCreateLobbyAsync(string lobbyName, int maxPlayers, bool isPrivate);

        /// <summary>
        /// Attempt to join an existing lobby. Will try to join via code, if code is null - will try to join via ID.
        /// </summary>
        Task<(bool Success, Lobby Lobby)> TryJoinLobbyAsync(string lobbyId, string lobbyCode);

        /// <summary>
        /// Attempt to join the first lobby among the available lobbies that match the filtered onlineMode.
        /// </summary>
        Task<(bool Success, Lobby Lobby)> TryQuickJoinLobbyAsync();

        /// <summary>
        /// Used for getting the list of all active lobbies, without needing full info for each.
        /// </summary>
        Task RetrieveAndPublishLobbyListAsync();

        /// <summary>
        /// Attempt to leave a lobby
        /// </summary>
        Task LeaveLobbyAsync(string lobbyId);

        void RemovePlayerFromLobbyAsync(string uasId, string lobbyId);
        void DeleteLobbyAsync(string lobbyId);

        /// <summary>
        /// Attempt to push a set of key-value pairs associated with the local player which will overwrite any existing data for these keys.
        /// </summary>
        Task UpdatePlayerDataAsync(Dictionary<string, PlayerDataObject> data);

        /// <summary>
        /// Lobby can be provided info about Relay (or any other remote allocation) so it can add automatic disconnect handling.
        /// </summary>
        Task UpdatePlayerRelayInfoAsync(string allocationId, string connectionInfo);

        /// <summary>
        /// Attempt to update a set of key-value pairs associated with a given lobby.
        /// </summary>
        Task UpdateLobbyDataAsync(Dictionary<string, DataObject> data);

        /// <summary>
        /// Lobby requires a periodic ping to detect rooms that are still active, in order to mitigate "zombie" lobbies.
        /// </summary>
        void DoLobbyHeartbeat(float dt);
    }
}
