#!/bin/sh

# Credits: http://stackoverflow.com/a/750191

git filter-branch -f --env-filter "GIT_AUTHOR_NAME='AdrianMartin' GIT_AUTHOR_EMAIL='am.dev.8080@gmail.com' GIT_COMMITTER_NAME='adrianmartin' GIT_COMMITTER_EMAIL='am.dev.8080@gmail.com'" HEAD