using Bot.Models;
using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Services
{
    public class StateService
    {
        #region Variables 
        //State Variables

        public ConversationState ConversationState { get; }
        public UserState UserState { get; }

        //IDs
        public static string UserProfileId { get; } = $"{nameof(StateService)}.UserProfile";
        public static string ConversationDataId { get; } = $"{nameof(StateService)}.ConversationData";

        //Accessors
        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }
        public IStatePropertyAccessor<ConversationData> ConversationDataAccessor { get; set; }
        #endregion

        public StateService(UserState userState, ConversationState conversationState)
        {
            ConversationState = conversationState ?? throw new ArgumentException(nameof(conversationState));
            UserState = userState ?? throw new ArgumentException(nameof(userState));

            InitializeAccssors();
        }

        private void InitializeAccssors()
        {
            //Initialize User State
            UserProfileAccessor = UserState.CreateProperty<UserProfile>(UserProfileId);
            //Initialize User State
            ConversationDataAccessor = ConversationState.CreateProperty<ConversationData>(ConversationDataId);
        }
    }
}
