The small education project for automation testing of www.stackoverflow.com(co) with API, BDD and UI tests.
To run test on remote:
1. Dowload docker
2. Dowload selenium/hub image
3. Run that command docker run -d -p 4444:4444 -v /dev/shm:/dev/shm selenium/standalone-chrome
4. Set driver configuration to RemoteChrome