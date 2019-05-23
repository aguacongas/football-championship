import Amplify, { Auth, Hub, API, graphqlOperation } from 'aws-amplify';
import awsmobile from '../aws-exports';

window.amplifyWrapper = {
    configure: config => {
        config = config || awsmobile;
        Amplify.configure(config);
    },
    hub: {
        listen: dotnetHelper => {
            Hub.listen("auth", ({ payload: { event } }) => {
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
        federatedSignIn: provider => {
            if (provider) {
                Auth.federatedSignIn({ provider: provider });
                return;
            }
            Auth.federatedSignIn();
        },
        signout: dotnetHelper => {
            Auth.signOut()
                .then(data => dotnetHelper.invokeMethodAsync("SetUser", null, null)
                    .then(_ => {
                        console.log(data);
                    }))
                .catch(err => console.log(err));

        }
    },
    graphql: {
        operation: async (graphQlQuery, params) => {
            return await API.graphql(graphqlOperation(graphQlQuery, params));
        },
        subsription: (to, handler, dotnetHelper) => {
            API.graphql(to)
            .subscribe({
                next: (data) => dotnetHelper.invokeMethodAsync(handler, data)
                    .then(_ => console.log(data))
                    .catch(err => console.log(err))
            });
        }
    }
};

