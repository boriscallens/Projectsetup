# BarelySliced Feature Files
BarelySliced is a solution setup that encourages Vertical Slicing
To add a feature to the Business/Feature folder run dotnet new feature -n <FeatureName> in that folder.
This will add a new feature folder with the following structure:
```
├───FeatureName
│   ├───FeatureNameRequest.cs
│   ├───FeatureNameResponse.cs
│   ├───FeatureNameHandler.cs
│   ├───FeatureNameValidator.cs
│   ├───FeatureNameAuthorizser.cs
```
The request, response and handler files are the core of the feature.
The Validator and Authorizer files extract orthagonal reponsabilities out of the core.
If no request validation or authorization need to take place you can leave these files empty or inherit from the NoOp implementations.
This is makes it explicit these were not forgotten, but rather were unnecessary.