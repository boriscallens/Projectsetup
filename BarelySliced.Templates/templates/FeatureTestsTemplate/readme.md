# BarelySliced Feature Files
BarelySliced is a solution setup that encourages Vertical Slicing
This adds unit tests for your feature to the business test project.
This will add a new feature folder with the following structure:
```
├───FeatureName
│   ├───FeatureNameHandlerShould.cs
│   ├───FeatureNammeRequestValidatorShould.cs
```
Test if your handler does what it says on the tin.
Does it do what was spelled out in the requirements? Make sure to check that your tests are not your feature implementation again.
Test if your validator validates the request. Test edge values.

Keep your tests as broad as possible without being irrelevant.
A few warning signs: 
    - Validating against specific numbers or strings. If you change a constant in your handler, will you have to change your unit tests?
      Instead you might want to test the relation of your input against your output. If input goes up, your output should do what?
    - Having to setup up a lot of state. Should you extract a builder with its own tests?
      Are you testing your handler or are you testing your database?
      Be mindfull of integration tests. They are important, but they are not unit tests.
And for the love of god name your variables. "sut" doesn't add enough context for the reader.

When refactoring your implementations, you should be able to change the implementation without changing the tests.
If you are testing for specific values consider if you can make them broader.
Do you expect numbers to go up if input goes up?