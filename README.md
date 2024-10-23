# unity-template

A template repository which has settings for handling Unity gitignores and LFS

## Instructions

1. Clone this repository (say yes to initializing LFS)
2. Using the unity hub (we are currently using editor `6000.0.23f1`), create a new project and set the location to be inside this cloned repository
3. In the terminal or through file explorer, copy `.gitignore` and `.gitattributes` into the root of the your unity project

If done correctly you should see a small number of new files (~23, not 250,000!) staged for commit.

## Editor Settings

As of unity 6, it appears like Asset Serialization is set to "force text" and version control is set to "visible meta files" by default, but you should double check that that is the case.
If these are unset you will encounter a lot of merge conflicts.
