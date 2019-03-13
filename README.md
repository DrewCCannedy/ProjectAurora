# Project Aurora
## How add to the project
- download git https://git-scm.com/downloads using 'git bash' makes it really easy to run the commands below
- launch git bash and run the following commands
- `git pull https://github.com/DrewCCannedy/ProjectAurora.git` copy the project from github onto your machine
- `cd ProjectAurora` cd into the folder 
- `git checkout -b <branchname>` name the branch your name
- `git add .` to add your changes to the current commit
- `git commit -m '<summary of the changes>'` commit changes
- `git push` push your changes to github
- alert me, I will attempt to merge your changes into the project

### Example of adding something new 
1. `cd Project Aurora`
2. `git checkout -b 'drew'` (if you arent already in your branch)
3. `git add .`
4. `git commit -m 'changed player movement script'`
5. `git push`
if you get an error when you use `git push`, just run the command that git bash tells you to run and then run `git push` again

### Other useful commands
- `git pull` will update your computer with changes that are posted on github
- `git status` will tell you what you have changed vs the master file on github
- `git checkout master` will return you to the master branch (DONT PUSH TO THE MASTER BRANCH) 
- You will have to checkout to the master branch to use `git pull`, so checkout to the master to update
