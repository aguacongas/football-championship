import Amplify, { Auth, Hub, Cache } from 'aws-amplify';
import awsmobile from '../aws-exports';

window.amplifyWrapper = {
    configure: function (config) {
        config = config || awsmobile;
        Amplify.configure(config);
    },
    hub: {
        listen: function (dotnetHelper) {
            Hub.listen("auth", ({ payload: { event, data } }) => {
                switch (event) {
                    case "signIn":
                        setUser(data);
                        break;
                    case "signOut":
                        setUser(null);
                        break;
                }
            });

            Auth.currentAuthenticatedUser()
                .then(user => setUser(user))
                .catch(() => console.log("Not signed in"));

            function setUser(user) {
                const federateInfo = Cache.getItem('federatedInfo');
                dotnetHelper.invokeMethodAsync("SetUser", user.username, federateInfo)
                    .then(_ => {
                        console.log(user);
                        console.log(federateInfo);
                    });
            }
        }
    },
    auth: {
        federatedSignIn: function (provider) {
            if (provider) {
                Auth.federatedSignIn({ provider: provider });
                return;
            }
            Auth.federatedSignIn();
        }
    }
};

