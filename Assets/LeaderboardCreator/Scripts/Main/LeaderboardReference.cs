using System;
using Dan.Models;

namespace Dan.Main
{
    public class LeaderboardReference
    {
        public string PublicKey { get; }

        public LeaderboardReference(string publicKey) => PublicKey = publicKey;

        public void UploadNewEntry(string username, int score, Action<bool> callback = null, Action<string> errorCallback = null) => 
            LeaderboardCreator.UploadNewEntry(PublicKey, username, score, callback, errorCallback);

        public void GetEntries(Action<Entry[]> callback) => LeaderboardCreator.GetLeaderboard(PublicKey, callback);
        
        public void GetEntries(LeaderboardSearchQuery query, Action<Entry[]> callback) => 
            LeaderboardCreator.GetLeaderboard(PublicKey, query, callback);
        
        public void GetPersonalEntry(Action<Entry> callback) => LeaderboardCreator.GetPersonalEntry(PublicKey, callback);
        
        public void UpdateEntryUsername(string username, Action<bool> callback = null, Action<string> errorCallback = null) => 
            LeaderboardCreator.UpdateEntryUsername(PublicKey, username, callback, errorCallback);
        
        public void DeleteEntry(Action<bool> callback = null, Action<string> errorCallback = null) => 
            LeaderboardCreator.DeleteEntry(PublicKey, callback, errorCallback);
        
        public void ResetPlayer(Action onReset = null) => LeaderboardCreator.ResetPlayer(onReset);
    }
}