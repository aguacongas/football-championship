import Amplify, { Auth, Hub, API, graphqlOperation } from 'aws-amplify';
import AWS from 'aws-sdk';
import awsmobile from './aws-exports';

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
                        user.signInUserSession.idToken.payload.groups = user.signInUserSession.idToken.payload["cognito:groups"];
                        dotnetHelper.invokeMethodAsync("SetUser", user)
                            .then(_ => {});
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
                .then(data => dotnetHelper.invokeMethodAsync("SetUser", null)
                    .then(_ => {
                        console.log(data);
                    }))
                .catch(err => console.log(err));

        },
        getUsers: async () => {
            var params = {
                UserPoolId: awsmobile["aws_cognito_identity_pool_id"],
                AttributesToGet: [
                    'ATTRIBUTE_NAME'
                ]
            };
            var cognitoidentityserviceprovider = new AWS.CognitoIdentityServiceProvider();
            return await cognitoidentityserviceprovider.listUsers(params);
        }
    },
    graphql: {
        operation: async (graphQlQuery, params) => {
            return await API.graphql(graphqlOperation(graphQlQuery, params));
        },
        subsription: (to, dotnetHelper, handler) => {
            API.graphql(graphqlOperation(to))
                .subscribe({
                    next: (data) => dotnetHelper.invokeMethodAsync(handler, data)
                        .then(_ => console.log(data))
                        .catch(err => console.error(err))
                });
        }
    }
};

