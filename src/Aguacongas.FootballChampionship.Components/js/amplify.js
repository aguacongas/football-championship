import Amplify, { Auth, Hub } from 'aws-amplify';
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
                        setUser();
                        break;
                }
            });

            if (location && (!location.search || !location.search.startsWith("?code="))) {
                setUser();
            }

            function setUser() {
                Auth.currentAuthenticatedUser()
                    .then(user => {
                        const userName = user.attributes.name || user.attributes.email;
                        dotnetHelper.invokeMethodAsync("SetUser", userName)
                            .then(_ => {
                                console.log(user);
                            });
                    })
                    .catch(() => dotnetHelper.invokeMethodAsync("SetUser", null)
                        .then(_ => console.log("Not signed in")));
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
        },
        signout: function (dotnetHelper) {
            Auth.signOut()
                .then(data => dotnetHelper.invokeMethodAsync("SetUser", null, null)
                    .then(_ => {
                        console.log(data);
                    }))
                .catch(err => console.log(err));

        }
    }
};

