rem user
rem curl https://api.bitbucket.org/2.0/users/jdheywood

rem team
rem curl https://api.bitbucket.org/2.0/teams/amidoltd

rem team repo
rem curl https://api.bitbucket.org/2.0/repositories/amidoltd/northern-shell-expresso
rem needs authentication first

rem public repo events
rem curl https://bitbucket.org/api/1.0/repositories/jdheywood/simple-web-php/events >> simple-web-api-events.json

rem authentication
curl --user jdheywood:D0nald3! https://api.bitbucket.org/1.0/user/repositories >> jdheywood.json
