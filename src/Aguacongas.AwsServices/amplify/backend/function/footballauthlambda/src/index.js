var AWS = require('aws-sdk');

exports.handler = (event, _, callback) => {
  var cognitoidentityserviceprovider = new AWS.CognitoIdentityServiceProvider({apiVersion: '2016-04-18'});

  var params = {
    GroupName: process.env.S3_GROUP_NAME,
    UserPoolId: event.userPoolId,
    Username: event.userName
  };

  cognitoidentityserviceprovider.adminAddUserToGroup(params, function(err) {
    if (err) {
      console.log(err);
    }
    else { 
      callback(null, event);
    };
  });
};