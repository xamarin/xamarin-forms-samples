TodoAWS
=======

This sample demonstrates a Todo list application where the data is stored and accessed from a SimpleDB service in Amazon Web Services.

The app functionality is:

- View a list of tasks.
- Add, edit, and delete tasks.
- Set a task's status to 'done'.
- Speak the task's name and notes fields.

In all cases the tasks are stored in a SimpleDB service in Amazon Web Services.

For more information about this sample see [Consuming an Amazon SimpleDB Service](http://developer.xamarin.com/guides/cross-platform/xamarin-forms/web-services/consuming/aws/).

Setting up an Amazon Cognito identity pool
------------------------------------------

In order to run this sample application an Amazon Cognito identity pool must first be created. This can be accomplished with the following steps:

1. In a web browser, browse to the [Amazon Web Services console](https://aws.amazon.com) and sign-up for an account.
1. In the AWS Console, navigate to the *Cognito* service.
1. In the Cognito console, click the *Create new identity pool* button. Give the identity pool a unique name and enable access to unauthenticated identities.
1. In the Cognito Console, click the *Create pool* button.
1. In the Cognito Console, expand *View Details*, expand *View Policy Document* for the unauthenticated identity, and click the *Edit* button.
1. In the text box, add `sdb:*` as an action. The policy document should resemble the following example:
    ```
    {  
    "Version":"2012-10-17",
    "Statement":[  
    {  
      "Effect":"Allow",
      "Action":[  
        "mobileanalytics:PutEvents",
        "cognito-sync:*",
        "sdb:*"
      ],
      "Resource":[  
        "*"
      ]
    }
    ]
  }
    ```
1. In the Cognito Console, click the *Allow* button.
1. In the Cognito Console, ensure that the *Sample code* tab is selected and copy the identity pool ID from the *Get AWS Credentials* section to the clipboard.
1. In *Xamarin Studio* or *Visual Studio*, load the *TodoAWS* solution, expand the *TodoAWS* project and paste the clipboard value into the `Constants.CognitoIdentityPoolId` property.

Author
------

David Britch
