git config --global credential.helper store 
Add-Content "$env:USERPROFILE\.git-credentials" "https://$($env:GH_TOKEN):x-oauth-basic@github.com`n"
git config --global user.email "aguacongas@gmail.com"
git config --global user.name "Olivier Lefebvre"
git commit docs -m "chore: Appveyor build succed $env:VERSION"
git push