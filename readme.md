### stuff to read:

- https://github.com/dotnet/format
- https://xunit.net/docs/shared-context


### notes to remember.

build command in actions uses parameter /p:TreatWarningsAsErrors=true
so that before we merge, we has to fix warnings by the rozalyn checker.

we could have used the properties we have under Release condition, but this would make it "hard" when we are starting to add code which is not complete and tests are created.
example: a async controller, which is async and we only add "throw new notimplemented", since we are going to create the tests first. (or am i wrong?)
