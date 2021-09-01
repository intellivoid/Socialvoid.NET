# Authentication Errors

These errors are raised when anything related to authentication has failed,
this can include things from when trying to authenticate to session
challenge errors.

| Name                                 | Code | Hex Code | Deprecated | Versions | Description                                                                                                                          |
|--------------------------------------|------|----------|------------|----------|--------------------------------------------------------------------------------------------------------------------------------------|
| IncorrectLoginCredentials            | 8704 | 0x02200  | No         | 1.0      | The given login credentials are incorrect                                                                                            |
| IncorrectTwoFactorAuthenticationCode | 8705 | 0x02201  | No         | 1.0      | The given two-factor authentication code is incorrect                                                                                |
| AuthenticationNotApplicable          | 8706 | 0x02202  | No         | 1.0      | Raised when the user does not support this method of authentication, see the message for further details                             |
| SessionNotFound                      | 8707 | 0x02203  | No         | 1.0      | Raised when the requested session was not found in the network                                                                       |
| NotAuthenticated                     | 8708 | 0x02204  | No         | 1.0      | Raised when the client attempts to invoke a method that requires authentication                                                      |
| PrivateAccessTokenRequired           | 8709 | 0x02205  | No         | 1.0      | Raised when the user/entity uses a Private Access Token to authenticate and the client attempted to authenticate in another way.     |
| AuthenticationFailure                | 8710 | 0x02206  | No         | 1.0      | The authentication process failed for some unexpected reason, see the message for further details.                                   |
| BadSessionChallengeAnswer            | 8711 | 0x02207  | No         | 1.0      | The given session challenge answer is incorrect or out of sync.                                                                      |
| TwoFactorAuthenticationRequired      | 8712 | 0x02208  | No         | 1.0      | Two-Factor Authentication is required, the client must repeat the same request but provide a Two-Factor authentication code as well. |
| AlreadyAuthenticated                 | 8713 | 0x02209  | No         | 1.0      | The client is attempting to authenticate when already authenticated                                                                  |
| SessionExpired                       | 8714 | 0x0220a  | No         | 1.0      | Raised when trying to use a session that has expired                                                                                 |