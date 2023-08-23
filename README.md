This is a list of notes to my future self.  
He will probably ignore them as he is still a moron

### Things you think can wait but can't

  - Authentication
  - Authorization
  - Validation
  - Consistent logging pattern
  - Deployment pipeline up untill production
  - Monitoring
  - Fake *all* external dependencies on localhost by default
    - webservices
    - filesystems
    - repositories (db or otherwise)
    - authorization
  - automate or document your dev environment setup
  - document your infrastructure

### Important things you never do

  - Write out your scenarios to find your data and processes
  - List of nouns and verbs
    - remember params parms parameters? yeah..
    - fetch vs get vs load
    - find vs search

### Minimize bikeshedding

  - .editorconfig / resharper rules
  - lint
  - break builds for style errors (I know, it sucks)

### Remember the milk

  - keyvaluepair is probably a business object
  - more then three parameters is probably a parameter object
  - more then three private static functions are probably somebody else's responsibility
  - immutability loves you
  - labels are data
  - single responsability https://docs.google.com/presentation/d/1OWobMSIh4y6jJvCuZTKznJSgU0b3HkcDmWKXAZfTVGg/edit?usp=sharing
  - scale horizontally 
