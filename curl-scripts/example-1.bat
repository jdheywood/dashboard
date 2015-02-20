rem user
rem curl https://bitbucket.org/api/2.0/users/jdheywood >> jdheywood.json

rem team
rem curl https://api.bitbucket.org/2.0/teams/amidoltd

rem public repo events
rem curl https://bitbucket.org/api/1.0/repositories/jdheywood/simple-web-php/events >> simple-web-php-events.json

rem team
rem curl https://api.bitbucket.org/2.0/teams/amidoltd >> amidoltd.json

rem authentication
rem curl --user jdheywood:password https://api.bitbucket.org/1.0/user/repositories >> jdheywood-repos.json

rem team repo
rem needs authentication first if private
rem curl --user jdheywood:password https://api.bitbucket.org/2.0/repositories/amidoltd/northern-shell-expresso >> nsexpresso-repo.json
