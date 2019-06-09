npm i -g semantic-release @semantic-release/exec @semantic-release/changelog @semantic-release/git @semantic-release/release-notes-generator @semantic-release/commit-analyzer 
if (test-path ./nextversion.txt)
{
    Remove-Item ./nextversion.txt
}
semantic-release -b $env:APPVEYOR_REPO_BRANCH -d
$nextversion = Get-Content ./nextversion.txt

appveyor SetVariable -Name Version -Value $nextversion
appveyor UpdateBuild -Version $nextversion
appveyor AddMessage "Version = $nextversion"

dotnet restore
