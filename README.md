# cangulo.changelog

## Goals

Main Goal:
* Offer a solution for all the changelog operation

Main Consumers:

1. cangulo.cicd
2. Github pipelines

## How this will be consume?

| Consumer         | Description                                                                                         |
| ---------------- | --------------------------------------------------------------------------------------------------- |
| cangulo.cicd     | As a nuget package that can be imported in cangulo.cicd to handle the changelog creation and update |
| Github Pipelines | As a console application that can be imported as a github action                                    |

# TODO

- [ ] **Create cangulo.changelog** 
  - [x] 1. Create a service to create a changelog for a specific version providing a list of changes
  - [ ] 2. Extend functionality to classify commits depending on the convention commits
  - [ ] 3. Extend functionality to only list the PRs names and add links
  - [ ] **Extend the changelog to update the changelog.md file**
    - [ ] Keep only 5 versions
    - [ ] Create a md file with the changes every release in a changelog folder
    - [ ] Create a index for all the files
- [ ] Check what other things we can provide in the release
- [ ] Prepare what can you offer to the cangulo.changelog


## More Details

### Using this in canculo.cicd

This should be imported first as a nuget package, but also as a CLI tool:

```csharp
[PackageExecutable(
    packageId: "cangulo.changelog",
    packageExecutable: "cangulo.changelog.exe")]
readonly Tool Xunit;
```
Example:
https://nuke.build/docs/authoring-builds/cli-tools.html#lightweight-integration

# Inspired by:

https://github.com/raulgomis/semversioner
https://github.com/aws/aws-cli/