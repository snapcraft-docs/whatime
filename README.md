# whatime

<a href="https://snapcraft.io/whatime">
  <img alt="whatime" src="https://snapcraft.io/whatime/badge.svg" />
</a>

Whatime is a simple date/time tool created to demonstrate how to build snap packages.

[![asciicast](https://asciinema.org/a/vFCsoPJk7F9USwk0AfvoNN6iv.svg)](https://asciinema.org/a/vFCsoPJk7F9USwk0AfvoNN6iv)

## How to Build

1. Clone this repository
2. Build the Snap package with
```
$ snapcraft --debug --use-lxd
```
  - `--debug` to get a shell into the build container in case an error occurs mid-build.
  - `--use-lxd` to use a container as the build infrastructure.
3. Install the Snap on your system with
```
$ sudo snap install whatime_1.0.0_amd64.snap --devmode
```
4. Run the app
```
$ whatime --in "New York"
```
