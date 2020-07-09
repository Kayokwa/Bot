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

        public UserState UserState { get; }

        //IDs
        public static string UserProfileId { get; } = $"{nameof(StateService)}.UserProfile";

        //Accessors
        public IStatePropertyAccessor<UserProfile> UserProfileAccessor { get; set; }
        #endregion

        public StateService(UserState userState)
        {
            UserState = userState ?? throw new ArgumentException(nameof(userState));

            InitializeAccssors();
        }

        private void InitializeAccssors()
        {
            //Initialize User State
            UserProfileAccessor = UserState.CreateProperty<UserProfile>(UserProfileId);
        }
    }
}
